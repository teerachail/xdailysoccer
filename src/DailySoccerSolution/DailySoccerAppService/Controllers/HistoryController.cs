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
    public class HistoryController : ApiController
    {
        public ApiServices Services { get; set; }

        //GET api/History
        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpGet]
        public GetAllGuessHistoryRespond GetAllGuessHistory(string userId)
        {
            var request = new GetAllGuessHistoryRequest { UserId = userId };
            var result = FacadeRepository.Instance.AccountFacade.GetAllGuessHistory(request, DateTime.Now);
            return result;
        }

        [HttpGet]
        public GetGuessHistoryByMonthRespond GetGuessHistoryByMonth(string userId, int year, int month)
        {
            var request = new GetGuessHistoryByMonthRequest { UserId = userId, Year = year, Month = month };
            var result = FacadeRepository.Instance.AccountFacade.GetGuessHistoryByMonth(request);
            return result;
        }

    }
}