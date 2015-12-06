Feature: GetGuessHistoryByMonth
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
Scenario: ผู้ใช้ขอข้อมูลการทายผลรายเดือนในปีที่ไม่มีแมช์ ระบบส่งรายการทายผลเปล่ากลับไป
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
	When ผู้ใช้ UserId: 's01' ขอข้อมูลการทายผลรายเดือน month: '1', year: '2014'
	Then ระบบส่งผลการทายผลรายเดือนกลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.CurrentScore | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name    | TeamHome.CurrentScore | TeamAway.WinningPredictionPoints |

#ผู้ใช้ขอข้อมูลการทายผลรายเดือนในเดือนที่ไม่มีแมช์ ระบบส่งรายการทายผลเปล่ากลับไป
#ผู้ใช้ขอข้อมูลการทายผลรายเดือนในเดือนที่ตัวเองไม่ได้ทายผล ระบบส่งรายการทายผลเปล่ากลับไป
#ผู้ใช้ขอข้อมูลการทายผลรายเดือนในเดือนที่ตัวเองมีการทายผลไว้วันเดียว ระบบส่งรายการทายผลในเดือนนั้นทั้งหมดกลับไป
#ผู้ใช้ขอข้อมูลการทายผลรายเดือนในเดือนที่ตัวเองมีการทายผลไว้หลายวัน ระบบส่งรายการทายผลในเดือนนั้นทั้งหมดกลับไป

#ผู้ใช้ขอข้อมูลการทายผลรายเดือนแต่ปีที่ส่งไปไม่ถูกต้อง ระบบส่งรายการทายผลเปล่ากลับไป
#ผู้ใช้ขอข้อมูลการทายผลรายเดือนแต่เดือนที่ส่งไปไม่ถูกต้อง ระบบส่งรายการทายผลเปล่ากลับไป
#ผู้ใช้ที่ไม่มีในระบบขอข้อมูลการทายผลรายเดือน ระบบส่งรายการทายผลเปล่ากลับไป