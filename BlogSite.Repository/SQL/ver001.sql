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
    [Name] nvarchar(50) NOT NULL,
    [UserName] nvarchar(max) NULL,
    [Mail] nvarchar(100) NOT NULL,
    [Title] nvarchar(100) NULL,
    [About] nvarchar(max) NULL,
    [Image] varbinary(max) NULL,
    [Password] nvarchar(50) NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MCategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [IsActive] bit NOT NULL,
    [ReferenceId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_MCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MCategories_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
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

DECLARE @historyTableSchema sysname = SCHEMA_NAME()
EXEC(N'CREATE TABLE [TBlogs] (
    [Id] bigint NOT NULL IDENTITY,
    [Category_ID] int NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Content] nvarchar(150) NOT NULL,
    [Description] nvarchar(max) NULL,
    [LikesNumber] int NOT NULL,
    [DislikesNumber] int NOT NULL,
    [ViewNumber] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [PeriodEnd] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    [PeriodStart] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    CONSTRAINT [PK_TBlogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TBlogs_MCategories_Category_ID] FOREIGN KEY ([Category_ID]) REFERENCES [MCategories] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TBlogs_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION,
    PERIOD FOR SYSTEM_TIME([PeriodStart], [PeriodEnd])
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [' + @historyTableSchema + N'].[TBlogsHistory]))');
GO

CREATE TABLE [UserRoles] (
    [Id] int NOT NULL IDENTITY,
    [Role_ID] int NOT NULL,
    [User_ID] int NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_Role_ID] FOREIGN KEY ([Role_ID]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserRoles_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [TComments] (
    [Id] bigint NOT NULL IDENTITY,
    [Blog_ID] bigint NOT NULL,
    [Parent_ID] bigint NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_TComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TComments_TBlogs_Blog_ID] FOREIGN KEY ([Blog_ID]) REFERENCES [TBlogs] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TComments_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [TImages] (
    [Id] bigint NOT NULL IDENTITY,
    [Blog_ID] bigint NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Image] varbinary(max) NULL,
    [CoverArt] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    CONSTRAINT [PK_TImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TImages_TBlogs_Blog_ID] FOREIGN KEY ([Blog_ID]) REFERENCES [TBlogs] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TImages_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Description', N'IsActive', N'Name', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedDate], [Description], [IsActive], [Name], [UpdatedDate], [User_ID])
VALUES (1, '2023-03-26T03:02:24.1432129+03:00', N'admin rolu tanımlama', CAST(1 AS bit), N'admin', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Description', N'IsActive', N'Name', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'CreatedDate', N'Image', N'IsActive', N'Mail', N'Name', N'Password', N'Title', N'UpdatedDate', N'UserName', N'User_ID') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [About], [CreatedDate], [Image], [IsActive], [Mail], [Name], [Password], [Title], [UpdatedDate], [UserName], [User_ID])
VALUES (1, NULL, '2023-03-26T03:02:24.1432611+03:00', NULL, CAST(1 AS bit), N'admin@gmail.com', N'admin', N'1234', N'Manager', NULL, N'admin Name', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'CreatedDate', N'Image', N'IsActive', N'Mail', N'Name', N'Password', N'Title', N'UpdatedDate', N'UserName', N'User_ID') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'IsActive', N'Role_ID', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] ON;
INSERT INTO [UserRoles] ([Id], [CreatedDate], [IsActive], [Role_ID], [UpdatedDate], [User_ID])
VALUES (1, '2023-03-26T03:02:24.1432507+03:00', CAST(1 AS bit), 1, NULL, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'IsActive', N'Role_ID', N'UpdatedDate', N'User_ID') AND [object_id] = OBJECT_ID(N'[UserRoles]'))
    SET IDENTITY_INSERT [UserRoles] OFF;
GO

CREATE INDEX [IX_MCategories_User_ID] ON [MCategories] ([User_ID]);
GO

CREATE INDEX [IX_Roles_User_ID] ON [Roles] ([User_ID]);
GO

CREATE INDEX [IX_TBlogs_Category_ID] ON [TBlogs] ([Category_ID]);
GO

CREATE INDEX [IX_TBlogs_User_ID] ON [TBlogs] ([User_ID]);
GO

CREATE INDEX [IX_TComments_Blog_ID] ON [TComments] ([Blog_ID]);
GO

CREATE INDEX [IX_TComments_User_ID] ON [TComments] ([User_ID]);
GO

CREATE INDEX [IX_TImages_Blog_ID] ON [TImages] ([Blog_ID]);
GO

CREATE INDEX [IX_TImages_User_ID] ON [TImages] ([User_ID]);
GO

CREATE INDEX [IX_UserRoles_Role_ID] ON [UserRoles] ([Role_ID]);
GO

CREATE INDEX [IX_UserRoles_User_ID] ON [UserRoles] ([User_ID]);
GO

CREATE INDEX [IX_Users_User_ID] ON [Users] ([User_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230326000224_ver001', N'7.0.4');
GO

COMMIT;
GO

