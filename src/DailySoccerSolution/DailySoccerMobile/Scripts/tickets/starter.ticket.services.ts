module starter.ticket {
    'use strict';

    export class TicketServices implements ITicketService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public BuyTicket(req: BuyTicketRequest): ng.IPromise<BuyTicketRespond> {
            var requestUrl = "BuyTicket/BuyTicket?userId=" + req.UserId + "&amount=" + req.Amount;
            return this.queryRemoteSvc.RemoteQuery<BuyTicketRespond>(requestUrl);
        };
    }

    export class BuyTicketManagerService {

    }

    angular
        .module('starter.ticket')
        .service('starter.ticket.TicketServices', TicketServices)
        .service('starter.ticket.BuyTicketManagerService', BuyTicketManagerService);
}