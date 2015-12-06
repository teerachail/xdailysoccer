using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class YourRewardInformation
    {
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int Ordering { get; set; }
        public string ReferenceCode { get; set; }
    }
}
