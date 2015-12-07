Feature: GetWinners
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
	| 3  | s03         | 0      | 5                  | 0                    |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่ไม่รางวัลในระบบ ระบบส่งรายชื่อผู้โชคดีเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name | Description | Amount | RemainingAmount | ImagePath |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath | Winners |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่ไม่มีผู้โชคดีในระบบ ระบบส่งรายชื่อผู้โชคดีเปล่ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S   | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6    | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S   | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath    | Winners |
	| 1        | iPhone 6S   | iphone6S.jpg |         |
	| 2        | iPhone 6    | iphone6.jpg  |         |
	| 3        | iPhone 5S   | iphone5S.jpg |         |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีแค่คนเดียว ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S   | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6    | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S   | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath    | Winners |
	| 1        | iPhone 6S   | iphone6S.jpg | Sakul   |
	| 2        | iPhone 6    | iphone6.jpg  |         |
	| 3        | iPhone 5S   | iphone5S.jpg |         |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีหลายคน (ถูกรางวัลเดียวกัน) ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S   | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6    | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S   | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	| 2  | s02                | 1        | Miolynet        |
	| 3  | s03                | 1        | Au              |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath    | Winners           |
	| 1        | iPhone 6S   | iphone6S.jpg | Sakul,Miolynet,Au |
	| 2        | iPhone 6    | iphone6.jpg  |                   |
	| 3        | iPhone 5S   | iphone5S.jpg |                   |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่มีผู้โชคดีหลายคน (ต่างรางวัลกัน) ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S   | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6    | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S   | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	| 2  | s02                | 1        | Miolynet        |
	| 3  | s03                | 3        | Au              |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath    | Winners        |
	| 1        | iPhone 6S   | iphone6S.jpg | Sakul,Miolynet |
	| 2        | iPhone 6    | iphone6.jpg  |                |
	| 3        | iPhone 5S   | iphone5S.jpg | Au             |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่เดือนปัจจุบันยังไม่มีข้อมูลรางวัล ระบบส่งรายชื่อผู้โชคดีเดือนก่อนหน้ากลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S   | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6    | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S   | 15     | 15              | iphone5S.jpg |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	| 2  | s02                | 1        | Miolynet        |
	| 3  | s03                | 3        | Au              |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description | ImagePath    | Winners        |
	| 1        | iPhone 6S   | iphone6S.jpg | Sakul,Miolynet |
	| 2        | iPhone 6    | iphone6.jpg  |                |
	| 3        | iPhone 5S   | iphone5S.jpg | Au             |

@mock
Scenario: ขอรายชื่อผู้โชคดีในตอนที่เดือนปัจจุบันยังไม่มีคนถูกรางวัล ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description          | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S            | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6             | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S            | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description  | 200    | 120             | xboxone.jpg  |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	| 2  | s02                | 1        | Miolynet        |
	| 3  | s03                | 3        | Au              |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description          | ImagePath   | Winners |
	| 1        | XBox 365 description | xbox365.jpg |         |
	| 2        | XBoxOne description  | xboxone.jpg |         |

@mock
Scenario: ขอรายชื่อผู้โชคดี มีข้อมูลคนถูกรางวัลของเดือนก่อนหน้า ระบบส่งรายชื่อผู้โชคดีปัจจุบันกลับไป
	Given กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้
	| Id | RequestPoints | ExpiredDate    |
	| 1  | 100           | 1/1/2015 00:00 |
	| 2  | 200           | 2/1/2015 00:00 |
	And ของรางวัลในแต่ละกลุ่มเป็นดังนี้
	| Id | RewardGroupId | Name      | Description          | Amount | RemainingAmount | ImagePath    |
	| 1  | 1             | iPhone 6S | iPhone 6S            | 5      | 5               | iphone6S.jpg |
	| 2  | 1             | iPhone 6  | iPhone 6             | 10     | 10              | iphone6.jpg  |
	| 3  | 1             | iPhone 5S | iPhone 5S            | 15     | 15              | iphone5S.jpg |
	| 4  | 2             | XBox 365  | XBox 365 description | 100    | 110             | xbox365.jpg  |
	| 5  | 2             | XBoxOne   | XBoxOne description  | 200    | 120             | xboxone.jpg  |
	And รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้
	| Id | AccountSecrectCode | RewardId | AccountFullName |
	| 1  | s01                | 1        | Sakul           |
	| 2  | s02                | 1        | Miolynet        |
	| 3  | s03                | 3        | Au              |
	| 4  | s03                | 4        | Au              |
	| 5  | s03                | 4        | Au              |
	| 6  | s03                | 5        | Au              |
	And วันเวลาในปัจจุบันเป็น '1/1/2015 00:00'
	When ขอรายชื่อผู้โชคดี
	Then ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น
	| Ordering | Description          | ImagePath   | Winners |
	| 1        | XBox 365 description | xbox365.jpg | Au,Au   |
	| 2        | XBoxOne description  | xboxone.jpg | Au      |