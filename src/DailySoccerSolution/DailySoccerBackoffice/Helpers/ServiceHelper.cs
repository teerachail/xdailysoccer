using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccerBackoffice.Helpers
{
    public class ServiceHelper : IDisposable
    {
        public JsonServiceClient Client { get; set; }

        public ServiceHelper()
        {
            Client = new JsonServiceClient("http://localhost:3728/api/");
        }

        void IDisposable.Dispose()
        {
            Client.Dispose();
        }
    }
}
