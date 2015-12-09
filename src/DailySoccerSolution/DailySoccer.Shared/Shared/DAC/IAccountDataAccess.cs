using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface IAccountDataAccess
    {
        AccountInformation CreateAccount();
        AccountInformation CreateNewAccountWithFacebook(string OAuthId, string email);
        void UpdateAccount(AccountInformation accountInfo);
        AccountInformation GetAccountBySecrectCode(string secrectCode);
        AccountInformation GetAccountByOAuthId(string OAuthId);
        IEnumerable<GuessMatchInformation> GetGuessMatchsByAccountSecrectCode(string secrectCode);
        IEnumerable<GuessMatchInformation> GetGuessMatchsByMatchId(int matchId);
        IEnumerable<LeagueInformation> GetAllLeagues();
        void SetFavoriteTeam(SetFavoriteTeamRequest request);
        void ChargeFromBuyTicket(string secrectCode, int requiredPoints);
        void RequestConfirmPhoneNumber(RequestConfirmPhoneNumberRequest request, string verificationCode);
        VerificationPhoneInformation GetVerificationPhoneByVerificationCode(string userId, string verificationCode);
        void VerifyPhoneSuccess(string userId, string phoneNo, string verificationCode);
        void UpdateGuessResult(int guessMatchId, bool isGuessCorrect, int gotPoints);
        void UpdateAccountPoints(int accountId, int additionPoints);
    }
}
