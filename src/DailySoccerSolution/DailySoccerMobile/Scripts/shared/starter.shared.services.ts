module starter.shared {
    'use strict';

    export interface IQueryRemoteDataService {
        RemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond>;
    }

    export class QueryRemoteDataService implements IQueryRemoteDataService {
        private serviceURL = 'https://dailysoccer.azurewebsites.net/api/'
        static $inject = ['$http'];
        constructor(protected $http: ng.IHttpService) { }

        public RemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond> {
            return this.$http({ method: 'GET', url: this.serviceURL + baseUrl })
                .then((respond: ng.IHttpPromiseCallbackArg<TRespond>): TRespond => respond.data);
        }
    }

    export class BuyTicketProcessingService {
        public isFirstTimeRequestFacaebookLogin: boolean;
        public isFirstTimeRequestPhoneNumber: boolean;
        public buyAmount: number;

        static $inject = ['starter.shared.AccountManagementService'];
        constructor(private accountManagementSvc: starter.shared.AccountManagementService) { }

        public CheckVerificationFacebookAccountComplete(): boolean {
            var accountInfo = this.accountManagementSvc.GetAccountInformation();
            var result = accountInfo.OAuthId != null;
            return result;
        }

        public CheckVerificationPhoneNumberComplete(): boolean {
            var accountInfo = this.accountManagementSvc.GetAccountInformation();
            var result = accountInfo.VerifiedPhoneNumber != null;
            return result;
        }
    }

    angular
        .module('starter.shared')
        .service('starter.shared.QueryRemoteDataService', QueryRemoteDataService)
        .service('starter.shared.BuyTicketProcessingService', BuyTicketProcessingService);
}