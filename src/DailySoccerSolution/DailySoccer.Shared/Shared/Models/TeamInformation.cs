using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class TeamInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentScore { get; set; }
        public int CurrentPredictionPoints { get; set; }
        public bool IsSelected { get; set; }
        public double WinningPredictionPoints { get; set; }
    }
}
