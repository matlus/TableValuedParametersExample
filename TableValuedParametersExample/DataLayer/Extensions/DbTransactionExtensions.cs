using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample.DataLayer
{
    internal static class DbTransactionExtensions
    {
        public static void RollbackIfNotNull(this DbTransaction dbTransaction)
        {
            if (dbTransaction != null)
            {
                dbTransaction.Rollback();
            }
        }
    }
}
