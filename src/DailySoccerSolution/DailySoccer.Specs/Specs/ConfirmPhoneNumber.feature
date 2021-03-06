﻿Feature: ConfirmPhoneNumber
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecretCode | VerifiedPhoneNumber	|
	| 1  | s01        |						|
	| 2  | s02        | +66914185555		|

@mock
Scenario: ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น
	Given ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น
	| Id | UserId | VerificationCode | PhoneNumber  | CompletedDate |
	| 1  | s01    | 1234567          | +66914185500 |               |
	When ผู้ใช้ UserId: 's01' ยืนยันรหัสลับ VerificationCode: '1234567'
	Then ระบบทำการบันทึกการยืนยันเบอร์โทรศัพ '+66914185500' และ VerificationCode: '1234567' ให้กับผู้ใช้ UserId: 's01' เสร็จสิ้น

@mock
Scenario: ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลไม่ถูกต้อง (รหัสลับไม่ถูก) ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด
	Given ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น
	| Id | UserId | VerificationCode | PhoneNumber  | CompletedDate |
	| 1  | s01    | 1234567          | +66914185500 |               |
	When ผู้ใช้ UserId: 's01' ยืนยันรหัสลับ VerificationCode: 'missMatch'
	Then ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด

@mock
Scenario: ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลไม่ถูกต้อง (ไม่มีรายการขอยืนยันเบอร์โทร) ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด
	Given ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น
	| Id | UserId | VerificationCode | PhoneNumber  | CompletedDate |
	When ผู้ใช้ UserId: 's01' ยืนยันรหัสลับ VerificationCode: '1234567'
	Then ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด

@mock
Scenario: ผู้ใช้ที่ยังไม่เคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง (มีรหัสลับที่ยังไม่ถูกยืนยันหลายรายการ) ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น
	Given ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น
	| Id | UserId | VerificationCode | PhoneNumber  | CompletedDate |
	| 1  | s01    | 1234567          | +66914185500 |               |
	| 2  | s01    | 0000001          | +7700000001  | 1/1/2015      |
	| 3  | s01    | 2222222          | +8800000001  |               |
	When ผู้ใช้ UserId: 's01' ยืนยันรหัสลับ VerificationCode: '2222222'
	Then ระบบทำการบันทึกการยืนยันเบอร์โทรศัพ '+8800000001' และ VerificationCode: '2222222' ให้กับผู้ใช้ UserId: 's01' เสร็จสิ้น

@mock
Scenario: ผู้ใช้ที่ยังเคยยืนยันรหัสลับขอทำการยืนยันรหัสลับข้อมูลถูกต้อง ระบบทำการบันทึกการยืนยันเบอร์โทรศัพเสร็จสิ้น
	Given ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น
	| Id | UserId | VerificationCode | PhoneNumber  | CompletedDate |
	| 1  | s02    | 1234567          | +66914185500 |               |
	When ผู้ใช้ UserId: 's02' ยืนยันรหัสลับ VerificationCode: '1234567'
	Then ระบบทำการบันทึกการยืนยันเบอร์โทรศัพ '+66914185500' และ VerificationCode: '1234567' ให้กับผู้ใช้ UserId: 's02' เสร็จสิ้น