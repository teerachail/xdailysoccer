using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DailySoccerAppService.Controllers
{
    public class FavoriteController : ApiController
    {
        [HttpGet]
        public GetAllLeagueRespond GetAllLeagues()
        {
            //Hack: Mock data for display favorit page
            var teamId = 1;
            var leagueList = new List<LeagueInformation>()
            {
                new LeagueInformation { TeamId = teamId++, LeagueName= "Premier League", TeamName = "Chelsea"},
                new LeagueInformation { TeamId = teamId++, LeagueName= "Premier League", TeamName = "Crystal Palace"},
                new LeagueInformation { TeamId = teamId++, LeagueName= "Premier League", TeamName = "Manchester City"},
                new LeagueInformation { TeamId = teamId++, LeagueName= "Premier League", TeamName = "Newcastle United"},
                new LeagueInformation { TeamId = teamId++, LeagueName= "Premier League", TeamName = "Swansea City"},
            };

            return new GetAllLeagueRespond { Leagues = leagueList };

            // TODO: GetAllLeague
            //throw new NotImplementedException();
        }

        [HttpGet]
        public void SetFavoriteTeam(int userId, int selectedTeamId)
        {

            //TODO: SetFavoriteTeam
            throw new NotImplementedException();
        }
    }
}
