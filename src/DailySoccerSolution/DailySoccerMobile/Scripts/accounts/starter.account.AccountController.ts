﻿module starter.account {
    'use strict';

    class AccountController {

        public isHideSkipButton: Boolean;
        public DisplayLeague: LeagueInformation[];
        private _allLeague: LeagueInformation[];
        private _selectedTeamId: number = -1;

        static $inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices','Azureservice'];
        constructor(private $scope, private $timeout: ng.ITimeoutService, private $location: ng.ILocationService, private accountSvc: starter.account.AccountServices, private Azureservice: any){
            //this.checkLocalStorageAccount();
            this.GetAllLeague();
        }


        private GetAllLeague(): void {
            this.accountSvc.GetAllLeague()
                .then((respond: GetAllLeagueRespond): void => {
                    this.updateDisplayLeague(respond.Leagues);
                    console.log('Get all league completed.');
                });
        }

        private updateDisplayLeague(leagues: LeagueInformation[]): void {
            this._allLeague = leagues;
            //Hack: Not fliter yet
            this.DisplayLeague = this._allLeague;
            console.log('# Update league completed.');
        }

        private checkLocalStorageAccount() {
            var user = Ionic.User.current();
            if (user.id && user.id != 'empty') {
                this.$location.path('/matches/todaymatches');
            } else {
                var isSkiped = user.get('isSkiped');
                if (isSkiped) {
                    this.isHideSkipButton = true;
                } 
            }
        }

       
        public SkipLogin(): void {
            // TODO: Login with guest
            this.createNewGuestUser();           
        };

        //สร้าง guestuser ใหม่
        private createNewGuestUser(OAuthId: string = null) {
            var user = Ionic.User.current();
            this.accountSvc.CreateNewGuest()
                .then((respond: CreateNewGuestRespond): void => {
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
        private createNewGuestWithFacebook(oAuthId: string) {
            this.accountSvc.CreateNewGuestWithFacebook(oAuthId)
                .then((respond: CreateNewGuestRespond): void => {
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
        private updateAccoutWithFacebook(secretCode: string, oAuthId: string) {
            this.accountSvc.UpdateAccountWithFacebook(secretCode, oAuthId)
                .then((respond: Boolean): void => {
                    if (respond)
                    {
                        var user = Ionic.User.current();
                        user.set('OAuthId', oAuthId);
                        user.save();
                        this.$location.path('/matches/todaymatches');
                    }
                });
        }

        public updateLocalStorageAccount(accountInfo: AccountInformation) {
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
                        .then((respond: AccountInformation): void => {
                            if (respond == null) {
                                var user = Ionic.User.current();
                                if (user.id && user.id != 'empty') {
                                    // TODO: userguestที่ทำการloginด้วยfacebook
                                    this.updateAccoutWithFacebook(user.id, oAuthId);
                                }
                                else {
                                    // TODO: facebook ใหม่ที่ยังไม่เคยใช้งานระบบ
                                    this.createNewGuestWithFacebook(oAuthId);
                                }
                            }
                            else {
                                // TODO: userที่มีอยู่ในระบบแล้ว
                                this.updateLocalStorageAccount(respond);
                                this.$location.path('/matches/todaymatches');
                            }
                        }).catch((): void => {
                            alert('cannot connect to server');
                        });

                    console.log('Login successful');
                }, (err): void => {
                    console.error('Azure Error: ' + err);
                });
        };

        public SelectFavoriteTeam(TeamId: number) {
            this._selectedTeamId = TeamId;
            console.log('Set favorite team completed.');
        }

        public SetFavoriteTeam() {
            var user = Ionic.User.current();
            if (this._selectedTeamId > -1) {
                var favoriteTeam = new SetFavoriteTeamRequest();
                favoriteTeam.UserId = user.id;
                favoriteTeam.SelectedTeamId = this._selectedTeamId;
                this.accountSvc.SetFavoriteTeam(favoriteTeam);
                console.log('Send favorite team completed.');
            }
            else {
                console.log('Skip to send favorite team completed.');
            }
            this.$location.path('/matches/todaymatches');
            user.set('isSetFavoriteTeam', 'true');
            user.save();
        }
    }

    angular
        .module('starter.account', [])
        .controller('starter.account.AccountController', AccountController);
}