BEGIN TRANSACTION;
GO

ALTER TABLE [Player] ADD [Gender] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Player] ADD [TimeReaction] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240509173446_Se agregan las participantes Femeninas', N'8.0.4');
GO

COMMIT;
GO