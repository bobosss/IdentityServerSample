using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allweb.Core.Common.Exceptions
{
    public class UpdateConcurrencyException : ApplicationException
    {
        public UpdateConcurrencyException(string message)
            : base(message)
        {
        }

        public UpdateConcurrencyException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}
