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
        AccountInformation GetAccountBySecrectCode(string secrectCode);
        IEnumerable<GuessMatchInformation> GetGuessMatchsByAccountSecrectCode(string secrectCode);
    }
}
