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

        public RequestConfirmPhoneNumber(request: RequestConfirmPhoneNumberRequest): ng.IPromise<RequestConfirmPhoneNumberRespond> {
            var requestUrl = "Account/RequestConfirmPhoneNumber?userId=" + request.UserId + "&phoneNo=" + request.PhoneNo;
            return this.queryRemoteSvc.RemoteQuery<RequestConfirmPhoneNumberRespond>(requestUrl);
        }

        public ConfirmPhoneNumber(request: ConfirmPhoneNumberRequest): ng.IPromise<ConfirmPhoneNumberRespond> {
            var requestUrl = "Account/ConfirmPhoneNumber?userId=" + request.UserId + "&verificationCode=" + request.VerificationCode;
            return this.queryRemoteSvc.RemoteQuery<ConfirmPhoneNumberRespond>(requestUrl);
        }
    }

    angular
        .module('starter.ticket')
        .service('starter.ticket.TicketServices', TicketServices);
}