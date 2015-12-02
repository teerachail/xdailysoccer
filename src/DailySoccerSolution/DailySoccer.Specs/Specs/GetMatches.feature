Feature: GetMatches
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
Scenario: ผู้ใช้ขอแมช์ในตอนที่เซิฟเวอร์ไม่มีข้อมูลแมช์อยู่เลย ระบบส่งแมช์เปล่ากลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName | BeginDate | StartedDate | CompletedDate |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 00:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName | BeginDate | StartedDate | CompletedDate |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่ยังไม่แข่ง ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 |             |               | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 |             |               | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 00:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 |             |               | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/1/2015 01:30 |             |               | 3           | Birmingham City | false               | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่กำลังแข่ง ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | false               | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่กำลังแข่ง (มีบางแมช์ที่ทายผลไว้) ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 2       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | true                | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่กำลังแข่ง (ทายผลไว้ทุกแมช์) ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 2           |
	| 2  | s01                | 2       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 02:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 |               | 1           | Brentford       | false               | 2           | Hull City        | true                |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 |               | 3           | Birmingham City | true                | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่แข่งจบแล้ว ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | false               | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่แข่งจบแล้ว (มีบางแมช์ที่ทายผลไว้) ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 2       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | true                | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีแต่รายการที่แข่งจบแล้ว (ทายผลไว้ทุกแมช์) ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name    |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City        |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | 4           | Blackburn Rovers |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 2           |
	| 2  | s01                | 2       | 3           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | false               | 2           | Hull City        | true                |
	| 2  | Premier league | 1/1/2015 01:30 | 1/1/2015 01:30 | 1/1/2015 03:00 | 3           | Birmingham City | true                | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ข้อแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ปัจจุบันที่มีรายการแข่งขันทุกประเภท ระบบส่งแมช์ปัจจุบันกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name       |
	| 1  | Premier league | 1/1/2015 02:00 | 1/1/2015 02:00 |                | 1           | FC Astana       | 2           | Atletico Madrid     |
	| 2  | Premier league | 1/1/2015 02:30 | 1/1/2015 02:30 | 1/1/2015 04:00 | 3           | Real Madrid     | 4           | Paris Saint-Germain |
	| 3  | Premier league | 1/1/2015 06:00 |                |                | 5           | Brentford       | 6           | Hull City           |
	| 4  | Premier league | 1/1/2015 06:30 |                |                | 7           | Birmingham City | 8           | Blackburn Rovers    |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 2       | 4           |
	| 3  | s01                | 3       | 6           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 05:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name       | TeamAway.IsSelected |
	| 1  | Premier league | 1/1/2015 02:00 | 1/1/2015 02:00 |                | 1           | FC Astana       | true                | 2           | Atletico Madrid     | false               |
	| 2  | Premier league | 1/1/2015 02:30 | 1/1/2015 02:30 | 1/1/2015 04:00 | 3           | Real Madrid     | false               | 4           | Paris Saint-Germain | true                |
	| 3  | Premier league | 1/1/2015 06:00 |                |                | 5           | Brentford       | false               | 6           | Hull City           | true                |
	| 4  | Premier league | 1/1/2015 06:30 |                |                | 7           | Birmingham City | false               | 8           | Blackburn Rovers    | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ขอแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ที่ผ่านมาแล้ว ระบบส่งแมช์ที่ผ่านมาแล้วที่ไม่เกิน 2 วันย้อนหลังกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name       |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford       | 2           | Hull City           |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City | 4           | Blackburn Rovers    |
	| 3  | Premier league | 1/3/2015 01:00 | 1/3/2015 01:00 | 1/3/2015 02:30 | 5           | FC Astana       | 7           | Atletico Madrid     |
	| 4  | Premier league | 1/4/2015 01:00 | 1/4/2015 01:00 | 1/4/2015 02:30 | 6           | Real Madrid     | 8           | Paris Saint-Germain |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	| 1  | s01                | 1       | 1           |
	| 2  | s01                | 4       | 8           |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/4/2015 04:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name       | TeamAway.IsSelected |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City | false               | 4           | Blackburn Rovers    | false               |
	| 3  | Premier league | 1/3/2015 01:00 | 1/3/2015 01:00 | 1/3/2015 02:30 | 5           | FC Astana       | false               | 7           | Atletico Madrid     | false               |
	| 4  | Premier league | 1/4/2015 01:00 | 1/4/2015 01:00 | 1/4/2015 02:30 | 6           | Real Madrid     | false               | 8           | Paris Saint-Germain | true                |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ขอแมช์ในตอนที่เซิฟเวอร์มีแต่แมช์ในอนาคต ระบบส่งแมช์ในอนาคตที่ไม่เกิน 2 วันในอนาคตกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamAway.Id | TeamAway.Name       |
	| 1  | Premier league | 1/2/2015 01:00 |             |               | 1           | Brentford       | 2           | Hull City           |
	| 2  | Premier league | 1/3/2015 01:00 |             |               | 3           | Birmingham City | 4           | Blackburn Rovers    |
	| 3  | Premier league | 1/4/2015 01:00 |             |               | 5           | FC Astana       | 7           | Atletico Madrid     |
	| 4  | Premier league | 1/5/2015 01:00 |             |               | 6           | Real Madrid     | 8           | Paris Saint-Germain |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/1/2015 04:00'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate | CompletedDate | TeamHome.Id | TeamHome.Name   | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name    | TeamAway.IsSelected |
	| 1  | Premier league | 1/2/2015 01:00 |             |               | 1           | Brentford       | false               | 2           | Hull City        | false               |
	| 2  | Premier league | 1/3/2015 01:00 |             |               | 3           | Birmingham City | false               | 4           | Blackburn Rovers | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |

@mock
Scenario: ผู้ใช้ขอแมช์ในตอนที่เซิฟเวอร์มีข้อมูลอดีต, ปัจจุบัน, อนาคต ระบบส่งข้อมูลแมช์อดีตที่ไม่เกิน 2 วันย้อนหลัง, แมช์ปัจจุบัน, แมช์ในอนาคตที่ไม่เกิน 2 วันในอนาคตกลับไป
	Given ในระบบมีข้อมูลแมช์เป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name     | TeamAway.Id | TeamAway.Name       |
	| 1  | Premier league | 1/1/2015 01:00 | 1/1/2015 01:00 | 1/1/2015 02:30 | 1           | Brentford         | 2           | Hull City           |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City   | 4           | Blackburn Rovers    |
	| 3  | Premier league | 1/3/2015 01:00 | 1/3/2015 01:00 | 1/3/2015 02:30 | 5           | FC Astana         | 7           | Atletico Madrid     |
	| 4  | Premier league | 1/4/2015 01:00 | 1/4/2015 01:00 |                | 6           | Real Madrid       | 8           | Paris Saint-Germain |
	| 5  | Premier league | 1/5/2015 01:00 |                |                | 9           | Shakhtar Donetsk  | 10          | Malmo               |
	| 6  | Premier league | 1/6/2015 01:00 |                |                | 11          | Manchester United | 12          | CSKA Moscow         |
	| 7  | Premier league | 1/7/2015 01:00 |                |                | 13          | PSV Eindhoven     | 14          | VfL Wolfsburg       |
	And ในระบบมีข้อมูลการทายเป็น
	| Id | AccountSecrectCode | MatchId | GuessTeamId |
	When ผู้ใช้ UserId: 's01' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '1/4/2015 01:30'
	Then ระบบส่งข้อมูลแมช์กลับไปเป็น
	| Id | LeagueName     | BeginDate      | StartedDate    | CompletedDate  | TeamHome.Id | TeamHome.Name     | TeamHome.IsSelected | TeamAway.Id | TeamAway.Name       | TeamAway.IsSelected |
	| 2  | Premier league | 1/2/2015 01:00 | 1/2/2015 01:00 | 1/2/2015 02:30 | 3           | Birmingham City   | false               | 4           | Blackburn Rovers    | false               |
	| 3  | Premier league | 1/3/2015 01:00 | 1/3/2015 01:00 | 1/3/2015 02:30 | 5           | FC Astana         | false               | 7           | Atletico Madrid     | false               |
	| 4  | Premier league | 1/4/2015 01:00 | 1/4/2015 01:00 |                | 6           | Real Madrid       | false               | 8           | Paris Saint-Germain | false               |
	| 5  | Premier league | 1/5/2015 01:00 |                |                | 9           | Shakhtar Donetsk  | false               | 10          | Malmo               | false               |
	| 6  | Premier league | 1/6/2015 01:00 |                |                | 11          | Manchester United | false               | 12          | CSKA Moscow         | false               |
	And ระบบส่งข้อมูลผู้ใช้กลับไปเป็น
	| Id | SecrectCode | Points | MaximumGuessAmount | CurrentOrderedCoupon |
	| 1  | s01         | 0      | 5                  | 0                    |