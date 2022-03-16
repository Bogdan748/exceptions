using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class FileProcessingException : Exception
    {
        public FileProcessingException()
        {
        }
        
        public FileProcessingException(string message)
            : base(message)
        {
        }

        public FileProcessingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
