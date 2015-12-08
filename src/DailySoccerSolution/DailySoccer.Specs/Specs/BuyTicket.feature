Feature: BuyTicket
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01        | 0      | 5                  | 0                    |

@mock
Scenario: ซื้อคูปองแต่มีแต้มไม่พอ ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     | RequestPoints |
	| 1  | 100           | 1/10/2015 00:00 | 100           |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's01' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก

#ซื้อคูปองมีแต้มพอดี ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
#ซื้อคูปองมีแต้มเกินกว่าที่ต้องการ ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
#ซื้อคูปองแต่จำนวนที่ต้องการไม่ถูกต้อง ระบบยกเลิกการสั่งซื้อ
#ซื้อคูปองแต่ระบบยังไม่มีกลุ่มของรางวัล ระบบยกเลิกการสั่งซื้อ
#ซื้อคูปองแต่ยังไม่มีกลุ่มของรางวัลชุดใหม่ ระบบยกเลิกการสั่งซื้อ
#ซื้อคูปองแต่กลุ่มของรางวัลชุดใหม่ยังไม่มีรายการของรางวัล ระบบยกเลิกการสั่งซื้อ
#ผู้ใช้ที่ไม่มีในระบบทำการสั่งซื้อ ระบบยกเลิกการสั่งซื้อ