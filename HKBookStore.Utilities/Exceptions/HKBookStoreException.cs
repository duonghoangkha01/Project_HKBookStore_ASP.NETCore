using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Utilities.Exceptions
{
    public class HKBookStoreException : Exception
    {
        public HKBookStoreException()
        {
        }

        public HKBookStoreException(string message)
            : base(message)
        {
        }

        public HKBookStoreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
