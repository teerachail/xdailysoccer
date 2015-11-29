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
            if (user.id) {
                this.$location.path('/matches/todaymatches');
            } else {
                var isSkiped = user.get('isSkiped');
                alert(isSkiped);
                if (isSkiped) {
                    // TODO: Hidden skip button
                }
            }
        }

        private createIonicUserData() {
            var user = Ionic.User.current();
            if (!user.id) {
                this.accountSvc.CreateNewGuest()
                    .then((respond: CreateNewGuestRespond): void => {
                        user.id = respond.AccountInfo.SecrectCode;
                        user.set('isSkiped', 'true');
                        user.save();
                        console.log('Create new guest complete.');
                    });              
            } 
        }

        public SkipLogin(): void {
            // TODO: Login with guest
            this.createIonicUserData();

            console.log('Doing Register new guest account');
            this.$timeout(1000).then(() => {
                this.$location.path('/matches/todaymatches');
            });
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