﻿module starter.account {
    'use strict';

    export class AccountServices implements IAccountService {

        static $inject = ['starter.shared.QueryRemoteDataService'];
        constructor(private queryRemoteSvc: starter.shared.QueryRemoteDataService) {
        }

        public CreateNewGuest(): ng.IPromise<CreateNewGuestRespond> {
            var requestUrl = "Account/CreateNewGuest";
            return this.queryRemoteSvc.RemoteQuery<CreateNewGuestRespond>(requestUrl);
        }

        public GetAllLeague(): ng.IPromise<GetAllLeagueRespond> {
            var requestUrl = "Favorite/GetAllLeagues";
            return this.queryRemoteSvc.RemoteQuery<GetAllLeagueRespond>(requestUrl);
        }

        public SetFavoriteTeam(req: SetFavoriteTeamRequest): void {
            var requestUrl = "Favorite/SetFavoriteTeam?userId=" + req.UserId + "&selectedTeamId=" + req.SelectedTeamId;
            this.queryRemoteSvc.RemoteQuery<SetFavoriteTeamRequest>(requestUrl);
        }

        public GetAccountByOAuthId(OAuthId: string): ng.IPromise<AccountInformation> {
            var requestUrl = "Account/GetAccountByOAuthId?OAuthId=" + OAuthId;
            return this.queryRemoteSvc.RemoteQuery<AccountInformation>(requestUrl);
        }

        public CreateNewGuestWithFacebook(OAuthId: string): ng.IPromise<CreateNewGuestRespond> {
            var requestUrl = "Account/CreateNewGuestWithFacebook?OAuthId=" + OAuthId;
            return this.queryRemoteSvc.RemoteQuery<CreateNewGuestRespond>(requestUrl);
        }

        public UpdateAccoutWithFacebook(secretCode: string, OAuthId: string): ng.IPromise<Boolean> {
            var requestUrl = "Account/UpdateAccoutWithFacebook?secretCode=" + secretCode + "&OAuthId=" + OAuthId;
            return this.queryRemoteSvc.RemoteQuery<Boolean>(requestUrl);
        }

    }
    angular
        .module('starter.account')
        .service('starter.account.AccountServices', AccountServices);
}