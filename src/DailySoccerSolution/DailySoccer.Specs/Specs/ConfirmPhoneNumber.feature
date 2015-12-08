Feature: ConfirmPhoneNumber
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode | VerifyCode		|
	| 1  | s01        |					|
	| 2  | s02        | +66914185555	|

@mock
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

#ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น
#ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลไม่ถูกต้อง ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด
#ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง (มีรหัสลับที่ยังไม่ถูกยืนยันหลายรายการ) ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น
#ผู้ใช้ที่ยังเคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น