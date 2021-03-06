﻿using System;
using Deptorygen.Annotations;

namespace UseDeptorygen.Samples.InternalCapture
{
	public class ForReturn
	{
		public ForReturn(ForParameter parameter)
		{
		}
	}

	public class ForParameter
	{
	}

	public class ForDependency
	{
	}

	public class ForResolution
	{
		public ForResolution(ForDependency dependency)
		{
		}
	}

	public interface IForResolution
	{
	}

	[Factory]
	public interface IFactory
	{
		IForCapture Capture { get; }
		ForReturn ResolveReturn(ForParameter parameter);
		[Resolution(typeof(ForResolution))]
		IForResolution ResolveResolution();
	}

	[Factory]
	internal interface IForCapture
	{
	}
}
