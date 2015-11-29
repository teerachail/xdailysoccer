module starter.match {

    export class MatchInformation {
        public id: number;
        public beginDate: Date;
        public leagueName: string;
        public startedDate: Date;
        public completedDate: Date;
        public status: string;
        public teamHome: TeamInformation;
        public teamAway: TeamInformation;
    }

    export class TeamInformation {
        public id: number;
        public name: string;
        public currentScore: number;
        public currentPredictionPoints: number;
        public isSelected: boolean;
        public winningPredictionPoints: number;
    }

    export interface IMatchService {
        GetMatches(req: GetMatchesRequest): ng.IPromise<GetMatchesRespond>;
    }
    export class GetMatchesRequest {
        public UserId: string;
    }
    export class GetMatchesRespond {
        public currentDate: Date;
        public accountInfo: account.AccountInformation;
        public matches: MatchInformation[];
    }

}