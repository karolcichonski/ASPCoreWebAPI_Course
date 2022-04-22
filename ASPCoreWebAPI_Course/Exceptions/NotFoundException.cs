using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message): base(message)
        {

        }
    }
}
