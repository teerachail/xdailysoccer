module starter.shared {
    'use strict';

    export interface IAccountManagementService{
        CreateNewGuestUser(): void;
        CreateNewGuestWithFacebook(oAuthId: string): void;
        UpdateAccoutWithFacebook(secretCode: string, oAuthId: string): void;
        UpdateLocalStorageAccount(accountInfo: starter.account.AccountInformation): void;
        LoginWithFacebook(): void;
        TieFacebook(): void;
        TieFacbookWithFacebookData(): void;
        TieFacbookWithLocalData(): void;

        ClearGuestData(): void;
    }

    export class AccountManagementService implements IAccountManagementService {

        public localPoint: number;
        public facebookPoint: number;

        static $inject = ['$location', 'starter.account.AccountServices', 'Azureservice'];
        constructor(
            private $location: ng.ILocationService,
            private accountSvc: starter.account.AccountServices,
            private Azureservice: any) {
        }

        //For test only (remove when run on production)
        public ClearGuestData(): void {
            var user = Ionic.User.current();
            user.id = '';
            user.unset('points');
            user.unset('IsSkiped');
            user.unset('PhoneVerified');
            user.unset('OAuthId');
            user.save();
        }

        //สร้าง guestuser ใหม่
        public CreateNewGuestUser(OAuthId: string = null) : void {
            var user = Ionic.User.current();
            this.accountSvc.CreateNewGuest()
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    if (OAuthId != null) user.set('OAuthId', OAuthId);
                    user.save();
                    console.log('Create new guest complete. #' + user.id);

                    this.$location.path('/account/favorite');
                });
        }

        //สร้างguestuserใหม่ และเชื่อมต่อfacebook 
        public CreateNewGuestWithFacebook(oAuthId: string) : void {
            this.accountSvc.CreateNewGuestWithFacebook(oAuthId)
                .then((respond: starter.account.CreateNewGuestRespond): void => {
                    var user = Ionic.User.current();
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('OAuthId', respond.AccountInfo.OAuthId);
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    user.save();
                    this.$location.path('/account/favorite');
                });
        }

        //ผูกfacebook เข้ากับ guestuser เดิม
        public UpdateAccoutWithFacebook(secretCode: string, oAuthId: string) : void {
            this.accountSvc.UpdateAccountWithFacebook(secretCode, oAuthId)
                .then((respond: Boolean): void => {
                    if (respond) {
                        var user = Ionic.User.current();
                        user.set('OAuthId', oAuthId);
                        user.save();
                        this.$location.path('/matches/todaymatches');
                    }
                });
        }

        public UpdateLocalStorageAccount(accountInfo: starter.account.AccountInformation): void {
            var user = Ionic.User.current();
            user.id = accountInfo.SecretCode;
            var PhoneVerified = accountInfo.VerifiedPhoneNumber != null
            user.set('OAuthId', accountInfo.OAuthId);
            user.set('IsSkiped', 'true');
            user.set('PhoneVerified', PhoneVerified);
            user.save();
        }

        public LoginWithFacebook(): void {
            this.Azureservice.login('facebook')
                .then((): void => {
                    var oAuthId = this.Azureservice.getCurrentUser().userId;
                    this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then((respond: starter.account.AccountInformation): void => {
                            if (respond == null) {
                                var user = Ionic.User.current();
                                if (user.id && user.id != 'empty') {
                                    // TODO: userguestที่ทำการloginด้วยfacebook
                                    this.UpdateAccoutWithFacebook(user.id, oAuthId);
                                }
                                else {
                                    // TODO: facebook ใหม่ที่ยังไม่เคยใช้งานระบบ
                                    this.CreateNewGuestWithFacebook(oAuthId);
                                }
                            }
                            else {
                                // TODO: userที่มีอยู่ในระบบแล้ว
                                this.UpdateLocalStorageAccount(respond);
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

        public TieFacebook(): void {
            this.Azureservice.login('facebook')
                .then((): void => {
                    var oAuthId = this.Azureservice.getCurrentUser().userId;
                    this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then((respond: starter.account.AccountInformation): void => {
                            var user = Ionic.User.current();
                            this.facebookPoint = respond.Points;
                            this.accountSvc.GetAccountBySecretCode(user.id)
                                .then((respond: starter.account.AccountInformation): void => {
                                    this.localPoint = respond.Points;
                                    this.$location.path('/account/tiefacebook');
                                });
                        });

                }, (err): void => {
                    console.error('Azure Error: ' + err);
                });
        }

        public TieFacbookWithFacebookData(): void {
            
        }

        public TieFacbookWithLocalData(): void {
            // TODO : TieFacbookWithLocalData
        }
    }

    angular
        .module('starter.shared')
        .service('starter.shared.IAccountManagementService', AccountManagementService);
}