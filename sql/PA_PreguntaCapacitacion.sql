USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_PreguntaCapacitacion]    Script Date: 17/08/2020 1:41:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PA_PreguntaCapacitacion]
@idPreguntaCapacitacion int = null,
@idModuloCapacitacion int = null,
@descripcion varchar(max) = null,
@nro int = null,
@alternativa1 varchar(500) = null,
@alternativa2 varchar(500) = null,
@alternativa3 varchar(500) = null,
@alternativa4 varchar(500) = null,
@alternativa5 varchar(500) = null,
@respuesta char(1) = null,
@tipo int
AS
BEGIN

	if @tipo = 1
	BEGIN
		
		update PreguntaCapacitacion set Nro = Nro + 1 where Nro >= @nro and idModuloCapacitacion = @idModuloCapacitacion

		insert into PreguntaCapacitacion(idModuloCapacitacion , Descripcion, Alternativa1, Alternativa2, Alternativa3, Alternativa4, Alternativa5, Respuesta, Nro)
			values(@idModuloCapacitacion,
					@descripcion,
					@alternativa1,
					@alternativa2,
					@alternativa3,
					@alternativa4,
					@alternativa5,
					@respuesta,
					@nro);
	END

	else if @tipo = 2
	BEGIN

		declare @ordenActual int

		select @ordenActual = Nro from PreguntaCapacitacion where idPreguntaCapacitacion = @idPreguntaCapacitacion
		
		update PreguntaCapacitacion set Nro = @ordenActual where Nro = @nro and idModuloCapacitacion = @idModuloCapacitacion

		update PreguntaCapacitacion 
			set Descripcion = @descripcion,
				Nro = @nro,
				Alternativa1 = @alternativa1,
				Alternativa2 = @alternativa2,
				Alternativa3 = @alternativa3,
				Alternativa4 = @alternativa4,
				Alternativa5 = @alternativa5,
				Respuesta = @respuesta
			where idPreguntaCapacitacion = @idPreguntaCapacitacion 
	END
	else if @tipo = 3
		DELETE FROM PreguntaCapacitacion where idPreguntaCapacitacion = @idPreguntaCapacitacion
	else if @tipo = 4
		
		SELECT        idPreguntaCapacitacion, idModuloCapacitacion, Descripcion, Nro, Alternativa1, Alternativa2, Alternativa3, Alternativa4, Alternativa5, Respuesta
			FROM            PreguntaCapacitacion where idModuloCapacitacion = @idModuloCapacitacion order by Nro
	else if @tipo = 5
		
		SELECT        idPreguntaCapacitacion, idModuloCapacitacion, Descripcion, Nro, Alternativa1, Alternativa2, Alternativa3, Alternativa4, Alternativa5, Respuesta
			FROM            PreguntaCapacitacion where idPreguntaCapacitacion = @idPreguntaCapacitacion
	else if @tipo = 6
		
		select ISNULL(MAX(nro) , 0) as Orden
			from PreguntaCapacitacion where idModuloCapacitacion = @idModuloCapacitacion
	

END