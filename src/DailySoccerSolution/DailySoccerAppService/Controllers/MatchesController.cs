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
            var request = new GetMatchesRequest { UserId = userId };
            var result = FacadeRepository.Instance.MatchFacade.GetMatches(request, DateTime.Now);
            return result;
        }

        [HttpGet]
        public GuessMatchRespond GuessMatch(string userId, int matchId, bool isHome, bool isCancel)
        {
            var request = new GuessMatchRequest
            {
                UserId = userId,
                MatchId = matchId,
                IsGuessTeamHome = isHome,
                IsCancelGuess = isCancel
            };
            var result = FacadeRepository.Instance.MatchFacade.GuessMatch(request, DateTime.Now);
            return result;
        }

        [HttpGet]
        public string CalculateGameResult()
        {
            var now = DateTime.Now;
            try
            {
                FacadeRepository.Instance.MatchFacade.CalculateGameResults(now);
                return string.Format("Completed: {0}", now);
            }
            catch (Exception e)
            {
                return string.Format("Failed: {0}, Message: {1}", now, e.ToString());
            }
        }
    }
}
