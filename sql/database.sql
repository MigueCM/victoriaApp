USE [master]
GO
/****** Object:  Database [db_victoria]    Script Date: 19/07/2020 2:32:57 ******/
CREATE DATABASE [db_victoria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_victoria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_victoria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_victoria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_victoria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_victoria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_victoria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_victoria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_victoria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_victoria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_victoria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_victoria] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_victoria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_victoria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_victoria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_victoria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_victoria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_victoria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_victoria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_victoria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_victoria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_victoria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_victoria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_victoria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_victoria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_victoria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_victoria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_victoria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_victoria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_victoria] SET RECOVERY FULL 
GO
ALTER DATABASE [db_victoria] SET  MULTI_USER 
GO
ALTER DATABASE [db_victoria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_victoria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_victoria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_victoria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_victoria] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_victoria', N'ON'
GO
ALTER DATABASE [db_victoria] SET QUERY_STORE = OFF
GO
USE [db_victoria]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 19/07/2020 2:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[user] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[idPerfil] [int] NULL,
	[idUsuarioRegistro] [int] NULL,
	[fechaRegistro] [datetime] NULL,
	[token] [varchar](20) NULL,
	[fechaToken] [datetime] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [user], [password], [idPerfil], [idUsuarioRegistro], [fechaRegistro], [token], [fechaToken]) VALUES (1, N'admin@hotmail.com', N'x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A==', 1, 1, CAST(N'2020-07-18T23:51:27.910' AS DateTime), N'PFW42eLX50', CAST(N'2020-07-19T01:59:55.047' AS DateTime))
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[PA_Usuario]    Script Date: 19/07/2020 2:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[PA_Usuario]
@idUsuario int = null,
@user varchar(50) = null,
@password varchar(100) = null,
@idPerfil int = null,
@idUsuarioRegistro int = null,
@fechaRegistro datetime = null,
@token varchar(20) = null,
@fechaToken datetime = null,
@tipo int
as
begin

	if @tipo = 4

		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where [user] = @user and password = @password

	else if @tipo = 5
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where [user] = @user

	else if @tipo = 6
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where idUsuario = @idUsuario

	else if @tipo = 7
		
		update usuario
		set token = @token,
			fechaToken = @fechaToken
		where idUsuario = @idUsuario

	else if @tipo = 8
		
		select idUsuario,
				[user],
				idPerfil
		from usuario 
		where token = @token and 
			GETDATE() < DATEADD(day, 1, fechaToken)

	else if @tipo = 9
		
		update usuario
		set password = @password
		where idUsuario = @idUsuario
			



end
GO
USE [master]
GO
ALTER DATABASE [db_victoria] SET  READ_WRITE 
GO
