alter PROCEDURE PA_WebinarNotificacion
@idNotificacion int = null,
@idUsuario int = null,
@idWebinar int = null,
@fechaRegistro datetime = null,
@tipo int
as
begin

	if @tipo = 1
		insert into WebinarNotificacion
				(idUsuario, idWebinar, fechaRegistro)
				values(@idUsuario,@idWebinar,@fechaRegistro)
	else if @tipo = 2
		select count(idNotificacion) as notificacion
			from WebinarNotificacion where idUsuario = @idUsuario and idWebinar = @idWebinar

end