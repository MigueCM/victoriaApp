USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_UsuarioHistorial]    Script Date: 17/08/2020 1:43:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PA_UsuarioHistorial]
@idHistorial int = null,
@idUsuario int = null,
@fechaSesion datetime = null,
@tipo int
AS
begin

	if @tipo = 1

		insert into usuario_historial(idUsuario, fechaSesion)
			values( @idUsuario , @fechaSesion) 




end
