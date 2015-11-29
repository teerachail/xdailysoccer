module starter.match {
    'use strict';

    class MatchController {

        public Matches: MatchInformation[] = [];
        public AccountInfo: account.AccountInformation;

        static $inject = ['$scope', 'starter.match.MatchServices', '$location'];
        constructor(private $scope: ng.IScope, private matchSvc: starter.match.MatchServices, private $location: ng.ILocationService) {
            this.GetTodayMatches();
        }

        public GetTodayMatches(): void {
            var user = Ionic.User.current();
            var data = new GetMatchesRequest();
            data.UserId = user.id;
            this.matchSvc.GetMatches(data)
                .then((respond: GetMatchesRespond): void => {
                    this.Matches = respond.matches;
                    this.AccountInfo = respond.accountInfo;
                    console.log('Get all matches completed.');
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