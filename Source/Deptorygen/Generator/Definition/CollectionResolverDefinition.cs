﻿using System.Collections.Generic;
using System.Linq;
using Deptorygen.Generator.Interfaces;
using Deptorygen.Utilities;
using Microsoft.CodeAnalysis;

namespace Deptorygen.Generator.Definition
{
	public class CollectionResolverDefinition : IDefinitionRequiringNamespace, IAccessibilityClaimer, IResolverContext
	{
		public TypeName ReturnType { get; }
		public TypeName ElementTypeInfo => ReturnType.TypeArguments[0];
		public string MethodName { get; }
		public TypeName[] ServiceTypes { get; }
		public VariableDefinition[] Parameters { get; }
		public string ElementTypeName => ElementTypeInfo.Name;

		public CollectionResolverDefinition(TypeName returnType,
			string methodName,
			TypeName[] serviceTypes,
			VariableDefinition[] parameters)
		{
			ReturnType = returnType;
			MethodName = methodName;
			ServiceTypes = serviceTypes;
			Parameters = parameters;
		}

		public string GetParameterList()
		{
			return Parameters.Select(x => x.Code).Join(", ");
		}

		public IEnumerable<string> GetRequiredNamespaces()
		{
			yield return ElementTypeInfo.FullNamespace;
			foreach (var p in Parameters)
			{
				yield return p.TypeNamespace;
			}
		}

		public IEnumerable<Accessibility> Accessibilities
		{
			get
			{
				yield return ElementTypeInfo.Accessibility;
				foreach (var parameter in Parameters)
				{
					yield return parameter.TypeNameInfo.Accessibility;
				}
			}
		}
	}
}
