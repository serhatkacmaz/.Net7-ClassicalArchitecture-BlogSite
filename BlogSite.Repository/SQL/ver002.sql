BEGIN TRANSACTION;
GO

ALTER TABLE [TBlogs] SET (SYSTEM_VERSIONING = OFF)

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'DislikesNumber');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TBlogs] DROP COLUMN [DislikesNumber];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'DislikesNumber');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TBlogsHistory] DROP COLUMN [DislikesNumber];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'LikesNumber');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [TBlogs] DROP COLUMN [LikesNumber];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'LikesNumber');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [TBlogsHistory] DROP COLUMN [LikesNumber];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'ViewNumber');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [TBlogs] ALTER COLUMN [ViewNumber] int NOT NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'ViewNumber');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [TBlogsHistory] ALTER COLUMN [ViewNumber] int NOT NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'User_ID');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [TBlogs] ALTER COLUMN [User_ID] int NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'User_ID');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [TBlogsHistory] ALTER COLUMN [User_ID] int NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'UpdatedDate');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [TBlogs] ALTER COLUMN [UpdatedDate] datetime2 NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'UpdatedDate');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [TBlogsHistory] ALTER COLUMN [UpdatedDate] datetime2 NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'IsActive');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [TBlogs] ALTER COLUMN [IsActive] bit NOT NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'IsActive');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [TBlogsHistory] ALTER COLUMN [IsActive] bit NOT NULL;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogs]') AND [c].[name] = N'CreatedDate');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [TBlogs] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [TBlogs] ALTER COLUMN [CreatedDate] datetime2 NOT NULL;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TBlogsHistory]') AND [c].[name] = N'CreatedDate');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [TBlogsHistory] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [TBlogsHistory] ALTER COLUMN [CreatedDate] datetime2 NOT NULL;
GO

CREATE TABLE [TMovement] (
    [Id] bigint NOT NULL IDENTITY,
    [Blog_ID] bigint NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [User_ID] int NULL,
    [EUserReaction] tinyint NOT NULL,
    CONSTRAINT [PK_TMovement] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TMovement_TBlogs_Blog_ID] FOREIGN KEY ([Blog_ID]) REFERENCES [TBlogs] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TMovement_Users_User_ID] FOREIGN KEY ([User_ID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

UPDATE [Roles] SET [CreatedDate] = '2023-03-26T03:40:03.7589287+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [UserRoles] SET [CreatedDate] = '2023-03-26T03:40:03.7589626+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [CreatedDate] = '2023-03-26T03:40:03.7589724+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TMovement_Blog_ID] ON [TMovement] ([Blog_ID]);
GO

CREATE INDEX [IX_TMovement_User_ID] ON [TMovement] ([User_ID]);
GO

DECLARE @historyTableSchema sysname = SCHEMA_NAME()
EXEC(N'ALTER TABLE [TBlogs] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [' + @historyTableSchema + '].[TBlogsHistory]))')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230326004003_ver002', N'7.0.4');
GO

COMMIT;
GO

