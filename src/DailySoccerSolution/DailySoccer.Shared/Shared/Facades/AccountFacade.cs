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
            var result = new GetAllLeagueRespond
            {
                Leagues = FacadeRepository.Instance.AccountDataAccess.GetAllLeagues()
            };
            return result;
        }
    }
}
