﻿// <autogenerated />
using System;
using System.Collections.Generic;
using UseDeptorygen.Samples.UsingNamespace.Another;

namespace UseDeptorygen.Samples.UsingNamespace
{
	internal partial class Factory : IFactory
		, IDisposable
	{
		private Service? _ResolveServiceCache;

		public Factory()
		{
		}

		public IService ResolveService()
		{
			return _ResolveServiceCache ??= new Service();
		}

		public void Dispose()
		{
		}
	}
}