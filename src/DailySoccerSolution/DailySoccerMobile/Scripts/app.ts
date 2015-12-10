// Ionic Starter App
declare var Ionic: any;
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
                        //controller: 'PlaylistsCtrl'
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
                        //controller: 'PlaylistsCtrl'
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
                controller: 'starter.history.HistoryController as historyCtrl'
            })
            .state('history.historybymonth', {
                url: '/historybymonth',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Matches/HistoryByMonth.html',
                    }
                }
            })
            .state('history.historybyday', {
                url: '/historybyday',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Matches/HistoryByDay.html',
                    }
                }
            })

            .state('ticket', {
                url: '/ticket',
                abstract: true,
                templateUrl: 'templates/_basicTemplate.html',
                controller: 'starter.ticket.TicketController as sidemenuCtrl'
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
                url: '/buyticketcompleted/:remainingPoints/:expiredDate',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Rewards/BuyTicketCompleted.html',
                        controller: 'starter.ticket.TicketController as ticketCtrl'
                    }
                }
            })

            .state('verify', {
                url: '/verify',
                abstract: true,
                templateUrl: 'templates/_basicTemplate.html',
                controller: 'starter.account.AccountController as accountCtrl'
            })
            .state('verify.verifyphonenumber', {
                url: '/verifyphonenumber/:buyTicketAmount',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Accounts/VerifyPhoneNumber.html',
                        controller: 'starter.account.AccountController as accountCtrl'
                    }
                }
            })
            .state('verify.verifycode', {
                url: '/verifycode/:phoneNumber/:buyTicketAmount',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Accounts/VerifyCode.html',
                        controller: 'starter.account.AccountController as accountCtrl'
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
                //controller: 'AppCtrl'
            })
            .state('syncdata.syncdata', {
                url: '/syncdata',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Accounts/SyncData.html',
                    }
                }
            })

        ;


        // if none of the above states are matched, use this as the fallback
        //$urlRouterProvider.otherwise('/app/playlists');
        $urlRouterProvider.otherwise('/account/login');
    });
