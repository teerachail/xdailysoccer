module starter.match {
    'use strict';

    class MatchController {

        static $inject = ['$scope', 'starter.match.MatchServices', '$location'];
        constructor(private $scope: ng.IScope, private matchSvc: starter.match.MatchServices, private $location: ng.ILocationService) {
        }

        public GetTodayMatches(): void {
            this.matchSvc.GetToDayMatches(null)
                .then((respond: GetToDayMatchesRespond): void => {
                    // TODO: GetTodayMatches
                });
        }

        public Logout(): void {
            var user = Ionic.User.current();
            user.id = '';

            this.$location.path('/account/login');
        }

    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}