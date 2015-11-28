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
    public class MatchesController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET: api/Matches
        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpPost]
        public string Post(int id)
        {
            return "Respond by POST method, your ID: " + id;
        }

        [HttpGet]
        public GetMatchesRespond GetMatches(string userId)
        {
            var now = DateTime.Now;
            var matches = new List<MatchInformation>
            {
                new MatchInformation
                {
                    Id = 1,
                    BeginDate = now,
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = 1,
                        Name = "FC Astana",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 7,
                        WinningPredictionPoints = 5
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = 2,
                        Name = "Atletico Madrid",
                        CurrentScore = 0,
                        CurrentPredictionPoints = 3,
                    },
                },
            };

            return new GetMatchesRespond
            {
                CurrentDate = now,
                AccountInfo = new AccountInformation
                {
                    Points = 255,
                    RemainingGuessAmount = 5,
                    CurrentOrderedCoupon = 15
                },
                Matches = matches
            };
        }
    }
}
