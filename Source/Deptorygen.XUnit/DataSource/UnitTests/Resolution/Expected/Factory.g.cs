﻿// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.Resolution
{
	internal partial class Factory : IFactory
		, IDisposable
	{
		private ServiceGold? _ResolveServiceCache;

		public Factory()
		{
		}

		public IService ResolveService()
		{
			return _ResolveServiceCache ??= new ServiceGold();
		}

		public void Dispose()
		{
		}
	}
}