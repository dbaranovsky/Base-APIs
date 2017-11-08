using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.Infrastructure.Providers.Configuration;
using Dorian.RouteApi.Infrastructure.RequestHandlers;
using Dorian.RouteApi.RouteGuard.Core.Models;
using Dorian.RouteApi.RouteGuard.Core.Providers;
using Module = Autofac.Module;

namespace Dorian.RouteApi.RouteGuard.Api.DependencyInjection
{
    public class RouteGuardApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .ToArray();

            builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IAsyncRequestHandler<,>)).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterType(typeof(RouteGuardUrlProvider)).As(typeof(IBaseHttpClientUrlProvider));
            builder.RegisterType(typeof(BaseHttpClientFactory)).As(typeof(IBaseHttpClientFactory));
            builder.RegisterGeneric(typeof(BaseHttpClient<>)).As(typeof(IBaseHttpClient<>));
            builder.RegisterType(typeof(RouteGuardAuthDataProvider)).As(typeof(IAuthDataProvider<RouteGuardAuthData>));
            builder.RegisterType(typeof(RouteGuardAuthProvider)).As(typeof(IAuthProvider));
            builder.RegisterType(typeof(ConfigurationProvider)).As(typeof(IConfigurationProvider));

            base.Load(builder);
        }
    }
}
