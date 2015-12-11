using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DailySoccerAppService.Controllers
{
    public class WinnerController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpPost]
        public string Post(int id)
        {
            return "Respond by POST method, your ID: " + id;
        }

        [HttpGet]
        public GetSelectedTicketRespond GetSelectedTicket(int rewardId)
        {
            var result = FacadeRepository.Instance.WinnerFacade.GetSelectedTicket(rewardId);
            return result;
        }

        [HttpGet]
        public void RandomWinner(int rewardId)
        {
            // TODO : Implement RandomWinner
        }

        [HttpGet]
        public void SelectWinner(int ticketId)
        {
            // TODO : Implement SelectWinner
        }

        [HttpGet]
        public void SubmitSelectedWinner(int ticketId)
        {
            // TODO : Implement SelectWinner
        }
    }
}
