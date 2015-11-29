using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.Facades;

namespace DailySoccerAppService.Controllers
{
    public class AccountController : ApiController
    {
        public ApiServices Services { get; set; }
        

        [HttpGet]
        public CreateNewGuestRespond CreateNewGuest()
        {
            var accountFacade = new AccountFacade();
            var result = accountFacade.CreateNewGuest();
            return result;
        }

    }
}
