Feature: UpdateMatches
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking

Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

#ทำการอัพเดทแมช์ในตอนทีไม่มีข้อมูลแมช์ ระบบไม่ทำการอัพเดทแมช์
#ทำการอัพเดทแมช์แล้วได้แมช์ที่ยังไม่เคยมี ระบบทำการเพิ่มแมช์ใหม่
#ทำการอัพเดทแมช์แล้วได้แมช์ที่เคยมีแล้วและไม่มีข้อมูลเปลี่ยนแปลง ระบบไม่ทำการอัพเดทแมช์
#ทำการอัพเดทแมช์แล้วได้แมช์ที่เคยมีแล้วและมีข้อมูลเปลี่ยนแปลง ระบบทำการอัพเดทแมช์
#ทำการอัพเดทแมช์แล้วได้แมช์ที่เคยมีและยังไม่เคย มีทั้งข้อมูลที่เปลี่ยนแปลงและยังไม่เปลี่ยนแปลง ระบบทำการเพิ่มแมช์เฉพาะแมช์ที่ยังไม่เคยมี และอัพเดทแมช์ที่เปลี่ยนแปลง