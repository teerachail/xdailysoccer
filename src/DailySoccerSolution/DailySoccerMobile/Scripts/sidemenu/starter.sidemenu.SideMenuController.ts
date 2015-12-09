module starter.sidemenu {
    'use strict';

    class SideMenuController {

        private isLogin: Boolean;

        static $inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices','Azureservice'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private accountSvc: starter.account.AccountServices, private Azureservice: any){
            this.checkCurrenUserLogin();
        }

        public checkCurrenUserLogin() {
            var user = Ionic.User.current();
            var OAuthId = user.get('OAuthId');
            if (OAuthId) {
                this.isLogin = true;
            } else {
                this.isLogin = false;
            }

            alert(OAuthId);
        }

    }

    angular
        .module('starter.sidemenu', [])
        .controller('starter.sidemenu.SideMenuController', SideMenuController);
}