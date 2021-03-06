USE [NSW]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 05-03-2021 21:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [varchar](50) NULL,
	[ExpiryDate] [datetime] NULL,
	[Type] [varchar](50) NULL,
	[Make] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[Colour] [nvarchar](50) NULL,
	[Vin] [varchar](50) NULL,
	[TareWeight] [nvarchar](50) NULL,
	[GrossMass] [varchar](50) NULL,
	[InsurerName] [varchar](50) NULL,
	[InsurerCode] [varchar](50) NULL,
 CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistrations]    Script Date: 05-03-2021 21:18:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistrations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RegistrationId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRegistrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-03-2021 21:18:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Registrations] ON 
GO
INSERT [dbo].[Registrations] ([Id], [PlateNumber], [ExpiryDate], [Type], [Make], [Model], [Colour], [Vin], [TareWeight], [GrossMass], [InsurerName], [InsurerCode]) VALUES (1, N'EBF28E', CAST(N'2021-02-06T04:45:30.000' AS DateTime), N'Wagon', N'BMW', N'X4 M40i', N'Blue', N'12389347324', N'1700', NULL, N'Allianz', N'32')
GO
INSERT [dbo].[Registrations] ([Id], [PlateNumber], [ExpiryDate], [Type], [Make], [Model], [Colour], [Vin], [TareWeight], [GrossMass], [InsurerName], [InsurerCode]) VALUES (2, N'CXD82F', CAST(N'2020-03-02T04:45:30.000' AS DateTime), N'Hatch', N'Toyota', N'Corolla', N'Silver', N'54646546313', N'1432', N'1500', N'AAMI', N'17')
GO
INSERT [dbo].[Registrations] ([Id], [PlateNumber], [ExpiryDate], [Type], [Make], [Model], [Colour], [Vin], [TareWeight], [GrossMass], [InsurerName], [InsurerCode]) VALUES (3, N'WOP29P', CAST(N'2020-12-09T04:45:30.000' AS DateTime), N'Sedan', N'Mercedes', N'X4 M40i', N'Blue', N'87676676762', N'1700', NULL, N'GIO', N'13')
GO
INSERT [dbo].[Registrations] ([Id], [PlateNumber], [ExpiryDate], [Type], [Make], [Model], [Colour], [Vin], [TareWeight], [GrossMass], [InsurerName], [InsurerCode]) VALUES (4, N'QWX55Z', CAST(N'2021-07-21T04:45:30.000' AS DateTime), N'SUV', N'Jaguar', N'F pace', N'Green', N'65465466541', N'1620', NULL, N'NRMA', N'27')
GO
SET IDENTITY_INSERT [dbo].[Registrations] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRegistrations] ON 
GO
INSERT [dbo].[UserRegistrations] ([Id], [UserId], [RegistrationId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserRegistrations] ([Id], [UserId], [RegistrationId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UserRegistrations] ([Id], [UserId], [RegistrationId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[UserRegistrations] ([Id], [UserId], [RegistrationId]) VALUES (4, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[UserRegistrations] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Address]) VALUES (1, N'Pratik', N'Pune')
GO
INSERT [dbo].[Users] ([Id], [Name], [Address]) VALUES (2, N'Hardik', N'USA')
GO
INSERT [dbo].[Users] ([Id], [Name], [Address]) VALUES (3, N'Ramesh', N'Pune')
GO
INSERT [dbo].[Users] ([Id], [Name], [Address]) VALUES (4, N'Tulsi', N'Baroda')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[UserRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_UserRegistrations_Registrations] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registrations] ([Id])
GO
ALTER TABLE [dbo].[UserRegistrations] CHECK CONSTRAINT [FK_UserRegistrations_Registrations]
GO
ALTER TABLE [dbo].[UserRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_UserRegistrations_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRegistrations] CHECK CONSTRAINT [FK_UserRegistrations_Users]
GO
