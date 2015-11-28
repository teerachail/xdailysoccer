module starter.match {
    'use strict';

    export class MatchServices implements IMatchService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetToDayMatches(req: GetToDayMatchesRequest): ng.IPromise<GetToDayMatchesRespond> {
            var requestUrl = ""; // HACK: GetTodayMatches
            return this.queryRemoteSvc.PostRemoteQuery<GetToDayMatchesRespond>(requestUrl);
        }

    }

    angular
        .module('starter.match')
        .service('starter.match.MatchServices', MatchServices);
}