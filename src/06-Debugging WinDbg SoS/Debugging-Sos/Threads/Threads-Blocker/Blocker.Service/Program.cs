using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Blocker.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("net.tcp://localhost:9999/BlockingService");
            using (var host1 = new ServiceHost(typeof(BlockingService), baseAddress))
            using (var host2 = new ServiceHost(typeof(BlockingServiceAsync), baseAddress))
            {
                host1.Open();
                host2.Open();
                Console.WriteLine("Service running. Press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
