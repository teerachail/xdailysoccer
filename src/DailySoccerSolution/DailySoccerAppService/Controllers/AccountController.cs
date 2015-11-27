using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccerAppService.Models;

namespace DailySoccerAppService.Controllers
{
    public class AccountController : ApiController
    {
        public ApiServices Services { get; set; }

        [HttpGet]
        public CreateNewGuessRespond CreateNewGuess()
        {
            var UserId = Guid.NewGuid();
            return new CreateNewGuessRespond()
            {
                UserId = UserId.ToString(),
                IsSuccessed = true
            };
        }

    }
}
