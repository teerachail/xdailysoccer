module starter.shared {
    'use strict';

    export interface IQueryRemoteDataService {
        RemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond>;
    }

    export class QueryRemoteDataService implements IQueryRemoteDataService {
        static $inject = ['$http'];
        constructor(protected $http: ng.IHttpService) { }

        public RemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond> {
            return this.$http.get(baseUrl)
                .then((respond: ng.IHttpPromiseCallbackArg<TRespond>): TRespond => respond.data);
        }
    }


    angular
        .module('starter.shared')
        .service('starter.shared.QueryRemoteDataService', QueryRemoteDataService);
}