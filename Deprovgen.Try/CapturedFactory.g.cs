﻿// <autogenerated />
using System;

namespace Deprovgen.Try
{
    internal partial class CapturedFactory : ICapturedFactory
    {

        private Service? _resolveServiceCache;
        private ServiceLocator? _resolveServiceLocatorCache;

        public CapturedFactory()
        {
        }

        public Service ResolveService()
        {
            return _resolveServiceCache ??= new Service();
        }

        public IServiceLocator ResolveServiceLocator(Service2 service2)
        {
            return _resolveServiceLocatorCache ??= new ServiceLocator(service2, this);
        }
    }

}