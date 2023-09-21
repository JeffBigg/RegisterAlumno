USE [master]
GO
/****** Object:  Database [dbSistema]    Script Date: 21/09/2023 09:02:52 ******/
CREATE DATABASE [dbSistema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSistema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSistema.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbSistema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSistema_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbSistema] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSistema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSistema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSistema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSistema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSistema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSistema] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSistema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSistema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSistema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSistema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSistema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSistema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSistema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSistema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSistema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSistema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSistema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSistema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSistema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSistema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSistema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSistema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSistema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSistema] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSistema] SET  MULTI_USER 
GO
ALTER DATABASE [dbSistema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSistema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSistema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSistema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbSistema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbSistema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbSistema', N'ON'
GO
ALTER DATABASE [dbSistema] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbSistema] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbSistema]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 21/09/2023 09:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departamento] [varchar](50) NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 21/09/2023 09:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[primerapellido] [varchar](50) NULL,
	[segundoapellido] [varchar](50) NULL,
	[correo] [nchar](50) NULL,
	[foto] [image] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoDepartamento]    Script Date: 21/09/2023 09:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoDepartamento](
	[idEmpleado] [int] NULL,
	[idDepartamento] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/09/2023 09:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](128) NOT NULL,
	[NombreCompleto] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Edad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmpleadoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_Departamento] FOREIGN KEY([idDepartamento])
REFERENCES [dbo].[Departamento] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadoDepartamento] CHECK CONSTRAINT [FK_EmpleadoDepartamento_Departamento]
GO
ALTER TABLE [dbo].[EmpleadoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadoDepartamento] CHECK CONSTRAINT [FK_EmpleadoDepartamento_Empleado]
GO
USE [master]
GO
ALTER DATABASE [dbSistema] SET  READ_WRITE 
GO
