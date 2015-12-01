// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ionic', 'ionic.service.core', 'starter.controllers', 'azure-mobile-service.module', 'starter.shared', 'starter.account', 'starter.match'])
    .constant('AzureMobileServiceClient', {
    API_URL: 'https://dailysoccer.azurewebsites.net'
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
        templateUrl: 'templates/_basicTemplate.html',
        controller: 'AppCtrl'
    })
        .state('history.historybymonth', {
        url: '/historybymonth',
        views: {
            'MainContent': {
                templateUrl: 'templates/Matches/HistoryByMonth.html',
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
            }
        }
    })
        .state('buyticketcompleted', {
        url: '/buyticketcompleted',
        abstract: true,
        templateUrl: 'templates/_fullpageTemplate.html',
    })
        .state('buyticketcompleted.buyticketcompleted', {
        url: '/buyticketcompleted',
        views: {
            'MainContent': {
                templateUrl: 'templates/Rewards/BuyTicketCompleted.html',
            }
        }
    })
        .state('verify', {
        url: '/verify',
        abstract: true,
        templateUrl: 'templates/_basicTemplate.html',
    })
        .state('verify.verifyphonenumber', {
        url: '/verifyphonenumber',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/VerifyPhoneNumber.html',
            }
        }
    })
        .state('verify.verifycode', {
        url: '/verifycode',
        views: {
            'MainContent': {
                templateUrl: 'templates/Accounts/VerifyCode.html',
            }
        }
    });
    // if none of the above states are matched, use this as the fallback
    //$urlRouterProvider.otherwise('/app/playlists');
    $urlRouterProvider.otherwise('/account/login');
});
angular.module('starter.controllers', [])
    .controller('AppCtrl', function ($scope, $ionicModal, $timeout) {
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
            function AccountController($scope, $timeout, $location, accountSvc) {
                this.$scope = $scope;
                this.$timeout = $timeout;
                this.$location = $location;
                this.accountSvc = accountSvc;
                this.checkIonicUserData();
            }
            AccountController.prototype.checkIonicUserData = function () {
                var user = Ionic.User.current();
                if (user.id && user.id != 'empty') {
                    this.$location.path('/matches/todaymatches');
                }
                else {
                    var isSkiped = user.get('isSkiped');
                    if (isSkiped) {
                        this.isHideSkipButton = true;
                    }
                }
            };
            AccountController.prototype.createIonicUserData = function () {
                var _this = this;
                var user = Ionic.User.current();
                this.accountSvc.CreateNewGuest()
                    .then(function (respond) {
                    user.id = respond.AccountInfo.SecrectCode;
                    user.set('isSkiped', 'true');
                    user.save();
                    console.log('Create new guest complete.');
                    _this.$location.path('/matches/todaymatches');
                });
            };
            AccountController.prototype.SkipLogin = function () {
                // TODO: Login with guest
                this.createIonicUserData();
            };
            ;
            AccountController.prototype.LoginWithFacebook = function () {
                // TODO: Login with facebook
                this.createIonicUserData();
            };
            ;
            AccountController.$inject = ['$scope', '$timeout', '$location', 'starter.account.AccountServices'];
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
    var match;
    (function (match) {
        'use strict';
        var MatchController = (function () {
            function MatchController($scope, matchSvc, $location, $ionicModal) {
                this.$scope = $scope;
                this.matchSvc = matchSvc;
                this.$location = $location;
                this.$ionicModal = $ionicModal;
                this.Matches = [];
                this.GetTodayMatches();
                this.$ionicModal.fromTemplateUrl('templates/Matches/MatchPopup.html', {
                    scope: $scope,
                    animation: 'slide-in-up'
                }).then(function (modal) {
                    $scope.MatchPopup = modal;
                });
            }
            MatchController.prototype.GetTodayMatches = function () {
                var _this = this;
                var user = Ionic.User.current();
                var data = new match.GetMatchesRequest();
                data.UserId = user.id;
                this.matchSvc.GetMatches(data)
                    .then(function (respond) {
                    _this.Matches = respond.Matches;
                    _this.AccountInfo = respond.AccountInfo;
                    console.log('Get all matches completed.');
                });
            };
            MatchController.prototype.Logout = function () {
                var user = Ionic.User.current();
                user.id = 'empty';
                user.save();
                this.$location.path('/account/login');
            };
            MatchController.prototype.SelectTeam = function (selectedMatch, selectedTeamId) {
                var _this = this;
                var isSelectedTeamHome = selectedMatch.TeamHome.Id == selectedTeamId;
                var selectedTeam = isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
                var unselectedTeam = !isSelectedTeamHome ? selectedMatch.TeamHome : selectedMatch.TeamAway;
                selectedTeam.IsSelected = !selectedTeam.IsSelected;
                unselectedTeam.IsSelected = false;
                var request = new match.GuessMatchRequest();
                request.UserId = Ionic.User.current().id;
                request.MatchId = selectedMatch.Id;
                request.IsHome = isSelectedTeamHome;
                this.matchSvc.GuessMatch(request)
                    .then(function (respond) {
                    _this.Matches = respond.Matches;
                    _this.AccountInfo = respond.AccountInfo;
                    console.log('Send guess match completed.');
                });
            };
            MatchController.$inject = ['$scope', 'starter.match.MatchServices', '$location', '$ionicModal'];
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
                var requestUrl = 'Matches/GuessMatch?userId=' + req.UserId + '&matchId=' + req.MatchId + '&isHome=' + req.IsHome;
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
        angular
            .module('starter.shared')
            .service('starter.shared.QueryRemoteDataService', QueryRemoteDataService);
    })(shared = starter.shared || (starter.shared = {}));
})(starter || (starter = {}));
//# sourceMappingURL=appBundle.js.map