# 解決したいオブジェクトの依存先も解決したい

このサンプルでは、`Service`クラスの生成もファクトリーに任せることで、ユーザーは`Service`についても`Client`についても、そのクラスの生成方法について考える責任から解放されることができます。

以下はユーザーの書くコードです。

```csharp
using System;
using Deptorygen.Annotations;
using UseDeptorygen.Infra;

namespace UseDeptorygen.Samples.BasicDependency
{
	class Service
	{
		public void Show()
		{
			Console.WriteLine("This is Service!");
		}
	}

	class Client
	{
		private readonly Service _service;

		public Client(Service service)
		{
			_service = service;
		}

		public void Execute()
		{
			Console.WriteLine("# Client");
			_service.Show();
		}
	}

	[Factory]
	interface IFactory
	{
        // Serviceクラスを解決してもらいたい
		Service ResolveService();
        // ClientクラスはServiceクラスに依存している。
        // これも解決してもらいたい
		Client ResolveClient();
	}

	class BasicDependencySample : ISample
	{
		public void Run()
		{
			// Factoryクラスのコンストラクタに引数がいらない
			var factory = new Factory();
			factory.ResolveClient().Execute();
			factory.Dispose();
		}
	}
}
```

生成されるコードは以下の通りです。

```csharp
// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.BasicDependency
{
    internal partial class Factory : IFactory
        , IDisposable
    {

        private Service? _ResolveServiceCache;
        private Client? _ResolveClientCache;

        public Factory()
        {
        }

        public Service ResolveService()
        {
            return _ResolveServiceCache ??= new Service();
        }

        public Client ResolveClient()
        {
            return _ResolveClientCache ??= new Client(ResolveService());
        }


        
        public void Dispose()
        {
        }
    }
}
```

実行結果は以下の通りです。

```
# Client
This is Service!
```
