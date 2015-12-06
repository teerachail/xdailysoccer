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
            var history = new List<GuessHistoryMonthlyInformation> {
                new GuessHistoryMonthlyInformation
                {
                    Month = 2,
                    TotalPoints = 120
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 3,
                    TotalPoints = 258
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 5,
                    TotalPoints = 98
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 6,
                    TotalPoints = 179
                }
            };

            return new GetAllGuessHistoryRespond
            {
                Histories = history
            };
        }

        [HttpGet]
        public GetGuessHistoryByMonthRespond GetGuessHistoryByMonth(string userId, int year, int month) 
        {

            //function จาก GetMatchesRespond GetMatches(string userId)
            var request = new GetMatchesRequest { UserId = userId };
            var result = FacadeRepository.Instance.MatchFacade.GetMatches(request, DateTime.Now);


            var history = new List<GuessHistoryDailyInformation>
            {
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 18),
                    TotalPoints = 120,
                    Matches = result.Matches
                },
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 19),
                    TotalPoints = 150,
                    Matches = result.Matches
                },
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 20),
                    TotalPoints = 180,
                    Matches = result.Matches
                }
            };

            return new GetGuessHistoryByMonthRespond {
                Histories = history
            };
        }

    }
}
