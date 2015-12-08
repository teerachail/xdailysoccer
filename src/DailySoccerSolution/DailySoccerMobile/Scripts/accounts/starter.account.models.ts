module starter.account {

    export interface IAccountService {
        CreateNewGuest(): ng.IPromise<CreateNewGuestRespond>;
    }

    export class AccountInformation {
        public SecretCode: string;
        public OAuthId: string;
        public Email: string;
        public Points: number;
        public MaximumGuessAmount: number;
        public CurrentOrderedCoupon: number;
    }

    export class CreateNewGuestRespond {
        public AccountInfo: AccountInformation;
        public IsSuccessed: Boolean;
    }

    export class LeagueInformation {
        public LeagueName: string;
        public TeamName: string;
        public TeamId: number;
    }

    export class GetAllLeagueRespond {
        public Leagues: LeagueInformation[];
    }

    export class SetFavoriteTeamRequest {
        public UserId: string;
        public SelectedTeamId: number;
    }

}