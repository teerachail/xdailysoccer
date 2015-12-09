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

}