using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.Facades;

namespace DailySoccerAppService.Controllers
{
    public class BuyTicketController : ApiController
    {
        [HttpGet]
        public BuyTicketRespond BuyTicket(string userId, int amount)
        {
            var request = new BuyTicketRequest { UserId = userId, Amount = amount };
            var result = FacadeRepository.Instance.TicketFacade.BuyTicket(request, DateTime.Now);
            return result;
        }
    }
}
