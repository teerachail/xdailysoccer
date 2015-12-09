module starter.sidemenu {

    export interface ISideMenuController {
    }

    export class AccountInformation {
        public SecretCode: string;
        public OAuthId: string;
        public Email: string;
        public Points: number;
        public MaximumGuessAmount: number;
        public CurrentOrderedCoupon: number;
    }

}