Feature: BuyTicket
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

#ซื้อ ticket แต่มีแต้มไม่พอ ระบบยกเลิกการสั่งซื้อ
#ซื้อ ticket มีแต้มพอดี ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
#ซื้อ ticket มีแต้มเกินกว่าที่ต้องการ ระบบทำการหักแต้มและบันทึกการสั่งซื้อ
#ซื้อ ticket แต่จำนวนที่ต้องการไม่ถูกต้อง ระบบยกเลิกการสั่งซื้อ
#ซื้อ ticket แต่ระบบยังไม่มีกลุ่มของรางวัล ระบบยกเลิกการสั่งซื้อ
#ซื้อ ticket แต่ยังไม่มีกลุ่มของรางวัลชุดใหม่ ระบบยกเลิกการสั่งซื้อ
#ซื้อ ticket แต่กลุ่มของรางวัลชุดใหม่ยังไม่มีรายการของรางวัล ระบบยกเลิกการสั่งซื้อ
#ผู้ใช้ที่ไม่มีในระบบทำการสั่งซื้อ ระบบยกเลิกการสั่งซื้อ