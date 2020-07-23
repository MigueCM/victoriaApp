USE [db_victoria]
GO

/****** Object:  Table [dbo].[Persona]    Script Date: 22/07/2020 19:42:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Sexo] [varchar](20) NOT NULL,
	[Celular] [varchar](13) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[Avatar] [varchar](max) NULL,
	[Enteraste] [varchar](100) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaUltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


