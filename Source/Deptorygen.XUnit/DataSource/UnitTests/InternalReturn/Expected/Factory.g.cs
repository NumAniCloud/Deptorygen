﻿// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.InternalReturn
{
	internal partial class Factory : IFactory
		, IDisposable
	{
		private readonly ForDependency _forDependency;

		public IForCapture Capture { get; }

		private ForReturn? _ResolveReturnCache;
		private ForResolution? _ResolveResolutionCache;

		public Factory(ForDependency forDependency, IForCapture capture)
		{
			_forDependency = forDependency;
			Capture = capture;
		}

		public ForReturn ResolveReturn(ForParameter parameter)
		{
			return _ResolveReturnCache ??= new ForReturn(parameter);
		}

		public IForResolution ResolveResolution()
		{
			return _ResolveResolutionCache ??= new ForResolution(_forDependency);
		}

		public void Dispose()
		{
		}
	}
}