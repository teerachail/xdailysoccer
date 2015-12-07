Feature: SetFavoriteTeam
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName			| LeagueName			|
	| TeamId | TeamName         | LeagueName            |
	| 1      | AS Roma          | EUFA Champions League |
	| 2      | Bayer Leverkusen | EUFA Champions League |
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode  | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้เลือกทีมที่ชอบ ระบบทำการบันทึกข้อมูลทีมที่ชอบ
	When ผู้ใช้ UserId: 's01' เลือกทีมที่ชอบเป็น SelectedTeamId: '1'
	Then ระบบทำการบันทึกข้อมูลทีมที่ชอบ ผู้ใช้ UserId: 's01' เลือกทีมที่ชอบเป็น SelectedTeamId: '1'

@mock
Scenario: ผู้ใช้ไม่เลือกทีมที่ชอบ ระบบไม่ทำการบันทึกข้อมูล
	When ผู้ใช้ UserId: 's01' เลือกทีมที่ชอบเป็น SelectedTeamId: '0'
	Then ระบบไม่ทำการบันทึกข้อมูลทีมที่ชอบ

@mock
Scenario: ผู้ใช้เลือกทีมที่ชอบที่ไม่มีในระบบ ระบบไม่ทำการบันทึกข้อมูล
	When ผู้ใช้ UserId: 's01' เลือกทีมที่ชอบเป็น SelectedTeamId: '99'
	Then ระบบไม่ทำการบันทึกข้อมูลทีมที่ชอบ

@mock
Scenario: ผู้ใช้ที่ข้อมูลไม่ถูกต้องทำการเลือกทีมที่ชอบ ระบบไม่ทำการบันทึกข้อมูล
	When ผู้ใช้ UserId: 's02' เลือกทีมที่ชอบเป็น SelectedTeamId: '1'
	Then ระบบไม่ทำการบันทึกข้อมูลทีมที่ชอบ