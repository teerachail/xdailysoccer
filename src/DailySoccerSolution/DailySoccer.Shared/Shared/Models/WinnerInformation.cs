using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class WinnerInformation
    {
        public int Id { get; set; }
        public string AccountSecrectCode { get; set; }
        public int RewardId { get; set; }
        public string ReferenceCode { get; set; }
        public string AccountFullName { get; set; }
    }
}
