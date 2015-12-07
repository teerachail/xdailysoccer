using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccerBackoffice.Helpers
{
    public class ServiceEngine
    {
        public JsonServiceClient Client { get; set; }

        public ServiceEngine()
        {
            Client = new JsonServiceClient("http://localhost:3728/api/");
        }
    }
}
