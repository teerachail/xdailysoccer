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
        public CurrentPoints: number;
        public CurrentOrderedCoupon: number;
        public CurrentTicketCost: number;
        public OAuthId: string;

        static $inject = ['$location', 'starter.account.AccountServices', 'Azureservice'];
        constructor(
            private $location: ng.ILocationService,
            private accountSvc: starter.account.AccountServices,
            private Azureservice: any) {
        }

        public GetAccountInformation(): account.AccountInformation {
            var user = Ionic.User.current();
            var accountInfo = new account.AccountInformation();
            accountInfo.SecretCode = user.id;
            accountInfo.Points = user.get('points');
            accountInfo.OAuthId = user.get('OAuthId');
            accountInfo.IsSkiped = user.get('IsSkiped');
            accountInfo.VerifiedPhoneNumber = user.get('PhoneVerified');
            return accountInfo;
        }

        public SetAccountInformation(accountInfo: account.AccountInformation): void {
            var user = Ionic.User.current();
            user.id = accountInfo.SecretCode;
            user.set('points', accountInfo.Points);
            user.set('OAuthId', accountInfo.OAuthId);
            user.set('IsSkiped', accountInfo.IsSkiped);
            user.set('PhoneVerified', accountInfo.VerifiedPhoneNumber);
            user.save();
        }

        public Logout(): void {
            var user = Ionic.User.current();
            user.id = 'empty';
            user.unset('OAuthId');
            user.unset('points');
            user.unset('PhoneVerified');
            user.save();
        }

        //For test only (remove when run on production)
        public ClearGuestData(): void {
            var user = Ionic.User.current();
            user.id = 'empty';
            user.unset('points');
            user.unset('IsSkiped');
            user.unset('PhoneVerified');
            user.unset('OAuthId');
            user.save();
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
                                var user = Ionic.User.current();
                                if (!user.id || user.id == 'empty') {
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
            var user = Ionic.User.current();
            this.accountSvc.CreateNewGuest()
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    user.save();

                    console.log('Create new guest complete. #UserId: ' + user.id);

                    this.$location.path('/account/favorite');
                });
        }

        //สร้างguestuserใหม่ และเชื่อมต่อfacebook 
        public CreateNewGuestWithFacebook(oAuthId: string): void {
            this.accountSvc.CreateNewGuestWithFacebook(oAuthId)
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    var user = Ionic.User.current();
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    user.set('OAuthId', respond.AccountInfo.OAuthId);
                    user.save();

                    console.log('Login with Facebook complete. #UserId: ' + user.id);

                    this.$location.path('/account/favorite');
                });
        }       

        // ดึงข้อมูลจาก facebook มาเก็บไว้ที่ storage account
        public UpdateLocalStorageAccountWithFacebookData(accountInfo: starter.account.AccountInformation): void {
            var user = Ionic.User.current();
            user.id = accountInfo.SecretCode;
            var PhoneVerified = accountInfo.VerifiedPhoneNumber != null
            user.set('OAuthId', accountInfo.OAuthId);
            user.set('IsSkiped', 'true');
            user.set('PhoneVerified', PhoneVerified);
            user.save();
        }


        //// Tie Facebook ////
        public TieFacebook(): void {
            this.Azureservice.login('facebook')
                .then((): void => {
                    var oAuthId = this.Azureservice.getCurrentUser().userId;
                    this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then((respond: starter.account.AccountInformation): void => {
                            var user = Ionic.User.current();
                            if (respond == null) {
                                // TODO : tie facebook ที่ยังไม่เคยใช้งานระบบมาก่อน
                                this.TieAccoutWithNewFacebook(user.id, oAuthId);
                            }
                            else {
                                // facebook ที่เคยใช้งานระบบแล้ว ให้ผู้ใช้เลือกข้อมูล
                                this.facebookPoint = respond.Points;
                                this.OAuthId = oAuthId;
                                this.accountSvc.GetAccountBySecretCode(user.id)
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
            var user = Ionic.User.current();
            this.accountSvc.TieFacbookWithFacebookData(user.id, this.OAuthId)
                .then((respond: Boolean): void => {
                    this.accountSvc.GetAccountByOAuthId(this.OAuthId)
                        .then((accountInfo: starter.account.AccountInformation): void => {
                            var PhoneVerified = accountInfo.VerifiedPhoneNumber != null
                            user.set('OAuthId', this.OAuthId);
                            user.set('PhoneVerified', PhoneVerified);
                            user.save();
                            this.$location.path('/matches/todaymatches');
                        });
                });
        }

        public TieFacbookWithLocalData(): void {
            var user = Ionic.User.current();
            this.accountSvc.TieFacbookWithLocalData(user.id, this.OAuthId)
                .then((respond: Boolean): void => {
                    this.accountSvc.GetAccountByOAuthId(this.OAuthId)
                        .then((accountInfo: starter.account.AccountInformation): void => {
                            var PhoneVerified = accountInfo.VerifiedPhoneNumber != null
                            user.set('OAuthId', this.OAuthId);
                            user.set('PhoneVerified', PhoneVerified);
                            user.save();
                            this.$location.path('/matches/todaymatches');
                        });
                });
        }

        //ผูก facebook เข้ากับ guest user เดิม
        public TieAccoutWithNewFacebook(secretCode: string, oAuthId: string): void {
            this.accountSvc.UpdateAccountWithFacebook(secretCode, oAuthId)
                .then((respond: Boolean): void => {
                    if (respond) {
                        var user = Ionic.User.current();
                        user.set('OAuthId', oAuthId);
                        user.save();
                        this.$location.path('/ticket/buyticket');
                    }
                });
        }
    }

    angular
        .module('starter.shared')
        .service('starter.shared.AccountManagementService', AccountManagementService);
}