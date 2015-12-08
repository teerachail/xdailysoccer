using System;
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

                dctx.Accounts.Add(new Account
                {
                    Points = 0,
                    SecretCode = SecrectCode,
                });
                dctx.SaveChanges();

                return new AccountInformation()
                {
                    SecretCode = SecrectCode,
                };
            }
        }

        public AccountInformation CreateNewAccountWithFacebook(string OAuthId, string email)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var SecrectCode = Guid.NewGuid().ToString();

                dctx.Accounts.Add(new Account
                {
                    SecretCode = SecrectCode,
                    Points = 0,
                    Email = email,
                    OAuthId = OAuthId, 
                });
                dctx.SaveChanges();

                return new AccountInformation()
                {
                    SecretCode = SecrectCode,
                    OAuthId = OAuthId,
                };
            }
        }

        public AccountInformation GetAccountBySecrectCode(string secrectCode)
        {
            var isArgumentValid = !string.IsNullOrEmpty(secrectCode);
            if (!isArgumentValid) return null;

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .FirstOrDefault(it => it.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return null;

                return new AccountInformation
                {
                    MaximumGuessAmount = 5,
                    Points = selectedAccount.Points,
                    SecretCode = selectedAccount.SecretCode,
                    OAuthId = selectedAccount.OAuthId,
                    Email = selectedAccount.Email,
                    VerifyCode = selectedAccount.VerifyCode
                };
            }
        }

        public AccountInformation GetAccountByOAuthId(string OAuthId)
        {
            var isArgumentValid = !string.IsNullOrEmpty(OAuthId);
            if (!isArgumentValid) return null;

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .FirstOrDefault(it => it.OAuthId.Equals(OAuthId, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return null;

                return new AccountInformation
                {
                    Points = selectedAccount.Points,
                    SecretCode = selectedAccount.SecretCode,
                    OAuthId = selectedAccount.OAuthId,
                    Email = selectedAccount.Email,
                    VerifyCode = selectedAccount.VerifyCode
                };
            }
        }

        public void UpdateAccount(AccountInformation accountInfo)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var account = dctx.Accounts.FirstOrDefault(it => it.SecretCode == accountInfo.SecretCode);
                if (account != null)
                {
                    account.SecretCode = accountInfo.SecretCode;
                    account.OAuthId = accountInfo.OAuthId;
                    account.Email = accountInfo.Email;
                    account.VerifyCode = accountInfo.VerifyCode;
                    account.Points = accountInfo.Points;
                    dctx.SaveChanges();
                }
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
                    .Where(it => it.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
                if (selectedAccount == null) return Enumerable.Empty<GuessMatchInformation>();

                var result = selectedAccount.GuessMatches
                    .Select(it => new GuessMatchInformation
                    {
                        Id = it.Id,
                        AccountSecrectCode = it.Account.SecretCode,
                        GuessTeamId = it.GuessTeamId,
                        MatchId = it.MatchId,
                        PredictionPoints = it.PredictionPoints
                    }).ToList();

                return result;
            }
        }

        public IEnumerable<LeagueInformation> GetAllLeagues()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var result = dctx.FavoriteTeams
                    .Select(it => new LeagueInformation
                    {
                        TeamId = it.Id,
                        LeagueName = it.LeagueName,
                        TeamName = it.TeamName
                    }).ToList();
                return result;
            }
        }

        public void SetFavoriteTeam(SetFavoriteTeamRequest request)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.SecretCode.Equals(request.UserId, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return;

                var selectedTeam = dctx.FavoriteTeams.FirstOrDefault(it => it.Id == request.SelectedTeamId);
                if (selectedTeam == null) return;

                selectedAccount.FavoriteTeam = selectedTeam;
                dctx.SaveChanges();
            }
        }

        public void ChargeFromBuyTicket(string secrectCode, int requiredPoints)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return;

                selectedAccount.Points -= requiredPoints;
                dctx.SaveChanges();
            }
        }
    }
}
