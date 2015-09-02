using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Blocker.Client
{
    [ServiceContract(Namespace="urn:demos")]
    interface IBlockingService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginNext(AsyncCallback cb, object state);

        int EndNext(IAsyncResult ar);
    }
}
