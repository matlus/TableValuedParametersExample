using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample.DataLayer
{
    internal static class DbConnectionExtensions
    {
        public static void CloseAndDispose(this DbConnection dbConnection)
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }
    }
}
