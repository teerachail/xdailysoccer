module starter.ticket {
    
    export class BuyTicketRespond {
        public AccountInfo: account.AccountInformation;
        public IsSuccessed: boolean;
        public RewardResultDate: Date;
    }
        
    export class BuyTicketRequest {
        public UserId: string;
        public Amount: number;
    }

    export interface ITicketService {
        BuyTicket(request: BuyTicketRequest): ng.IPromise<BuyTicketRespond>;
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