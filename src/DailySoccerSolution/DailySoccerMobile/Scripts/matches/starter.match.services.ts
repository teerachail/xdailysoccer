module starter.match {
    'use strict';

    export class MatchServices implements IMatchService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetMatches(req: GetMatchesRequest): ng.IPromise<GetMatchesRespond> {
            var requestUrl = "Matches?UserId=" + req.UserId;
            return this.queryRemoteSvc.RemoteQuery<GetMatchesRespond>(requestUrl);
        }

    }

    angular
        .module('starter.match')
        .service('starter.match.MatchServices', MatchServices);
}