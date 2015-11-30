module starter.account {

    export interface IAccountService {
        CreateNewGuest(): ng.IPromise<CreateNewGuestRespond>;
    }

    export class AccountInformation {
        public SecrectCode: string;
        public Point: number;
        public MaximumGuessAmount: number;
        public CurrentOrderedCoupon: number;
    }

    export class CreateNewGuestRespond {
        public AccountInfo: AccountInformation;
        public IsSuccessed: Boolean;
    }

}