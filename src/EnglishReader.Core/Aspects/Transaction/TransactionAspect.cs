using Castle.DynamicProxy;
using EnglishReader.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace EnglishReader.Core.Aspects.Transaction
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
