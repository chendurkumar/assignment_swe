SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Customer_Id], [FirstName], [LastName], [SSN], [Email], [HouseNumber], [StreetAddress1], [StreetAddress2], [Phone], [Username], [Password]) VALUES (1, N'Kumar', N'Subramanian', N'120281-1234', N'kumar.s@email.com', N'12   ', N'Vasagatan', NULL, N'+35812345678', N'skumar', N'5f4dcc3b5aa765d61d8327deb882cf99')
INSERT INTO [dbo].[Customer] ([Customer_Id], [FirstName], [LastName], [SSN], [Email], [HouseNumber], [StreetAddress1], [StreetAddress2], [Phone], [Username], [Password]) VALUES (2, N'Test ', N'User', N'120385-1234', N'test.user@gmail.com', N'132  ', N'Esbo', NULL, N'+36985421623', N'testuser', N'5f4dcc3b5aa765d61d8327deb882cf99')
SET IDENTITY_INSERT [dbo].[Customer] OFF
