using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;

namespace DailySoccerAppService.Controllers
{
    public class MatchesController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Matches
        public string Get()
        {
            Services.Log.Info("Hello from custom controller!");
            return "Hello";
        }

    }
}
