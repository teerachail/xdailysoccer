using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class GetCurrentWinnersRespond
    {
        public IEnumerable<WinnerAwardInformation> Winners { get; set; }
    }
}
