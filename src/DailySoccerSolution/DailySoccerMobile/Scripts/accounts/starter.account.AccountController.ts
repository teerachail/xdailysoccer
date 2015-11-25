angular
    .module('starter.account', [])
    .controller('AccountCtrl', function ($scope, $location, $timeout) {

        $scope.skipLogin = function (): void {
            // TODO: Login with guest
            console.log('Doing Register new guest account');
            $timeout(function () {
                $location.path('/matches/todaymatches')
            }, 1000);
        };

        $scope.loginWithFacebook = function (): void {
            // TODO: Login with facebook
            console.log('Doing connecting to facebook');
            $timeout(function () {
                $location.path('/matches/todaymatches')
            }, 1000);
        };

    });