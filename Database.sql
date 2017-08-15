CREATE TABLE [dbo].[Playlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO

CREATE TABLE [dbo].[Songs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaylistId] [int] NOT NULL,
	[TenantId] [uniqueidentifier] NOT NULL,
	[Artist] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO
SET IDENTITY_INSERT [dbo].[Playlists] ON 
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (1, N'069b57ab-6ec7-479c-b6d4-a61ba3001c86', N'Ballads', 0)
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (2, N'069b57ab-6ec7-479c-b6d4-a61ba3001c86', N'80''s pop', 1)
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (3, N'069b57ab-6ec7-479c-b6d4-a61ba3001c86', N'Japanese heavy metal', 0)
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (4, N'069b57ab-6ec7-479c-b6d4-a61ba3001c86', N'Slovakian folklore', 0)
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (5, N'80d612ab-22ee-4480-a80a-92bbea3b4419', N'European mainstream', 0)
GO
INSERT [dbo].[Playlists] ([Id], [TenantId], [Title], [IsDeleted]) VALUES (7, N'80d612ab-22ee-4480-a80a-92bbea3b4419', N'Classics', 0)
GO
SET IDENTITY_INSERT [dbo].[Playlists] OFF
GO
ALTER TABLE [dbo].[Playlists] ADD  CONSTRAINT [DF_Playlists_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Songs] ADD  CONSTRAINT [DF_Songs_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
