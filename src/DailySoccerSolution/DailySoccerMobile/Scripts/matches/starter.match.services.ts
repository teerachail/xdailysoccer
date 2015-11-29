module starter.match {
    'use strict';

    export class MatchServices implements IMatchService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public GetMatches(req: GetMatchesRequest): ng.IPromise<GetMatchesRespond> {
            var requestUrl = 'Matches/GetMatches?UserId=' + req.UserId;
            return this.queryRemoteSvc.RemoteQuery<GetMatchesRespond>(requestUrl);
        }

        public GuessMatch(req: GuessMatchRequest): ng.IPromise<GuessMatchRespond> {
            var requestUrl = 'Matches/GuessMatch?userId=' + req.UserId + '&matchId=' + req.MatchId + '&isHome=' + req.IsHome;
            return this.queryRemoteSvc.RemoteQuery<GuessMatchRespond>(requestUrl);
        }

    }

    angular
        .module('starter.match')
        .service('starter.match.MatchServices', MatchServices);
}