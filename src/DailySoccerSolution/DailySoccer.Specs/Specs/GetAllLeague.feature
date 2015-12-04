Feature: GetAllLeague
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking

@mock
Scenario: ขอข้อมูลทีมทั้งหมดในตอนที่ไม่มีข้อมูลทีม ระบบส่งข้อมูลเปล่ากลับไป
	Given ข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName | LeagueName |
	When ขอข้อมูลทีมทั้งหมดในระบบ
	Then ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName | LeagueName |

@mock
Scenario: ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่ข้อมูลเดียว ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป
	Given ข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName | LeagueName            |
	| 1      | AS Roma  | EUFA Champions League |
	When ขอข้อมูลทีมทั้งหมดในระบบ
	Then ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName | LeagueName            |
	| 1      | AS Roma  | EUFA Champions League |

@mock
Scenario: ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่หลายข้อมูล ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป
	Given ข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName         | LeagueName            |
	| 1      | AS Roma          | EUFA Champions League |
	| 2      | Bayer Leverkusen | EUFA Champions League |
	| 3      | Barcelona        | EUFA Champions League |
	| 4      | BATE Borisov     | EUFA Champions League |
	| 5      | Bayern Munich    | EUFA Champions League |
	When ขอข้อมูลทีมทั้งหมดในระบบ
	Then ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น
	| TeamId | TeamName | LeagueName            |
	| 1      | AS Roma          | EUFA Champions League |
	| 2      | Bayer Leverkusen | EUFA Champions League |
	| 3      | Barcelona        | EUFA Champions League |
	| 4      | BATE Borisov     | EUFA Champions League |
	| 5      | Bayern Munich    | EUFA Champions League |