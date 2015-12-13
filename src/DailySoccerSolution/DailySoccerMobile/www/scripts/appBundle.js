// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ionic', 'ionic.service.core', 'azure-mobile-service.module', 'starter.controllers', 'starter.shared', 'starter.account', 'starter.match', 'starter.reward', 'starter.sidemenu', 'starter.history', 'bhResponsiveImages', 'starter.ticket'])
    .constant('AzureMobileServiceClient', {
    API_URL: 'https://dailysoccer.azurewebsites.net',
    API_KEY: 'https://dailysoccerb2b9cb00dad1424394487af38c61ca1e.azurewebsites.net'
})
    .run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);
        }
        if (window.StatusBar) {
            // org.apache.cordova.statusbar required
            window.StatusBar.styleDefault();
        }
        // kick off the platform web client
        Ionic.io();
    });
})
    .config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('app', {
        url: '/app',
        abstract: true,
        templateUrl: 'templates/menu.html',
        controller: 'AppCtrl'
    })
        .state('app.search', {
        url: '/search',
        views: {
            'menuContent': {
                templateUrl: 'templates/search.html'
            }
        }
    })
        .state('app.browse', {
        url: '/browse',
        views: {
            'menuContent': {
                templateUrl: 'templates/browse.html'
            }
        }
    })
        .state('app.playlists', {
        url: '/playlists',
        views: {
            'menuContent': {
                templateUrl: 'templates/playlists.html',
                controller: 'PlaylistsCtrl'
            }
        }
    })
        .state('app.single', {
        url: '/playlists/:playlistId',
        views: {
            'menuContent': {
                templateUrl: 'templates/playlist.html',
                controller: 'PlaylistCtrl'
            }
        }
    })
        .state('account', {
        url: '/account',
        abstract: true,
        cache: false,
        templateUrl: 'templates/_fullpageTemplate.html',
        controller: 'starter.account.AccountController as accountCtrl'
    })
        .state('account.login', {
        url: '/login',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/Login.html',
            }
        }
    })
        .state('account.tiefacebook', {
        url: '/tiefacebook',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/SyncData.html',
            }
        }
    })
        .state('account.favorite', {
        url: '/favorite',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/Favorite.html',
            }
        }
    })
        .state('matches', {
        url: '/matches',
        abstract: true,
        cache: false,
        templateUrl: 'templates/_matchTemplate.html',
        controller: 'starter.match.MatchController as matchCtrl'
    })
        .state('matches.todaymatches', {
        url: '/todaymatches',
        views: {
            'MainContent': {
                templateUrl: 'templates/Matches/TodayMatches.html',
            }
        }
    })
        .state('rewards', {
        url: '/rewards',
        abstract: true,
        templateUrl: 'templates/_rewardTemplate.html',
        controller: 'starter.reward.RewardController as rewardCtrl'
    })
        .state('rewards.rewards', {
        url: '/rewards',
        views: {
            'tab-rewards': {
                templateUrl: 'templates/Rewards/Rewards.html',
            }
        }
    })
        .state('rewards.myrewards', {
        url: '/myrewards',
        views: {
            'tab-myrewards': {
                templateUrl: 'templates/Rewards/MyRewards.html',
            }
        }
    })
        .state('rewards.rewardwinner', {
        url: '/rewardwinner',
        views: {
            'tab-rewardwinner': {
                templateUrl: 'templates/Rewards/RewardWinner.html',
            }
        }
    })
        .state('history', {
        url: '/history',
        abstract: true,
        templateUrl: 'templates/_basicTemplate.html'
    })
        .state('history.historybymonth', {
        url: '/historybymonth',
        views: {
            'MainContent': {
                controller: 'starter.history.HistoryController as historyCtrl',
                templateUrl: 'templates/Matches/HistoryByMonth.html'
            }
        }
    })
        .state('history.historybyday', {
        cache: false,
        url: '/historybyday/:month/:year',
        views: {
            'MainContent': {
                templateUrl: 'templates/Matches/HistoryByDay.html'
            }
        }
    })
        .state('ticket', {
        url: '/ticket',
        abstract: true,
        templateUrl: 'templates/_basicTemplate.html',
    })
        .state('ticket.buyticket', {
        url: '/buyticket',
        views: {
            'MainContent': {
                templateUrl: 'templates/Rewards/BuyTicket.html',
                controller: 'starter.ticket.TicketController as ticketCtrl'
            }
        }
    })
        .state('ticket.buyticketprocessing', {
        url: '/buyticketprocessing',
        cache: false,
        views: {
            'MainContent': {
                templateUrl: 'templates/Rewards/BuyTicketProcessing.html',
                controller: 'starter.ticket.TicketProcessingController as sidemenuCtrl'
            }
        }
    })
        .state('ticket.verifyphonenumber', {
        url: '/verifyphonenumber',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/VerifyPhoneNumber.html',
                controller: 'starter.ticket.PhoneVerificationController as phoneVerificationCtrl'
            }
        }
    })
        .state('ticket.verifycode', {
        url: '/verifycode/:phoneNumber',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/VerifyCode.html',
                controller: 'starter.ticket.CodeVerificationController as codeVerificationCtrl'
            }
        }
    })
        .state('buyticketcompleted', {
        url: '/buyticketcompleted',
        abstract: true,
        templateUrl: 'templates/_fullpageTemplate.html',
    })
        .state('buyticketcompleted.buyticketcompleted', {
        url: '/buyticketcompleted/:expiredDate',
        views: {
            'MainContent': {
                templateUrl: 'templates/Rewards/BuyTicketCompleted.html',
                controller: 'starter.ticket.BuyTicketCompleteController as buyTicketCompleteCtrl'
            }
        }
    })
        .state('underconstruction', {
        url: '/underconstruction',
        abstract: true,
        templateUrl: 'templates/_basicTemplate.html'
    })
        .state('underconstruction.underconstruction', {
        url: '/underconstruction',
        views: {
            'MainContent': {
                templateUrl: 'templates/UnderConstruction.html',
            }
        }
    })
        .state('syncdata', {
        url: '/syncdata',
        abstract: true,
        templateUrl: 'templates/_fullpageTemplate.html',
    })
        .state('syncdata.syncdata', {
        url: '/syncdata',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/SyncData.html',
            }
        }
    });
    // if none of the above states are matched, use this as the fallback
    //$urlRouterProvider.otherwise('/app/playlists');
    $urlRouterProvider.otherwise('/account/login');
});
angular.module('starter.controllers', [])
    .controller('AppCtrl', function ($scope, $ionicModal, $timeout) {
    $scope.groups = [];
    for (var i = 0; i < 2; i++) {
        $scope.groups[i] = {
            name: i,
            items: []
        };
    }
    $scope.toggleGroup = function (group) {
        if ($scope.isGroupShown(group)) {
            $scope.shownGroup = null;
        }
        else {
            $scope.shownGroup = group;
        }
    };
    $scope.isGroupShown = function (group) {
        return $scope.shownGroup === group;
    };
    // With the new view caching in Ionic, Controllers are only called
    // when they are recreated or on app start, instead of every page change.
    // To listen for when this page is active (for example, to refresh data),
    // listen for the $ionicView.enter event:
    //$scope.$on('$ionicView.enter', function(e) {
    //});
    // Form data for the login modal
    $scope.loginData = {};
    // Create the login modal that we will use later
    $ionicModal.fromTemplateUrl('templates/login.html', {
        scope: $scope
    }).then(function (modal) {
        $scope.modal = modal;
    });
    // Triggered in the login modal to close it
    $scope.closeLogin = function () {
        $scope.modal.hide();
    };
    // Open the login modal
    $scope.login = function () {
        $scope.modal.show();
    };
    // Perform the login action when the user submits the login form
    $scope.doLogin = function () {
        console.log('Doing login', $scope.loginData);
        // Simulate a login delay. Remove this and replace with your login
        // code if using a login system
        $timeout(function () {
            $scope.closeLogin();
        }, 1000);
    };
})
    .controller('PlaylistsCtrl', function ($scope, Azureservice) {
    //var user = Ionic.User.current();
    //alert(user.get('name'));
    //Azureservice.invokeApi('Account/CreateNewGuess', {
    //        method: 'get'
    //})
    //.then(function (response) {
    //    console.log('Here is my response object');
    //    alert(response.userId)
    //}, function (err) {
    //    console.error('Azure Error: ' + err);
    //});
    $scope.playlists = [
        { title: 'Reggae', id: 1 },
        { title: 'Chill', id: 2 },
        { title: 'Dubstep', id: 3 },
        { title: 'Indie', id: 4 },
        { title: 'Rap', id: 5 },
        { title: 'Cowbell', id: 6 }
    ];
})
    .controller('PlaylistCtrl', function ($scope, $stateParams) {
});
var starter;
(function (starter) {
    var account;
    (function (account) {
        'use strict';
        var AccountController = (function () {
            function AccountController($scope, $timeout, $location, accountSvc, Azureservice, AccountManagementService, ticketSvc) {
                this.$scope = $scope;
                this.$timeout = $timeout;
                this.$location = $location;
                this.accountSvc = accountSvc;
                this.Azureservice = Azureservice;
                this.AccountManagementService = AccountManagementService;
                this.ticketSvc = ticketSvc;
                this._selectedTeamId = -1;
                //Clear local storage for test only!
                //this.AccountManagementService.ClearGuestData();
            }
            AccountController.prototype.GetAllLeague = function () {
                var _this = this;
                this.accountSvc.GetAllLeague()
                    .then(function (respond) {
                    _this.updateDisplayLeague(respond.Leagues);
                    console.log('Get all league completed.');
                });
            };
            AccountController.prototype.updateDisplayLeague = function (leagues) {
                this._allLeague = leagues;
                //Hack: Not fliter yet
                this.DisplayLeague = this._allLeague;
                console.log('# Update league completed.');
            };
            AccountController.prototype.CheckLocalStorageAccount = function () {
                var accountInfo = this.AccountManagementService.GetAccountInformation();
                var isLogedIn = accountInfo.SecretCode != null && accountInfo.SecretCode != 'empty';
                if (isLogedIn)
                    this.$location.path('/matches/todaymatches');
                this.isHideSkipButton = accountInfo.IsSkiped != null;
            };
            AccountController.prototype.SkipLogin = function () {
                // TODO: Login with guest
                this.AccountManagementService.CreateNewGuestUser();
            };
            ;
            AccountController.prototype.LoginWithFacebook = function () {
                this.AccountManagementService.LoginWithFacebook();
            };
            ;
            AccountController.prototype.TieFacbookWithFacebookData = function () {
                this.AccountManagementService.TieFacbookWithFacebookData();
            };
            AccountController.prototype.TieFacbookWithLocalData = function () {
                this.AccountManagementService.TieFacbookWithLocalData();
            };
            AccountController.prototype.SelectFavoriteTeam = function (TeamId) {
                this._selectedTeamId = TeamId;
                console.log('Set favorite team completed.');
            };
            AccountController.prototype.SetFavoriteTeam = function () {
                if (this._selectedTeamId > -1) {
                    var favoriteTeam = new account.SetFavoriteTeamRequest();
                    favoriteTeam.UserId = this.AccountManagementService.GetAccountInformation().SecretCode;
                    favoriteTeam.SelectedTeamId = this._selectedTeamId;
                    this.accountSvc.SetFavoriteTeam(favoriteTeam);
                    console.log('Send favorite team completed.');
                }
                else
                    console.log('Skip to send favorite team completed.');
                this.$location.path('/matches/todaymatches');
            };
            AccountController.prototype.ShowFacebookData = function () {
                this.facebookPoint = this.AccountManagementService.facebookPoint;
                this.localPoint = this.AccountManagementService.localPoint;
            };
            AccountController.$inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices', 'Azureservice', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices'];
            return AccountController;
        })();
        angular
            .module('starter.account', [])
            .controller('starter.account.AccountController', AccountController);
    })(account = starter.account || (starter.account = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var account;
    (function (account) {
        var AccountInformation = (function () {
            function AccountInformation() {
            }
            return AccountInformation;
        })();
        account.AccountInformation = AccountInformation;
        var CreateNewGuestRespond = (function () {
            function CreateNewGuestRespond() {
            }
            return CreateNewGuestRespond;
        })();
        account.CreateNewGuestRespond = CreateNewGuestRespond;
        var LeagueInformation = (function () {
            function LeagueInformation() {
            }
            return LeagueInformation;
        })();
        account.LeagueInformation = LeagueInformation;
        var GetAllLeagueRespond = (function () {
            function GetAllLeagueRespond() {
            }
            return GetAllLeagueRespond;
        })();
        account.GetAllLeagueRespond = GetAllLeagueRespond;
        var SetFavoriteTeamRequest = (function () {
            function SetFavoriteTeamRequest() {
            }
            return SetFavoriteTeamRequest;
        })();
        account.SetFavoriteTeamRequest = SetFavoriteTeamRequest;
    })(account = starter.account || (starter.account = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var account;
    (function (account) {
        'use strict';
        var AccountServices = (function () {
            function AccountServices(queryRemoteSvc) {
                this.queryRemoteSvc = queryRemoteSvc;
            }
            AccountServices.prototype.CreateNewGuest = function () {
                var requestUrl = "Account/CreateNewGuest";
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.GetAllLeague = function () {
                var requestUrl = "Favorite/GetAllLeagues";
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.SetFavoriteTeam = function (req) {
                var requestUrl = "Favorite/SetFavoriteTeam?userId=" + req.UserId + "&selectedTeamId=" + req.SelectedTeamId;
                this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.GetAccountBySecretCode = function (secretCode) {
                var requestUrl = "Account/GetAccountBySecretCode?secretCode=" + secretCode;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.GetAccountByOAuthId = function (OAuthId) {
                var requestUrl = "Account/GetAccountByOAuthId?OAuthId=" + OAuthId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.CreateNewGuestWithFacebook = function (OAuthId) {
                var requestUrl = "Account/CreateNewGuestWithFacebook?OAuthId=" + OAuthId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.UpdateAccountWithFacebook = function (secretCode, OAuthId) {
                var requestUrl = "Account/UpdateAccountWithFacebook?secretCode=" + secretCode + "&OAuthId=" + OAuthId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.TieFacbookWithFacebookData = function (secretCode, OAuthId) {
                var requestUrl = "Account/TieFacbookWithFacebookData?secretCode=" + secretCode + "&OAuthId=" + OAuthId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.prototype.TieFacbookWithLocalData = function (secretCode, OAuthId) {
                var requestUrl = "Account/TieFacbookWithLocalData?secretCode=" + secretCode + "&OAuthId=" + OAuthId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            AccountServices.$inject = ['starter.shared.QueryRemoteDataService'];
            return AccountServices;
        })();
        account.AccountServices = AccountServices;
        angular
            .module('starter.account')
            .service('starter.account.AccountServices', AccountServices);
    })(account = starter.account || (starter.account = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var history;
    (function (history) {
        'use strict';
        var HistoryController = (function () {
            function HistoryController($scope, historySvc, accountManagerSvc) {
                this.$scope = $scope;
                this.historySvc = historySvc;
                this.accountManagerSvc = accountManagerSvc;
            }
            HistoryController.prototype.GetHistories = function () {
                var _this = this;
                var accountInfo = this.accountManagerSvc.GetAccountInformation();
                var data = new history.GetAllGuessHistoryRequest();
                data.UserId = accountInfo.SecretCode;
                this.historySvc.GetAllGuessHistory(data)
                    .then(function (respond) {
                    _this.HistoryInfo = respond;
                    var date = new Date(respond.CurrentDate.toString());
                    _this.Year = date.getFullYear();
                    console.log('Get all history completed.');
                });
            };
            HistoryController.prototype.GetMonthString = function (month) {
                month -= 1;
                var monthString = new Date(this.Year, month);
                return monthString;
            };
            HistoryController.$inject = ['$scope', 'starter.history.HistoryServices', 'starter.shared.AccountManagementService'];
            return HistoryController;
        })();
        var HistoryDailyController = (function () {
            function HistoryDailyController($scope, $stateParams, historySvc, accountManagerSvc) {
                this.$scope = $scope;
                this.$stateParams = $stateParams;
                this.historySvc = historySvc;
                this.accountManagerSvc = accountManagerSvc;
                this.getHistoriesByMonth(this.$stateParams.month, this.$stateParams.year);
            }
            HistoryDailyController.prototype.getHistoriesByMonth = function (month, year) {
                var _this = this;
                console.log("Call getHistoriesByMonth, month: " + month + ", year: " + year);
                var accountInfo = this.accountManagerSvc.GetAccountInformation();
                var data = new history.GetGuessHistoryByMonthRequest();
                data.UserId = accountInfo.SecretCode;
                data.Month = month;
                data.Year = year;
                this.historySvc.GetGuessHistoryByMonth(data)
                    .then(function (respond) {
                    _this.HistoryByMonthInfo = respond;
                    console.log('Get all history by month completed, month: ' + month);
                });
            };
            HistoryDailyController.prototype.toggleGroup = function (group) {
                if (this.isGroupShown(group)) {
                    this.shownGroup = null;
                }
                else {
                    this.shownGroup = group;
                }
            };
            ;
            HistoryDailyController.prototype.isGroupShown = function (group) {
                return this.shownGroup == group;
            };
            ;
            HistoryDailyController.$inject = ['$scope', '$stateParams', 'starter.history.HistoryServices', 'starter.shared.AccountManagementService'];
            return HistoryDailyController;
        })();
        angular
            .module('starter.history', [])
            .controller('starter.history.HistoryController', HistoryController)
            .controller('starter.history.HistoryDailyController', HistoryDailyController);
    })(history = starter.history || (starter.history = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var history;
    (function (history) {
        var MatchInformation = (function () {
            function MatchInformation() {
            }
            return MatchInformation;
        })();
        history.MatchInformation = MatchInformation;
        var TeamInformation = (function () {
            function TeamInformation() {
            }
            return TeamInformation;
        })();
        history.TeamInformation = TeamInformation;
        var GetAllGuessHistoryRequest = (function () {
            function GetAllGuessHistoryRequest() {
            }
            return GetAllGuessHistoryRequest;
        })();
        history.GetAllGuessHistoryRequest = GetAllGuessHistoryRequest;
        var GetAllGuessHistoryRespond = (function () {
            function GetAllGuessHistoryRespond() {
            }
            return GetAllGuessHistoryRespond;
        })();
        history.GetAllGuessHistoryRespond = GetAllGuessHistoryRespond;
        var GuessHistoryMonthlyInformation = (function () {
            function GuessHistoryMonthlyInformation() {
            }
            return GuessHistoryMonthlyInformation;
        })();
        history.GuessHistoryMonthlyInformation = GuessHistoryMonthlyInformation;
        var GetGuessHistoryByMonthRequest = (function () {
            function GetGuessHistoryByMonthRequest() {
            }
            return GetGuessHistoryByMonthRequest;
        })();
        history.GetGuessHistoryByMonthRequest = GetGuessHistoryByMonthRequest;
        var GetGuessHistoryByMonthRespond = (function () {
            function GetGuessHistoryByMonthRespond() {
            }
            return GetGuessHistoryByMonthRespond;
        })();
        history.GetGuessHistoryByMonthRespond = GetGuessHistoryByMonthRespond;
        var GuessHistoryDailyInformation = (function () {
            function GuessHistoryDailyInformation() {
            }
            return GuessHistoryDailyInformation;
        })();
        history.GuessHistoryDailyInformation = GuessHistoryDailyInformation;
    })(history = starter.history || (starter.history = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var history;
    (function (history) {
        'use strict';
        var HistoryServices = (function () {
            function HistoryServices(queryRemoteSvc) {
                this.queryRemoteSvc = queryRemoteSvc;
            }
            HistoryServices.prototype.GetAllGuessHistory = function (req) {
                var requestUrl = 'History/GetAllGuessHistory?UserId=' + req.UserId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            HistoryServices.prototype.GetGuessHistoryByMonth = function (req) {
                var requestUrl = 'History/GetGuessHistoryByMonth?UserId=' + req.UserId + '&year=' + req.Year + '&month=' + req.Month;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            HistoryServices.$inject = ['starter.shared.QueryRemoteDataService'];
            return HistoryServices;
        })();
        history.HistoryServices = HistoryServices;
        angular
            .module('starter.history')
            .service('starter.history.HistoryServices', HistoryServices);
    })(history = starter.history || (starter.history = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var match;
    (function (match_1) {
        'use strict';
        var MatchController = (function () {
            function MatchController($scope, matchSvc, $location, $ionicModal, $ionicTabsDelegate, accountManagementSvc) {
                this.$scope = $scope;
                this.matchSvc = matchSvc;
                this.$location = $location;
                this.$ionicModal = $ionicModal;
                this.$ionicTabsDelegate = $ionicTabsDelegate;
                this.accountManagementSvc = accountManagementSvc;
                this.PastOneDaysDate = new Date();
                this.PastTwoDaysDate = new Date();
                this.FutureOneDaysDate = new Date();
                this.FutureTwoDaysDate = new Date();
                this.DisplayMatches = [];
                this._allMatches = [];
                this.GetTodayMatches();
                this.$ionicModal.fromTemplateUrl('templates/Matches/MatchPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { $scope.MatchPopup = modal; });
                this.$ionicModal.fromTemplateUrl('templates/Accounts/TieFacebookPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { $scope.TieFacebookPopup = modal; });
            }
            MatchController.prototype.LoginWithFacebook = function () {
                this.$scope.TieFacebookPopup.show();
            };
            MatchController.prototype.GetTodayMatches = function () {
                var _this = this;
                var accountInfo = this.accountManagementSvc.GetAccountInformation();
                var data = new match_1.GetMatchesRequest();
                data.UserId = accountInfo.SecretCode;
                this.matchSvc.GetMatches(data)
                    .then(function (respond) {
                    _this.updateAccountInformation(respond.AccountInfo);
                    _this.updateDisplayDate(respond.CurrentDate);
                    _this.updateDisplayMatches(respond.Matches);
                    _this.updateRemainingGuessAmount();
                    _this.$ionicTabsDelegate.$getByHandle('calendarTabs').select(2);
                    console.log('Get all matches completed.');
                });
            };
            MatchController.prototype.SelectTeam = function (selectedMatch, selectedTeamId) {
                var _this = this;
                var isChangingValid = this.AccountInfo.MaximumGuessAmount > this.getSelectedTodayMatches().length;
                if (!isChangingValid) {
                    if (selectedMatch.TeamHome.IsSelected != !selectedMatch.TeamAway.IsSelected) {
                        this.$scope.MatchPopup.show();
                        return;
                    }
                }
                var isSelectedTeamHome = selectedMatch.TeamHome.Id == selectedTeamId;
                var selectedTeam = isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
                var unselectedTeam = !isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
                var beforeChange = selectedTeam.IsSelected;
                selectedTeam.IsSelected = !selectedTeam.IsSelected;
                unselectedTeam.IsSelected = false;
                var accountInfo = this.accountManagementSvc.GetAccountInformation();
                var request = new match_1.GuessMatchRequest();
                request.UserId = accountInfo.SecretCode;
                request.MatchId = selectedMatch.Id;
                request.IsHome = isSelectedTeamHome;
                request.IsCancel = ((selectedTeamId == selectedTeam.Id) && (beforeChange)) ? true : false;
                this.matchSvc.GuessMatch(request)
                    .then(function (respond) {
                    _this.updateAccountInformation(respond.AccountInfo);
                    _this.updateDisplayMatches(respond.Matches);
                    _this.updateRemainingGuessAmount();
                    console.log('Send guess match completed.');
                });
                this.updateRemainingGuessAmount();
            };
            MatchController.prototype.SelectDay = function (days) {
                var _this = this;
                this.DisplayMatches = this._allMatches.filter(function (it) { return _this.dateAreEqual(it.BeginDate, days); });
                console.log('# Change display matches completed.');
            };
            MatchController.prototype.IsTodayMatch = function (match) {
                return this.dateAreEqual(match.BeginDate, this.CurrentDate);
            };
            MatchController.prototype.updateAccountInformation = function (accountInfo) {
                this.AccountInfo = accountInfo;
                var memoryAccountInfo = this.accountManagementSvc.GetAccountInformation();
                memoryAccountInfo.Points = accountInfo.Points;
                memoryAccountInfo.CurrentOrderedCoupon = accountInfo.CurrentOrderedCoupon;
                memoryAccountInfo.OAuthId = accountInfo.OAuthId;
                memoryAccountInfo.VerifiedPhoneNumber = accountInfo.VerifiedPhoneNumber;
                this.accountManagementSvc.SetAccountInformation(memoryAccountInfo);
            };
            MatchController.prototype.dateAreEqual = function (firstDate, secondDate) {
                var first = new Date(firstDate.toString());
                var second = new Date(secondDate.toString());
                return first.getDay() == second.getDay();
            };
            MatchController.prototype.updateDisplayMatches = function (matches) {
                this._allMatches = matches;
                this.SelectDay(this.CurrentDate);
                console.log('# Update matches completed.');
            };
            MatchController.prototype.updateDisplayDate = function (currentDate) {
                this.CurrentDate = currentDate;
                currentDate = new Date(currentDate.toString());
                this.PastOneDaysDate.setDate(currentDate.getDate() - 1);
                this.PastTwoDaysDate.setDate(currentDate.getDate() - 2);
                this.FutureOneDaysDate.setDate(currentDate.getDate() + 1);
                this.FutureTwoDaysDate.setDate(currentDate.getDate() + 2);
                console.log('# Update date completed.');
            };
            MatchController.prototype.updateRemainingGuessAmount = function () {
                this.RemainingGuessAmount = this.AccountInfo.MaximumGuessAmount - this.getSelectedTodayMatches().length;
                console.log('# Update remaining guess amount completed.');
            };
            MatchController.prototype.getSelectedTodayMatches = function () {
                var _this = this;
                var selectedMatchesQry = this._allMatches.filter(function (it) { return (it.TeamHome.IsSelected || it.TeamAway.IsSelected) && _this.dateAreEqual(it.BeginDate, _this.CurrentDate); });
                return selectedMatchesQry;
            };
            MatchController.$inject = ['$scope', 'starter.match.MatchServices',
                '$location', '$ionicModal',
                '$ionicTabsDelegate', 'starter.shared.AccountManagementService'];
            return MatchController;
        })();
        angular
            .module('starter.match', [])
            .controller('starter.match.MatchController', MatchController);
    })(match = starter.match || (starter.match = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var match;
    (function (match) {
        var MatchInformation = (function () {
            function MatchInformation() {
            }
            return MatchInformation;
        })();
        match.MatchInformation = MatchInformation;
        var TeamInformation = (function () {
            function TeamInformation() {
            }
            return TeamInformation;
        })();
        match.TeamInformation = TeamInformation;
        var GetMatchesRequest = (function () {
            function GetMatchesRequest() {
            }
            return GetMatchesRequest;
        })();
        match.GetMatchesRequest = GetMatchesRequest;
        var GetMatchesRespond = (function () {
            function GetMatchesRespond() {
            }
            return GetMatchesRespond;
        })();
        match.GetMatchesRespond = GetMatchesRespond;
        var GuessMatchRequest = (function () {
            function GuessMatchRequest() {
            }
            return GuessMatchRequest;
        })();
        match.GuessMatchRequest = GuessMatchRequest;
        var GuessMatchRespond = (function () {
            function GuessMatchRespond() {
            }
            return GuessMatchRespond;
        })();
        match.GuessMatchRespond = GuessMatchRespond;
    })(match = starter.match || (starter.match = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var match;
    (function (match) {
        'use strict';
        var MatchServices = (function () {
            function MatchServices(queryRemoteSvc) {
                this.queryRemoteSvc = queryRemoteSvc;
            }
            MatchServices.prototype.GetMatches = function (req) {
                var requestUrl = 'Matches/GetMatches?UserId=' + req.UserId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            MatchServices.prototype.GuessMatch = function (req) {
                var requestUrl = 'Matches/GuessMatch?userId=' + req.UserId + '&matchId=' + req.MatchId + '&isHome=' + req.IsHome + '&isCancel=' + req.IsCancel;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            MatchServices.$inject = ['starter.shared.QueryRemoteDataService'];
            return MatchServices;
        })();
        match.MatchServices = MatchServices;
        angular
            .module('starter.match')
            .service('starter.match.MatchServices', MatchServices);
    })(match = starter.match || (starter.match = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var reward;
    (function (reward) {
        var GetCurrentRewardsRespond = (function () {
            function GetCurrentRewardsRespond() {
            }
            return GetCurrentRewardsRespond;
        })();
        reward.GetCurrentRewardsRespond = GetCurrentRewardsRespond;
        var RewardInformation = (function () {
            function RewardInformation() {
            }
            return RewardInformation;
        })();
        reward.RewardInformation = RewardInformation;
        var GetCurrentWinnersRespond = (function () {
            function GetCurrentWinnersRespond() {
            }
            return GetCurrentWinnersRespond;
        })();
        reward.GetCurrentWinnersRespond = GetCurrentWinnersRespond;
        var WinnerAwardInformation = (function () {
            function WinnerAwardInformation() {
            }
            return WinnerAwardInformation;
        })();
        reward.WinnerAwardInformation = WinnerAwardInformation;
        var GetYourRewardsRequest = (function () {
            function GetYourRewardsRequest() {
            }
            return GetYourRewardsRequest;
        })();
        reward.GetYourRewardsRequest = GetYourRewardsRequest;
        var GetYourRewardsRespond = (function () {
            function GetYourRewardsRespond() {
            }
            return GetYourRewardsRespond;
        })();
        reward.GetYourRewardsRespond = GetYourRewardsRespond;
        var YourRewardInformation = (function () {
            function YourRewardInformation() {
            }
            return YourRewardInformation;
        })();
        reward.YourRewardInformation = YourRewardInformation;
    })(reward = starter.reward || (starter.reward = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var reward;
    (function (reward) {
        'use strict';
        var RewardController = (function () {
            function RewardController($scope, rewardSvc, accountManagementSvc) {
                this.$scope = $scope;
                this.rewardSvc = rewardSvc;
                this.accountManagementSvc = accountManagementSvc;
                this.GetRewards();
                this.GetWinners();
                this.updateDisplayRewards();
            }
            RewardController.prototype.GetRewards = function () {
                var _this = this;
                this.rewardSvc.GetCurrentRewards()
                    .then(function (respond) {
                    _this.RewardInfo = respond;
                    _this.accountManagementSvc.CurrentTicketCost = respond.TicketCost;
                    console.log('Get all rewards completed.');
                });
            };
            RewardController.prototype.GetWinners = function () {
                var _this = this;
                this.rewardSvc.GetCurrentWinners()
                    .then(function (respond) {
                    _this.WinnersInfo = respond;
                    console.log('Get all winners completed.');
                });
            };
            RewardController.prototype.updateDisplayRewards = function () {
                var _this = this;
                var getYourRewardsRequest = new reward.GetYourRewardsRequest();
                getYourRewardsRequest.UserId = this.accountManagementSvc.GetAccountInformation().SecretCode;
                this.rewardSvc.GetYourRewards(getYourRewardsRequest)
                    .then(function (respond) {
                    _this.ContactNo = respond.ContactNo;
                    _this.CurrentRewards = respond.CurrentRewards;
                    _this.AllRewards = respond.AllRewards;
                    console.log('# update display rewards completed.');
                });
            };
            RewardController.$inject = ['$scope', 'starter.reward.RewardServices', 'starter.shared.AccountManagementService'];
            return RewardController;
        })();
        angular
            .module('starter.reward', [])
            .controller('starter.reward.RewardController', RewardController);
    })(reward = starter.reward || (starter.reward = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var reward;
    (function (reward) {
        'use strict';
        var RewardServices = (function () {
            function RewardServices(queryRemoteSvc) {
                this.queryRemoteSvc = queryRemoteSvc;
            }
            RewardServices.prototype.GetCurrentRewards = function () {
                var requestUrl = 'Reward/GetCurrentRewards';
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            RewardServices.prototype.GetCurrentWinners = function () {
                var requestUrl = 'Reward/GetCurrentWinners';
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            RewardServices.prototype.GetYourRewards = function (req) {
                var requestUrl = 'Reward/GetYourRewards?userId=' + req.UserId;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            RewardServices.$inject = ['starter.shared.QueryRemoteDataService'];
            return RewardServices;
        })();
        reward.RewardServices = RewardServices;
        angular
            .module('starter.reward')
            .service('starter.reward.RewardServices', RewardServices);
    })(reward = starter.reward || (starter.reward = {}));
})(starter || (starter = {}));
(function () {
    'use strict';
    angular
        .module('starter.shared', []);
})();
var starter;
(function (starter) {
    var shared;
    (function (shared) {
        'use strict';
        var AccountManagementService = (function () {
            function AccountManagementService($location, accountSvc, Azureservice) {
                this.$location = $location;
                this.accountSvc = accountSvc;
                this.Azureservice = Azureservice;
            }
            AccountManagementService.prototype.GetAccountInformation = function () {
                var user = Ionic.User.current();
                var accountInfo = new starter.account.AccountInformation();
                accountInfo.SecretCode = user.id;
                accountInfo.Points = user.get('points', 0);
                accountInfo.OAuthId = user.get('OAuthId', null);
                accountInfo.IsSkiped = user.get('IsSkiped', null);
                accountInfo.VerifiedPhoneNumber = user.get('PhoneVerified', null);
                return accountInfo;
            };
            AccountManagementService.prototype.SetAccountInformation = function (accountInfo) {
                var user = Ionic.User.current();
                user.id = accountInfo.SecretCode;
                user.set('points', accountInfo.Points);
                user.set('OAuthId', accountInfo.OAuthId);
                user.set('IsSkiped', accountInfo.IsSkiped);
                user.set('PhoneVerified', accountInfo.VerifiedPhoneNumber);
                user.save(function () { console.log('saved user data'); }, function () { console.log('fail to save user data'); });
            };
            AccountManagementService.prototype.Logout = function () {
                var user = Ionic.User.current();
                user.id = 'empty';
                user.unset('OAuthId');
                user.unset('points');
                user.unset('PhoneVerified');
                user.save(function () { console.log('saved user data'); }, function () { console.log('fail to save user data'); });
            };
            //For test only (remove when run on production)
            AccountManagementService.prototype.ClearGuestData = function () {
                var user = Ionic.User.current();
                user.id = 'empty';
                user.unset('points');
                user.unset('IsSkiped');
                user.unset('PhoneVerified');
                user.unset('OAuthId');
                user.save();
            };
            //Set phone be verified
            AccountManagementService.prototype.SetPhoneVerified = function () {
                var accountInfo = this.GetAccountInformation();
                accountInfo.VerifiedPhoneNumber = 'true';
                this.SetAccountInformation(accountInfo);
            };
            //// Login Facebook ////
            AccountManagementService.prototype.LoginWithFacebook = function () {
                var _this = this;
                this.Azureservice.login('facebook')
                    .then(function () {
                    var oAuthId = _this.Azureservice.getCurrentUser().userId;
                    _this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then(function (respond) {
                        if (respond == null) {
                            var user = Ionic.User.current();
                            if (!user.id || user.id == 'empty') {
                                // ทำการ login ด้วย facebook ที่ยังไม่เคยใช้งานระบบมาก่อน
                                _this.CreateNewGuestWithFacebook(oAuthId);
                            }
                        }
                        else {
                            // ทำการ login ด้วย facebook ที่เคยใช้งานระบบแล้ว
                            _this.UpdateLocalStorageAccountWithFacebookData(respond);
                            _this.$location.path('/matches/todaymatches');
                        }
                    }).catch(function () {
                        alert('cannot connect to server');
                    });
                    console.log('Login successful');
                }, function (err) {
                    console.error('Azure Error: ' + err);
                });
            };
            //สร้าง guestuser ใหม่
            AccountManagementService.prototype.CreateNewGuestUser = function () {
                var _this = this;
                var user = Ionic.User.current();
                this.accountSvc.CreateNewGuest()
                    .then(function (respond) {
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    user.save();
                    console.log('Create new guest complete. #UserId: ' + user.id);
                    _this.$location.path('/account/favorite');
                });
            };
            //สร้างguestuserใหม่ และเชื่อมต่อfacebook 
            AccountManagementService.prototype.CreateNewGuestWithFacebook = function (oAuthId) {
                var _this = this;
                this.accountSvc.CreateNewGuestWithFacebook(oAuthId)
                    .then(function (respond) {
                    var user = Ionic.User.current();
                    user.id = respond.AccountInfo.SecretCode;
                    user.set('IsSkiped', 'true');
                    user.set('PhoneVerified', 'false');
                    user.set('OAuthId', respond.AccountInfo.OAuthId);
                    user.save();
                    console.log('Login with Facebook complete. #UserId: ' + user.id);
                    _this.$location.path('/account/favorite');
                });
            };
            // ดึงข้อมูลจาก facebook มาเก็บไว้ที่ storage account
            AccountManagementService.prototype.UpdateLocalStorageAccountWithFacebookData = function (accountInfo) {
                var user = Ionic.User.current();
                user.id = accountInfo.SecretCode;
                var PhoneVerified = accountInfo.VerifiedPhoneNumber != null;
                user.set('OAuthId', accountInfo.OAuthId);
                user.set('IsSkiped', 'true');
                user.set('PhoneVerified', PhoneVerified);
                user.save();
            };
            //// Tie Facebook ////
            AccountManagementService.prototype.TieFacebook = function () {
                var _this = this;
                this.Azureservice.login('facebook')
                    .then(function () {
                    var oAuthId = _this.Azureservice.getCurrentUser().userId;
                    _this.accountSvc.GetAccountByOAuthId(oAuthId)
                        .then(function (respond) {
                        var user = Ionic.User.current();
                        if (respond == null) {
                            // TODO : tie facebook ที่ยังไม่เคยใช้งานระบบมาก่อน
                            _this.TieAccoutWithNewFacebook(user.id, oAuthId);
                        }
                        else {
                            // facebook ที่เคยใช้งานระบบแล้ว ให้ผู้ใช้เลือกข้อมูล
                            _this.facebookPoint = respond.Points;
                            _this.OAuthId = oAuthId;
                            _this.accountSvc.GetAccountBySecretCode(user.id)
                                .then(function (respond) {
                                _this.localPoint = respond.Points;
                                _this.$location.path('/account/tiefacebook');
                            });
                        }
                    });
                }, function (err) {
                    console.error('Azure Error: ' + err);
                });
            };
            AccountManagementService.prototype.TieFacbookWithFacebookData = function () {
                var _this = this;
                var user = Ionic.User.current();
                this.accountSvc.TieFacbookWithFacebookData(user.id, this.OAuthId)
                    .then(function (respond) {
                    _this.accountSvc.GetAccountByOAuthId(_this.OAuthId)
                        .then(function (accountInfo) {
                        var PhoneVerified = accountInfo.VerifiedPhoneNumber != null;
                        user.set('OAuthId', _this.OAuthId);
                        user.set('PhoneVerified', PhoneVerified);
                        user.save();
                        _this.$location.path('/matches/todaymatches');
                    });
                });
            };
            AccountManagementService.prototype.TieFacbookWithLocalData = function () {
                var _this = this;
                var user = Ionic.User.current();
                this.accountSvc.TieFacbookWithLocalData(user.id, this.OAuthId)
                    .then(function (respond) {
                    _this.accountSvc.GetAccountByOAuthId(_this.OAuthId)
                        .then(function (accountInfo) {
                        var PhoneVerified = accountInfo.VerifiedPhoneNumber != null;
                        user.set('OAuthId', _this.OAuthId);
                        user.set('PhoneVerified', PhoneVerified);
                        user.save();
                        _this.$location.path('/matches/todaymatches');
                    });
                });
            };
            //ผูก facebook เข้ากับ guest user เดิม
            AccountManagementService.prototype.TieAccoutWithNewFacebook = function (secretCode, oAuthId) {
                var _this = this;
                this.accountSvc.UpdateAccountWithFacebook(secretCode, oAuthId)
                    .then(function (respond) {
                    if (respond) {
                        var user = Ionic.User.current();
                        user.set('OAuthId', oAuthId);
                        user.save();
                        _this.$location.path('/ticket/buyticket');
                    }
                });
            };
            AccountManagementService.$inject = ['$location', 'starter.account.AccountServices', 'Azureservice'];
            return AccountManagementService;
        })();
        shared.AccountManagementService = AccountManagementService;
        angular
            .module('starter.shared')
            .service('starter.shared.AccountManagementService', AccountManagementService);
    })(shared = starter.shared || (starter.shared = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var shared;
    (function (shared) {
        'use strict';
        var QueryRemoteDataService = (function () {
            function QueryRemoteDataService($http) {
                this.$http = $http;
                this.serviceURL = 'http://localhost:3728/api/';
            }
            QueryRemoteDataService.prototype.RemoteQuery = function (baseUrl) {
                return this.$http({ method: 'GET', url: this.serviceURL + baseUrl })
                    .then(function (respond) { return respond.data; });
            };
            QueryRemoteDataService.$inject = ['$http'];
            return QueryRemoteDataService;
        })();
        shared.QueryRemoteDataService = QueryRemoteDataService;
        var BuyTicketProcessingService = (function () {
            function BuyTicketProcessingService(accountManagementSvc) {
                this.accountManagementSvc = accountManagementSvc;
            }
            BuyTicketProcessingService.prototype.CheckVerificationFacebookAccountComplete = function () {
                var accountInfo = this.accountManagementSvc.GetAccountInformation();
                var result = accountInfo.OAuthId != null;
                return result;
            };
            BuyTicketProcessingService.prototype.CheckVerificationPhoneNumberComplete = function () {
                var accountInfo = this.accountManagementSvc.GetAccountInformation();
                var result = accountInfo.VerifiedPhoneNumber != null;
                return result;
            };
            BuyTicketProcessingService.$inject = ['starter.shared.AccountManagementService'];
            return BuyTicketProcessingService;
        })();
        shared.BuyTicketProcessingService = BuyTicketProcessingService;
        angular
            .module('starter.shared')
            .service('starter.shared.QueryRemoteDataService', QueryRemoteDataService)
            .service('starter.shared.BuyTicketProcessingService', BuyTicketProcessingService);
    })(shared = starter.shared || (starter.shared = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var sidemenu;
    (function (sidemenu) {
        'use strict';
        var SideMenuController = (function () {
            function SideMenuController($scope, $timeout, $location, $ionicModal, Azureservice, AccountManagementService) {
                this.$scope = $scope;
                this.$timeout = $timeout;
                this.$location = $location;
                this.$ionicModal = $ionicModal;
                this.Azureservice = Azureservice;
                this.AccountManagementService = AccountManagementService;
                this.$ionicModal.fromTemplateUrl('templates/Accounts/TieFacebookPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { $scope.TieFacebookPopup = modal; });
            }
            SideMenuController.prototype.LoginWithFacebookPopup = function () {
                this.$scope.TieFacebookPopup.show();
            };
            SideMenuController.prototype.LoginWithFacebook = function () {
                this.$scope.TieFacebookPopup.hide();
                this.AccountManagementService.TieFacebook();
            };
            SideMenuController.prototype.Logout = function () {
                this.AccountManagementService.Logout();
                this.$location.path('/account/login');
            };
            SideMenuController.prototype.IsLogedIn = function () {
                var accountInfo = this.AccountManagementService.GetAccountInformation();
                var isLogedIn = accountInfo.OAuthId != null;
                return isLogedIn;
            };
            SideMenuController.$inject = ['$scope', '$timeout', '$location', '$ionicModal', 'Azureservice', 'starter.shared.AccountManagementService'];
            return SideMenuController;
        })();
        angular
            .module('starter.sidemenu', [])
            .controller('starter.sidemenu.SideMenuController', SideMenuController);
    })(sidemenu = starter.sidemenu || (starter.sidemenu = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var sidemenu;
    (function (sidemenu) {
        var AccountInformation = (function () {
            function AccountInformation() {
            }
            return AccountInformation;
        })();
        sidemenu.AccountInformation = AccountInformation;
    })(sidemenu = starter.sidemenu || (starter.sidemenu = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var ticket;
    (function (ticket) {
        'use strict';
        var TicketController = (function () {
            function TicketController($scope, $stateParams, $timeout, $location, $ionicModal, ticketSvc, accountSvc, buyTicketProcessingSvc) {
                this.$scope = $scope;
                this.$stateParams = $stateParams;
                this.$timeout = $timeout;
                this.$location = $location;
                this.$ionicModal = $ionicModal;
                this.ticketSvc = ticketSvc;
                this.accountSvc = accountSvc;
                this.buyTicketProcessingSvc = buyTicketProcessingSvc;
                this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { $scope.ErrorPopup = modal; });
            }
            TicketController.prototype.CalculateBuyTicket = function () {
                var result = Math.floor(this.accountSvc.GetAccountInformation().Points / this.accountSvc.CurrentTicketCost);
                return result;
            };
            TicketController.prototype.BuyTicket = function (amount) {
                var accountInformation = this.accountSvc.GetAccountInformation();
                var MinimumAmount = 1;
                var canBuyTicket = (amount >= MinimumAmount) && (accountInformation.Points >= amount * this.accountSvc.CurrentTicketCost);
                if (!canBuyTicket) {
                    this.$scope.ErrorPopup.show();
                    return;
                }
                this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin = true;
                this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber = true;
                this.buyTicketProcessingSvc.buyAmount = amount;
                this.$location.path('/ticket/buyticketprocessing');
            };
            TicketController.$inject = ['$scope', '$stateParams', '$timeout', '$location', '$ionicModal', 'starter.ticket.TicketServices', 'starter.shared.AccountManagementService', 'starter.shared.BuyTicketProcessingService'];
            return TicketController;
        })();
        var TicketProcessingController = (function () {
            function TicketProcessingController($scope, $location, $timeout, $ionicHistory, $ionicModal, accountSvc, buyTicketProcessingSvc, ticketSvc) {
                var _this = this;
                this.$scope = $scope;
                this.$location = $location;
                this.$timeout = $timeout;
                this.$ionicHistory = $ionicHistory;
                this.$ionicModal = $ionicModal;
                this.accountSvc = accountSvc;
                this.buyTicketProcessingSvc = buyTicketProcessingSvc;
                this.ticketSvc = ticketSvc;
                this.$ionicModal.fromTemplateUrl('templates/Rewards/BuyTicketPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { _this.$scope.ErrorPopup = modal; });
                this.$ionicModal.fromTemplateUrl('templates/Accounts/TieFacebookPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) { _this.$scope.TieFacebookPopup = modal; });
                this.$scope.$on('modal.hidden', function () { return _this.BuyTicket(); });
                this.waitForPreparingPopup();
            }
            TicketProcessingController.prototype.waitForPreparingPopup = function () {
                var _this = this;
                console.log('Preparing...');
                this.$timeout(function () { return _this.BuyTicket(); }, 750);
            };
            TicketProcessingController.prototype.LoginWithFacebook = function () {
                this.$scope.TieFacebookPopup.hide();
                this.accountSvc.TieFacebook();
            };
            TicketProcessingController.prototype.BuyTicket = function () {
                var _this = this;
                var isPrepared = this.$scope.TieFacebookPopup != null && this.$scope.ErrorPopup != null;
                if (!isPrepared) {
                    console.log('Preparing...');
                    this.waitForPreparingPopup();
                    return;
                }
                var amount = this.buyTicketProcessingSvc.buyAmount;
                var accountInformation = this.accountSvc.GetAccountInformation();
                var isTieWithFacaebookAlready = accountInformation.OAuthId != null && accountInformation.SecretCode != null;
                if (!isTieWithFacaebookAlready) {
                    if (this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin) {
                        this.buyTicketProcessingSvc.isFirstTimeRequestFacaebookLogin = false;
                        this.$scope.TieFacebookPopup.show();
                    }
                    else
                        this.$ionicHistory.goBack();
                    return;
                }
                console.log('Facebook authentication verified');
                var isVerifiedPhoneNumber = accountInformation.VerifiedPhoneNumber != null;
                if (!isVerifiedPhoneNumber) {
                    if (this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber) {
                        this.buyTicketProcessingSvc.isFirstTimeRequestPhoneNumber = false;
                        this.$location.path('/ticket/verifyphonenumber');
                    }
                    else
                        this.$ionicHistory.goBack();
                    return;
                }
                console.log('Phone authentication verified');
                var request = new ticket.BuyTicketRequest();
                request.UserId = accountInformation.SecretCode;
                request.Amount = amount;
                this.ticketSvc.BuyTicket(request)
                    .then(function (respond) {
                    console.log('BuyTicket success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed) {
                        var accountInfo = _this.accountSvc.GetAccountInformation();
                        accountInfo.Points = respond.AccountInfo.Points;
                        accountInfo.CurrentOrderedCoupon = respond.AccountInfo.CurrentOrderedCoupon;
                        _this.accountSvc.SetAccountInformation(accountInfo);
                        var rewardResultDate = new Date(respond.RewardResultDate.toString());
                        _this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.RewardResultDate);
                    }
                });
            };
            TicketProcessingController.$inject = ['$scope', '$location', '$timeout', '$ionicHistory', '$ionicModal', 'starter.shared.AccountManagementService', 'starter.shared.BuyTicketProcessingService', 'starter.ticket.TicketServices'];
            return TicketProcessingController;
        })();
        var PhoneVerificationController = (function () {
            function PhoneVerificationController($scope, $location, accountManagementSvc, ticketSvc, buyTicketProcessingSvc) {
                this.$scope = $scope;
                this.$location = $location;
                this.accountManagementSvc = accountManagementSvc;
                this.ticketSvc = ticketSvc;
                this.buyTicketProcessingSvc = buyTicketProcessingSvc;
            }
            PhoneVerificationController.prototype.SendRequestVerifyPhoneNumber = function (phoneNumber) {
                var _this = this;
                console.log('Call SendRequestVerifyPhoneNumber');
                var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
                var areArgumentValid = phoneNumber != null && userId != null;
                if (!areArgumentValid)
                    return;
                console.log('Begin SendRequestVerifyPhoneNumber');
                var request = new ticket.RequestConfirmPhoneNumberRequest();
                request.UserId = userId;
                request.PhoneNo = phoneNumber;
                this.ticketSvc.RequestConfirmPhoneNumber(request)
                    .then(function (respond) {
                    console.log('#RequestConfirmPhoneNumber success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed)
                        _this.$location.path('/ticket/verifycode/' + phoneNumber);
                });
            };
            PhoneVerificationController.$inject = ['$scope', '$location', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices', 'starter.shared.BuyTicketProcessingService'];
            return PhoneVerificationController;
        })();
        var CodeVerificationController = (function () {
            function CodeVerificationController($scope, $stateParams, $location, accountManagementSvc, ticketSvc, buyTicketProcessingSvc) {
                this.$scope = $scope;
                this.$stateParams = $stateParams;
                this.$location = $location;
                this.accountManagementSvc = accountManagementSvc;
                this.ticketSvc = ticketSvc;
                this.buyTicketProcessingSvc = buyTicketProcessingSvc;
            }
            CodeVerificationController.prototype.ResendVerificationCode = function () {
                var phoneNumber = this.$stateParams.phoneNumber;
                console.log('Call Resend verification code');
                var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
                var areArgumentValid = phoneNumber != null && userId != null;
                if (!areArgumentValid)
                    return;
                var request = new ticket.RequestConfirmPhoneNumberRequest();
                request.UserId = userId;
                request.PhoneNo = phoneNumber;
                this.ticketSvc.RequestConfirmPhoneNumber(request)
                    .then(function (respond) {
                    console.log('#Resend verification code success: ' + respond.IsSuccessed);
                });
            };
            CodeVerificationController.prototype.ConfirmPhoneNumber = function (verificationCode) {
                var _this = this;
                if (verificationCode != null) {
                    var userId = this.accountManagementSvc.GetAccountInformation().SecretCode;
                    var request = new ticket.ConfirmPhoneNumberRequest();
                    request.UserId = userId;
                    request.VerificationCode = verificationCode;
                    this.ticketSvc.ConfirmPhoneNumber(request)
                        .then(function (respond) {
                        console.log('#RequestVerificationCode success: ' + respond.IsSuccessed);
                        if (respond.IsSuccessed) {
                            _this.accountManagementSvc.SetPhoneVerified();
                            _this.sentBuyTicket();
                        }
                    });
                }
            };
            CodeVerificationController.prototype.sentBuyTicket = function () {
                var _this = this;
                var accountInformation = this.accountManagementSvc.GetAccountInformation();
                var request = new ticket.BuyTicketRequest();
                request.UserId = accountInformation.SecretCode;
                request.Amount = this.buyTicketProcessingSvc.buyAmount;
                this.ticketSvc.BuyTicket(request)
                    .then(function (respond) {
                    console.log('BuyTicket success: ' + respond.IsSuccessed);
                    if (respond.IsSuccessed) {
                        _this.buyTicketProcessingSvc.buyAmount = 0;
                        var accountInfo = _this.accountManagementSvc.GetAccountInformation();
                        accountInfo.Points = respond.AccountInfo.Points;
                        accountInfo.CurrentOrderedCoupon = respond.AccountInfo.CurrentOrderedCoupon;
                        _this.accountManagementSvc.SetAccountInformation(accountInfo);
                        var rewardResultDate = new Date(respond.RewardResultDate.toString());
                        _this.$location.path('/buyticketcompleted/buyticketcompleted/' + respond.RewardResultDate);
                    }
                    else
                        _this.$location.path('/ticket/buyticketprocessing');
                });
            };
            CodeVerificationController.$inject = ['$scope', '$stateParams', '$location', 'starter.shared.AccountManagementService', 'starter.ticket.TicketServices', 'starter.shared.BuyTicketProcessingService'];
            return CodeVerificationController;
        })();
        var BuyTicketCompleteController = (function () {
            function BuyTicketCompleteController($scope, $stateParams, accountManagementSvc) {
                this.$scope = $scope;
                this.$stateParams = $stateParams;
                this.accountManagementSvc = accountManagementSvc;
            }
            BuyTicketCompleteController.$inject = ['$scope', '$stateParams', 'starter.shared.AccountManagementService'];
            return BuyTicketCompleteController;
        })();
        angular
            .module('starter.ticket', [])
            .controller('starter.ticket.TicketController', TicketController)
            .controller('starter.ticket.TicketProcessingController', TicketProcessingController)
            .controller('starter.ticket.PhoneVerificationController', PhoneVerificationController)
            .controller('starter.ticket.CodeVerificationController', CodeVerificationController)
            .controller('starter.ticket.BuyTicketCompleteController', BuyTicketCompleteController);
    })(ticket = starter.ticket || (starter.ticket = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var ticket;
    (function (ticket) {
        var BuyTicketRespond = (function () {
            function BuyTicketRespond() {
            }
            return BuyTicketRespond;
        })();
        ticket.BuyTicketRespond = BuyTicketRespond;
        var BuyTicketRequest = (function () {
            function BuyTicketRequest() {
            }
            return BuyTicketRequest;
        })();
        ticket.BuyTicketRequest = BuyTicketRequest;
        var RequestConfirmPhoneNumberRequest = (function () {
            function RequestConfirmPhoneNumberRequest() {
            }
            return RequestConfirmPhoneNumberRequest;
        })();
        ticket.RequestConfirmPhoneNumberRequest = RequestConfirmPhoneNumberRequest;
        var RequestConfirmPhoneNumberRespond = (function () {
            function RequestConfirmPhoneNumberRespond() {
            }
            return RequestConfirmPhoneNumberRespond;
        })();
        ticket.RequestConfirmPhoneNumberRespond = RequestConfirmPhoneNumberRespond;
        var ConfirmPhoneNumberRequest = (function () {
            function ConfirmPhoneNumberRequest() {
            }
            return ConfirmPhoneNumberRequest;
        })();
        ticket.ConfirmPhoneNumberRequest = ConfirmPhoneNumberRequest;
        var ConfirmPhoneNumberRespond = (function () {
            function ConfirmPhoneNumberRespond() {
            }
            return ConfirmPhoneNumberRespond;
        })();
        ticket.ConfirmPhoneNumberRespond = ConfirmPhoneNumberRespond;
    })(ticket = starter.ticket || (starter.ticket = {}));
})(starter || (starter = {}));
var starter;
(function (starter) {
    var ticket;
    (function (ticket) {
        'use strict';
        var TicketServices = (function () {
            function TicketServices(queryRemoteSvc) {
                this.queryRemoteSvc = queryRemoteSvc;
            }
            TicketServices.prototype.BuyTicket = function (req) {
                var requestUrl = "BuyTicket/BuyTicket?userId=" + req.UserId + "&amount=" + req.Amount;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            ;
            TicketServices.prototype.RequestConfirmPhoneNumber = function (request) {
                var requestUrl = "Account/RequestConfirmPhoneNumber?userId=" + request.UserId + "&phoneNo=" + request.PhoneNo;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            TicketServices.prototype.ConfirmPhoneNumber = function (request) {
                var requestUrl = "Account/ConfirmPhoneNumber?userId=" + request.UserId + "&verificationCode=" + request.VerificationCode;
                return this.queryRemoteSvc.RemoteQuery(requestUrl);
            };
            TicketServices.$inject = ['starter.shared.QueryRemoteDataService'];
            return TicketServices;
        })();
        ticket.TicketServices = TicketServices;
        angular
            .module('starter.ticket')
            .service('starter.ticket.TicketServices', TicketServices);
    })(ticket = starter.ticket || (starter.ticket = {}));
})(starter || (starter = {}));
//# sourceMappingURL=appBundle.js.map