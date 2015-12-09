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
	And วันเวลาในปัจจุบันเป็น '1/10/2015 00:00'

@mock
Scenario: คำนวณผลคะแนนในตอนที่ไม่มีข้อมูลแมช์ ระบบไม่ทำการคำนวณผลคะแนน
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName | BeginDate | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name | TeamHome.CurrentScore | TeamHome.CurrentPredictionPoints | TeamHome.WinningPredictionPoints | TeamAway.Id | TeamAway.Name | TeamAway.CurrentScore | TeamAway.CurrentPredictionPoints | TeamAway.WinningPredictionPoints |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When เริ่มคำนวณผลคะแนน
	Then ระบบไม่ทำการคำนวณผลคะแนน

#คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่คำนวณผลคะแนนไปแล้ว ระบบไม่ทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอนาคต ระบบไม่ทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่จบ ระบบไม่ทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ถูกนวณผลไปแล้ว ระบบไม่ทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่ถูกนวณผล (มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ปัจจุบันที่ยังไม่ถูกนวณผล (ไม่มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่ยังไม่คำนวณผลคะแนน (มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน
#คำนวณผลคะแนนในตอนที่มีแต่แมช์ในอดีตที่ยังไม่คำนวณผลคะแนน (ไม่มีผู้ใช้ทายผลในแมช์เหล่านั้น) ระบบทำการคำนวณผลคะแนน