# ミックスインとキャプチャを組み合わせる

前のいくつかの節で紹介した「特定のファクトリーをベースにして他のファクトリーを生成する」機能と「他のファクトリーの定義を取り込む」機能を組み合わせて使うことをお勧めします。

以下はユーザーの書くコードです。

```csharp
using Deptorygen.Annotations;
using System;
using UseDeptorygen.Infra;

namespace UseDeptorygen.Samples.CaptureMixin
{
	class Service
	{
		public void Write()
		{
			Console.WriteLine("It's Service!");
		}
	}

	class Client
	{
		private readonly Service _service;

		public Client(Service service)
		{
			_service = service;
		}

		public void Invoke()
		{
			Console.WriteLine("# Client");
			_service.Write();
		}
	}

	[Factory]
	interface IBaseFactory
	{
		Service ResolveService();
		[Resolution(typeof(CaptureFactory))]
		ICaptureFactory ResolveCaptureFactory();
	}

	[Factory]
	interface ICaptureFactory : IBaseFactory
	{
		IBaseFactory BaseFactory { get; }
		Client ResolveClient();
	}

	class CaptureMixinSample : ISample
	{
		public void Run()
		{
			var baseFactory = new BaseFactory();
			baseFactory.ResolveCaptureFactory()
				.ResolveClient()
				.Invoke();
		}
	}
}
```

生成されるソースコード`BaseFactory.g.cs`は以下の通りです。

```csharp
// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.CaptureMixin
{
    internal partial class BaseFactory : IBaseFactory
        , IDisposable
    {

        private Service? _ResolveServiceCache;
        private CaptureFactory? _ResolveCaptureFactoryCache;

        public BaseFactory()
        {
        }

        public Service ResolveService()
        {
            return _ResolveServiceCache ??= new Service();
        }

        public ICaptureFactory ResolveCaptureFactory()
        {
            return _ResolveCaptureFactoryCache ??= new CaptureFactory(this);
        }


        
        public void Dispose()
        {
            _ResolveCaptureFactoryCache?.Dispose();
        }
    }
}
```

生成されるソースコード`CaptureFactory.g.cs`は以下の通りです。

```csharp
// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.CaptureMixin
{
    internal partial class CaptureFactory : ICaptureFactory
        , IDisposable
    {
        public IBaseFactory BaseFactory { get; }

        private Client? _ResolveClientCache;

        public CaptureFactory(IBaseFactory baseFactory)
        {
            BaseFactory = baseFactory;
        }

        public Client ResolveClient()
        {
            return _ResolveClientCache ??= new Client(ResolveService());
        }

        public Service ResolveService()
        {
            return BaseFactory.ResolveService();
        }

        public ICaptureFactory ResolveCaptureFactory()
        {
            return BaseFactory.ResolveCaptureFactory();
        }


        
        public void Dispose()
        {
        }
    }
}
```

生成された`CaptureFactory`クラスには、`IBaseFactory`インターフェースにあったメソッドが実装されています。
そして、そうしたメソッド群を実装するためにキャプチャしたファクトリー`IBaseFactory`に解決を委譲しています。

実行結果は以下の通りです。

```
# Client
It's Service!
```

これらの機能を組み合わせて、ファクトリーの間に継承関係のようなものを作ることができます。
`CaptureFactory`は`BaseFactory`と同じインターフェースを`IBaseFactory`実装しており、
かつ`IBaseFactory`インターフェースの実装のために`BaseFactory`クラスのメソッドを利用しています。
