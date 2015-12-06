module starter.history {
    'use strict';

    export class HistoryServices implements IHistoryService {
        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetAllGuessHistory(req: GetAllGuessHistoryRequest): ng.IPromise<GetAllGuessHistoryRespond> {
            var requestUrl = 'History/GetCurrentRewards?UserId=' + req.UserId;
            return this.queryRemoteSvc.RemoteQuery<GetAllGuessHistoryRespond>(requestUrl);
        }

        public GetGuessHistoryByMonth(req: GetGuessHistoryByMonthRequest): ng.IPromise<GetGuessHistoryByMonthRespond> {
            var requestUrl = 'History/GetGuessHistoryByMonth?UserId=' + req.UserId + '&year=' + req.Year + '&month=' + req.Month;
            return this.queryRemoteSvc.RemoteQuery<GetGuessHistoryByMonthRespond>(requestUrl);
        }
    }

    angular
        .module('starter.history')
        .service('starter.history.HistoryServices', HistoryServices);
}