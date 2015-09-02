using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Blocker.Service
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    class BlockingServiceAsync : IBlockingServiceAsync
    {
        private Primes _primes;

        public BlockingServiceAsync()
        {
            _primes = new Primes();
        }

        public IAsyncResult BeginNext(AsyncCallback cb, object state)
        {
            return _primes.NextAsync().AsApm(cb, state);
        }

        public int EndNext(IAsyncResult ar)
        {
            return ((Task<int>)ar).Result;
        }
    }
}
