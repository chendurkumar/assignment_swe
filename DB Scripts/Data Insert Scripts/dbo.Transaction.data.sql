SET IDENTITY_INSERT [dbo].[Transaction] ON
INSERT INTO [dbo].[Transaction] ([Transaction_Id], [Account_Id], [Transaction_Type], [Amount], [Message], [Timestamp], [Details]) VALUES (5, 2, 1, CAST(100.0000 AS Money), N'100 deposit to my account', NULL, N' Test details')
INSERT INTO [dbo].[Transaction] ([Transaction_Id], [Account_Id], [Transaction_Type], [Amount], [Message], [Timestamp], [Details]) VALUES (6, 2, 1, CAST(100.0000 AS Money), N'100 deposit to my account', NULL, N' Test details')
INSERT INTO [dbo].[Transaction] ([Transaction_Id], [Account_Id], [Transaction_Type], [Amount], [Message], [Timestamp], [Details]) VALUES (7, 2, 1, CAST(100.0000 AS Money), N'100 deposit to my account', NULL, N' Test details')
INSERT INTO [dbo].[Transaction] ([Transaction_Id], [Account_Id], [Transaction_Type], [Amount], [Message], [Timestamp], [Details]) VALUES (8, 2, 1, CAST(10000.0000 AS Money), N'100 deposit to my account', NULL, N' Test details')
SET IDENTITY_INSERT [dbo].[Transaction] OFF
