Feature: CalculateGameResult
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode  | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |
	| 2  | s02         | 100	| 5                  | 0                    |
	And วันเวลาในปัจจุบันเป็น '1/15/2015 00:00'

@mock
Scenario: คำนวณผลคะแนนในตอนที่ไม่มีข้อมูลแมช์ ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName | BeginDate | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่คำนวณผลคะแนนไปแล้ว ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     | 1/10/2015      | 1           | Benfica       | 2                     | 4                                | 4                                | 2           | Galatasaray   | 1                     | 6                                | 6                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอนาคต ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/20/2015 |             |               |                | 1           | Benfica       | 0                     | 4                                | 4                                | 2           | Galatasaray   | 0                     | 6                                | 6                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่จบ ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/15/2015 | 1/15/2015   |               |                | 1           | Benfica       | 2                     | 4                                | 4                                | 2           | Galatasaray   | 1                     | 6                                | 6                                |
	| 2  | Champion League | 1/15/2015 | 1/15/2015   |               |                | 3           | Sevilla FC    | 1                     | 5                                | 5                                | 4           | Hull City     | 6                     | 8                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s02                | 2       | 3           |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ถูกนวณผลไปแล้ว ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     | 1/15/2015      | 1           | Benfica       | 2                     | 4                                | 4                                | 2           | Galatasaray   | 1                     | 6                                | 6                                |
	| 2  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     | 1/15/2015      | 3           | Sevilla FC    | 1                     | 5                                | 5                                | 4           | Hull City     | 6                     | 8                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s02                | 2       | 3           |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่ถูกนวณผล (มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 1           | Benfica       | 1                     | 4                                | 4                                | 2           | Galatasaray   | 0                     | 6                                | 6                                |
	| 2  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 3           | Sevilla FC    | 0                     | 5                                | 5                                | 4           | Hull City     | 1                     | 8                                | 4                                |
	| 3  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 5           | Chelsea       | 0                     | 5                                | 5                                | 6           | Liverpool     | 0                     | 4                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 1       | 1           | 5                |
	| 2  | s02                | 2       | 3           | 10               |
	| 3  | s02                | 3       | 5           | 100              |
	When เริ่มคำนวณผลคะแนน
	Then ระบบทำการอัพเดทผลการคำนวณให้กับแมช์ดังนี้
	| MatchId |
	| 1       |
	| 2       |
	| 3       |
	And ระบบอัพเดทการทายผล Id: '1', ผลการทาย: 'true', คะแนนที่ได้: '5'
	And ระบบอัพเดทการทายผล Id: '2', ผลการทาย: 'false', คะแนนที่ได้: '0'
	And ระบบอัพเดทการทายผล Id: '3', ผลการทาย: 'true', คะแนนที่ได้: '50'
	And ระบบทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ Id: '1' เพิ่มคะแนนให้ '5' คะแนน
	And ระบบทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ Id: '2' เพิ่มคะแนนให้ '50' คะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่ถูกนวณผล (ไม่มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 1           | Benfica       | 1                     | 4                                | 4                                | 2           | Galatasaray   | 0                     | 6                                | 6                                |
	| 2  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 3           | Sevilla FC    | 0                     | 5                                | 5                                | 4           | Hull City     | 1                     | 8                                | 4                                |
	| 3  | Champion League | 1/15/2015 | 1/15/2015   | 1/15/2015     |                | 5           | Chelsea       | 0                     | 5                                | 5                                | 6           | Liverpool     | 0                     | 4                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When เริ่มคำนวณผลคะแนน
	Then ระบบทำการอัพเดทผลการคำนวณให้กับแมช์ดังนี้
	| MatchId |
	| 1       |
	| 2       |
	| 3       |
	And ระบบไม่ทำการอัพเดทการทายผล
	And ระบบไม่ทำการทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ใดๆ

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่ยังไม่คำนวณผลคะแนน (มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 1           | Benfica       | 1                     | 4                                | 4                                | 2           | Galatasaray   | 0                     | 6                                | 6                                |
	| 2  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 3           | Sevilla FC    | 0                     | 5                                | 5                                | 4           | Hull City     | 1                     | 8                                | 4                                |
	| 3  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 5           | Chelsea       | 0                     | 5                                | 5                                | 6           | Liverpool     | 0                     | 4                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	| 1  | s01                | 1       | 1           | 5                |
	| 2  | s02                | 2       | 3           | 10               |
	| 3  | s02                | 3       | 5           | 100              |
	When เริ่มคำนวณผลคะแนน
	Then ระบบทำการอัพเดทผลการคำนวณให้กับแมช์ดังนี้
	| MatchId |
	| 1       |
	| 2       |
	| 3       |
	And ระบบอัพเดทการทายผล Id: '1', ผลการทาย: 'true', คะแนนที่ได้: '5'
	And ระบบอัพเดทการทายผล Id: '2', ผลการทาย: 'false', คะแนนที่ได้: '0'
	And ระบบอัพเดทการทายผล Id: '3', ผลการทาย: 'true', คะแนนที่ได้: '50'
	And ระบบทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ Id: '1' เพิ่มคะแนนให้ '5' คะแนน
	And ระบบทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ Id: '2' เพิ่มคะแนนให้ '50' คะแนน

@mock
Scenario: คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่ยังไม่คำนวณผลคะแนน (ไม่มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName      | BeginDate | StartedDate | CompletedDate | CalculatedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	| 1  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 1           | Benfica       | 1                     | 4                                | 4                                | 2           | Galatasaray   | 0                     | 6                                | 6                                |
	| 2  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 3           | Sevilla FC    | 0                     | 5                                | 5                                | 4           | Hull City     | 1                     | 8                                | 4                                |
	| 3  | Champion League | 1/10/2015 | 1/10/2015   | 1/10/2015     |                | 5           | Chelsea       | 0                     | 5                                | 5                                | 6           | Liverpool     | 0                     | 4                                | 4                                |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId | PredictionPoints |
	When เริ่มคำนวณผลคะแนน
	Then ระบบทำการอัพเดทผลการคำนวณให้กับแมช์ดังนี้
	| MatchId |
	| 1       |
	| 2       |
	| 3       |
	And ระบบไม่ทำการอัพเดทการทายผล
	And ระบบไม่ทำการทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ใดๆ