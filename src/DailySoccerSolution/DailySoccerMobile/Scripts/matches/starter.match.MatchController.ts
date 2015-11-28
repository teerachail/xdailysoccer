module starter.match {
    'use strict';

    class MatchController {

        static $inject = ['$scope', 'starter.match.MatchServices', '$location', '$ionicModal'];
        constructor(private $scope, private matchSvc: starter.match.MatchServices, private $location: ng.ILocationService, private $ionicModal) {

            $ionicModal.fromTemplateUrl('templates/Matches/modal.html', {
                scope: $scope
            }).then(function (modal) {
                $scope.modal = modal;
                });

            $scope.openModal = function () {
                $scope.modal.show();
            };
        }


        public GetTodayMatches(): void {
            this.matchSvc.GetToDayMatches(null)
                .then((respond: GetToDayMatchesRespond): void => {
                    // TODO: GetTodayMatches
                });
        }

        public Logout(): void {
            var user = Ionic.User.current();
            user.id = '';

            this.$location.path('/account/login');
        }

    }

    angular
        .module('starter.match', [])
        .controller('starter.match.MatchController', MatchController);
}