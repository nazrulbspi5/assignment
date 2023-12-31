USE [AssingmentDb]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [Postion], [SalaryAmount], [JoiningDate], [IsBonusAdded], [ManagerId]) VALUES (1, N'Nazrul Islam', N'General Manager', CAST(50000.00 AS Decimal(18, 2)), CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Employees] ([Id], [Name], [Postion], [SalaryAmount], [JoiningDate], [IsBonusAdded], [ManagerId]) VALUES (2, N'Minhazul Islam', N'Manager', CAST(40000.00 AS Decimal(18, 2)), CAST(N'2020-05-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Postion], [SalaryAmount], [JoiningDate], [IsBonusAdded], [ManagerId]) VALUES (3, N'Sagor Hossain', N'Office Executive', CAST(35000.00 AS Decimal(18, 2)), CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[Employees] ([Id], [Name], [Postion], [SalaryAmount], [JoiningDate], [IsBonusAdded], [ManagerId]) VALUES (4, N'Abdul Alim', N'Manager', CAST(45000.00 AS Decimal(18, 2)), CAST(N'2019-04-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Postion], [SalaryAmount], [JoiningDate], [IsBonusAdded], [ManagerId]) VALUES (5, N'Nayem Hossain', N'Office Executive', CAST(30000.00 AS Decimal(18, 2)), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 0, 4)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
