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
	| Id | RequestPoints | ExpiredDate    |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	When ขอข้อมูลของรางวัลในรอบล่าสุด
	Then ระบบส่งรายการของรางวัลกลับไปเป็น
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |

#ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดยังไม่มีรายการของรางวัล ระบบส่งรายการของรางวัลเปล่ากลับไป
#ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดมีรายการของรางวัลครบ ระบบส่งรายการของรางวัลเดือนล่าสุดกลับไป
#ขอข้อมูลของรางวัลในตอนที่กลุ่มของรางวัลเดือนล่าสุดยังไม่มีรายการของรางวัล แต่ข้อมูลกลุ่มเดือนก่อนหน้ามีข้อมูลครบ ระบบส่งรายการของรางวัลเปล่ากลับไป