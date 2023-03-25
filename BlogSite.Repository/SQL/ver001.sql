IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [Title] nvarchar(100) NULL,
    [Mail] nvarchar(100) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [About] nvarchar(max) NULL,
    [Image] varbinary(max) NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [ReferenceId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Categories_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(100) NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Roles_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Blogs] (
    [Id] bigint NOT NULL IDENTITY,
    [Content] nvarchar(150) NOT NULL,
    [Description] nvarchar(max) NULL,
    [ViewNumber] int NOT NULL,
    [LikesNumber] int NOT NULL,
    [DislikesNumber] int NOT NULL,
    [Category_ID] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Blogs_Categories_Category_ID] FOREIGN KEY ([Category_ID]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Blogs_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UserRoles] (
    [Id] int NOT NULL IDENTITY,
    [Role_ID] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_Role_ID] FOREIGN KEY ([Role_ID]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserRoles_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Comments] (
    [Id] bigint NOT NULL IDENTITY,
    [Comment] nvarchar(max) NOT NULL,
    [Parent_ID] bigint NOT NULL,
    [Blog_ID] bigint NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Blogs_Blog_ID] FOREIGN KEY ([Blog_ID]) REFERENCES [Blogs] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Comments_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Images] (
    [Id] bigint NOT NULL IDENTITY,
    [Image] varbinary(max) NULL,
    [CoverArt] bit NOT NULL,
    [Blog_ID] bigint NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Images_Blogs_Blog_ID] FOREIGN KEY ([Blog_ID]) REFERENCES [Blogs] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Images_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Description', N'IsActive', N'Name', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedDate], [Description], [IsActive], [Name], [UpdatedDate], [User_ID])
VALUES (1, '2023-03-26T02:16:51.3522908+03:00', N'admin rolu tanımlama.', CAST(1 AS bit), N'admin', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Description', N'IsActive', N'Name', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'CreatedDate', N'Image', N'IsActive', N'Mail', N'Name', N'Password', N'Title', N'UpdatedDate', N'UserName', N'User_ID') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [About], [CreatedDate], [Image], [IsActive], [Mail], [Name], [Password], [Title], [UpdatedDate], [UserName], [User_ID])
VALUES (1, NULL, '2023-03-26T02:16:51.3523280+03:00', NULL, CAST(1 AS bit), N'admin@gmail.com', N'admin', N'1234', N'Manager', NULL, N'admin Name', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'CreatedDate', N'Image', N'IsActive', N'Mail', N'Name', N'Password', N'Title', N'UpdatedDate', N'UserName', N'User_ID') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'IsActive', N'Role_ID', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] ON;
INSERT INTO [UserRoles] ([Id], [CreatedDate], [IsActive], [Role_ID], [UpdatedDate], [User_ID])
VALUES (1, '2023-03-26T02:16:51.3523194+03:00', CAST(1 AS bit), 1, NULL, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'IsActive', N'Role_ID', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] OFF;
GO

CREATE INDEX [IX_Blogs_Category_ID] ON [Blogs] ([Category_ID]);
GO

CREATE INDEX [IX_Blogs_User_ID] ON [Blogs] ([User_ID]);
GO

CREATE INDEX [IX_Categories_User_ID] ON [Categories] ([User_ID]);
GO

CREATE INDEX [IX_Comments_Blog_ID] ON [Comments] ([Blog_ID]);
GO

CREATE INDEX [IX_Comments_User_ID] ON [Comments] ([User_ID]);
GO

CREATE INDEX [IX_Images_Blog_ID] ON [Images] ([Blog_ID]);
GO

CREATE INDEX [IX_Images_User_ID] ON [Images] ([User_ID]);
GO

CREATE INDEX [IX_Roles_User_ID] ON [Roles] ([User_ID]);
GO

CREATE INDEX [IX_UserRoles_Role_ID] ON [UserRoles] ([Role_ID]);
GO

CREATE INDEX [IX_UserRoles_User_ID] ON [UserRoles] ([User_ID]);
GO

CREATE INDEX [IX_Users_User_ID] ON [Users] ([User_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230325231651_ver001', N'7.0.4');
GO

COMMIT;
GO

