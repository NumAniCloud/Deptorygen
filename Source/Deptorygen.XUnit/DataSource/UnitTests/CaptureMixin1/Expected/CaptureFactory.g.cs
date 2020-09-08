﻿// <autogenerated />
#nullable enable
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
			return _ResolveClientCache ??= new Client(BaseFactory.ResolveService());
		}

		public Service ResolveService()
		{
			return BaseFactory.ResolveService();
		}

		public ICaptureFactory ResolveCaptureFactory()
		{
			return this;
		}

		public void Dispose()
		{
		}
	}
}