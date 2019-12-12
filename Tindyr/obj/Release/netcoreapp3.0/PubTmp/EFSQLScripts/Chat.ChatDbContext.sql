IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143550_chatdbmigration1')
BEGIN
    CREATE TABLE [Conversations] (
        [ConversationId] int NOT NULL IDENTITY,
        [User1Name] nvarchar(max) NULL,
        [User2Name] nvarchar(max) NULL,
        CONSTRAINT [ConversationId] PRIMARY KEY ([ConversationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143550_chatdbmigration1')
BEGIN
    CREATE TABLE [Message] (
        [MessageId] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NULL,
        [Timestamp] nvarchar(max) NULL,
        [FromUser] nvarchar(max) NULL,
        [ToUser] nvarchar(max) NULL,
        [ConversationId] int NOT NULL,
        CONSTRAINT [MessageId] PRIMARY KEY ([MessageId]),
        CONSTRAINT [FK_Message_Conversations_ConversationId] FOREIGN KEY ([ConversationId]) REFERENCES [Conversations] ([ConversationId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143550_chatdbmigration1')
BEGIN
    CREATE INDEX [IX_Message_ConversationId] ON [Message] ([ConversationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143550_chatdbmigration1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191210143550_chatdbmigration1', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210180025_chatdbmigration4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191210180025_chatdbmigration4', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001556_ChatDbTestReady')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212001556_ChatDbTestReady', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212174238_ChatDbTestReady4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212174238_ChatDbTestReady4', N'3.0.0');
END;

GO

