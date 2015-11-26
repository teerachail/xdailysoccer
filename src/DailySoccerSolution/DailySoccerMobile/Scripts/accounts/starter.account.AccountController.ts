module starter.account {
    'use strict';

    class AccountController {
        static $inject = ['$scope', '$timeout', '$location'];
        constructor(private $scope: ng.IScope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService) {
        }

        public SkipLogin(): void {
            // TODO: Login with guest
            console.log('Doing Register new guest account');
            this.$timeout(1000).then(() => {
                this.$location.path('/matches/todaymatches');
            });
        };

        public LoginWithFacebook(): void {
            // TODO: Login with facebook
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