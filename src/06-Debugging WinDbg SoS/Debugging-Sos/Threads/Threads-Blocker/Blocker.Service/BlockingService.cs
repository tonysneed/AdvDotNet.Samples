using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Blocker.Service
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    class BlockingService : IBlockingService
    {
        private Primes _primes;

        public BlockingService()
        {
            _primes = new Primes();
        }

        public int Next()
        {
            return _primes.Next();
        }
    }
}
