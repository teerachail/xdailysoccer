Feature: CreateNewGuest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: สร้างuserใหม่แบบguest ระบบทำการสร้างguestได้สำเร็จ
	Given มีการเรียกใช้serviceให้สร้าง guest user
	When ระบบทำการสร้างguestให้ใหม่
	Then ระบบทำการส่งข้อมูลguestกลับ
