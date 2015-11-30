module starter.match {
    'use strict';

    class MatchController {

        public Matches: MatchInformation[] = [];
        public AccountInfo: account.AccountInformation;

        static $inject = ['$scope', 'starter.match.MatchServices', '$location', '$ionicModal'];
        constructor(private $scope, private matchSvc: starter.match.MatchServices, private $location: ng.ILocationService,private $ionicModal) {
            this.GetTodayMatches();

            this.$ionicModal.fromTemplateUrl('templates/Matches/MatchPopup.html', {
                scope: $scope,
                animation: 'slide-in-up'
            }).then(function (modal) {
                $scope.MatchPopup = modal;
            });
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

            var request = new GuessMatchRequest();
            request.UserId = Ionic.User.current().id;
            request.MatchId = selectedMatch.Id;
            request.IsHome = isSelectedTeamHome;

            this.matchSvc.GuessMatch(request)
                .then((respond: GuessMatchRespond) => {
                    this.Matches = respond.Matches;
                    this.AccountInfo = respond.AccountInfo;
                    console.log('Send guess match completed.');
                });
        }

    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}