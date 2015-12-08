Feature: RequestConfirmPhoneNumber
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

#ผู้ใช้ทำการขอยืนยันเบอร์โทรศัพ ระบบบันทึกเบอร์โทรแล้วส่งรหัสลับในการยืนยันกลับไป
#ผู้ใช้ทำการขอยืนยันเบอร์โทรศัพแต่เป็นเบอร์ที่เคยขอยืนยันไปแล้ว (เบอร์โทรนั้นยังไม่เคยยืนยัน) ระบบบันทึกเบอร์โทรแล้วส่งรหัสลับในการยืนยันกลับไป
#ผู้ใช้ทำการขอยืนยันเบอร์โทรศัพแต่เป็นเบอร์ที่เคยขอยืนยันไปแล้ว (เบอร์โทรนั้นเคยยืนยันไปแล้ว) ระบบบันทึกเบอร์โทรแล้วส่งรหัสลับในการยืนยันกลับไป
#ผู้ใช้ที่ไม่มีในระบบขอยืนยันเบอร์โทรศัพ ระบบไม่ทำการบันทึกเบอร์โทรและไม่ส่งรหัสลับกลับไป