
CREATE OR ALTER PROCEDURE PA_Usuario
@idUsuario int = null,
@user varchar(50) = null,
@password varchar(100) = null,
@idPerfil int = null,
@idUsuarioRegistro int = null,
@fechaRegistro datetime = null,
@token varchar(20) = null,
@fechaToken datetime = null,
@tipo int
as
begin

	if @tipo = 4

		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where [user] = @user and password = @password

	else if @tipo = 5
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where [user] = @user

	else if @tipo = 6
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where idUsuario = @idUsuario

	else if @tipo = 7
		
		update usuario
		set token = @token,
			fechaToken = @fechaToken
		where idUsuario = @idUsuario

	else if @tipo = 8
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where token = @token and 
			GETDATE() < DATEADD(day, 1, fechaToken)

	else if @tipo = 9
		
		update usuario
		set password = @password
		where idUsuario = @idUsuario
			



end
