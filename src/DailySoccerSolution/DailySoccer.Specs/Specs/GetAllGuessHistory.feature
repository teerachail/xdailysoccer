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

#ผู้ใช้ที่เคยทายผลไว้บางเดือนขอข้อมูลการทายผลทั้งหมด ระบบส่งรายการทายผลทั้งหมดของปีนั้นๆกลับไป
#ผู้ใช้ขอข้อมูลการทายผลทั้งหมด ระบบส่งรายการทายผลทั้งหมดของปีนั้นๆกลับไป
#ผู้ใช้ที่ไม่มีในระบบขอข้อมูลการทายผล ระบบส่งรายการทายผลเปล่ากลับไป