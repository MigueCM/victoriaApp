USE [DB_137602_victoria]
GO
/****** Object:  StoredProcedure [dbo].[PA_Perfil]    Script Date: 17/08/2020 1:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PA_Perfil]
@tipo int
as
begin

	if @tipo = 4
	begin
		
		select Id as idPerfil,
				Nombre as Perfil
			from Perfil

	end

end
