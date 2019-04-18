using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample.DataLayer
{
    internal static class DisposableExtensions
    {
        public static void DisposeIfNotNull(this IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
