USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_ModuloCapacitacion]    Script Date: 22/08/2020 14:10:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PA_ModuloCapacitacion]
@idModuloCapacitacion int = null,
@nombre varchar(200) = null, 
@descripcion varchar(max) = null, 
@nro int = null, 
@autor varchar(100) = null, 
@enlace varchar(500) = null, 
@imagen varchar(100) = null, 
@idUsuarioRegistro int = null, 
@fechaRegistro datetime = null, 
@estado bit = null,
@idUsuario int = null,
@tipo int
as
begin

	if @tipo = 1
	BEGIN

		DECLARE @orden int

		SELECT @orden = isnull(max(Nro),0)
		FROM ModuloCapacitacion 

		insert into ModuloCapacitacion (Nombre , Descripcion , Nro , Autor , Enlace, Imagen, idUsuarioRegistro , fechaRegistro , estado)
		values(
		@nombre,
		@descripcion,
		@orden + 1,
		@autor,
		@enlace,
		@imagen,
		@idUsuarioRegistro,
		@fechaRegistro,
		@estado
		);

	END
	else if @tipo = 2

		update ModuloCapacitacion
			set Nombre = @nombre,
				Descripcion = @descripcion,
				Autor = @autor,
				Enlace = @enlace,
				Imagen = @imagen
			where idModuloCapacitacion = @idModuloCapacitacion
	else if @tipo = 3
		delete from ModuloCapacitacion where idModuloCapacitacion = @idModuloCapacitacion

	else if @tipo = 4
		
		SELECT        m.idModuloCapacitacion, m.Nombre, m.Descripcion, m.Nro, m.Autor, isnull(m.Enlace,'') as Enlace, m.Imagen ,
				isnull(u.Completado,0) Completado , u.fechaActualizacion ,
				(select isnull(max(uc.intentos),0) from UsuarioCapacitacion uc where uc.idUsuario  = @idUsuario and uc.idModuloCapacitacion = m.idModuloCapacitacion) as intentos,
				isnull(u.aprobado,0) as Aprobado
			FROM            moduloCapacitacion m 
			LEFT JOIN usuarioCapacitacion u on m.idModuloCapacitacion = u.idModuloCapacitacion and  u.idUsuario = @idUsuario --and u.Intentos = 1
			where m.estado = 1 order by m.Nro
	else if @tipo = 5
		SELECT        m.idModuloCapacitacion, m.Nombre, m.Descripcion, m.Nro, m.Autor, isnull(m.Enlace,'') as Enlace, m.Imagen,
		isnull((select avg(uc.calificacion) from UsuarioCapacitacion uc where m.idModuloCapacitacion = uc.idModuloCapacitacion),0) as calificacion
			FROM    moduloCapacitacion m where m.estado = 1 order by m.Nro
	else if @tipo = 6
		SELECT        idModuloCapacitacion, Nombre, Descripcion, Nro, Autor, Enlace, Imagen, idUsuarioRegistro, 
			fechaRegistro, estado
		FROM            ModuloCapacitacion where idModuloCapacitacion = @idModuloCapacitacion and estado = 1
	else if @tipo = 7
		update ModuloCapacitacion set estado = 0 where idModuloCapacitacion = @idModuloCapacitacion
	else if @tipo = 8
		
		SELECT        m.idModuloCapacitacion, m.Nombre, m.Descripcion, m.Nro, m.Autor, isnull(m.Enlace,'') as Enlace, m.Imagen ,
				isnull(u.Completado,0) Completado , u.fechaActualizacion,
				isnull((select avg(uc.calificacion) from UsuarioCapacitacion uc where m.idModuloCapacitacion = uc.idModuloCapacitacion),0) as calificacion
			FROM            moduloCapacitacion m 
			LEFT JOIN usuarioCapacitacion u on m.idModuloCapacitacion = u.idModuloCapacitacion and  u.idUsuario = @idUsuario --and u.Intentos = 1
			where m.estado = 1 order by m.Nro
	else if @tipo = 9
		SELECT        m.idModuloCapacitacion,
				isnull(u.Completado,0) Completado,
				isnull(u.Aprobado,0) Aprobado
			FROM            moduloCapacitacion m 
			LEFT JOIN usuarioCapacitacion u on m.idModuloCapacitacion = u.idModuloCapacitacion and  u.idUsuario = @idUsuario --and u.Intentos = 1
			where m.estado = 1 order by m.Nro

	if @tipo = 10
		SELECT        m.idModuloCapacitacion, m.Nombre
			FROM            moduloCapacitacion m 
			LEFT JOIN usuarioCapacitacion u on m.idModuloCapacitacion = u.idModuloCapacitacion and  u.idUsuario = @idUsuario --and u.Intentos = 1
			where m.estado = 1 and u.Completado=1 order by m.Nro
end
