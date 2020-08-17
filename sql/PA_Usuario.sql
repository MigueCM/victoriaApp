USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_Usuario]    Script Date: 17/08/2020 1:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER   PROCEDURE [dbo].[PA_Usuario]
@idUsuario int = null,
@user varchar(50) = null,
@password varchar(100) = null,
@idPerfil int = null,
@idPersona int = null,
@idUsuarioRegistro int = null,
@fechaRegistro datetime = null,
@token varchar(20) = null,
@fechaToken datetime = null,
@idUsuarioEdicion int = null,
@fechaEdicion datetime = null,
@tipo int
as
begin
	if @tipo = 1
		insert into [dbo].[usuario]([user], [password],[idPerfil],[idUsuarioRegistro], [fechaRegistro],[idPersona],estado)
		values(@user, @password,@idPerfil, @idUsuarioRegistro, GETDATE() , @idPersona , 1)
	else if @tipo = 2
		update usuario set idPerfil = @idPerfil,
						idUsuarioEdicion = @idUsuarioEdicion,
						fechaEdicion = @fechaEdicion
						where idUsuario = @idUsuario
						
	else if @tipo = 4

		select idUsuario,
				[user],
				idPerfil,
				p.Id as idPersona,
				p.Nombre,
				p.Apellidos,
				p.Avatar,
				p.Dni,
				d.[name] as Distrito,
				dp.[name] as Departamento
		from usuario u
		left join persona p on u.idPersona = p.Id
		inner join [ubigeo_peru_districts] d on d.Id = p.Departamento
		inner join [ubigeo_peru_departments] dp on dp.Id = d.department_id
		where [user] = @user and password = @password and estado = 1

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
			
			--Verificar Existe Correo
	else if @Tipo = 10
		SELECT COUNT([user]) as Existe FROM usuario WHERE [user] like @user
		-- Obtener Todos los usuario
	else if @tipo = 11
		select u.idUsuario, u.idPersona, u.idPerfil , pe.Nombre as perfil, u.[user] ,  p.Nombre , p.Apellidos
			from usuario u
			inner join Persona p on u.idPersona = p.Id
			inner join Perfil pe on u.idPerfil = pe.Id
			where u.estado = 1
	else if @tipo = 12
		select u.idUsuario, u.idPersona, u.idPerfil , u.[user] ,  p.Nombre , p.Apellidos,
		p.Dni,p.FechaNacimiento,p.Sexo
			from usuario u
			inner join Persona p on u.idPersona = p.Id
			where u.idUsuario = @idUsuario
		
	else if @tipo = 13
		update usuario
			set estado = 0
			where idUsuario = @idUsuario

end
