using DailySoccer.DAC.EF;
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
        private DailySoccerModelContainer dbContext;

        public AccountFacade ()
        {
            dbContext = new DailySoccerModelContainer();
        }

        public CreateNewGuestRespond CreateNewGuest()
        {
            var SecrectCode = Guid.NewGuid().ToString();
            var newGuest = new AccountInformation()
            {
                SecrectCode = SecrectCode,
                CurrentOrderedCoupon = 0,
                Points = 0,
                MaximumGuessAmount = 5,
            };

            dbContext.Accounts.Add(new Account
            {
                Points = newGuest.Points,
                SecrectCode = newGuest.SecrectCode,
            });
            dbContext.SaveChanges();

            return new CreateNewGuestRespond()
            {
                AccountInfo =  newGuest,
                IsSuccessed = true
            };
        }
    }
}
