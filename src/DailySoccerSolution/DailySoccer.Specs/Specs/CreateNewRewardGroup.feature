Feature: CreateNewRewardGroup
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ข้อมูลrewordgroupที่อยู่ในระบบคือ
	| Id | RequestPoints|ExpiredDate|
	|1|100|11/24/2015 00:00|
	|2|200|12/8/2015 00:00|
	And วันเวลาในปัจจุบันเป็น '12/7/2015 00:00'


@mock
Scenario: สร้าง rewardgroup หลังจากวันปัจจุบัน
	Given Admin ทำการสร้าง rewardgroup คะแนนที่ใช้ในการแลก: '100', วันที่สิ้นสุดการส่งชิงโชค: '12/7/2015 00:00'
	When ระบบทำการตรวจสอบความถูกต้อง
	Then ระบบทำการบันทึกข้อมูล rewardgroup

@mock
Scenario: สร้าง rewardgroup ก่อนวันปัจจุบัน
	Given Admin ทำการสร้าง rewardgroup คะแนนที่ใช้ในการแลก: '100', วันที่สิ้นสุดการส่งชิงโชค: '12/5/2015 00:00'
	When ระบบทำการตรวจสอบความถูกต้อง
	Then ระบบไม่ทำการบันทึกข้อมูล rewardgroup

@mock
Scenario: สร้าง rewardgroup จากวันที่ที่เคยสร้างไปแล้ว
	Given Admin ทำการสร้าง rewardgroup คะแนนที่ใช้ในการแลก: '100', วันที่สิ้นสุดการส่งชิงโชค: '12/8/2015 00:00'
	When ระบบทำการตรวจสอบความถูกต้อง
	Then ระบบไม่ทำการบันทึกข้อมูล rewardgroup