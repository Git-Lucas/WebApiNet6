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

CREATE TABLE [Tarefas] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] NVARCHAR(160) NOT NULL,
    [Feito] BIT NOT NULL,
    CONSTRAINT [PK_Tarefas] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221021224145_Inicio', N'6.0.10');
GO

COMMIT;
GO

