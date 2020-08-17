USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_Webinar]    Script Date: 17/08/2020 1:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   procedure [dbo].[PA_Webinar]
@id int = null,
@titulo varchar(100) = null,
@autor varchar(50) = null,
@imagen varchar(200) = null,
@descripcion varchar(max) = null,
@idUsuarioRegistro int = null,
@fechaRegistro datetime = null,
@idUsuarioEdicion int = null,
@fechaEdicion datetime = null,
@tipo int
as
begin

	if @tipo = 1
		insert into Webinar(titulo, autor, imagen, descripcion, idUsuarioRegistro, fechaRegistro)
			values(@titulo, @autor, @imagen, @descripcion, @idUsuarioRegistro , @fechaRegistro)
	else if @tipo = 2
		update Webinar set titulo = @titulo,
							autor = @autor,
							imagen = @imagen,
							descripcion = @descripcion,
							idUsuarioEdicion = @idUsuarioEdicion,
							fechaEdicion = @fechaEdicion
						where id = @id
	else if @tipo = 3
		delete from Webinar where id = @id
	else if @tipo = 4
		SELECT        id, titulo, autor, imagen, descripcion, idUsuarioRegistro, fechaRegistro, idUsuarioEdicion, fechaEdicion
			FROM            Webinar
	else if @tipo = 5
		SELECT        id, titulo, autor, imagen, descripcion, idUsuarioRegistro, fechaRegistro, idUsuarioEdicion, fechaEdicion
			FROM            Webinar where id = @id


end