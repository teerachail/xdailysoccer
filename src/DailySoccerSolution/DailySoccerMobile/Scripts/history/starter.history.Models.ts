module starter.history {

    export class MatchInformation {
        public Id: number;
        public BeginDate: Date;
        public LeagueName: string;
        public StartedDate: Date;
        public CompletedDate: Date;
        public Status: string;
        public TeamHome: TeamInformation;
        public TeamAway: TeamInformation;
    }

    export class TeamInformation {
        public Id: number;
        public Name: string;
        public CurrentScore: number;
        public CurrentPredictionPoints: number;
        public IsSelected: boolean;
        public WinningPredictionPoints: number;
    }

    export interface IHistoryService {
        GetAllGuessHistory(req: GetAllGuessHistoryRequest): ng.IPromise<GetAllGuessHistoryRespond>;
        GetGuessHistoryByMonth(req: GetGuessHistoryByMonthRequest): ng.IPromise<GetGuessHistoryByMonthRespond>;
    }

    export class GetAllGuessHistoryRequest {
         public UserId: string;
    }

    export class GetAllGuessHistoryRespond {
        public CurrentDate: Date;
         public Histories: GuessHistoryMonthlyInformation[];
    }

    export class GuessHistoryMonthlyInformation {
         public Month: number;
         public TotalPoints: number;
    }

    export class GetGuessHistoryByMonthRequest {
        public UserId: string;
        public Year: number;
        public Month: number;
    }

    export class GetGuessHistoryByMonthRespond {
         public Histories: GuessHistoryDailyInformation[];
    }

    export class GuessHistoryDailyInformation {
         public Day: Date;
         public TotalPoints: number;
         public Matches: MatchInformation[];
    }
}