module starter.reward {

    export interface IRewardService {
        GetCurrentRewards(): ng.IPromise<GetCurrentRewardsRespond>;
    }

    export class GetCurrentRewardsRespond {
        public TicketCost: number;
        public Rewards: RewardInformation[];
    }

    export class RewardInformation {
        public ImagePath: string;
        public RemainingAmount: number;
    }
}