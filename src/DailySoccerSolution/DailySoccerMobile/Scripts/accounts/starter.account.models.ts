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
        public VerifiedPhoneNumber: string;
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

    export class RequestConfirmPhoneNumberRequest {
        public UserId: string;
        public PhoneNo: string;
    }
    export class RequestConfirmPhoneNumberRespond {
        public IsSuccessed: boolean;
        public ForPhoneNumber: string;
    }
    export class ConfirmPhoneNumberRequest {
        public UserId: string;
        public VerificationCode: string;
    }
    export class ConfirmPhoneNumberRespond {
        public IsSuccessed: boolean;
    }

}