Feature: GetYourRewards
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mock
Background: Initialize
	Given Setup mocking
	And ผู้ใช้ในระบบมีดังนี้
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ขอข้อมูลของรางวัลที่เคยได้ ในตอนที่ยังไม่เคยมีข้อมูลของรางวัล ระบบส่งรายการของรางวัลที่เคยได้เปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

#ผู้ใช้ที่ไม่เคยได้รับของรางวัล ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้เปล่ากลับไป
#ผู้ใช้มีของรางวัลที่เคยได้ชิ้นเดียว ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
#ผู้ใช้มีของรางวัลที่เคยได้หลายเดียว (ของรางวัลเดือนก่อนหน้าทั้งหมด) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
#ผู้ใช้มีของรางวัลที่เคยได้หลายเดียว (ของรางวัลที่ผ่านมานานแล้วทั้งหมด) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
#ผู้ใช้มีของรางวัลที่เคยได้หลายเดียว (ของรางวัลเดือนก่อนและผ่านมาแล้ว) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป