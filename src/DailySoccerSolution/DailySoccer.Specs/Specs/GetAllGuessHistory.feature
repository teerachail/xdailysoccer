Feature: GetAllGuessHistory
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking

@mock
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

#ผู้ใช้ที่ไม่เคยทายผลขอข้อมูลการทายผลทั้งหมด ระบบส่งรายการทายผลเปล่ากลับไป
#ผู้ใช้ที่เคยทายผลไว้บางเดือนขอข้อมูลการทายผลทั้งหมด ระบบส่งรายการทายผลทั้งหมดของปีนั้นๆกลับไป
#ผู้ใช้ขอข้อมูลการทายผลทั้งหมด ระบบส่งรายการทายผลทั้งหมดของปีนั้นๆกลับไป
#ผู้ใช้ที่ไม่มีในระบบขอข้อมูลการทายผล ระบบส่งรายการทายผลเปล่ากลับไป