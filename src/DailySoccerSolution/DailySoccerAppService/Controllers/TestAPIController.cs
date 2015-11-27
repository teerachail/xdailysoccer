using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;

namespace DailySoccerAppService.Controllers
{
    public class TestAPIController : ApiController
    {
        public ApiServices Services { get; set; }

        [HttpGet]
        public string GetName(string firstname, string lastname)
        {
            Services.Log.Info("Hello from custom controller!");
            return string.Format("Hello {0} {1}", firstname, lastname);
        }

    }
}
