using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;

namespace DailySoccerAppService.Controllers
{
    public class MatchesController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET: api/Matches
        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpPost]
        public string Post(int id)
        {
            return "Respond by POST method, your ID: " + id;
        }

        [HttpGet]
        public GetMatchesRespond GetMatches(string userId)
        {
            // HACK: Mocking GetMatches' data
            var now = DateTime.Now;
            var matchId = 1;
            var teamId = 100;
            var matches = new List<MatchInformation>
            {
                // ยังไม่แข่ง + ยังไม่เลือก
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "FC Astana",
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Atletico Madrid",
                        CurrentPredictionPoints = 3,
                    },
                },
                // ยังไม่แข่ง + เลือกแล้ว
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Real Madrid",
                        CurrentPredictionPoints = 7,
                        WinningPredictionPoints = 7,
                        IsSelected = true
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Paris Saint-Germain ",
                        CurrentPredictionPoints = 3,
                    },
                },
                // แข่งอยู่ + ยังไม่เลือก
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    Status = "15",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Shakhtar Donetsk",
                        CurrentScore = 2,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Malmo",
                        CurrentScore = 4,
                        CurrentPredictionPoints = 3,
                    },
                },
                // แข่งอยู่ + เลือกแล้ว
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    Status = "15",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Manchester United",
                        CurrentScore = 3,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "CSKA Moscow",
                        CurrentScore = 5,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 3
                    },
                },
                // แข่งอยู่ + เลือกแล้ว + คะแนนเปลี่ยน
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    Status = "15",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "PSV Eindhoven",
                        CurrentScore = 4,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "VfL Wolfsburg",
                        CurrentScore = 6,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 9
                    },
                },
                // จบแล้ว + ยังไม่เลือก
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    CompletedDate = now,
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Benfica",
                        CurrentScore = 5,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Galatasaray",
                        CurrentScore = 7,
                        CurrentPredictionPoints = 3,
                    },
                },
                // จบแล้ว + เลือกแล้ว + ทายผิด
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    CompletedDate = now,
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Borussia Monchengladbach",
                        CurrentScore = 5,
                        CurrentPredictionPoints = 7,
                        IsSelected = true,
                        WinningPredictionPoints = 0
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Juventus",
                        CurrentScore = 7,
                        CurrentPredictionPoints = 3,
                    },
                },
                // จบแล้ว + เลือกแล้ว + ทายถูก
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    CompletedDate = now,
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Sevilla FC",
                        CurrentScore = 5,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Manchester City",
                        CurrentScore = 7,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 3
                    },
                },
                // จบแล้ว + เลือกแล้ว + ทายถูกแต่เสมอ
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now,
                    StartedDate = now,
                    CompletedDate = now,
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Birmingham City",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Blackburn Rovers",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 3
                    },
                },

                // +1 Future
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now.AddDays(1),
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Future A",
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Future B",
                    },
                },
                // +2 Future
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now.AddDays(2),
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Future C",
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Future D",
                    },
                },

                // -1 Past
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now.AddDays(-1),
                    StartedDate = now.AddDays(-1),
                    CompletedDate = now.AddDays(-1),
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Past 1",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Past 2",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 3
                    },
                },
                // -2 Past
                new MatchInformation
                {
                    Id = matchId++,
                    BeginDate = now.AddDays(-2),
                    StartedDate = now.AddDays(-2),
                    CompletedDate = now.AddDays(-2),
                    Status = "FT",
                    LeagueName = "Premier League",
                    TeamHome = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Past 3",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 7,
                    },
                    TeamAway = new TeamInformation
                    {
                        Id = teamId++,
                        Name = "Past 4",
                        CurrentScore = 1,
                        CurrentPredictionPoints = 3,
                        IsSelected = true,
                        WinningPredictionPoints = 3
                    },
                },

            };

            return new GetMatchesRespond
            {
                CurrentDate = now,
                AccountInfo = new AccountInformation
                {
                    Points = 255,
                    MaximumGuessAmount = 5,
                    CurrentOrderedCoupon = 15
                },
                Matches = matches
            };
        }

        [HttpGet]
        public GuessMatchRespond GuessMatch(string userId, int matchId, bool isHome)
        {
            // HACK: Mocking GuessMatch' data
            return new GuessMatchRespond
            {
                IsSuccessed = true,
                AccountInfo = new AccountInformation(),
                Matches = Enumerable.Empty<MatchInformation>()
            };
        }
    }
}
