Feature: GetAllGuessHistory
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'

@mock
Scenario: ผู้ใช้ที่ไม่เคยทายผลขอข้อมูลการทายผลทั้งหมด (ไม่มีข้อมูลแมช์) ระบบส่งรายการทายผลเปล่ากลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName | BeginDate | StartedDate | CompletedDate |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |

@mock
Scenario: ผู้ใช้ที่ไม่เคยทายผลขอข้อมูลการทายผลทั้งหมด (มีข้อมูลแมช์) ระบบส่งรายการทายผลเปล่ากลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |

@mock
Scenario: ผู้ใช้ที่เคยทายผลไว้บางเดือนขอข้อมูลการทายผลทั้งหมด (ปีเดียวกันและเดือนเดียว) ระบบส่งรายการทายผลทั้งหมดของปีปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.CurrentScore | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name    | TeamHome.CurrentScore | TeamAway.WinningPredictionPoints |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 0                     | 10                               | 2           | Hull City        | 1                     | 5                                |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City | 1                     | 10                               | 4           | Blackburn Rovers | 0                     | 5                                |
	| 3  | Premier league | 1/3/2015 01:00 | 1/3/2015 01:00 | 1/3/2015 02:30 | 5           | FC Astana       | 0                     | 7                                | 6           | Atletico Madrid  | 0                     | 5                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 2       | 2           |
	| 3  | s01                | 3       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |
	| 1     | 13          |

@mock
Scenario: ผู้ใช้ที่เคยทายผลไว้บางเดือนขอข้อมูลการทายผลทั้งหมด (ปีเดียวกันและต่างเดือนกัน) ระบบส่งรายการทายผลทั้งหมดของปีปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate       | StartedDate     | CompletedDate   | TeamHome.Id | TeamHome.Name   | TeamHome.CurrentScore | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name    | TeamHome.CurrentScore | TeamAway.WinningPredictionPoints |
	| 1  | Premier league | 1/1/2015 01:00  | 1/1/2015 01:00  | 1/1/2015 02:30  | 1           | Brentford       | 0                     | 10                               | 2           | Hull City        | 1                     | 5                                |
	| 2  | Premier league | 1/2/2015 01:00  | 1/2/2015 01:00  | 1/2/2015 02:30  | 3           | Birmingham City | 1                     | 10                               | 4           | Blackburn Rovers | 0                     | 5                                |
	| 3  | Premier league | 10/3/2015 01:00 | 10/3/2015 01:00 | 10/3/2015 02:30 | 5           | FC Astana       | 0                     | 7                                | 6           | Atletico Madrid  | 0                     | 5                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 2       | 2           |
	| 3  | s01                | 3       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |
	| 1     | 10          |
	| 10    | 3           |

@mock
Scenario: ผู้ใช้ที่เคยทายผลไว้บางเดือนขอข้อมูลการทายผลทั้งหมด (ต่างปีกันและต่างเดือนกัน) ระบบส่งรายการทายผลทั้งหมดของปีปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate       | StartedDate     | CompletedDate   | TeamHome.Id | TeamHome.Name   | TeamHome.CurrentScore | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name    | TeamHome.CurrentScore | TeamAway.WinningPredictionPoints |
	| 1  | Premier league | 1/1/2015 01:00  | 1/1/2015 01:00  | 1/1/2015 02:30  | 1           | Brentford       | 0                     | 10                               | 2           | Hull City        | 1                     | 5                                |
	| 2  | Premier league | 1/2/2015 01:00  | 1/2/2015 01:00  | 1/2/2015 02:30  | 3           | Birmingham City | 1                     | 10                               | 4           | Blackburn Rovers | 0                     | 5                                |
	| 3  | Premier league | 10/3/2015 01:00 | 10/3/2015 01:00 | 10/3/2015 02:30 | 5           | FC Astana       | 0                     | 7                                | 6           | Atletico Madrid  | 0                     | 5                                |
	| 4  | Premier league | 1/1/2014 01:00  | 1/1/2014 01:00  | 1/1/2014 02:30  | 1           | Brentford       | 0                     | 5                                | 2           | Hull City        | 1                     | 10                               |
	| 5  | Premier league | 1/2/2014 01:00  | 1/2/2014 01:00  | 1/2/2014 02:30  | 3           | Birmingham City | 1                     | 5                                | 4           | Blackburn Rovers | 0                     | 10                               |
	| 6  | Premier league | 10/3/2014 01:00 | 10/3/2014 01:00 | 10/3/2014 02:30 | 5           | FC Astana       | 0                     | 4                                | 6           | Atletico Madrid  | 0                     | 10                               |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 2       | 2           |
	| 3  | s01                | 3       | 3           |
	| 4  | s01                | 4       | 1           |
	| 5  | s01                | 5       | 2           |
	| 6  | s01                | 6       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |
	| 1     | 10          |
	| 10    | 3           |

@mock
Scenario: ผู้ใช้ที่ไม่มีในระบบขอข้อมูลการทายผล ระบบส่งรายการทายผลเปล่ากลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 2       | 2           |
	| 3  | s01                | 3       | 3           |
	When ผู้ใช้ UserId: 'unknow' ขอข้อมูลการทายผลทั้งหมด
	Then ระบบส่งรายการทายผลกลับไปเป็น
	| Month | TotalPoints |