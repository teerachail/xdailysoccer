Feature: GetCurrentRewards
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking

@mock
Scenario: ขอข้อมูลของรางวัลในตอนที่ไม่มีกลุ่มของรางวัลในระบบ ระบบส่งรายการของรางวัลเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |

@mock
Scenario: ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดยังไม่มีรายการของรางวัล ระบบส่งรายการของรางวัลเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	And ราคา Ticket ของเดือนนี้คือ '100' Points

@mock
Scenario: ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดมีรายการของรางวัลครบ ระบบส่งรายการของรางวัลเดือนล่าสุดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	And ราคา Ticket ของเดือนนี้คือ '100' Points

@mock
Scenario: ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดยังไม่มีรายการของรางวัล แต่ข้อมูลกลุ่มเดือนก่อนหน้ามีข้อมูลครบ ระบบส่งรายการของรางวัลเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	And ราคา Ticket ของเดือนนี้คือ '200' Points

@mock
Scenario: ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดและเดือนก่อนหน้ามีข้อมูลครับ แต่ข้อมูลกลุ่มเดือนก่อนหน้ามีข้อมูลครบ ระบบส่งรายการของรางวัลเดือนล่าสุดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description  | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description   | 200    | 120             | xboxone.jpg  |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name     | Description          | Amount | RemainingAmount | ImagePath   |
	| 4  | 2             | XBox 365 | XBox 365 description | 100    | 110             | xbox365.jpg |
	| 5  | 2             | XBoxOne  | XBoxOne description  | 200    | 120             | xboxone.jpg |
	And ราคา Ticket ของเดือนนี้คือ '200' Points