CREATE OR ALTER PROCEDURE PA_UsuarioHistorial
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