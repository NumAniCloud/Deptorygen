# ファクトリーを別のアセンブリに提供する

ファクトリーを生成したら、それを1つのアセンブリ内だけでなく、別のアセンブリからも呼び出したいことが多いでしょう。

ファクトリーは必ずインターフェースを実装しているため、インターフェースだけを外部に公開すれば実装を隠蔽することができます。

その際に恐らく必要になるであろうテクニックを紹介します。

## 例

以下のようなクラス・インターフェース群があるとします。

```csharp
namespace UseDeptorygen.Guides.Export
{
	// アセンブリ内部だけで使う
	internal class InternalService
	{
		public InternalService(IRequiredService required, PublicService publicService)
		{	
		}
	}

	// アセンブリ内部でも外部でも使う
	public class PublicService
	{
	}

	// アセンブリ内部で使うが、インスタンスはアセンブリ外部から来る
	public interface IRequiredService
	{
	}
}
```

これらの型は、それらが属するアセンブリから外部へ公開されたり、公開されなかったりします。
いずれにせよ、どの型も外部アセンブリとの関わり方が異なります。

例えば`InternalService`クラスはinternalアクセシビリティを持ちますので、外部アセンブリへは公開しません。
このクラスのインスタンスを解決するようなファクトリーもまた、internalアクセシビリティを持つべきでしょう。

一方で、`PublicService`クラスはpublicアクセシビリティを持ち、外部アセンブリへ公開する前提です。
このクラスのインスタンスを解決するようなファクトリークラスかインターフェースの少なくとも一方は、publicアクセシビリティを持つべきでしょう。

それから、`IRequiredService`インターフェースは、その実装が`InternalService`によって要求されています。
ここでは`IRequiredService`を生成するようなファクトリークラスは、外部アセンブリに存在する前提です。

### ファクトリーを作る

……さて、これらの型について依存関係をうまく解決するには、外部との関わり方ごとにインターフェースを分けるのがよいでしょう。
以下のようにファクトリー定義を書きます。

```csharp
using Deptorygen.Annotations;

namespace UseDeptorygen.Guides.Export
{
	// Factory属性は、ミックスインの対象として認識されるために付けた。
	// これに対してコード生成はしない。つまりOpenFactoryクラスは生成しない。
	[Factory]
	public interface IOpenFactory
	{
		PublicService ResolvePublicService();
	}
	
	[Factory]
	internal interface IClosedFactory : IOpenFactory
	{
		IRequirementFactory Required { get; }

		InternalService ResolveInternalService();
	}
	
	// Factory属性は、キャプチャの対象として認識されるために付けた。
	// これに対してコード生成はしない。つまりRequirementFactoryクラスは生成しない。
	[Factory]
	public interface IRequirementFactory
	{
		IRequiredService ResolveRequiredService();
	}
}
```

3つのインターフェースを作成しました：

* 外部へ提供するインスタンスを生成するインターフェースは`IOpenFactory`です。
* 内部のみへ提供するインスタンスを生成するインターフェースは`IClosedFactory`です。
* 外部から提供してほしいファクトリーのAPIを示すインターフェースは`IRequirementFactory`です。

ここで、`IClosedFactory`のみに対してコード生成を行います。
これには理由があります。

まず、`IOpenFactory`で生成できる`PublicService`は、`InternalService`を生成するために必須です。
また、publicなクラスが他にも存在する場合、それらは逆に`InternalService`を要求しているかもしれません。

そのため、`IClosedFactory`でも`IOpenFactory`を実装する必要がありました。
こうなると`IOpenFactory`は`IClosedFactory`から生成するクラス`ClosedFactory`が実装しているので、
外部には`ClosedFactory`を`IOpenFactory`にキャストして送り出せばよいだけになります。

それから、`IRequirementFactory`インターフェースに対してコード生成をしないのは、
このインターフェースの実装が元々外部アセンブリに書かれている前提であり、
それを`IClosedFactory`のために受け取る必要があるに過ぎないという理由からです。

生成されるファクトリーは以下のようになります：

```csharp
// <autogenerated />
#nullable enable
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Guides.Export
{
	internal partial class ClosedFactory : IClosedFactory
		, IDisposable
	{
		public IRequirementFactory Required { get; }

		private InternalService? _ResolveInternalServiceCache;
		private PublicService? _ResolvePublicServiceCache;

		public ClosedFactory(IRequirementFactory required)
		{
			Required = required;
		}

		public InternalService ResolveInternalService()
		{
			return _ResolveInternalServiceCache ??= new InternalService(Required.ResolveRequiredService(), ResolvePublicService());
		}

		public PublicService ResolvePublicService()
		{
			return _ResolvePublicServiceCache ??= new PublicService();
		}

		public void Dispose()
		{
		}
	}
}
```

`InternalService`も`PublicService`も生成できていますね。
`ClosedFactory`自身はinternalアクセシビリティを持つので、
`InternalService`を戻り値としていてもコンパイルエラーになりません。

実際の運用では更に、以下のようなヘルパーをアセンブリどうしの境界として置くとよいかもしれません。

```csharp
namespace UseDeptorygen.Guides.Export
{
	public static class ApiProvider
	{
		public static IOpenFactory GetFactory(IRequirementFactory requirement)
		{
			return new ClosedFactory(requirement);
		}
	}
}
```

`GetFactory`メソッドは、その定義自体がアセンブリどうしの依存関係をよく表現しています。

外部アセンブリに対して要求したいAPI(=`IRequirementFactory`)は引数で受け取ります。
逆に、外部アセンブリが欲しがっているであろうAPI(=`IOpenFactory`)は戻り値で返します。
そして、そうした引数を要求し、戻り値を提供している実体(=`ClosedFactory`)が内部で生成されていますが、これは外部からは隠蔽されています。

もちろん、`ClosedFactory`が要求するAPIをふたつに分けたければ、
インターフェースを2つに分けて、`GetFactory`メソッドで2つの引数を通じて受け取れば十分です。

こうした様子で、依存関係がよく可視化されるようにファクトリーを作成できる余地があるのもDeptorygenの強みです。
こうした長所は、Deptorygeのファクトリークラスがインターフェースを用いて設計されることに基づいています。

