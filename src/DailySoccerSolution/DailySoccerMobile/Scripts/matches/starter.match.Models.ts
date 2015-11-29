﻿module starter.match {

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
    }
    export class GetMatchesRequest {
        public UserId: string;
    }
    export class GetMatchesRespond {
        public CurrentDate: Date;
        public AccountInfo: account.AccountInformation;
        public Matches: MatchInformation[];
    }

}