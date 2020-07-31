﻿using System;
using System.Collections.Generic;
using System.Text;
using Deptorygen.Generator.Definition;
using Deptorygen.Utilities;

namespace Deptorygen.Exceptions
{
	public class CannotResolveException : Exception
	{
		public TypeName TargetType { get; set; }
		public ResolverDefinition TargetResolver { get; set; }

		public CannotResolveException(string message)
		{
		}
	}
}
