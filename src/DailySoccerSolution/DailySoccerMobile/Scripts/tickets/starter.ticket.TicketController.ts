module starter.ticket {
    'use strict';

    class TicketController {

        static $inject = ['$scope', '$timeout', '$location', '$ionicModal'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private $ionicModal) {

            this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html',
                {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal): void { $scope.MatchPopup = modal; });

        }

        public BuyTicket(amount: number): void {

            // TODO: ตรวจสอบ account ว่าผูก Facebook แล้วหรือยัง
            // TODO: ตรวจสอบ account ว่ายืนยันเบอร์โทรศัพแล้วหรือยัง

            const MinimumAmount = 1;
            if (amount < MinimumAmount) {
                // TODO: Alert!!
            }

            // TODO: ตรวจสอบแต้มเพียงพอที่จะสั่งซื้อหรือไม่
            // TODO: ส่ง Request ในการขอซื้อ Ticket
            console.log("Buy ticket!!")
        }
    }

    angular
        .module('starter.ticket', [])
        .controller('starter.ticket.TicketController', TicketController);
}