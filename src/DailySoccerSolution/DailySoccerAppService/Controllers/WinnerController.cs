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
        public void SelectTicket(int rewardId, int ticketId)
        {
            var selectedDate = DateTime.Now;
            FacadeRepository.Instance.WinnerFacade.SelectTicket(rewardId, ticketId, selectedDate);
        }

        [HttpGet]
        public void CancelSelectedTicket(int rewardId, int ticketId)
        {
            var selectedDate = DateTime.Now;
            FacadeRepository.Instance.WinnerFacade.CancelSelectedTicket(rewardId, ticketId);
        }

        [HttpGet]
        public void SubmitSelectedWinner(int rewardId)
        {
            var approveWinnerDate = DateTime.Now;
            FacadeRepository.Instance.WinnerFacade.SubmitSelectedWinner(rewardId, approveWinnerDate);
        }
    }
}
