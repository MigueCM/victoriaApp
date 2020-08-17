USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_Foro]    Script Date: 17/08/2020 1:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PA_Foro] 
	@Id int = null
	,@IdUsuario int = null
	,@Titulo varchar(max) = null
	,@Contenido varchar(max) = null
	,@IdUsuarioRespuesta int = null
	,@Respuesta varchar(max) = null
	,@FechaPregunta datetime = null
	,@FechaRespuesta datetime = null
	,@IdModulo int = null
	,@Votado int = null
	,@Tipo int 
AS
BEGIN

	IF @Tipo = 1
		INSERT INTO [dbo].[Foro] ([IdUsuario] ,[Titulo] ,[Contenido] ,[FechaPregunta] ,[IdModulo],[Votado])
			 VALUES (@IdUsuario ,@Titulo ,@Contenido ,GETDATE() ,@IdModulo ,@Votado)

	IF @Tipo = 2
		SELECT F.Id, F.Titulo, F.Contenido, F.FechaPregunta, F.Votado, P.Nombre, P.Apellidos, P.Avatar, F.Respuesta 
		FROM [dbo].[Foro] F
		INNER JOIN usuario U on U.idUsuario = F.IdUsuario
		INNER JOIN Persona P on P.Id = U.idPersona

	IF @Tipo = 3
		UPDATE [dbo].[Foro]
			SET Votado = Votado + 1
			
			WHERE Id = @Id
	IF @Tipo = 4
		SELECT F.Votado 
		FROM [dbo].[Foro] F WHERE Id = @Id

	IF @Tipo = 5
		SELECT F.Id, F.Titulo, F.Contenido, P.Nombre, P.Apellidos 
		FROM [dbo].[Foro] F
		INNER JOIN usuario U on U.idUsuario = F.IdUsuario
		INNER JOIN Persona P on P.Id = U.idPersona
		WHERE F.Id = @Id

	IF @Tipo = 6
		UPDATE [dbo].[Foro]
			SET Respuesta = @Respuesta, [FechaRespuesta] = GETDATE(),[IdUsuarioRespuesta] =@IdUsuarioRespuesta
			WHERE Id = @Id

	IF @Tipo = 7
		SELECT F.Id, F.Titulo, F.Respuesta, P.Nombre, P.Apellidos , P.Avatar, F.FechaRespuesta
		FROM [dbo].[Foro] F
		INNER JOIN usuario U on U.idUsuario = F.IdUsuarioRespuesta
		INNER JOIN Persona P on P.Id = U.idPersona
		WHERE F.Id = @Id
END
