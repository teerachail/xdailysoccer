﻿module starter.history {
    'use strict';

    class HistoryController {
        
        public HistoryInfo: history.GetAllGuessHistoryRespond;
        public HistoryByMonthInfo: history.GetGuessHistoryByMonthRespond;
        public shownGroup: GuessHistoryDailyInformation[];
        public Year: number = 2015;


        static $inject = ['$scope', 'starter.history.HistoryServices'];
        constructor(private $scope,
            private historySvc: starter.history.HistoryServices) {
            this.GetHistories();
        }

        public GetHistories(): void {
            var user = Ionic.User.current();
            var data = new GetAllGuessHistoryRequest();
            data.UserId = user.id;
            this.historySvc.GetAllGuessHistory(data)
                .then((respond: GetAllGuessHistoryRespond): void => {
                    this.HistoryInfo = respond;
                    console.log('Get all history completed.');
                });
        }

        public GetHistoriesByMonth(month: number): void {
            var user = Ionic.User.current();
            var data = new GetGuessHistoryByMonthRequest();
            data.UserId = user.id;
            data.Year = this.Year;
            data.Month = month;
            this.historySvc.GetGuessHistoryByMonth(data)
                .then((respond: GetGuessHistoryByMonthRespond): void => {
                    this.HistoryByMonthInfo = respond;
                    console.log('Get all history by month completed.');
                    console.log(month);
                });
        }

        public GetMonthString(month: number): Date {
            var monthString = new Date(this.Year, month);
            return monthString;
        }

        public toggleGroup(group: GuessHistoryDailyInformation[]): void {
            if (this.isGroupShown(group)) {
                this.shownGroup = null;
            } else {
                this.shownGroup = group;
            }
        };


        public isGroupShown(group: GuessHistoryDailyInformation[]): boolean {
            console.log(this.shownGroup == group);
            return this.shownGroup == group;
        };
    }

    angular
        .module('starter.history', [])
        .controller('starter.history.HistoryController', HistoryController);
}