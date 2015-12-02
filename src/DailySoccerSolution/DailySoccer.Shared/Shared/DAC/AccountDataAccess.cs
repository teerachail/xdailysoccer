﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;
using DailySoccer.DAC.EF;

namespace DailySoccer.Shared.DAC
{
    public class AccountDataAccess : IAccountDataAccess
    {
        public AccountInformation CreateAccount()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var SecrectCode = Guid.NewGuid().ToString();
                var newGuest = new AccountInformation()
                {
                    SecrectCode = SecrectCode,
                    CurrentOrderedCoupon = 0,
                    Points = 0,
                    MaximumGuessAmount = 5,
                };

                dctx.Accounts.Add(new Account
                {
                    Points = newGuest.Points,
                    SecrectCode = newGuest.SecrectCode,
                });
                dctx.SaveChanges();

                return newGuest;
            }
        }

        public AccountInformation GetAccountBySecrectCode(string secrectCode)
        {
            var isArgumentValid = !string.IsNullOrEmpty(secrectCode);
            if (!isArgumentValid) return null;

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .FirstOrDefault(it => it.SecrectCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return null;

                return new AccountInformation
                {
                    MaximumGuessAmount = 5,
                    Points = selectedAccount.Points,
                    SecrectCode = selectedAccount.SecrectCode,
                };
            }
        }

        public IEnumerable<GuessMatchInformation> GetGuessMatchsByAccountSecrectCode(string secrectCode)
        {
            var isArgumentValid = !string.IsNullOrEmpty(secrectCode);
            if (!isArgumentValid) return Enumerable.Empty<GuessMatchInformation>();

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .Include("GuessMatches")
                    .Where(it => it.SecrectCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
                if (selectedAccount == null) return Enumerable.Empty<GuessMatchInformation>();

                var result = selectedAccount.GuessMatches
                    .Select(it => new GuessMatchInformation
                    {
                        Id = it.Id,
                        GuessTeamId = it.GuessTeamId,
                        MatchId = it.MatchId
                    }).ToList();

                return result;
            }
        }
    }
}