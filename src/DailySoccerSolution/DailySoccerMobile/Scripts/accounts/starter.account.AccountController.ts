module starter.account {
    'use strict';

    class AccountController {

        public isHideSkipButton: Boolean;

        static $inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private accountSvc: starter.account.AccountServices){
            this.checkIonicUserData();
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

                        this.$location.path('/matches/todaymatches');
                    });
        }

        public SkipLogin(): void {
            // TODO: Login with guest
            this.createIonicUserData();           
        };

        public LoginWithFacebook(): void {
            // TODO: Login with facebook
            this.createIonicUserData();

            console.log('Doing connecting to facebook');
            this.$timeout(1000).then(() => {
                this.$location.path('/matches/todaymatches');
            });
        };
    }

    angular
        .module('starter.account', [])
        .controller('starter.account.AccountController', AccountController);
}