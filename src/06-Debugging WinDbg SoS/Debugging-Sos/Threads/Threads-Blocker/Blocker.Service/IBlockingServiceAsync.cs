using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Blocker.Service
{
    [ServiceContract(Name = "IBlockingService", Namespace = "urn:demos")]
    interface IBlockingServiceAsync
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginNext(AsyncCallback cb, object state);
        int EndNext(IAsyncResult ar);
    }
}
