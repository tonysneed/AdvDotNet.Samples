using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blocker.Client
{
    struct NextPrimeRequest
    {
        public int RequestNumber;
        public IBlockingService Client;
    }
}
