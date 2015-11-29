using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;

namespace DailySoccerAppService.Controllers
{
    public class AccountController : ApiController
    {
        public ApiServices Services { get; set; }

        [HttpGet]
        public CreateNewGuestRespond CreateNewGuest()
        {
            var SecrectCode = Guid.NewGuid().ToString();
            return new CreateNewGuestRespond()
            {
                AccountInfo = new AccountInformation()
                {
                     SecrectCode = SecrectCode,
                     CurrentOrderedCoupon = 10,
                     Points = 200,
                     RemainingGuessAmount = 5,
                },
                IsSuccessed = true
            };
        }

    }
}
