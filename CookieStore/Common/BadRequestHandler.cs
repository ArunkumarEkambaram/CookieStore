using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Common
{
    public class BadRequestHandler : Exception
    {
        public BadRequestHandler(string message):base(message)
        {

        }
    }
}
