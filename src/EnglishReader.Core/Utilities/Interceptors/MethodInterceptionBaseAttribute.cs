using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Core.Utilities.Interceptors
{
    /// <summary>
    /// Interception attribute for Aspect Oriented Programming
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        /// <summary>
        /// Invocation priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Method invocation
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void Intercept(IInvocation invocation);
    }
}
