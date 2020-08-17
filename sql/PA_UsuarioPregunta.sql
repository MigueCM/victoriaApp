USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_UsuarioPregunta]    Script Date: 17/08/2020 1:44:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PA_UsuarioPregunta]
@idUsuarioPregunta int = null,
@idUsuarioCapacitacion int = null,
@idPreguntaCapacitacion int = null,
@respuesta char(1) = null,
@tipo int
as
BEGIN

	if @tipo = 1
		
		insert into UsuarioPregunta(idUsuarioCapacitacion,idPreguntaCapacitacion,Respuesta)
			values(@idUsuarioCapacitacion, @idPreguntaCapacitacion , @respuesta)
			

END