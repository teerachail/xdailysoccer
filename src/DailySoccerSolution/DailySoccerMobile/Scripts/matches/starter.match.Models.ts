module starter.match {

    export class MatchInformation {
        public Id: number;
    }

    export interface IMatchService {
        GetMatches(req: GetMatchesRequest): ng.IPromise<GetMatchesRespond>;
    }
    export class GetMatchesRequest {
        public UserId: string;
    }
    export class GetMatchesRespond {
        public AccountInfo: account.AccountInformation;
        public Matches: MatchInformation[];
    }

}