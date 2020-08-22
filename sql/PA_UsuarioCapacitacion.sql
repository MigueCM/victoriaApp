USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_UsuarioCapacitacion]    Script Date: 22/08/2020 16:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PA_UsuarioCapacitacion]
@idUsuarioCapacitacion int = null,
@idUsuario int = null,
@idModuloCapacitacion int = null,
@fechaRegistro datetime = null,
@fechaActualizacion datetime = null,
@completado bit = null,
@iniciado bit = null,
@nota int = null,
@aprobado bit = null,
@calificacion int = null,
@tipo int
as
begin

	if @tipo = 1
	begin	

		/*DECLARE @num_intentos int

		select @num_intentos = isnull(max(uc.intentos),0) from UsuarioCapacitacion uc where uc.idUsuario  = @idUsuario and uc.idModuloCapacitacion = @idModuloCapacitacion

		set @num_intentos = @num_intentos + 1*/

		DECLARE @cant_modulos int

		select @cant_modulos = count(idModuloCapacitacion) from UsuarioCapacitacion where idUsuario = @idUsuario and idModuloCapacitacion = @idModuloCapacitacion

		if @cant_modulos > 0
		begin
			
			DECLARE @id int

			select @id = idUsuarioCapacitacion from UsuarioCapacitacion where idUsuario = @idUsuario and idModuloCapacitacion = @idModuloCapacitacion

			update UsuarioCapacitacion
				set FechaActualizacion = @fechaActualizacion,
					Calificacion = @calificacion,
					Aprobado = @aprobado,
					Nota = @nota
				where idUsuarioCapacitacion = @id

			delete from UsuarioPregunta where idUsuarioCapacitacion in (@id)
			SELECT @id as ID;

		end
		else
		begin
			insert into UsuarioCapacitacion(idUsuario,idModuloCapacitacion,FechaRegistro,FechaActualizacion,Completado,Iniciado,Calificacion, Intentos, Aprobado, Nota)
				values(@idUsuario,@idModuloCapacitacion,@fechaRegistro,@fechaActualizacion,@completado,@iniciado,@calificacion, 1 , @aprobado, @nota);
		
			SELECT SCOPE_IDENTITY() as ID;

		end

		
	end
	else if @tipo = 4
	begin
		
		DECLARE @tol_modulos int
		DECLARE @tol_avance float

		SELECT @tol_modulos = count(idModuloCapacitacion)
			from ModuloCapacitacion where estado = 1

		select @tol_avance = count(uc.idUsuarioCapacitacion)
			from UsuarioCapacitacion uc
			inner join ModuloCapacitacion mc on uc.idModuloCapacitacion = mc.idModuloCapacitacion
			where uc.idUsuario = @idUsuario and mc.estado = 1 --and uc.Intentos = 1

		select CAST((@tol_avance / @tol_modulos)*100 AS INT) as por_avance
	end
	else if @tipo = 5
	begin
		select isnull(max(idModuloCapacitacion),0) as modulo from UsuarioCapacitacion where idUsuario = @idUsuario and Aprobado = 1
	end
	else if @tipo = 6
	begin

		select isnull(avg(uc.calificacion),0) calificacion from UsuarioCapacitacion uc where uc.idModuloCapacitacion = @idModuloCapacitacion

	end
	else if @tipo = 7
	begin

		select isnull(max(uc.intentos),0) intentos  from UsuarioCapacitacion uc where uc.idUsuario  = @idUsuario and uc.idModuloCapacitacion = @idModuloCapacitacion

	end

	else if @tipo = 8
	begin

		select count(idUsuarioCapacitacion) visualizacion  from UsuarioCapacitacion uc where uc.idModuloCapacitacion = @idModuloCapacitacion

	end

	else if @tipo = 9
	begin

		select isnull(uc.Aprobado,0) aprobado  from UsuarioCapacitacion uc where uc.idUsuario  = @idUsuario and uc.idModuloCapacitacion = @idModuloCapacitacion

	end

end


