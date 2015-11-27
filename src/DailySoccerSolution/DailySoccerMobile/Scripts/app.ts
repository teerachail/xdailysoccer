// Ionic Starter App
declare var Ionic: any; 
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
            // this will give you a fresh user or the previously saved 'current user'
            var user = Ionic.User.current();

            // if the user doesn't have an id, you'll need to give it one.
            if (!user.id) {
                user.id = Ionic.User.anonymousId();
                user.save();
            } 
                     
            //persist the user
            
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
                templateUrl: 'templates/_fullpageTemplate.html',
                controller: 'starter.account.AccountController as accountCtrl'
            })
            .state('account.login', {
                url: '/login',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Accounts/Login.html',
                        controller: 'PlaylistsCtrl'
                    }
                }
            })

            .state('matches', {
                url: '/matches',
                abstract: true,
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
                //controller: 'AppCtrl'
            })
            .state('rewards.rewards', {
                url: '/rewards',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Rewards/Rewards.html',
                        //controller: 'PlaylistsCtrl'
                    }
                }
            })

            .state('history', {
                url: '/history',
                abstract: true,
                templateUrl: 'templates/_basicTemplate.html',
                //controller: 'AppCtrl'
            })
            .state('history.historybymonth', {
                url: '/historybymonth',
                views: {
                    'MainContent': {
                        templateUrl: 'templates/Matches/HistoryByMonth.html',
                        //controller: 'PlaylistsCtrl'
                    }
                }
            });


        // if none of the above states are matched, use this as the fallback
        //$urlRouterProvider.otherwise('/app/playlists');
        $urlRouterProvider.otherwise('/account/login');
    });
