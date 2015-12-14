module starter.ticket {
    'use strict';

    class TicketController {

        static $inject = ['$scope', '$stateParams', '$timeout', '$location', '$ionicModal', 'starter.ticket.TicketServices', 'starter.shared.AccountManagementService', 'starter.shared.BuyTicketProcessingService'];
        constructor(private $scope,
            private $stateParams,
            private $timeout: ng.ITimeoutService,
            private $location: ng.ILocationService,
            private $ionicModal,
            private ticketSvc: starter.ticket.TicketServices,
            private accountSvc: shared.AccountManagementService,
            private buyTicketProcessingSvc: starter.shared.BuyTicketProcessingService) {

            this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal): void { $scope.ErrorPopup = modal; });
        }

        public CalculateBuyTicket(): number {
            var result = Math.floor(this.accountSvc.GetAccountInformation().Points / this.accountSvc.CurrentTicketCost);
            return result;
        }

        public BuyTicket(amount: number): void {
            amount = Math.floor(amount);
            var accountInformation = this.accountSvc.GetAccountInformation();
            const MinimumAmount = 1;
            var canBuyTicket = (amount >= MinimumAmount) && (accountInformation.Points >= amount * this.accountSvc.CurrentTicketCost);
            if (!canBuyTicket) {
                this.$scope.ErrorPopup.show();
                return;
            }

            this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin = true;
            this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber = true;
            this.buyTicketProcessingSvc.buyAmount = amount;
            this.$location.path('/ticket/buyticketprocessing');
        }
    }

    class TicketProcessingController {

        static $inject = ['$scope', '$location', '$timeout', '$ionicHistory', '$ionicModal', 'starter.shared.AccountManagementService', 'starter.shared.BuyTicketProcessingService', 'starter.ticket.TicketServices'];
        constructor(private $scope,
            private $location: ng.ILocationService,
            private $timeout: ng.ITimeoutService,
            private $ionicHistory,
            private $ionicModal,
            private accountSvc: shared.AccountManagementService,
            private buyTicketProcessingSvc: starter.shared.BuyTicketProcessingService,
            private ticketSvc: starter.ticket.TicketServices) {

            this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(modal=> { this.$scope.ErrorPopup = modal; });

            this.$ionicModal.fromTemplateUrl('templates/Accounts/TieFacebookPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(modal=> { this.$scope.TieFacebookPopup = modal; });

            this.$scope.$on('modal.hidden', () => this.BuyTicket());
            this.waitForPreparingPopup();
        }

        private waitForPreparingPopup(): void {
            console.log('Preparing...');
            this.$timeout(() => this.BuyTicket(), 750);
        }

        public LoginWithFacebook(): void {
            this.$scope.TieFacebookPopup.hide();
            this.accountSvc.TieFacebook();
        }

        public BuyTicket(): void {
            var isPrepared = this.$scope.TieFacebookPopup != null && this.$scope.ErrorPopup != null;
            if (!isPrepared) {
                console.log('Preparing...');
                this.waitForPreparingPopup();
                return;
            }

            var amount = this.buyTicketProcessingSvc.buyAmount;
            var accountInformation = this.accountSvc.GetAccountInformation();

            var isTieWithFacaebookAlready = accountInformation.OAuthId != null && accountInformation.SecretCode != null;
            if (!isTieWithFacaebookAlready) {
                if (this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin) {
                    this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin = false;
                    this.accountSvc.IsRequestFacebookLoginFromBuyTicket = true;
                    this.$scope.TieFacebookPopup.show();
                }
                else this.$ionicHistory.goBack();
                return;
            }
            console.log('Facebook authentication verified');

            var isVerifiedPhoneNumber = accountInformation.VerifiedPhoneNumber != null;
            if (!isVerifiedPhoneNumber) {
                if (this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber) {
                    this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber = false;
                    this.$location.path('/ticket/verifyphonenumber');
                }
                else this.$ionicHistory.goBack();
                return;
            }
            console.log('Phone authentication verified');

            var request = new BuyTicketRequest();
            request.UserId = accountInformation.SecretCode;
            request.Amount = amount;
            this.ticketSvc.BuyTicket(request)
                .then((respond: BuyTicketRespond): void => {
                    console.log('BuyTicket success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed) {
                        var accountInfo = this.accountSvc.GetAccountInformation();
                        accountInfo.Points = respond.AccountInfo.Points;
                        accountInfo.CurrentOrderedCoupon = respond.AccountInfo.CurrentOrderedCoupon;
                        this.accountSvc.SetAccountInformation(accountInfo);
                        var rewardResultDate = new Date(respond.RewardResultDate.toString());
                        this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.RewardResultDate);
                    }
                });
        }
    }

    class PhoneVerificationController {
        static $inject = ['$scope', '$location', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices', 'starter.shared.BuyTicketProcessingService'];
        constructor(private $scope,
            private $location: ng.ILocationService,
            private accountManagementSvc: starter.shared.AccountManagementService,
            private ticketSvc: starter.ticket.TicketServices,
            private buyTicketProcessingSvc: starter.shared.BuyTicketProcessingService) {
        }

        public SendRequestVerifyPhoneNumber(phoneNumber: string): void {
            console.log('Call SendRequestVerifyPhoneNumber');
            var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
            var areArgumentValid = phoneNumber != null && userId != null;
            if (!areArgumentValid) return;

            console.log('Begin SendRequestVerifyPhoneNumber');
            var request = new RequestConfirmPhoneNumberRequest();
            request.UserId = userId;
            request.PhoneNo = phoneNumber;
            this.ticketSvc.RequestConfirmPhoneNumber(request)
                .then((respond: RequestConfirmPhoneNumberRespond): void => {
                    console.log('#RequestConfirmPhoneNumber success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed) this.$location.path('/ticket/verifycode/' + phoneNumber);
                });
        }
    }

    class CodeVerificationController {
        static $inject = ['$scope', '$stateParams', '$location', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices', 'starter.shared.BuyTicketProcessingService'];
        constructor(private $scope,
            private $stateParams,
            private $location: ng.ILocationService,
            private accountManagementSvc: starter.shared.AccountManagementService,
            private ticketSvc: starter.ticket.TicketServices,
            private buyTicketProcessingSvc: starter.shared.BuyTicketProcessingService) {
        }

        public ResendVerificationCode(): void {
            var phoneNumber = this.$stateParams.phoneNumber;
            console.log('Call Resend verification code');
            var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
            var areArgumentValid = phoneNumber != null && userId != null;
            if (!areArgumentValid) return;

            var request = new RequestConfirmPhoneNumberRequest();
            request.UserId = userId;
            request.PhoneNo = phoneNumber;
            this.ticketSvc.RequestConfirmPhoneNumber(request)
                .then((respond: RequestConfirmPhoneNumberRespond): void => {
                    console.log('#Resend verification code success: ' + respond.IsSuccessed);
                });
        }

        public ConfirmPhoneNumber(verificationCode: string): void {
            if (verificationCode != null) {
                var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
                var request = new ConfirmPhoneNumberRequest();
                request.UserId = userId;
                request.VerificationCode = verificationCode;
                this.ticketSvc.ConfirmPhoneNumber(request)
                    .then((respond: ConfirmPhoneNumberRespond) => {
                        console.log('#RequestVerificationCode success: ' + respond.IsSuccessed);
                        if (respond.IsSuccessed) {
                            this.accountManagementSvc.SetPhoneVerified();
                            this.sentBuyTicket();
                        }
                    });
            }
        }

        private sentBuyTicket(): void {
            var accountInformation = this.accountManagementSvc.GetAccountInformation();
            var request = new BuyTicketRequest();
            request.UserId = accountInformation.SecretCode;
            request.Amount = this.buyTicketProcessingSvc.buyAmount;
            this.ticketSvc.BuyTicket(request)
                .then((respond: BuyTicketRespond): void => {
                    console.log('BuyTicket success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed) {
                        this.buyTicketProcessingSvc.buyAmount = 0;
                        var accountInfo = this.accountManagementSvc.GetAccountInformation();
                        accountInfo.Points = respond.AccountInfo.Points;
                        accountInfo.CurrentOrderedCoupon = respond.AccountInfo.CurrentOrderedCoupon;
                        this.accountManagementSvc.SetAccountInformation(accountInfo);
                        var rewardResultDate = new Date(respond.RewardResultDate.toString());
                        this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.RewardResultDate);
                    }
                    else this.$location.path('/ticket/buyticketprocessing');
                });
        }
    }

    class BuyTicketCompleteController {
        static $inject = ['$scope', '$stateParams', 'starter.shared.AccountManagementService'];
        constructor(private $scope,
            private $stateParams,
            private accountManagementSvc: starter.shared.AccountManagementService) {
        }
    }

    angular
        .module('starter.ticket', [])
        .controller('starter.ticket.TicketController', TicketController)
        .controller('starter.ticket.TicketProcessingController', TicketProcessingController)
        .controller('starter.ticket.PhoneVerificationController', PhoneVerificationController)
        .controller('starter.ticket.CodeVerificationController', CodeVerificationController)
        .controller('starter.ticket.BuyTicketCompleteController', BuyTicketCompleteController);
}