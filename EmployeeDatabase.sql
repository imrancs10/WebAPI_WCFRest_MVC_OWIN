USE [master]
GO
/****** Object:  Database [EmployeeDemo]    Script Date: 1/19/2018 4:42:13 PM ******/
CREATE DATABASE [EmployeeDemo]
GO
USE [EmployeeDemo]
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Salary] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 1/19/2018 4:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetail](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserDetail] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/19/2018 4:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (1, N'Mark', N'Hastings', N'Male', 60000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (2, N'Steve', N'Pound', N'Male', 45000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (3, N'Ben', N'Hoskins', N'Male', 70000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (4, N'Philip', N'Hastings', N'Male', 45000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (5, N'Mary', N'Lambeth', N'Female', 30000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (6, N'Valarie', N'Vikings', N'Female', 35000)
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (7, N'John', N'Stanmore', N'Male', 80000)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetail] ON 

GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [Password], [RoleId]) VALUES (1, N'imran', N'12345', 1)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [Password], [RoleId]) VALUES (2, N'adminimran', N'12345', 2)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [Password], [RoleId]) VALUES (3, N'imranguest', N'12345', 3)
GO
SET IDENTITY_INSERT [dbo].[UserDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

GO
INSERT [dbo].[UserRole] ([RoleId], [Role]) VALUES (1, N'User')
GO
INSERT [dbo].[UserRole] ([RoleId], [Role]) VALUES (2, N'Admin')
GO
INSERT [dbo].[UserRole] ([RoleId], [Role]) VALUES (3, N'Guest')
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[UserDetail]  WITH CHECK ADD  CONSTRAINT [FK_UserDetail_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRole] ([RoleId])
GO
ALTER TABLE [dbo].[UserDetail] CHECK CONSTRAINT [FK_UserDetail_UserRole]
GO
USE [master]
GO
ALTER DATABASE [EmployeeDemo] SET  READ_WRITE 
GO
