SET IDENTITY_INSERT [dbo].[Account] ON
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (1, N'1         ', N'1234-000001', CAST(11300.1500 AS Money), 1, 0)
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (2, N'2         ', N'1234-000002', CAST(100.0000 AS Money), 3, 0)
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (3, N'Deposit   ', N'1234-000003', CAST(1000.0000 AS Money), 1, 0)
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (4, N'Deposit   ', N'1234-000004', CAST(1300.0000 AS Money), 1, 0)
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (5, N'Deposit   ', N'1234-000005', CAST(1300.0000 AS Money), 3, 0)
INSERT INTO [dbo].[Account] ([Account_Id], [Account_Type], [Account_Number], [Account_Balance], [Customer_Id], [Deleted]) VALUES (6, N'Deposit   ', N'1234-000006', CAST(1300.0000 AS Money), 3, 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
