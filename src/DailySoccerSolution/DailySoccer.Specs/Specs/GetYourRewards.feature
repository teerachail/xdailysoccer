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
	| 2  | s02         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ขอข้อมูลของรางวัลที่เคยได้ ในตอนที่ยังไม่เคยมีข้อมูลของรางวัล ระบบส่งรายการของรางวัลที่เคยได้เปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

@mock
Scenario: ผู้ใช้ที่ไม่เคยได้รับของรางวัล ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้เปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

@mock
Scenario: ผู้ใช้ที่ไม่เคยได้รับของรางวัล (มีผู้ใช้อื่นเคยได้รับรางวัล) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้เปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	| 1  | s02                | 1        | r01           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

@mock
Scenario: ผู้ใช้มีของรางวัลที่เคยได้ชิ้นเดียว ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	| 1  | s01                | 1        | r01           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description           | ImagePath    | ExpiredDate    |
	| 1        | r01           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

@mock
Scenario: ผู้ใช้มีของรางวัลที่เคยได้หลายชิ้น (ของรางวัลเดือนเดียวกันทั้งหมด) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	| 1  | s01                | 1        | r01           |
	| 2  | s01                | 1        | r02           |
	| 3  | s01                | 2        | r03           |
	| 4  | s01                | 3        | r04           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description           | ImagePath    | ExpiredDate    |
	| 1        | r01           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 2        | r02           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 3        | r03           | iPhone 6 description  | iphone6.jpg  | 1/1/2015 00:00 |
	| 4        | r04           | iPhone 5S description | iphone5S.jpg | 1/1/2015 00:00 |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |

@mock
Scenario: ผู้ใช้มีของรางวัลที่เคยได้หลายชิ้น (ของรางวัลที่ผ่านมาแล้วทั้งหมด) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description  | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description   | 200    | 120             | xboxone.jpg  |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	| 1  | s01                | 1        | r01           |
	| 2  | s01                | 1        | r02           |
	| 3  | s01                | 2        | r03           |
	| 4  | s01                | 3        | r04           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description | ImagePath | ExpiredDate |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description           | ImagePath    | ExpiredDate    |
	| 1        | r01           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 2        | r02           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 3        | r03           | iPhone 6 description  | iphone6.jpg  | 1/1/2015 00:00 |
	| 4        | r04           | iPhone 5S description | iphone5S.jpg | 1/1/2015 00:00 |

@mock
Scenario: ผู้ใช้มีของรางวัลที่เคยได้หลายชิ้น (ของรางวัลเดือนปัจจุบันและผ่านมาแล้ว) ขอข้อมูลของรางวัลที่เคยได้ ระบบส่งรายการของรางวัลที่เคยได้ทั้งหมดกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description           | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S description | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6 description  | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S description | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description  | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description   | 200    | 120             | xboxone.jpg  |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | ReferenceCode |
	| 1  | s01                | 1        | r01           |
	| 2  | s01                | 1        | r02           |
	| 3  | s01                | 2        | r03           |
	| 4  | s01                | 3        | r04           |
	| 5  | s01                | 5        | r05           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลของรางวัลที่เคยได้
	Then ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น
	| Ordering | ReferenceCode | Description         | ImagePath   | ExpiredDate    |
	| 1        | r05           | XBoxOne description | xboxone.jpg | 2/1/2015 00:00 |
	Then ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น
	| Ordering | ReferenceCode | Description           | ImagePath    | ExpiredDate    |
	| 1        | r01           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 2        | r02           | iPhone 6S description | iphone6S.jpg | 1/1/2015 00:00 |
	| 3        | r03           | iPhone 6 description  | iphone6.jpg  | 1/1/2015 00:00 |
	| 4        | r04           | iPhone 5S description | iphone5S.jpg | 1/1/2015 00:00 |