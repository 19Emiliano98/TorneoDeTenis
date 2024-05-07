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

CREATE TABLE [Player] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(26) NOT NULL,
    [Luck] int NOT NULL,
    [Strenght] int NOT NULL,
    [Speed] int NOT NULL,
    [Hability] int NOT NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Match] (
    [Id] int NOT NULL IDENTITY,
    [IdWinner] int NOT NULL,
    [IdLoser] int NOT NULL,
    CONSTRAINT [PK_Match] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Match_Loser] FOREIGN KEY ([IdLoser]) REFERENCES [Player] ([Id]),
    CONSTRAINT [FK_Match_Winner] FOREIGN KEY ([IdWinner]) REFERENCES [Player] ([Id])
);
GO

CREATE TABLE [MatchHistory] (
    [Id] int NOT NULL IDENTITY,
    [IdTournament] int NOT NULL,
    [IdMatch] int NOT NULL,
    CONSTRAINT [PK_MatchHistory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MatchHistory_Match] FOREIGN KEY ([IdMatch]) REFERENCES [Match] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HistoryTournament] (
    [Id] int NOT NULL IDENTITY,
    [IdPlayer] int NOT NULL,
    [IdHistoryMatch] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_HistoryTournament] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoryTournament_MatchHistory] FOREIGN KEY ([IdHistoryMatch]) REFERENCES [MatchHistory] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HistoryTournament_Player] FOREIGN KEY ([IdPlayer]) REFERENCES [Player] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_HistoryTournament_IdHistoryMatch] ON [HistoryTournament] ([IdHistoryMatch]);
GO

CREATE INDEX [IX_HistoryTournament_IdPlayer] ON [HistoryTournament] ([IdPlayer]);
GO

CREATE INDEX [IX_Match_IdLoser] ON [Match] ([IdLoser]);
GO

CREATE INDEX [IX_Match_IdWinner] ON [Match] ([IdWinner]);
GO

CREATE INDEX [IX_MatchHistory_IdMatch] ON [MatchHistory] ([IdMatch]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240507164943_Primera Migracion', N'8.0.4');
GO

COMMIT;
GO

