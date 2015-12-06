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

        public GetAllLeague(): ng.IPromise<GetAllLeagueRespond> {
            var requestUrl = "Favorite/GetAllLeagues";
            return this.queryRemoteSvc.RemoteQuery<GetAllLeagueRespond>(requestUrl);
        }

        public SetFavoriteTeam(req: SetFavoriteTeamRequest): void {
            var requestUrl = "Favorite/SetFavoriteTeam?userId=" + req.UserId + "selectedTeamId=" + req.SelectedTeamId;
            this.queryRemoteSvc.RemoteQuery<SetFavoriteTeamRequest>(requestUrl);
        }

    }
    angular
        .module('starter.account')
        .service('starter.account.AccountServices', AccountServices);
}