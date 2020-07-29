﻿// <autogenerated />
using System;
using System.Collections.Generic;
using Deptorygen.GenericHost;
using Microsoft.Extensions.DependencyInjection;

namespace Deptorygen.Try
{
    internal partial class Factory : IFactory
        , IDisposable
        , IDeptorygenFactory
    {
        private Service? _ResolveServiceCache;

        public Factory()
        {
        }

        public Service ResolveService()
        {
            return _ResolveServiceCache ??= new Service();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Factory>(provider => this);
            services.AddTransient<Service>(provider => ResolveService());
        }

        public void Dispose()
        {
        }
    }
}