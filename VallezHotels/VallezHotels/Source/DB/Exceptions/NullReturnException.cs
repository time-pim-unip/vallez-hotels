using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.DB.Exceptions
{
    class NullReturnException : ApplicationException
    {
        public NullReturnException(string message) : base(message) {  }
    }
}
