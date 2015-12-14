module starter.shared {
    'use strict';

    export interface IAccountManagementService{
        CreateNewGuestUser(): void;
        CreateNewGuestWithFacebook(oAuthId: string): void;
        UpdateLocalStorageAccountWithFacebookData(accountInfo: starter.account.AccountInformation): void;
        LoginWithFacebook(): void;
        TieFacebook(): void;
        TieFacbookWithFacebookData(): void;
        TieFacbookWithLocalData(): void;
        TieAccoutWithNewFacebook(secretCode: string, oAuthId: string): void;

        ClearGuestData(): void;
    }

    export class AccountManagementService implements IAccountManagementService {

        public localPoint: number;
        public facebookPoint: number;
        public OAuthId: string;

        public CurrentTicketCost: number;
        public IsRequestFacebookLoginFromBuyTicket: boolean;

        static $inject = ['$location', 'starter.account.AccountServices', 'Azureservice', '$window'];
        constructor(
            private $location: ng.ILocationService,
            private accountSvc: starter.account.AccountServices,
            private Azureservice: any,
            private $window) {
        }

        public getStringData(key: string): string {
            var result = this.$window.localStorage[key] || null;
            return result;
        }

        public getNumberData(key: string): number {
            var result = this.$window.localStorage[key] || 0;
            return result;
        }

        public setData(key: string, value: string): void {
            if (value == null) this.$window.localStorage.removeItem(key);
            else this.$window.localStorage[key] = value;
        }

        public GetAccountInformation(): account.AccountInformation {
            var accountInfo = new account.AccountInformation();
            accountInfo.SecretCode = this.getStringData('SecretCode');
            accountInfo.Points = this.getNumberData('Points');
            accountInfo.OAuthId = this.getStringData('OAuthId');
            accountInfo.IsSkiped = this.getStringData('IsSkiped');
            accountInfo.VerifiedPhoneNumber = this.getStringData('VerifiedPhoneNumber');
            accountInfo.CurrentOrderedCoupon = this.getNumberData('CurrentOrderedCoupon');
            return accountInfo;
        }
        public SetAccountInformation(accountInfo: account.AccountInformation): void {
            this.setData('SecretCode', accountInfo.SecretCode);
            this.$window.localStorage['Points'] = accountInfo.Points;
            this.setData('OAuthId', accountInfo.OAuthId);
            this.setData('IsSkiped', accountInfo.IsSkiped);
            this.setData('VerifiedPhoneNumber', accountInfo.VerifiedPhoneNumber);
            this.$window.localStorage['CurrentOrderedCoupon'] = accountInfo.CurrentOrderedCoupon;
        }

        public Logout(): void {
            this.$window.localStorage['SecretCode'] = 'empty';
            this.$window.localStorage.removeItem('Points');
            this.$window.localStorage.removeItem('OAuthId');
            this.$window.localStorage.removeItem('VerifiedPhoneNumber');
            this.$window.localStorage.removeItem('CurrentOrderedCoupon');
        }

        //For test only (remove when run on production)
        public ClearGuestData(): void {
            this.$window.localStorage['SecretCode'] = 'empty';
            this.$window.localStorage.removeItem('Points');
            this.$window.localStorage.removeItem('OAuthId');
            this.$window.localStorage.removeItem('VerifiedPhoneNumber');
            this.$window.localStorage.removeItem('IsSkiped');
            this.$window.localStorage.removeItem('CurrentOrderedCoupon');
        }

        //Set phone be verified
        public SetPhoneVerified() {
            var accountInfo = this.GetAccountInformation();
            accountInfo.VerifiedPhoneNumber = 'true';
            this.SetAccountInformation(accountInfo);
        }

        
        //// Login Facebook ////
        public LoginWithFacebook(): void {
            this.Azureservice.login('facebook')
                .then((): void => {
                    var oAuthId = this.Azureservice.getCurrentUser().userId;
                    this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then((respond: starter.account.AccountInformation): void => {
                            if (respond == null) {
                                var memoryAccountInfo = this.GetAccountInformation();
                                if (memoryAccountInfo.SecretCode == null || memoryAccountInfo.SecretCode == 'empty') {
                                    // ทำการ login ด้วย facebook ที่ยังไม่เคยใช้งานระบบมาก่อน
                                    this.CreateNewGuestWithFacebook(oAuthId);
                                }
                            }
                            else {
                                // ทำการ login ด้วย facebook ที่เคยใช้งานระบบแล้ว
                                this.UpdateLocalStorageAccountWithFacebookData(respond);
                                this.$location.path('/matches/todaymatches');
                            }
                        }).catch((): void => {
                            alert('cannot connect to server');
                        });

                    console.log('Login successful');
                }, (err): void => {
                    console.error('Azure Error: ' + err);
                });
        }

        //สร้าง guestuser ใหม่
        public CreateNewGuestUser(): void {
            this.accountSvc.CreateNewGuest()
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    var memoryAccountInfo = this.GetAccountInformation();
                    memoryAccountInfo.SecretCode = respond.AccountInfo.SecretCode;
                    memoryAccountInfo.IsSkiped = 'true';
                    memoryAccountInfo.VerifiedPhoneNumber = null;
                    this.SetAccountInformation(memoryAccountInfo);

                    console.log('Create new guest complete. #UserId: ' + memoryAccountInfo.SecretCode);

                    this.$location.path('/account/favorite');
                });
        }

        //สร้างguestuserใหม่ และเชื่อมต่อfacebook 
        public CreateNewGuestWithFacebook(oAuthId: string): void {
            this.accountSvc.CreateNewGuestWithFacebook(oAuthId)
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    var memoryAccountInfo = this.GetAccountInformation();
                    memoryAccountInfo.SecretCode = respond.AccountInfo.SecretCode;
                    memoryAccountInfo.IsSkiped = 'true';
                    memoryAccountInfo.VerifiedPhoneNumber = null;
                    memoryAccountInfo.OAuthId = respond.AccountInfo.OAuthId;
                    this.SetAccountInformation(memoryAccountInfo);

                    console.log('Login with Facebook complete. #UserId: ' + memoryAccountInfo.SecretCode);

                    this.$location.path('/account/favorite');
                });
        }       

        // ดึงข้อมูลจาก facebook มาเก็บไว้ที่ storage account
        public UpdateLocalStorageAccountWithFacebookData(accountInfo: starter.account.AccountInformation): void {
            var memoryAccountInfo = this.GetAccountInformation();
            memoryAccountInfo.SecretCode = accountInfo.SecretCode;
            memoryAccountInfo.OAuthId = accountInfo.OAuthId;
            memoryAccountInfo.IsSkiped = 'true';
            memoryAccountInfo.VerifiedPhoneNumber = accountInfo.VerifiedPhoneNumber != null ? 'true' : null;
            this.SetAccountInformation(memoryAccountInfo);
        }


        //// Tie Facebook ////
        public TieFacebook(): void {
            this.Azureservice.login('facebook')
                .then((): void => {
                    var oAuthId = this.Azureservice.getCurrentUser().userId;
                    this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then((respond: starter.account.AccountInformation): void => {
                            var memoryAccountInfo = this.GetAccountInformation();
                            if (respond == null) {
                                // TODO : tie facebook ที่ยังไม่เคยใช้งานระบบมาก่อน
                                this.TieAccoutWithNewFacebook(memoryAccountInfo.SecretCode, oAuthId);
                            }
                            else {
                                // facebook ที่เคยใช้งานระบบแล้ว ให้ผู้ใช้เลือกข้อมูล
                                this.facebookPoint = respond.Points;
                                this.OAuthId = oAuthId;
                                this.accountSvc.GetAccountBySecretCode(memoryAccountInfo.SecretCode)
                                    .then((respond: starter.account.AccountInformation): void => {
                                        this.localPoint = respond.Points;
                                        this.$location.path('/account/tiefacebook');
                                    });
                            }                           
                        });

                }, (err): void => {
                    console.error('Azure Error: ' + err);
                });
        }

        public TieFacbookWithFacebookData(): void {
            var memoryAccountInfo = this.GetAccountInformation();
            this.accountSvc.TieFacbookWithFacebookData(memoryAccountInfo.SecretCode, this.OAuthId)
                .then((respond: Boolean): void => {
                    this.accountSvc.GetAccountByOAuthId(this.OAuthId)
                        .then((accountInfo: starter.account.AccountInformation): void => {
                            memoryAccountInfo.OAuthId = this.OAuthId;
                            memoryAccountInfo.VerifiedPhoneNumber = accountInfo.VerifiedPhoneNumber != null ? 'true' : null;
                            this.SetAccountInformation(memoryAccountInfo);

                            if (this.IsRequestFacebookLoginFromBuyTicket) {
                                this.IsRequestFacebookLoginFromBuyTicket = false;
                                this.$location.path('/ticket/buyticket');
                            }
                            else this.$location.path('/matches/todaymatches');
                        });
                });
        }

        public TieFacbookWithLocalData(): void {
            var memoryAccountInfo = this.GetAccountInformation();
            this.accountSvc.TieFacbookWithLocalData(memoryAccountInfo.SecretCode, this.OAuthId)
                .then((respond: Boolean): void => {
                    this.accountSvc.GetAccountByOAuthId(this.OAuthId)
                        .then((accountInfo: starter.account.AccountInformation): void => {
                            memoryAccountInfo.OAuthId = this.OAuthId;
                            memoryAccountInfo.VerifiedPhoneNumber = accountInfo.VerifiedPhoneNumber != null ? 'true' : null;
                            this.SetAccountInformation(memoryAccountInfo);
                            
                            if (this.IsRequestFacebookLoginFromBuyTicket) {
                                this.IsRequestFacebookLoginFromBuyTicket = false;
                                this.$location.path('/ticket/buyticket');
                            }
                            else this.$location.path('/matches/todaymatches');
                        });
                });
        }

        //ผูก facebook เข้ากับ guest user เดิม
        public TieAccoutWithNewFacebook(secretCode: string, oAuthId: string): void {
            this.accountSvc.UpdateAccountWithFacebook(secretCode, oAuthId)
                .then((respond: Boolean): void => {
                    if (respond) {
                        var memoryAccountInfo = this.GetAccountInformation();
                        memoryAccountInfo.OAuthId = oAuthId;
                        this.SetAccountInformation(memoryAccountInfo);
                        
                        if (this.IsRequestFacebookLoginFromBuyTicket) {
                            this.IsRequestFacebookLoginFromBuyTicket = false;
                            this.$location.path('/ticket/buyticket');
                        }
                        else this.$location.path('/matches/todaymatches');
                    }
                });
        }
    }

    angular
        .module('starter.shared')
        .service('starter.shared.AccountManagementService', AccountManagementService);
}