using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace RxWrappers.Service
{
    [ServiceContract(Namespace = "urn:dm:demos")]
    interface IPrimesService
    {
        [OperationContract]
        int[] GetPrimes(string s);
    }
}