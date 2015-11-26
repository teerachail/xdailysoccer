module starter.match {

    export class MatchInformation {
        public Id: number;
    }

    export interface IMatchService {
        GetToDayMatches(req: GetToDayMatchesRequest): ng.IPromise<GetToDayMatchesRespond>;
    }
    export class GetToDayMatchesRequest {
        public UserId: string;
    }
    export class GetToDayMatchesRespond {
        public AccountInfo: account.AccountInformation;
        public Matches: MatchInformation[];
    }

}