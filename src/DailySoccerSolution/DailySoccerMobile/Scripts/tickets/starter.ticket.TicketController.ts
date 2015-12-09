module starter.ticket {
    'use strict';

    class TicketController {

        public AccountInfo: account.AccountInformation;
        public DisplayRewardResultDate: Date;

        static $inject = ['$scope', '$timeout', '$location', '$ionicModal', 'starter.ticket.TicketServices'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private $ionicModal, private ticketSvc: starter.ticket.TicketServices) {

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
                // TODO: ตรวจสอบทศนิยมได้
                this.$scope.MatchPopup.show();
                return;
            }
            

            // TODO: ตรวจสอบแต้มเพียงพอที่จะสั่งซื้อหรือไม่


            //ส่ง Request ในการขอซื้อ Ticket
            var user = Ionic.User.current();
            var request = new BuyTicketRequest();
            request.UserId = user.id;
            request.Amount = amount;
            this.ticketSvc.BuyTicket(request)
                .then((respond: BuyTicketRespond): void => {
                    
                    if (respond.IsSuccessed) {
                        this.AccountInfo = respond.AccountInfo;
                        this.DisplayRewardResultDate = new Date(respond.RewardResultDate.toString());
                        console.log('Buy ticket completed.')
                        this.$location.path('/buyticketcompleted/buyticketcompleted');
                    }
                });
        }
    }

    angular
        .module('starter.ticket', [])
        .controller('starter.ticket.TicketController', TicketController);
}