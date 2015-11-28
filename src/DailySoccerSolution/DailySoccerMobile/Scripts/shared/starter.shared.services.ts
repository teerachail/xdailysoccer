module starter.shared {
    'use strict';

    export interface IQueryRemoteDataService {
        GetRemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond>;
        PostRemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond>;
    }

    export class QueryRemoteDataService implements IQueryRemoteDataService {
        static $inject = ['$http'];
        constructor(protected $http: ng.IHttpService) { }

        public GetRemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond> {
            return this.$http({ method: 'GET', url: baseUrl })
                .then((respond: ng.IHttpPromiseCallbackArg<TRespond>): TRespond => respond.data);
        }

        public PostRemoteQuery<TRespond>(baseUrl: string): ng.IPromise<TRespond> {
            return this.$http({ method: 'POST', url: baseUrl })
                .then((respond: ng.IHttpPromiseCallbackArg<TRespond>): TRespond => respond.data);
        }
    }


    angular
        .module('starter.shared')
        .service('starter.shared.QueryRemoteDataService', QueryRemoteDataService);
}