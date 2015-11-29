module starter.account {
    'use strict';

    export class AccountServices implements IAccountService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public CreateNewGuest(): ng.IPromise<CreateNewGuestRespond> {
            var requestUrl = "Account/CreateNewGuest";
            return this.queryRemoteSvc.RemoteQuery<CreateNewGuestRespond>(requestUrl);
        }

    }
    angular
        .module('starter.account')
        .service('starter.account.AccountServices', AccountServices);
}