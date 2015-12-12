module starter.account {
    'use strict';

    class AccountController {

        public localPoint: number;
        public facebookPoint: number;
        public isHideSkipButton: Boolean;
        public DisplayLeague: LeagueInformation[];
        private _allLeague: LeagueInformation[];
        private _selectedTeamId: number = -1;
        private _buyTicketAmount: number;

        static $inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices', 'Azureservice', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices'];
        constructor(private $scope,
            private $timeout: ng.ITimeoutService,
            private $location: ng.ILocationService,
            private accountSvc: starter.account.AccountServices,
            private Azureservice: any,
            private AccountManagementService: starter.shared.AccountManagementService,
            private ticketSvc: starter.ticket.TicketServices) {

            //Clear local storage for test only!
            //this.AccountManagementService.ClearGuestData();
        }


        public GetAllLeague(): void {
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

        public CheckLocalStorageAccount(): void {
            var accountInfo = this.AccountManagementService.GetAccountInformation();
            var isLogedIn = accountInfo.SecretCode != null && accountInfo.SecretCode != 'empty';
            if (isLogedIn) this.$location.path('/matches/todaymatches');
            this.isHideSkipButton = accountInfo.IsSkiped != null;
        }
       
        public SkipLogin(): void {
            // TODO: Login with guest
            this.AccountManagementService.CreateNewGuestUser();     
        };        

        public LoginWithFacebook(): void {
            this.AccountManagementService.LoginWithFacebook();
        };

        public TieFacbookWithFacebookData(): void {
            this.AccountManagementService.TieFacbookWithFacebookData();
        }

        public TieFacbookWithLocalData(): void {
            this.AccountManagementService.TieFacbookWithLocalData();
        }

        public SelectFavoriteTeam(TeamId: number) {
            this._selectedTeamId = TeamId;
            console.log('Set favorite team completed.');
        }

        public SetFavoriteTeam() {
            if (this._selectedTeamId > -1) {
                var favoriteTeam = new SetFavoriteTeamRequest();
                favoriteTeam.UserId = this.AccountManagementService.GetAccountInformation().SecretCode;
                favoriteTeam.SelectedTeamId = this._selectedTeamId;
                this.accountSvc.SetFavoriteTeam(favoriteTeam);
                console.log('Send favorite team completed.');
            }
            else console.log('Skip to send favorite team completed.');

            this.$location.path('/matches/todaymatches');
        }

        public ShowFacebookData(): void {
            this.facebookPoint = this.AccountManagementService.facebookPoint;
            this.localPoint = this.AccountManagementService.localPoint;
        }
    }

    angular
        .module('starter.account', [])
        .controller('starter.account.AccountController', AccountController);
}