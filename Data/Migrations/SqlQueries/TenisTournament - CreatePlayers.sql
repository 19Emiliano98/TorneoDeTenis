USE [TenisTournament]
GO

INSERT INTO [dbo].[Player]
           ([Name]
           ,[Luck]
           ,[Strenght]
           ,[Speed]
		   ,[Hability])
     VALUES
           ( 'Facundo Villalobo', 0, 80, 32,40 ),
		   ( 'Matias Corredera', 0, 60, 40,32 ),
		   ( 'Lautaro De Simeone', 0, 61, 39,40 ),
		   ( 'Emiliano Caballero', 0, 65, 34,43 ),
		   ( 'Carlos Palladino', 0, 59, 35,25 ),
		   ( 'Gustavo Lucci', 0, 69, 31,52 ),
		   ( 'Roque Olguin', 0, 49, 70,42 ),
		   ( 'Joaquin Martinez', 0, 50, 47,43 )




GO

USE [TenisTournament]
GO

INSERT INTO [dbo].[Users]
           ([Name]
           ,[Password]
           ,[RefeshToken]
           ,[RefeshTokenExpiration])
     VALUES
          ('sarasa@gmail.com','Tarata',NUll,NULL)
          
GO





