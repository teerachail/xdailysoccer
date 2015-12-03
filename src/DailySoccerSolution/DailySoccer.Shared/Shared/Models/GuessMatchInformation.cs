using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GuessMatchInformation
    {
        public int Id { get; set; }
        public string AccountSecrectCode { get; set; }
        public int MatchId { get; set; }
        public int? GuessTeamId { get; set; }
        public int PredictionPoints { get; set; }
    }
}
