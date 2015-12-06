using DailySoccer.Shared.Facades;
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
            var accountFacade = new AccountFacade();
            var result = accountFacade.GetAllLeagues();
            return result;
        }

        [HttpGet]
        public void SetFavoriteTeam(string userId, int selectedTeamId)
        {
            var accountFacade = new AccountFacade();
            var favoriteRequest = new SetFavoriteTeamRequest();
            favoriteRequest.UserId = userId;
            favoriteRequest.SelectedTeamId = selectedTeamId;
            accountFacade.SetFavoriteTeam(favoriteRequest);
        }
    }
}
