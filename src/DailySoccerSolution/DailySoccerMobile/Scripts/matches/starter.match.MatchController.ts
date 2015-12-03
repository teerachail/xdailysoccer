module starter.match {
    'use strict';

    class MatchController {

        public CurrentDate: Date;
        public PastOneDaysDate: Date = new Date();
        public PastTwoDaysDate: Date = new Date();
        public FutureOneDaysDate: Date = new Date();
        public FutureTwoDaysDate: Date = new Date();
        public RemainingGuessAmount: number;
        public DisplayMatches: MatchInformation[] = [];
        public AccountInfo: account.AccountInformation;
        private _allMatches: MatchInformation[] = [];

        static $inject = ['$scope', 'starter.match.MatchServices', '$location', '$ionicModal', '$ionicTabsDelegate'];
        constructor(private $scope,
            private matchSvc: starter.match.MatchServices,
            private $location: ng.ILocationService,
            private $ionicModal,
            private $ionicTabsDelegate) {
        
            this.GetTodayMatches();
            this.$ionicModal.fromTemplateUrl('templates/Matches/MatchPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal): void { $scope.MatchPopup = modal; });
        }

        public GetTodayMatches(): void {
            var user = Ionic.User.current();
            var data = new GetMatchesRequest();
            data.UserId = user.id;
            this.matchSvc.GetMatches(data)
                .then((respond: GetMatchesRespond): void => {
                    this.AccountInfo = respond.AccountInfo;
                    this.updateDisplayDate(respond.CurrentDate);
                    this.updateDisplayMatches(respond.Matches);
                    this.updateRemainingGuessAmount();
                    this.$ionicTabsDelegate.$getByHandle('calendarTabs').select(2);
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
            var isChangingValid = this.AccountInfo.MaximumGuessAmount > this.getSelectedTodayMatches().length
            if (!isChangingValid) {
                if (selectedMatch.TeamHome.IsSelected != !selectedMatch.TeamAway.IsSelected) {
                    this.$scope.MatchPopup.show();
                    return;
                }
            }

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
                .then((respond: GuessMatchRespond): void => {
                    this.AccountInfo = respond.AccountInfo;
                    this.updateDisplayMatches(respond.Matches);
                    this.updateRemainingGuessAmount();
                    console.log('Send guess match completed.');
                });

            this.updateRemainingGuessAmount();
        }

        public SelectDay(days: Date) {
            var compareDate = new Date(days.toString());
            this.DisplayMatches = this._allMatches.filter(it=> {
                var matchDate = new Date(it.BeginDate.toString());
                return matchDate.getDay() == compareDate.getDay();
            });
            console.log('# Change display matches completed.');
        }

        private updateDisplayMatches(matches: MatchInformation[]): void {
            this._allMatches = matches;
            this.SelectDay(this.CurrentDate);
            console.log('# Update matches completed.');
        }
        
        private updateDisplayDate(currentDate: Date): void {
            this.CurrentDate = currentDate;

            currentDate = new Date(currentDate.toString());
            this.PastOneDaysDate.setDate(currentDate.getDate() - 1);
            this.PastTwoDaysDate.setDate(currentDate.getDate() - 2);
            this.FutureOneDaysDate.setDate(currentDate.getDate() + 1);
            this.FutureTwoDaysDate.setDate(currentDate.getDate() + 2);
            console.log('# Update date completed.');
        }

        private updateRemainingGuessAmount(): void {
            this.RemainingGuessAmount = this.AccountInfo.MaximumGuessAmount - this.getSelectedTodayMatches().length;
            console.log('# Update remaining guess amount completed.');
        }

        private getSelectedTodayMatches(): MatchInformation[] {
            var selectedMatchesQry = this._allMatches.filter(it => (it.TeamHome.IsSelected || it.TeamAway.IsSelected) && it.BeginDate == this.CurrentDate);
            return selectedMatchesQry;
        }
    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}