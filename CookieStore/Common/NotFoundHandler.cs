using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Common
{
    public class NotFoundHandler : Exception
    {
        public NotFoundHandler(string message): base(message)
        {

        }
    }
}
