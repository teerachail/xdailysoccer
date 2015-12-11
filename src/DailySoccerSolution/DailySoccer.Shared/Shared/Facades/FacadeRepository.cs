using DailySoccer.Shared.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class FacadeRepository
    {
        private static FacadeRepository _instance;

        public static FacadeRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new FacadeRepository();
                return _instance;
            }
        }

        public IAccountDataAccess AccountDataAccess { get; private set; }
        public IMatchDataAccess MatchDataAccess { get; private set; }
        public IRewardDataAccess RewardDataAccess { get; private set; }
        public ITicketDataAccess TicketDataAccess { get; private set; }
        public IWinnerDataAccess WinnerDataAccess { get; private set; }

        public MatchFacade MatchFacade { get; private set; }
        public AccountFacade AccountFacade { get; private set; }
        public RewardFacade RewardFacade { get; private set; }
        public TicketFacade TicketFacade { get; private set; }
        public WinnerFacade WinnerFacade { get; private set; }
        public PhoneVerificationFacade PhoneVerificationFacade { get; private set; }

        private FacadeRepository()
        {
            AccountDataAccess = new AccountDataAccess();
            MatchDataAccess = new MatchDataAccess();
            RewardDataAccess = new RewardDataAccess();
            TicketDataAccess = new TicketDataAccess();
            WinnerDataAccess = new WinnerDataAccess();

            MatchFacade = new MatchFacade();
            AccountFacade = new AccountFacade();
            RewardFacade = new RewardFacade();
            TicketFacade = new TicketFacade();
            WinnerFacade = new WinnerFacade();
            PhoneVerificationFacade = new PhoneVerificationFacade(new TwilioSMSSender());
        }

        internal void InitializeDataAccess(IAccountDataAccess accountDac,
            IMatchDataAccess matchDac,
            IRewardDataAccess rewardDac,
            ITicketDataAccess ticketDac)
        {
            AccountDataAccess = accountDac;
            MatchDataAccess = matchDac;
            RewardDataAccess = rewardDac;
            TicketDataAccess = ticketDac;
        }

        internal void InitializePhoneVerification(ISMSSender phoneVerification)
        {
            PhoneVerificationFacade = new PhoneVerificationFacade(phoneVerification);
        }
    }
}
