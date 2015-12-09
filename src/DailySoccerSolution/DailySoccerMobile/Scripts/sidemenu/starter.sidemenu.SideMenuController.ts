module starter.sidemenu {
    'use strict';

    class SideMenuController {

        private isLogedin: Boolean;

        static $inject = ['$scope', '$timeout', '$location', 'Azureservice'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private Azureservice: any){
            this.checkCurrenUserLogin();
        }

        public checkCurrenUserLogin() {
            var user = Ionic.User.current();
            var OAuthId = user.get('OAuthId');
            if (OAuthId) {
                this.isLogedin = true;
            } else {
                this.isLogedin = false;
            }
        }

    }

    angular
        .module('starter.sidemenu', [])
        .controller('starter.sidemenu.SideMenuController', SideMenuController);
}