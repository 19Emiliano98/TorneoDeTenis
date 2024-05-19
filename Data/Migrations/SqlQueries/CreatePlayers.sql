USE [TenisTournament]
GO

INSERT INTO [dbo].[Player]
           ([Name]
           ,[Luck]
           ,[Hability]
           ,[Strenght]
           ,[Speed]
           ,[Gender]
           ,[TimeReaction])
     VALUES
			( 'Facundo', null, 40, 80, 32, 'Male', 35 ),
			( 'Matias', null, 20, 60, 40, 'Male', 32 ),
			( 'Lautaro', null, 30, 61, 39, 'Male', 31 ),
			( 'Emiliano', null, 40, 65, 34, 'Male', 37 ),
			( 'Carlos', null, 15, 59, 35, 'Male', 36 ),
			( 'Gustavo', null, 30, 69, 31, 'Male', 35 ),
			( 'Roque', null, 20, 49, 70, 'Male', 33 ),
			( 'Joaquin', null, 10, 50, 47, 'Male', 35 ),

			( 'Alumine', null, 40, 25, 35, 'Female', 35 ),
			( 'Florencia', null, 20, 28, 40, 'Female', 32 ),
			( 'Julieta', null, 30, 30, 39, 'Female', 31 ),
			( 'Noelia', null, 40, 35, 34, 'Female', 37 ),
			( 'Giusmina', null, 15, 34, 35, 'Female', 36 ),
			( 'Luciana', null, 30, 37, 37, 'Female', 35 ),
			( 'Silvina', null, 20, 20, 40, 'Female', 33 ),
			( 'Nadia', null, 10, 15, 43, 'Female', 35 )
GO


