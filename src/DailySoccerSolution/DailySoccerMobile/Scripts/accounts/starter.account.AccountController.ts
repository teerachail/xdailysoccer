module starter.account {
    'use strict';

    class AccountController {

        public isHideSkipButton: Boolean;
        public DisplayLeague: LeagueInformation[];
        private _allLeague: LeagueInformation[];
        private _selectedTeamId: number = -1;

        static $inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private accountSvc: starter.account.AccountServices){
            //this.checkIonicUserData();
            this.GetAllLeague();
        }

        private GetAllLeague(): void {
            this.accountSvc.GetAllLeague()
                .then((respond: GetAllLeagueRespond): void => {
                    this.updateDisplayLeague(respond.Leagues);
                    console.log('Get all league completed.');
                });
        }

        private updateDisplayLeague(leagues: LeagueInformation[]): void {
            this._allLeague = leagues;
            //Hack: Not fliter yet
            this.DisplayLeague = this._allLeague;
            console.log('# Update league completed.');
        }

        private checkIonicUserData() {
            var user = Ionic.User.current();
            if (user.id && user.id != 'empty') {
                this.$location.path('/matches/todaymatches');
            } else {
                var isSkiped = user.get('isSkiped');
                if (isSkiped) {
                    this.isHideSkipButton = true;
                } 
            }
        }

        private createIonicUserData() {
            var user = Ionic.User.current();
                this.accountSvc.CreateNewGuest()
                    .then((respond: CreateNewGuestRespond): void => {
                        user.id = respond.AccountInfo.SecrectCode;
                        user.set('isSkiped', 'true');
                        user.save();
                        console.log('Create new guest complete.');
                        
                        this.$location.path('/account/favorite');
                    });
        }

        public SkipLogin(): void {
            // TODO: Login with guest
            this.createIonicUserData();           
        };

        public LoginWithFacebook(): void {
            // TODO: Login with facebook
            this.createIonicUserData();
        };

        public SelectFavoriteTeam(TeamId: number) {
            this._selectedTeamId = TeamId;
            console.log('Set favorite team completed.');
        }

        public SetFavoriteTeam() {
            var user = Ionic.User.current();
            if (this._selectedTeamId > -1) {
                var favoriteTeam = new SetFavoriteTeamRequest();
                favoriteTeam.UserId = user.id;
                favoriteTeam.SelectedTeamId = this._selectedTeamId;
                this.accountSvc.SetFavoriteTeam(favoriteTeam);
                console.log('Send favorite team completed.');
            }
            else {
                console.log('Skip to send favorite team completed.');
            }
            this.$location.path('/matches/todaymatches');
            user.set('isSetFavoriteTeam', 'true');
            user.save();
        }
    }

    angular
        .module('starter.account', [])
        .controller('starter.account.AccountController', AccountController);
}