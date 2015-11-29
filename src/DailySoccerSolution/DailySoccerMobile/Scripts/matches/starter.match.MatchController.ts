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
                    this.Matches = respond.Matches;
                    this.AccountInfo = respond.AccountInfo;
                    console.log('Get all matches completed.');
                });
        }

        public Logout(): void {
            var user = Ionic.User.current();
            user.id = 'empty';
            user.save();
            this.$location.path('/account/login');
        }

        public SelectTeam(selectedMatch: MatchInformation, selectedTeamId: number) {
            var isSelectedTeamHome = selectedMatch.TeamHome.Id == selectedTeamId;
            var selectedTeam = isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
            var unselectedTeam = !isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
            selectedTeam.IsSelected = !selectedTeam.IsSelected;
            unselectedTeam.IsSelected = false;
            console.log('Select team: ' + selectedTeam.Name);
        }

    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}