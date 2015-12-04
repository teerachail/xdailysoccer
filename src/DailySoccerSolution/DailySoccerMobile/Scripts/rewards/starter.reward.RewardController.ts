module starter.reward {
    'use strict';

    class RewardController {

        public CurrentOrderedCoupon: number = 2940;
        public UserCoupon: number = 0;
        public RewardInfo: reward.GetCurrentRewardsRespond;

        
        static $inject = ['$scope', 'starter.reward.RewardServices', '$location', '$ionicModal'];
        constructor(private $scope,
            private rewardSvc: starter.reward.RewardServices,
            private $location: ng.ILocationService,
            private $ionicModal) {
            this.GetRewards();

            //this.$ionicModal.fromTemplateUrl('templates/Matches/MatchPopup.html',
            //    {
            //        scope: $scope,
            //        animation: 'slide-in-up'
            //    }).then(function (modal): void { $scope.MatchPopup = modal; });
        }

        public GetRewards(): void {
            this.rewardSvc.GetCurrentRewards()
                .then((respond: GetCurrentRewardsRespond): void => {
                    this.RewardInfo = respond;
                    console.log('Get all rewards completed.');
                });
        }

        //public Logout(): void {
        //    var user = Ionic.User.current();
        //    user.id = 'empty';
        //    user.save();
        //    this.$location.path('/account/login');
        //}
    }

    angular
        .module('starter.reward', [])
        .controller('starter.reward.RewardController', RewardController);
}