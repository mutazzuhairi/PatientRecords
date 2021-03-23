using PatientRecords.Web.WebBasics.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientRecords.Web.WebBasics.HelperServices
{
    public class TransactionFactory: ITransactionFactory
    {
        public   TransactionScope GetTransaction(TimeSpan? timeOut = null)
        {
            TransactionScope transactionScope = GetTransactionScope(timeOut);
            return transactionScope;
        }


        public TransactionScope GetAsyncTransaction(TimeSpan? timeOut = null)
        {
            TransactionScope transactionScope = GetTransactionScope(timeOut,true);

            return transactionScope;

        }
 
        private TransactionScope GetTransactionScope(TimeSpan? timeOut = null,bool isAsync=false)
        {
            TransactionOptions transactionOptions = new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot };
            TransactionScopeOption scopeOption = TransactionScopeOption.RequiresNew;
            if (timeOut != null)
                transactionOptions.Timeout = timeOut.Value;
            if (Transaction.Current != null)
                scopeOption = TransactionScopeOption.Required;
            if (isAsync)
                return new TransactionScope(scopeOption, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
           
            return new TransactionScope(scopeOption, transactionOptions);
        }

    }

}
 
