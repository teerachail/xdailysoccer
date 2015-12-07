module starter.reward {

    export interface IRewardService {
        GetCurrentRewards(): ng.IPromise<GetCurrentRewardsRespond>;
        GetCurrentWinners(): ng.IPromise<GetCurrentWinnersRespond>;
    }

    export class GetCurrentRewardsRespond {
        public TicketCost: number;
        public Rewards: RewardInformation[];
    }

    export class RewardInformation {
        public ImagePath: string;
        public RemainingAmount: number;
    }

    export class GetCurrentWinnersRespond {
        public Winners: WinnerAwardInformation[];
    }
    
    export class WinnerAwardInformation {
        public Ordering: number;
        public Description: string;
        public ImagePath: string;
        public Winners: string[];
    }

    export class GetYourRewardsRequest {
        public UserId: string;
    }

    export class GetYourRewardsRespond {
        public ContactNo: string;
        public CurrentRewards: YourRewardInformation[];
        public AllRewards: YourRewardInformation[];
    }

    export class YourRewardInformation {
        public Description: string;
        public ImagePath: string;
        public ExpiredDate: Date;
        public Ordering: number;
        public ReferenceCode: string;
    }
}