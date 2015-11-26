module starter.match {
    'use strict';

    class MatchController {

        static $inject = ['$scope', 'starter.match.MatchServices'];
        constructor(private $scope: ng.IScope, private matchSvc: starter.match.MatchServices) {
        }

        public GetTodayMatches(): void {
            this.matchSvc.GetToDayMatches(null)
                .then((respond: GetToDayMatchesRespond): void => {
                    // TODO: GetTodayMatches
                });
        }

    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}