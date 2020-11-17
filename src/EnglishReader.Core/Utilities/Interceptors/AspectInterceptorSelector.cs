using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EnglishReader.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttiributes = type.GetCustomAttributes<MethodInterceptionBaseAttiribute>(true).ToList();
            var methodAttiributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttiribute>(true);
            classAttiributes.AddRange(methodAttiributes);

            return classAttiributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
