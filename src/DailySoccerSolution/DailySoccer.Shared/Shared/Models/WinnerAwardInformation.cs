using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class WinnerAwardInformation
    {
        public int Ordering { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<string> Winners { get; set; }
    }
}
