using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientRecords.Web.WebBasics.BasicServices.Interfaces
{
    public interface ITransactionFactory
    {
        public TransactionScope GetTransaction(TimeSpan? timeOut = null);
        public TransactionScope GetAsyncTransaction(TimeSpan? timeOut = null);

    }
}
