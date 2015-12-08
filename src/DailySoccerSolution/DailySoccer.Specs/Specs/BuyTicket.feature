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
	| 2  | s02        | 100    | 5                  | 0                    |
	| 3  | s03        | 10000  | 5                  | 0                    |

@mock
Scenario: ซื้อคูปองแต่มีแต้มไม่พอ ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's01' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01        | 0      | 5                  | 0                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/10/2015 00:00'

@mock
Scenario: ซื้อคูปองมีแต้มพอดี ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's02' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบทำการบันทึกการสั่งซื้อคูปอง '1' คูปอง จากผู้ใช้ UserId: 's02' จากกลุ่มของรางวัลรหัส '1'
	And ผู้ใช้ UserId: 's02' ถูกหักแต้มจำนวน '100' แต้ม
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 2  | s02        | 0      | 5                  | 1                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'true' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/10/2015 00:00'

@mock
Scenario: ซื้อคูปองมีแต้มเกินกว่าที่ต้องการ ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's03' สั่งซื้อคูปองจำนวน '10' คูปอง
	Then ระบบทำการบันทึกการสั่งซื้อคูปอง '10' คูปอง จากผู้ใช้ UserId: 's03' จากกลุ่มของรางวัลรหัส '1'
	And ผู้ใช้ UserId: 's03' ถูกหักแต้มจำนวน '1000' แต้ม
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 3  | s03        | 9000   | 5                  | 10                   |
	And ผลการสั่งซื้อสำเร็จเป็น 'true' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/10/2015 00:00'

@mock
Scenario: ซื้อคูปองตอนมีกลุ่มของรางวัลหลายชุด ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	| 2  | 30            | 2/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description  | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description   | 200    | 120             | xboxone.jpg  |
	When ผู้ใช้ UserId: 's02' สั่งซื้อคูปองจำนวน '3' คูปอง
	Then ระบบทำการบันทึกการสั่งซื้อคูปอง '3' คูปอง จากผู้ใช้ UserId: 's02' จากกลุ่มของรางวัลรหัส '2'
	And ผู้ใช้ UserId: 's02' ถูกหักแต้มจำนวน '90' แต้ม
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 2  | s02        | 10     | 5                  | 3                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'true' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '2/10/2015 00:00'

@mock
Scenario: ซื้อคูปองแต่จำนวนที่ต้องการไม่ถูกต้อง ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's03' สั่งซื้อคูปองจำนวน '-1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 3  | s03        | 10000  | 5                  | 0                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/1/0001 00:00'

@mock
Scenario: ซื้อคูปองแต่ระบบยังไม่มีกลุ่มของรางวัล ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	When ผู้ใช้ UserId: 's02' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 2  | s02        | 100    | 5                  | 0                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/1/0001 00:00'

@mock
Scenario: ซื้อคูปองแต่ยังไม่มีกลุ่มของรางวัลชุดใหม่ ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/11/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 's02' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 2  | s02        | 100    | 5                  | 0                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/10/2015 00:00'

@mock
Scenario: ซื้อคูปองแต่กลุ่มของรางวัลชุดใหม่ยังไม่มีรายการของรางวัล ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	When ผู้ใช้ UserId: 's02' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น
	| Id | SecretCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 2  | s02        | 100    | 5                  | 0                    |
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/10/2015 00:00'

@mock
Scenario: ผู้ใช้ที่ไม่มีในระบบทำการสั่งซื้อ ระบบยกเลิกการสั่งซื้อ
	Given วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	And กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate     |
	| 1  | 100           | 1/10/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ผู้ใช้ UserId: 'unknow' สั่งซื้อคูปองจำนวน '1' คูปอง
	Then ระบบไม่ทำการบันทึกการสั่งซื้อ
	And แต้มผู้ใช้ไม่ถูกหัก
	And ผลการสั่งซื้อสำเร็จเป็น 'false' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '1/1/0001 00:00'