USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_TerminosCondiciones]    Script Date: 17/08/2020 1:41:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PA_TerminosCondiciones]
	-- Add the parameters for the stored procedure here
	@Tipo int = null,
	@Titulo varchar(MAX) = null,
	@Descripcion varchar(MAX) = null,
	@FechaCreacion datetime = null,
	@Usuario varchar(8) = null,
	@FechaMov datetime = null
AS
BEGIN
	IF @Tipo = 1
		INSERT INTO [dbo].[TerminosCondiciones]
           ([Titulo]
           ,[Descripcion]
           ,[Usuario]
           ,[FechaCreacion])
		 VALUES
			   (@Titulo, @Descripcion, @Usuario, GETDATE())

	IF @Tipo = 2
		SELECT TOP 1 [Titulo], [Descripcion] FROM [dbo].[TerminosCondiciones] ORDER BY FechaCreacion DESC
END
