      
      
      
     CREATE TABLE [Users] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          [Password] nvarchar(max) NOT NULL,
          [RefeshToken] nvarchar(max) NULL,
          [RefeshTokenExpiration] datetime2 NULL,
          CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
      );