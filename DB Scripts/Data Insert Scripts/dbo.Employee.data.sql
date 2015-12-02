SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([Employee_Id], [Name], [Username], [Password], [Deleted]) VALUES (1, N'Kumar Subramanian', N'skumar', N'password', 0)
INSERT INTO [dbo].[Employee] ([Employee_Id], [Name], [Username], [Password], [Deleted]) VALUES (2, N'Test User', N'tester', N'pass', 0)
SET IDENTITY_INSERT [dbo].[Employee] OFF
