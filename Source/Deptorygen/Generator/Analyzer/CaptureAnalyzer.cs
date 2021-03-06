﻿using System.Linq;
using Deptorygen.Generator.Definition;
using Deptorygen.Generator.Syntaxes;

namespace Deptorygen.Generator.Analyzer
{
	class CaptureAnalyzer
	{
		private readonly CaptureSyntax _syntax;

		public CaptureAnalyzer(CaptureSyntax syntax)
		{
			_syntax = syntax;
		}

		public CaptureDefinition GetDefinition()
		{
			var resolvers = _syntax.Resolvers
				.Select(x => new ResolverAnalyzer(x).GetDefinition())
				.ToArray();

			var collectionResolvers = _syntax.CollectionResolvers
				.Select(x => new CollectionResolverAnalyzer(x).GetDefinition())
				.ToArray();

			return new CaptureDefinition(
				_syntax.TypeName,
				_syntax.PropertyName,
				resolvers,
				collectionResolvers);
		}
	}
}
