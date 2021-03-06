using System;
using System.Transactions;

namespace PatientRecords.Web.WebUtilities.HelperServices.Interfaces
{
    public interface ITransactionFactory
    {
        public TransactionScope GetTransaction(TimeSpan? timeOut = null);
        public TransactionScope GetAsyncTransaction(TimeSpan? timeOut = null);

    }
}
