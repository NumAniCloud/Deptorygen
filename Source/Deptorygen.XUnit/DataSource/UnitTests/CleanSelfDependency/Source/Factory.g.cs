﻿// <autogenerated />
#nullable enable
using System;
using System.Collections.Generic;

namespace Deptorygen.XUnit.DataSource.UnitTests.CleanSelfDependency.Source
{
	internal partial class Factory : IFactory
		, IDisposable
	{
		private readonly Service2 _service2;

		public Factory(Service2 service2)
		{
			_service2 = service2;
		}

		public Service1 ResolveService1AsTransient()
		{
			return new Service1();
		}

		public IFactory ResolveFactoryAsTransient()
		{
			return new Factory(_service2);
		}

		public void Dispose()
		{
		}
	}
}
