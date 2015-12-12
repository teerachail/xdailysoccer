module starter.history {
    'use strict';

    class HistoryController {
        
        public HistoryInfo: history.GetAllGuessHistoryRespond;
        public shownGroup: GuessHistoryDailyInformation[];
        public Year: number;

        static $inject = ['$scope', 'starter.history.HistoryServices', 'starter.shared.AccountManagementService'];
        constructor(private $scope,
            private historySvc: starter.history.HistoryServices,
            private accountManagerSvc: shared.AccountManagementService) {
        }

        public GetHistories(): void {
            var accountInfo = this.accountManagerSvc.GetAccountInformation();
            var data = new GetAllGuessHistoryRequest();
            data.UserId = accountInfo.SecretCode;
            this.historySvc.GetAllGuessHistory(data)
                .then((respond: GetAllGuessHistoryRespond): void => {
                    this.HistoryInfo = respond;
                    var date = new Date(respond.CurrentDate.toString());
                    this.Year = date.getFullYear();
                    console.log('Get all history completed.');
                });
        }

        public GetMonthString(month: number): Date {
            month -= 1;
            var monthString = new Date(this.Year, month);
            return monthString;
        }
    }

    class HistoryDailyController {

        public HistoryByMonthInfo: history.GetGuessHistoryByMonthRespond;
        public shownGroup: GuessHistoryDailyInformation[];

        static $inject = ['$scope', '$stateParams', 'starter.history.HistoryServices', 'starter.shared.AccountManagementService'];
        constructor(private $scope,
            private $stateParams,
            private historySvc: starter.history.HistoryServices,
            private accountManagerSvc: shared.AccountManagementService) {

            this.getHistoriesByMonth(this.$stateParams.month, this.$stateParams.year);
        }

        private getHistoriesByMonth(month: number, year: number): void {
            console.log("Call getHistoriesByMonth, month: " + month + ", year: " + year);
            var accountInfo = this.accountManagerSvc.GetAccountInformation();
            var data = new GetGuessHistoryByMonthRequest();
            data.UserId = accountInfo.SecretCode;
            data.Month = month;
            data.Year = year;
            this.historySvc.GetGuessHistoryByMonth(data)
                .then((respond: GetGuessHistoryByMonthRespond): void => {
                    this.HistoryByMonthInfo = respond;
                    console.log('Get all history by month completed, month: ' + month);
                });
        }

        public toggleGroup(group: GuessHistoryDailyInformation[]): void {
            if (this.isGroupShown(group)) {
                this.shownGroup = null;
            } else {
                this.shownGroup = group;
            }
        };


        public isGroupShown(group: GuessHistoryDailyInformation[]): boolean {
            return this.shownGroup == group;
        };
    }

    angular
        .module('starter.history', [])
        .controller('starter.history.HistoryController', HistoryController)
        .controller('starter.history.HistoryDailyController', HistoryDailyController);
}