using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Models
{
    public class SetFavoriteTeamRequest
    {
        public string UserId { get; set; }
        public int SelectedTeamId { get; set; }
    }
}
