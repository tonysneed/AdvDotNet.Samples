using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace FromScratch
{
    public class SampleConfiguration : DbConfiguration
    {
        public SampleConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}
