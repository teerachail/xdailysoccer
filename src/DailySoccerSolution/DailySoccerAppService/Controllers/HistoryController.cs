using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.Facades;

namespace DailySoccerAppService.Controllers
{
    public class HistoryController : ApiController
    {
        public ApiServices Services { get; set; }

        //GET api/History
        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpGet]
        public GetAllGuessHistoryRespond GetAllGuessHistory(string userId)
        {
            var history = new List<GuessHistoryMonthlyInformation> {
                new GuessHistoryMonthlyInformation
                {
                    Month = 2,
                    TotalPoints = 120
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 3,
                    TotalPoints = 258
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 5,
                    TotalPoints = 98
                },
                new GuessHistoryMonthlyInformation
                {
                    Month = 6,
                    TotalPoints = 179
                }
            };

            return new GetAllGuessHistoryRespond
            {
                Histories = history
            };
        }

        [HttpGet]
        public GetGuessHistoryByMonthRespond GetGuessHistoryByMonth(string userId, int year, int month)
        {

            //function จาก GetMatchesRespond GetMatches(string userId)
            var request = new GetMatchesRequest { UserId = userId };
            var result = FacadeRepository.Instance.MatchFacade.GetMatches(request, DateTime.Now);


            var history = new List<GuessHistoryDailyInformation>
            {
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 18),
                    TotalPoints = 120,
                    Matches = new List<MatchInformation>
                    {
                        new MatchInformation
                        {
                            Id = 1,
                            BeginDate = DateTime.Now,
                            LeagueName = "A",
                            StartedDate = DateTime.Now,
                            CompletedDate = DateTime.Now,
                            Status = "FT",
                            TeamHome = new TeamInformation
                            {
                                Id = 1,
                                Name = "AA",
                                CurrentScore = 5,
                                CurrentPredictionPoints = 8,
                                IsSelected = true,
                                WinningPredictionPoints = 7
                            },
                            TeamAway = new TeamInformation
                            {
                                Id = 2,
                                Name = "AB",
                                CurrentScore = 5,
                                CurrentPredictionPoints = 8,
                                IsSelected = false,
                                WinningPredictionPoints = 7
                            }
                        },

                        new MatchInformation
                        {
                            Id = 2,
                            BeginDate = DateTime.Now,
                            LeagueName = "A",
                            StartedDate = DateTime.Now,
                            CompletedDate = DateTime.Now,
                            Status = "FT",
                            TeamHome = new TeamInformation
                            {
                                Id = 3,
                                Name = "AC",
                                CurrentScore = 5,
                                CurrentPredictionPoints = 8,
                                IsSelected = false,
                                WinningPredictionPoints = 7
                            },
                            TeamAway = new TeamInformation
                            {
                                Id = 4,
                                Name = "AD",
                                CurrentScore = 4,
                                CurrentPredictionPoints = 8,
                                IsSelected = true,
                                WinningPredictionPoints = 7
                            }
                        },

                        new MatchInformation
                        {
                            Id = 3,
                            BeginDate = DateTime.Now,
                            LeagueName = "A",
                            StartedDate = DateTime.Now,
                            CompletedDate = DateTime.Now,
                            Status = "FT",
                            TeamHome = new TeamInformation
                            {
                                Id = 5,
                                Name = "AE",
                                CurrentScore = 5,
                                CurrentPredictionPoints = 8,
                                IsSelected = false,
                                WinningPredictionPoints = 7
                            },
                            TeamAway = new TeamInformation
                            {
                                Id = 6,
                                Name = "AF",
                                CurrentScore = 6,
                                CurrentPredictionPoints = 8,
                                IsSelected = true,
                                WinningPredictionPoints = 7
                            }
                        },

                        new MatchInformation
                        {
                            Id = 4,
                            BeginDate = DateTime.Now,
                            LeagueName = "A",
                            StartedDate = DateTime.Now,
                            CompletedDate = DateTime.Now,
                            Status = "FT",
                            TeamHome = new TeamInformation
                            {
                                Id = 7,
                                Name = "AG",
                                CurrentScore = 5,
                                CurrentPredictionPoints = 8,
                                IsSelected = false,
                                WinningPredictionPoints = 7
                            },
                            TeamAway = new TeamInformation
                            {
                                Id = 8,
                                Name = "AH",
                                CurrentScore = 6,
                                CurrentPredictionPoints = 8,
                                IsSelected = false,
                                WinningPredictionPoints = 7
                            }
                        }

                        //public int Id { get; set; }
                        //public DateTime BeginDate { get; set; }
                        //public string LeagueName { get; set; }
                        //public DateTime? StartedDate { get; set; }
                        //public DateTime? CompletedDate { get; set; }
                        //public string Status { get; set; }
                        //public TeamInformation TeamHome { get; set; }
                        //public TeamInformation TeamAway { get; set; }
                    }
                },
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 19),
                    TotalPoints = 150,
                    Matches = result.Matches
                },
                new GuessHistoryDailyInformation
                {
                    Day = new DateTime(2015 , 1, 20),
                    TotalPoints = 180,
                    Matches = result.Matches
                }
            };

            return new GetGuessHistoryByMonthRespond
            {
                Histories = history
            };
        }

    }
}