using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Blocker.Service
{
    [ServiceContract(Namespace="urn:demos")]
    interface IBlockingService
    {
        [OperationContract]
        int Next();
    }
}
