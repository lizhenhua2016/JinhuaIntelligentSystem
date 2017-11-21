using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using JinhuaIntelligentSystem.ServiceModel;

namespace JinhuaIntelligentSystem.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
