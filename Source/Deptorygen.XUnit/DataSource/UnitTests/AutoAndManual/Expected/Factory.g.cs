﻿// <autogenerated />
using System;
using System.Collections.Generic;

namespace UseDeptorygen.Samples.AutoAndManual
{
	internal partial class Factory : IFactory
		, IDisposable
	{
		private readonly ServiceGold _serviceGold;

		private ServiceSilver? _ResolveServiceSilverCache;
		private Client? _ResolveClientCache;

		public Factory(ServiceGold serviceGold)
		{
			_serviceGold = serviceGold;
		}

		public ServiceSilver ResolveServiceSilver()
		{
			return _ResolveServiceSilverCache ??= new ServiceSilver();
		}

		public Client ResolveClient()
		{
			return _ResolveClientCache ??= new Client(ResolveServiceSilver(), _serviceGold);
		}

		public void Dispose()
		{
		}
	}
}