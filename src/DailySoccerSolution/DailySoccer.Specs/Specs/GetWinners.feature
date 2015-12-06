Feature: GetWinners
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
Scenario: ขอรายชื่อผู้โชคดีในตอนที่ไม่รางวัลในระบบ ระบบส่งรายชื่อผู้โชคดีเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| RewardGroupId | Id | Name | Description | Amount | RemainingAmount | ImagePath |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath | Winners |

#ขอรายชื่อผู้โชคดีในตอนที่ไม่มีผู้โชคดีในระบบ ระบบส่งรายชื่อผู้โชคดีเปล่ากลับไป
#ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีแค่คนเดียว ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
#ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีหลายคน (ถูกรางวัลเดียวกัน) ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
#ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีหลายคน (ต่างรางวัลกัน) ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป