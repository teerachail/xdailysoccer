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

        static $inject = ['$scope', '$stateParams', '$timeout', '$location', 'starter.account.AccountServices', 'Azureservice', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices'];
        constructor(private $scope,
            private $stateParams,
            private $timeout: ng.ITimeoutService,
            private $location: ng.ILocationService,
            private accountSvc: starter.account.AccountServices,
            private Azureservice: any,
            private AccountManagementService: starter.shared.AccountManagementService,
            private ticketSvc: starter.ticket.TicketServices) {

            if (this.$stateParams.buyTicketAmount) {
                this._buyTicketAmount = this.$stateParams.buyTicketAmount;
            }

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

        public CheckLocalStorageAccount() {
            var accountInfo = this.AccountManagementService.GetAccountInformation();
            var isLogedIn = accountInfo.SecretCode != null && accountInfo.SecretCode != 'empty';
            if (isLogedIn) this.$location.path('/matches/todaymatches');
            this.isHideSkipButton = accountInfo.IsSkiped == 'true';
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

        public SendRequestVerifyPhoneNumber(phoneNumber: string, isRequireReload: boolean = true): void {
            console.log('Call SendRequestVerifyPhoneNumber');
            var userId = this.AccountManagementService.GetAccountInformation().SecretCode;
            var areArgumentValid = phoneNumber != null && userId != null;
            if (!areArgumentValid) return;

            console.log('Begin SendRequestVerifyPhoneNumber');
            var request = new RequestConfirmPhoneNumberRequest();
            request.UserId = userId;
            request.PhoneNo = phoneNumber;
            this.accountSvc.RequestConfirmPhoneNumber(request)
                .then((respond: RequestConfirmPhoneNumberRespond): void => {
                    if (respond.IsSuccessed) {
                        console.log("#RequestConfirmPhoneNumber successed.");
                        if (isRequireReload) {
                            this.$location.path('/verify/verifycode/' + respond.ForPhoneNumber + '/' + this._buyTicketAmount);
                        }
                        //TODO: Do not navigate to another page (# Currently,it naviagated to another page)
                    }
                    else {
                        
                        console.log("#RequestConfirmPhoneNumber failed.");
                    }
                });
        }

        public ConfirmPhoneNumber(verificationCode: string): void {
            var userId = this.AccountManagementService.GetAccountInformation().SecretCode;
            if (verificationCode != null) {
                var request = new ConfirmPhoneNumberRequest();
                request.UserId = userId;
                request.VerificationCode = verificationCode;
                this.accountSvc.ConfirmPhoneNumber(request)
                    .then((respond: ConfirmPhoneNumberRespond) => {
                        if (respond.IsSuccessed) {

                            this.AccountManagementService.SetPhoneVerified();
                            var request = new starter.ticket.BuyTicketRequest();
                            request.UserId = userId;
                            request.Amount = this._buyTicketAmount;
                            this.ticketSvc.BuyTicket(request).
                                then((respond: starter.ticket.BuyTicketRespond) => {
                                    if (respond.IsSuccessed) {
                                        var memoryAccountInfo = this.AccountManagementService.GetAccountInformation();
                                        memoryAccountInfo.Points = respond.AccountInfo.Points;
                                        memoryAccountInfo.CurrentOrderedCoupon = respond.AccountInfo.CurrentOrderedCoupon;
                                        this.AccountManagementService.SetAccountInformation(memoryAccountInfo);
                                        console.log('Buy ticket completed.')
                                        this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.AccountInfo.Points + '/' + respond.RewardResultDate);
                                    }
                                    else {
                                        console.log('Buy ticket failed.')
                                        this.$location.path('/ticket/buyticket');
                                    }
                                });

                            console.log("#RequestVerificationCode successed.");
                        }
                        else {
                            console.log("#RequestVerificationCode failed.");
                        }
                    });
            }
        }
    }

    angular
        .module('starter.account', [])
        .controller('starter.account.AccountController', AccountController);
}