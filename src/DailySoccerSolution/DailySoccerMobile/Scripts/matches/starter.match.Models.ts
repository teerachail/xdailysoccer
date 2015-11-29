module starter.match {

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

    export interface IMatchService {
        GetMatches(req: GetMatchesRequest): ng.IPromise<GetMatchesRespond>;
        GuessMatch(req: GuessMatchRequest): ng.IPromise<GuessMatchRespond>;
    }
    export class GetMatchesRequest {
        public UserId: string;
    }
    export class GetMatchesRespond {
        public CurrentDate: Date;
        public AccountInfo: account.AccountInformation;
        public Matches: MatchInformation[];
    }
    export class GuessMatchRequest {
        public UserId: string;
        public MatchId: number;
        public IsHome: boolean;
    }
    export class GuessMatchRespond {
        public AccountInfo: account.AccountInformation;
        public Matches: MatchInformation[];
        public IsSuccessed: boolean;
    }

}