using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GuessMatchRequest
    {
        public string UserId { get; set; }
        public int MatchId { get; set; }
        public bool IsGuessTeamHome { get; set; }
        public bool IsCancelGuess { get; set; }
    }
}
