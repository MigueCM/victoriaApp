USE [db_victoria]
GO

/****** Object:  StoredProcedure [dbo].[PA_Persona]    Script Date: 22/07/2020 19:42:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PA_Persona] 
	-- Add the parameters for the stored procedure here
	@Id int = null
  ,@Nombre varchar(100) = null
  ,@Apellidos varchar(100) = null
  ,@FechaNacimiento datetime
  ,@Sexo varchar(20) = null
  ,@Celular varchar(13) = null
  ,@Pais varchar(50) = null
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
	SET NOCOUNT ON;

    --Registrar Persona
	IF @Tipo = 1
		INSERT INTO [dbo].[Persona](Nombre, Apellidos, FechaNacimiento, Sexo, Celular, Pais, Ciudad, Avatar, Enteraste, FechaRegistro, FechaUltimaModificacion)
		VALUES(@Nombre, @Apellidos, @FechaNacimiento, @Sexo, @Celular, @Pais, @Ciudad, @Avatar, @Enteraste, GETDATE(), GETDATE())
		SELECT SCOPE_IDENTITY() as ID;
END
GO


