module starter.account {

    export interface IAccountService {
        CreateNewGuest(): ng.IPromise<CreateNewGuestRespond>;
    }

    export class AccountInformation {
        public SecrectCode: string;
        public point: number;
        public remainingGuessAmount: number;
        public currentOrderedCoupon: number;
    }

    export class CreateNewGuestRespond {
        public AccountInfo: AccountInformation;
        public IsSuccessed: Boolean;
    }

}