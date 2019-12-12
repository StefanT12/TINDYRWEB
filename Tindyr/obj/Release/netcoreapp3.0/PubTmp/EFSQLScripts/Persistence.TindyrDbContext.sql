IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143758_tindyrdbmigration1')
BEGIN
    CREATE TABLE [Matches] (
        [MatchId] int NOT NULL IDENTITY,
        [User2LikedBack] bit NOT NULL,
        [User1] nvarchar(max) NULL,
        [User2] nvarchar(max) NULL,
        CONSTRAINT [PK_Matches] PRIMARY KEY ([MatchId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143758_tindyrdbmigration1')
BEGIN
    CREATE TABLE [Users] (
        [UserID] int NOT NULL IDENTITY,
        [Username] nvarchar(60) NULL,
        [Password] nvarchar(60) NULL,
        [Role] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143758_tindyrdbmigration1')
BEGIN
    CREATE TABLE [UserProfiles] (
        [ProfileID] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [ProfileOf] int NOT NULL,
        CONSTRAINT [ProfileID] PRIMARY KEY ([ProfileID]),
        CONSTRAINT [FK_UserProfiles_Users] FOREIGN KEY ([ProfileOf]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143758_tindyrdbmigration1')
BEGIN
    CREATE UNIQUE INDEX [IX_UserProfiles_ProfileOf] ON [UserProfiles] ([ProfileOf]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191210143758_tindyrdbmigration1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191210143758_tindyrdbmigration1', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    ALTER TABLE [Matches] DROP CONSTRAINT [PK_Matches];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    ALTER TABLE [Matches] ADD CONSTRAINT [MatchId] PRIMARY KEY ([MatchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    CREATE TABLE [Animals] (
        [AnimalId] int NOT NULL IDENTITY,
        [AnimalName] nvarchar(max) NULL,
        [AnimalGender] nvarchar(max) NULL,
        [AnimalType] nvarchar(max) NULL,
        [AnimalBreed] nvarchar(max) NULL,
        [LookingFor] nvarchar(max) NULL,
        [AnimalDateOfBirth] datetime2 NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [AnimalId] PRIMARY KEY ([AnimalId]),
        CONSTRAINT [FK_Animals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    CREATE TABLE [Picture] (
        [Id] int NOT NULL IDENTITY,
        [FileName] nvarchar(max) NULL,
        [AnimalId] int NOT NULL,
        CONSTRAINT [Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Picture_Animals_AnimalId] FOREIGN KEY ([AnimalId]) REFERENCES [Animals] ([AnimalId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    CREATE UNIQUE INDEX [IX_Animals_UserId] ON [Animals] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    CREATE INDEX [IX_Picture_AnimalId] ON [Picture] ([AnimalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212001451_TindyrDbTestReady')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212001451_TindyrDbTestReady', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    DROP INDEX [IX_Picture_AnimalId] ON [Picture];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    ALTER TABLE [Picture] ADD [AnimalId1] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    ALTER TABLE [Animals] ADD [FrontPictureId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    CREATE UNIQUE INDEX [IX_Picture_AnimalId] ON [Picture] ([AnimalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    CREATE INDEX [IX_Picture_AnimalId1] ON [Picture] ([AnimalId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    ALTER TABLE [Picture] ADD CONSTRAINT [FK_Picture_Animals_AnimalId1] FOREIGN KEY ([AnimalId1]) REFERENCES [Animals] ([AnimalId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212172507_TindyrDbTestReady4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212172507_TindyrDbTestReady4', N'3.0.0');
END;

GO

