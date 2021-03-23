using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientRecords.DataLayer.DataBasics.BasicService
{
    public interface ITransactionFactory
    {
        public TransactionScope GetTransaction(TimeSpan? timeOut = null);
        public TransactionScope GetAsyncTransaction(TimeSpan? timeOut = null);
        public TransactionScope GetAsyncNewReadCommittedTransaction(TimeSpan? timeOut = null);
        public TransactionScope GetNewReadCommittedTransaction(TimeSpan? timeOut = null);

    }
}
