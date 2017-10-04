using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowQueen.Server.ServerException
{
   public class TextFileXmlDataProviderException : Exception
    {
        public TextFileXmlDataProviderException(string message) 
            : base(message)
        {    }

        public TextFileXmlDataProviderException(string message, Exception inner) 
            : base(message, inner)
        {   }
    }
}
