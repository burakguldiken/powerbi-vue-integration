using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EnglishReader.Business.Abstract;
using EnglishReader.Business.Concrete;
using EnglishReader.Core.Utilities.Interceptors;
using EnglishReader.DataAccess.Abstract;
using EnglishReader.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
