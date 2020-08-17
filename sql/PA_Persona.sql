USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_Persona]    Script Date: 17/08/2020 1:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PA_Persona] 
	-- Add the parameters for the stored procedure here
	@Id int = null
  ,@Nombre varchar(100) = null
  ,@Apellidos varchar(100) = null
  ,@Dni varchar(8)=null
  ,@FechaNacimiento datetime = null
  ,@Sexo varchar(20) = null
  ,@Celular varchar(13) = null
  ,@Departamento varchar(50) = null
  ,@Ciudad varchar(50) = null
  ,@Avatar varchar(MAX) = null
  ,@Enteraste varchar(100) = null
  ,@FechaRegistro datetime = null
  ,@FechaUltimaModificacion datetime =null
  ,@Tipo int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    --Registrar Persona
	IF @Tipo = 1
		begin
			INSERT INTO [dbo].[Persona](Nombre, Apellidos, Dni, FechaNacimiento, Sexo, Celular, Departamento, Ciudad, Avatar, Enteraste, FechaRegistro, FechaUltimaModificacion)
			VALUES(@Nombre, @Apellidos, @Dni, @FechaNacimiento, @Sexo, @Celular, @Departamento, @Ciudad, @Avatar, @Enteraste, GETDATE(), GETDATE())
			SELECT SCOPE_IDENTITY() as ID;
		end
	else IF @Tipo = 2
		UPDATE [dbo].[Persona]
		   SET [Avatar] = @Avatar
			  ,[FechaUltimaModificacion] = GETDATE()
		 WHERE Id = @Id

	 else IF @Tipo = 3
		SELECT [Avatar] FROM Persona WHERE Id = @Id

	else if @Tipo = 4
		update Persona 
			set Nombre = @Nombre,
				Apellidos = @Apellidos,
				Dni = @Dni,
				FechaNacimiento = @FechaNacimiento,
				Sexo = @Sexo,
				FechaUltimaModificacion = @FechaUltimaModificacion
				where Id = @Id
END
