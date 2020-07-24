﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Deprovgen.Annotations;
using Deprovgen.Generator.Domains;
using Deprovgen.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;

namespace Deprovgen.Generator.Analyzers
{
	class FactoryAnalyzer
	{
		private readonly Document _document;
		private readonly Func<CancellationToken, Task<INamedTypeSymbol>> _getSymbolFunc;

		public FactoryAnalyzer(InterfaceDeclarationSyntax syntax, Document document)
		{
			_document = document;
			_getSymbolFunc = ct =>
			{
				var ns = syntax.Parent is NamespaceDeclarationSyntax nsds
					? (nsds.Name is QualifiedNameSyntax qns ? qns.ToString() : throw new Exception())
					: throw new Exception();
				return AnalyzeInterfaceAsync(ns, syntax.Identifier.ValueText, ct);
			};
		}

		private async Task<INamedTypeSymbol> AnalyzeInterfaceAsync(string @namespace, string typeName, CancellationToken ct)
		{
			var symbols = await SymbolFinder.FindSourceDeclarationsAsync(
				_document.Project,
				typeName,
				false,
				ct);
			return symbols.OfType<INamedTypeSymbol>()
				.First(x => x.GetFullNameSpace() == @namespace);
		}

		private async Task<FactoryDefinition> AnalyzeInterfaceAsync(INamedTypeSymbol symbol, CancellationToken ct)
		{
			var collectionResolvers = ResolverAnalyzer.GetCollectionResolverDefinitions(symbol);

			var methods = ResolverAnalyzer.GetResolverDefinitions(symbol);

			var captures = GetCaptures(symbol).ToArray();

			var dependencies = GetDependencies(symbol, methods, captures);

			var typeName = symbol.Name[0].ToString().Replace("I", "") + symbol.Name.Substring(1);

			var genericHost = symbol.GetAttributes()
				.Any(x => x.AttributeClass.Name == nameof(ConfigureGenericHostAttribute));

			return new FactoryDefinition(symbol.GetFullNameSpace(),
				typeName,
				dependencies,
				methods,
				symbol.Name,
				genericHost,
				captures,
				collectionResolvers);
		}

		private static TypeName[] GetDependencies(INamedTypeSymbol definition, ResolverDefinition[] methods, CaptureDefinition[] captures)
		{
			var satisfied = captures.SelectMany(x => x.Resolvers)
				.Concat(methods)
				.Select(x => x.ServiceType.TypeNameInfo)
				.Append(TypeName.FromSymbol(definition))
				.ToArray();

			var result = from resolver in methods
						 from dependency in resolver.ServiceType.Dependencies
						 let parameters = resolver.Parameters.Select(x => x.TypeNameInfo)
						 where !parameters.Concat(satisfied).Contains(dependency)
						 select dependency;

			return result.Distinct().ToArray();
		}

		private IEnumerable<CaptureDefinition> GetCaptures(INamedTypeSymbol symbol)
		{
			var properties = symbol.GetMembers()
				.OfType<IPropertySymbol>()
				.Where(x => x.IsReadOnly);

			foreach (var propertySymbol in properties)
			{
				if (propertySymbol.Type is INamedTypeSymbol nts && nts.HasAttribute(nameof(FactoryAttribute)))
				{
					var analyzer = new CaptureAnalyzer(propertySymbol);
					yield return analyzer.GetDefinition();
				}
			}
		}

		public async Task<FactoryDefinition> GetFactoryDefinitionAsync(CancellationToken ct)
		{
			var symbol = await _getSymbolFunc(ct);
			return await AnalyzeInterfaceAsync(symbol, ct);
		}
	}
}
