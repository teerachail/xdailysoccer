Feature: GuessMatch
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate       | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.CurrentPredictionPoints | TeamAway.Id | TeamAway.Name       | TeamAway.CurrentPredictionPoints |
	| 1  | Premier league | 1/1/2015 01:00  |                |                | 1           | Brentford       | 6                                | 2           | Hull City           | 7                                |
	| 2  | Premier league | 1/1/2015 01:30  | 1/1/2015 01:30 |                | 3           | Birmingham City | 8                                | 4           | Blackburn Rovers    | 9                                |
	| 3  | Premier league | 1/1/2015 02:00  | 1/1/2015 02:00 | 1/1/2015 03:30 | 5           | FC Astana       | 10                               | 6           | Atletico Madrid     | 11                               |
	| 4  | Premier league | 1/20/2015 02:00 |                |                | 7           | Real Madrid     | 12                               | 8           | Paris Saint-Germain | 13                               |
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ทายผลว่าทีมเย่าชนะให้กับแมช์ที่ยังไม่แข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '1' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '1', GuessTeamId '1', PredictionPoints '6'

@mock
Scenario: ทายผลว่าทีมเยือนชนะให้กับแมช์ที่ยังไม่แข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '1' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '1', GuessTeamId '2', PredictionPoints '7'

@mock
Scenario: ทายผลว่าทีมเย่าชนะให้กับแมช์ที่กำลังแข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '2' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '2', GuessTeamId '3', PredictionPoints '8'

@mock
Scenario: ทายผลว่าทีมเยือนชนะให้กับแมช์ที่กำลังแข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '2' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '2', GuessTeamId '4', PredictionPoints '9'

@mock
Scenario: ทายผลว่าทีมเย่าชนะให้กับแมช์ที่แข่งจบแล้ว ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '3' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: ทายผลว่าทีมเยือนชนะให้กับแมช์ที่แข่งจบแล้ว ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '3' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: เปลี่ยนการทายจากทีมเย่าชนะเป็นทีมเยือนชนะให้กับแมช์ที่ยังไม่แข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 1       | 1           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '1' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '1', GuessTeamId '2', PredictionPoints '7'

@mock
Scenario: เปลี่ยนการทายจากทีมเยือนชนะเป็นทีมเย่าชนะให้กับแมช์ที่ยังไม่แข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 1       | 2           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '1' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '1', GuessTeamId '1', PredictionPoints '6'

@mock
Scenario: เปลี่ยนการทายจากทีมเย่าชนะเป็นทีมเยือนชนะให้กับแมช์ที่กำลังแข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 2       | 3           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '2' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '2', GuessTeamId '4', PredictionPoints '9'

@mock
Scenario: เปลี่ยนการทายจากทีมเยือนชนะเป็นทีมเย่าชนะให้กับแมช์ที่กำลังแข่ง ระบบทำการบันทึกการทายผลไว้
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 2       | 4           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '2' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบทำการบันทึกการทายผลไว้ UserId: 's01', MatchId: '2', GuessTeamId '3', PredictionPoints '8'

@mock
Scenario: เปลี่ยนการทายจากทีมเย่าชนะเป็นทีมเยือนชนะให้กับแมช์ที่แข่งจบแล้ว ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 3       | 5           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '3' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: เปลี่ยนการทายจากทีมเยือนชนะเป็นทีมเย่าชนะให้กับแมช์ที่แข่งจบแล้ว ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 3       | 6           | 10               |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '3' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: ทายแมช์ที่ไม่มีในระบบ ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '99' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: ทายผลว่าทีมเย่าชนะให้กับแมช์ที่ยังไม่แข่งที่อยู่ในอนาคต ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '4' IsGuessTeamHome: 'true' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย

@mock
Scenario: ทายผลว่าทีมเยือนชนะให้กับแมช์ที่ยังไม่แข่งที่อยู่ในอนาคต ระบบไม่ทำการบันทึกผล
	Given ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When ผู้ใช้ UserId: 's01' ทายผลแมช์ MatchId: '4' IsGuessTeamHome: 'false' เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบไม่ทำการบันทึกผลการทาย
