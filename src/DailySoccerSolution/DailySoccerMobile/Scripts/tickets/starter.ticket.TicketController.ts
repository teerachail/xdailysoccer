module starter.ticket {
    'use strict';

    class TicketController {

        public AccountInfo: account.AccountInformation;
        public DisplayRewardResultDate: Date;
        public RemainingPoints: number;
        public ExpiredDate: Date;

        static $inject = ['$scope', '$stateParams', '$timeout', '$location', '$ionicModal', 'starter.ticket.TicketServices', 'starter.shared.AccountManagementService'];
        constructor(private $scope, private $stateParams, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private $ionicModal, private ticketSvc: starter.ticket.TicketServices, private accountSvc: shared.AccountManagementService) {
            
            this.RemainingPoints = this.$stateParams.remainingPoints;
            this.ExpiredDate = this.$stateParams.expiredDate;

            this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal): void { $scope.ErrorPopup = modal; });

            this.$ionicModal.fromTemplateUrl('templates/Accounts/TieFacebookPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal): void { $scope.TieFacebookPopup = modal; });
        }

        public LoginWithFacebook(): void {
            this.$scope.TieFacebookPopup.hide();
            this.accountSvc.TieFacebook();
        }

        public BuyTicket(amount: number): void {
            var accountInformation = this.accountSvc.GetAccountInformation();
            const MinimumAmount = 1;
            var canBuyTicket = (amount >= MinimumAmount) && (accountInformation.Points >= amount * this.accountSvc.CurrentTicketCost);
            if (!canBuyTicket) {
                this.$scope.ErrorPopup.show();
                return;
            }

            var isTieWithFacaebookAlready = (accountInformation.OAuthId != null) && (accountInformation.SecretCode != null);
            if (!isTieWithFacaebookAlready) {
                this.$scope.TieFacebookPopup.show();
                return;
            }

            var isVerifiedPhoneNumber = (accountInformation.VerifiedPhoneNumber == 'true');
            if (!isVerifiedPhoneNumber) {
                this.$location.path('/verify/verifyphonenumber/' + amount);
                return;
            }

            console.log('#Begin send buy ticket request.')
            var user = Ionic.User.current();
            var request = new BuyTicketRequest();
            request.UserId = user.id;
            request.Amount = amount;
            this.ticketSvc.BuyTicket(request)
                .then((respond: BuyTicketRespond): void => {
                    if (respond.IsSuccessed) {
                        this.AccountInfo = respond.AccountInfo;
                        this.DisplayRewardResultDate = new Date(respond.RewardResultDate.toString());
                        console.log('Buy ticket completed.')
                        this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.AccountInfo.Points + '/' + respond.RewardResultDate);
                    }
                    else {
                        // TODO: Buy ticket failed
                        console.log('Buy ticket failed.');
                    }
                });
        }
    }

    angular
        .module('starter.ticket', [])
        .controller('starter.ticket.TicketController', TicketController);
}