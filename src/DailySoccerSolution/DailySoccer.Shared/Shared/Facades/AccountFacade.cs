using DailySoccer.DAC.EF;
using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class AccountFacade
    {
        public CreateNewGuestRespond CreateNewGuest()
        {
            var facade = FacadeRepository.Instance;
            var accountInfo = facade.AccountDataAccess.CreateAccount();
            return new CreateNewGuestRespond()
            {
                AccountInfo = new AccountInformation
                {
                    SecrectCode = accountInfo.SecrectCode,
                    Points = accountInfo.Points,
                    CurrentOrderedCoupon = accountInfo.CurrentOrderedCoupon,
                    MaximumGuessAmount = accountInfo.MaximumGuessAmount,
                },
                IsSuccessed = true
            };
        }

        public GetAllLeagueRespond GetAllLeagues()
        {
            var leagues = FacadeRepository.Instance.AccountDataAccess.GetAllLeagues();
            var result = new GetAllLeagueRespond { Leagues = leagues };
            return result;
        }

        public void SetFavoriteTeam(SetFavoriteTeamRequest request)
        {
            const int IgnoreRange = 0;
            var isArgumentValid = request != null 
                && !string.IsNullOrEmpty(request.UserId) 
                && request.SelectedTeamId > IgnoreRange;
            if (!isArgumentValid) return;

            FacadeRepository.Instance.AccountDataAccess.SetFavoriteTeam(request);
        }
    }
}
