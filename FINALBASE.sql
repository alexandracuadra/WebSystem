USE [master]
GO
/****** Object:  Database [sistema_horario]    Script Date: 30/8/2020 10:45:08 ******/
CREATE DATABASE [sistema_horario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistema_horario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sistema_horario.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sistema_horario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sistema_horario_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sistema_horario] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistema_horario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistema_horario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistema_horario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistema_horario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistema_horario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistema_horario] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistema_horario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistema_horario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistema_horario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistema_horario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistema_horario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistema_horario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistema_horario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistema_horario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistema_horario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistema_horario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistema_horario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistema_horario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistema_horario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistema_horario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistema_horario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistema_horario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistema_horario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistema_horario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sistema_horario] SET  MULTI_USER 
GO
ALTER DATABASE [sistema_horario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistema_horario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistema_horario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistema_horario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [sistema_horario] SET DELAYED_DURABILITY = DISABLED 
GO
USE [sistema_horario]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[anolectivo]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[anolectivo](
	[cod_ano] [int] IDENTITY(1,1) NOT NULL,
	[ano] [varchar](4) NOT NULL,
	[activo] [varchar](2) NOT NULL,
 CONSTRAINT [PK__anolecti__F92ABD5E0E03033A] PRIMARY KEY CLUSTERED 
(
	[cod_ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aula]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aula](
	[cod_aula] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[ubicasion] [varchar](45) NOT NULL,
	[ac] [varchar](45) NOT NULL,
	[capacidad] [int] NOT NULL,
	[n_equipo] [int] NULL,
	[cod_tipoaula] [int] NOT NULL,
	[cod_dpto] [int] NOT NULL,
 CONSTRAINT [PK__aula__52A406149C648B04] PRIMARY KEY CLUSTERED 
(
	[cod_aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[aulaDpto]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aulaDpto](
	[cod_aula] [int] NULL,
	[cod_dpto] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[carrera]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carrera](
	[cod_carrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[tipo_carrera] [varchar](50) NOT NULL,
	[modalidad] [varchar](45) NOT NULL,
	[cod_dpto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dia]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dias] [varchar](20) NOT NULL,
 CONSTRAINT [PK_dia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dpto]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dpto](
	[cod_dpto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cod_faculta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_dpto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faculta]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[faculta](
	[cod_faculta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[telefono] [varchar](8) NOT NULL,
	[direccion] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_faculta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grupo](
	[cod_grupo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[capacidad] [int] NOT NULL,
	[tipo_ciclo] [varchar](45) NOT NULL,
	[cod_asig] [int] NOT NULL,
	[hora_grupo] [int] NULL,
	[tipo_grupo] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[horario]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[horario](
	[cod_horario] [int] IDENTITY(1,1) NOT NULL,
	[cod_periodo] [int] NULL,
	[cod_dias] [int] NULL,
	[fecha_ini] [varchar](45) NULL,
	[cod_asig] [int] NOT NULL,
	[cod_aula] [int] NOT NULL,
	[cod_grupo] [int] NOT NULL,
	[inss] [varchar](45) NOT NULL,
	[cod_ano] [int] NOT NULL,
 CONSTRAINT [PK__horario__CCE87E1179ABA9A6] PRIMARY KEY CLUSTERED 
(
	[cod_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[horario_vista]    Script Date: 30/8/2020 10:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horario_vista](
	[id] [int] NOT NULL,
	[cod_depar] [nchar](10) NULL,
	[carrera] [nchar](10) NULL,
	[año_estudio] [nchar](10) NULL,
 CONSTRAINT [PK_horario_vista] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[horariogeneracion]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[horariogeneracion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cod_carrera] [varchar](10) NOT NULL,
	[tipo_ciclo] [varchar](10) NOT NULL,
	[fecha_ini] [varchar](10) NOT NULL,
	[cod_dpto] [nchar](10) NULL,
	[semestr] [nchar](10) NULL,
	[año_estudio] [nchar](10) NULL,
	[profesor] [nchar](10) NULL,
	[cod_aula] [nchar](10) NULL,
	[cod_grupo] [nchar](10) NULL,
	[cod_periodo] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[inportarcion]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inportarcion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[inss] [varchar](45) NOT NULL,
	[cod_dpto] [int] NULL,
	[cod_asignatura] [int] NULL,
	[cod_carrera] [int] NOT NULL,
	[grupo] [int] NOT NULL,
	[hora_grupo] [int] NOT NULL,
	[tipo_ciclo] [varchar](2) NOT NULL,
	[tipo_grupo] [varchar](10) NULL,
	[cod_asig] [int] NULL,
 CONSTRAINT [PK__exportar__3213E83F6940D243] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[materia]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[materia](
	[cod_materia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pensum]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pensum](
	[cod_asig] [int] IDENTITY(1,1) NOT NULL,
	[N_credito] [int] NOT NULL,
	[ciclo] [int] NOT NULL,
	[anio_est] [varchar](4) NULL,
	[prerrequisito1] [varchar](100) NULL,
	[prerrequisito2] [varchar](100) NULL,
	[cod_plan] [int] NOT NULL,
	[cod_materia] [int] NOT NULL,
	[total_horas] [int] NOT NULL,
 CONSTRAINT [PK__pensum__427F9846B38F652A] PRIMARY KEY CLUSTERED 
(
	[cod_asig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[periodo]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[periodo](
	[cod_periodo] [int] IDENTITY(1,1) NOT NULL,
	[periodo] [varchar](20) NOT NULL,
 CONSTRAINT [PK__periodo__5790DD41E1827BC8] PRIMARY KEY CLUSTERED 
(
	[cod_periodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Plans]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plans](
	[cod_plan] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[total_credito] [int] NOT NULL,
	[fecha_ini] [date] NULL,
	[fecha_fin] [date] NULL,
	[Nciclos] [int] NULL,
	[cod_carrera] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[profesorDepartameto]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[profesorDepartameto](
	[cod_dpto] [int] NULL,
	[inss] [varchar](45) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[profesores]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[profesores](
	[inss] [varchar](45) NOT NULL,
	[cedula] [varchar](45) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[apellido] [varchar](60) NOT NULL,
	[telefono] [int] NULL,
	[direccion] [varchar](100) NULL,
	[foto_ruta] [varchar](200) NULL,
	[cod_dpto] [int] NOT NULL,
 CONSTRAINT [PK__profesor__94B92FF05B4E1107] PRIMARY KEY CLUSTERED 
(
	[inss] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipoaula]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipoaula](
	[cod_tipoaula] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_tipoaula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[correo] [varchar](40) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[apellido] [varchar](45) NOT NULL,
	[foto] [varchar](45) NULL,
	[pass] [varchar](45) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios_roles]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [nvarchar](128) NULL,
	[id_rol] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[componentes]    Script Date: 30/8/2020 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[componentes]
AS
SELECT        nombre
FROM            dbo.materia
GROUP BY nombre





GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201902070307524_InitialCreate', N'SistemaWeb.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE436127D5F20FF20E82959382D5F7606B3463B81D3B6B3C68E2F98F664F336604BEC363112A548946363912FDB87FDA4FD852D4AD48D175DBAE5EE7630C0A045164F158B45B2582CFA7FFFF9EFF4C7E7C0B79E709C90909ED9479343DBC2D40D3D42576776CA96DF7FB07FFCE19BBF4C2FBDE0D9FAA5A03BE174D0922667F62363D1A9E324EE230E503209881B8749B86413370C1CE485CEF1E1E1DF9DA3230703840D589635FD945246029C7DC0E72CA42E8E588AFC9BD0C37E22CAA1669EA15AB728C049845C7C66CF49C2A0E85F7831C9896DEBDC27080499637F695B88D2902106629E7E4EF09CC5215DCD232840FEC34B84816E89FC040BF14F2BF2BE3D393CE63D71AA8605949B262C0C06021E9D08D53872F3B5146C97AA03E55D8292D90BEF75A6C033FBDAC359D1A7D00705C80C4F677ECC89CFEC9B92C57912DD6236291A4E72C8AB18E07E0FE3AF933AE281D5BBDD41694AC79343FEEFC09AA53E4B637C4671CA62E41F58F7E9C227EE3FF1CB43F815D3B393A3C5F2E4C3BBF7C83B79FF377CF2AEDE53E82BD0350AA0E83E0E231C836C7859F6DFB69C663B476E5836ABB5C9B502B604B3C2B66ED0F3474C57EC11E6CBF107DBBA22CFD82B4A84717DA60426113462710A9FB7A9EFA3858FCB7AA79527FFBF85EBF1BBF7A370BD454F64950DBDC41F264E0CF3EA13F6B3DAE49144F9F46A8CF7174176158701FF6EDA575EFB651EA6B1CB3B131A491E50BCC2AC29DDD4A98CB7974973A8F1CDBA40DD7FD3E692AAE6AD25E51D5A6726142CB63D1B0A795F976F6F8B3B8F2218BCCCB4B846DA0C4ED9AB2652E303AB22A90CE7A8AFE150E8D09F791DBC0C10F14758087B7001176449E20097BDFC2904B34374B0CCF72849601DF0FE8192C716D1E1E708A2CFB19BC6609E738682E8D5B9DD3F8614DFA6C1825BFDF6788D36340FBF8757C865617C4979AB8DF13E86EED7306597D4BB400C7F666E01C83F1F48D01F601471CE5D1727C9151833F6662178D805E0356527C783E1F8FAB46B4764E62312E83D116925FD529056DE889E42F1480C643AAFA44DD48FE18AD07EA216A46651738A4E5105D9505139583F4905A559D08CA053CE9C6A343F2F1BA1F11DBD0C76FF3DBDCD366FD35A5053E31C5648FC33A6388665CCBB478CE1985623D067DDD885B3900D1F67FAEA7B53C6E917E4A763B35A6B36648BC0F8B32183DDFFD9908909C54FC4E35E498FE34F410CF0BDE8F527ABEE392749B6EDE9D0E8E6B6996F670D304D97F324095D92CD024DE04B842D9AF2830F6775C730F2DEC87110E818183AE15B1E9440DF6CD9A8EEE805F631C3D6B99B070667287191A7AA113AE40D10ACD851358255F190A6707F557882A5E3983742FC1094C04C2594A9D382509744C8EFD492D4B2E716C6FB5EF2906B2E70842967D8A9893ECCF5E10F2E40C9471A942E0D4D9D9AC5B51BA2C16B358D79970B5B8DBB1295D88A4D76F8CE06BB14FEDBAB1866BBC6B6609CED2AE923803194B70B03156795BE06201F5CF6CD40A51393C140854BB515036D6A6C0706DA54C99B33D0FC88DA77FCA5F3EABE9967F3A0BCFD6DBD555D3BB0CD863EF6CC3473DF13DA30688163D53C2F16BC123F33CDE10CE414E7B344B8BAB28970F03966CD904DE5EF6AFD50A71D4436A236C0CAD03A40C525A002A44CA801C215B1BC56E984173100B688BBB5C28AB55F82ADD9808A5DBF0CAD119AAF4C65E3EC75FA287B565A8362E4BD0E0B351C8D41C88B57B3E33D94628ACBAA8AE9E30B0FF1866B1D1383D1A2A00ECFD5A0A4A233A36BA930CD6E2DE91CB2212ED9465A92DC2783968ACE8CAE2561A3DD4AD2380503DC828D54D4DCC2479A6C45A4A3DC6DCABAA993A7488982A963C8A59ADEA028227455CBAD1225D63C4FAC9A7D3F1F9E7214E4188E9B68328F4A694B4E2C8CD10A4BB5C01A24BD2271C22E10430BC4E33C332F50C8B47BAB61F92F58D6B74F75108B7DA0A0E6BFC5CDAA7275DFD86A555F44405C410703EED0645174CDF0EB9B5B3CD50DF928D604EE67A19F06D4EC5F995BE7D777F5F679898A307524F915FF495196E2E53635DF6B5CD43931CE1895DECBFAE364863069BBF03DEBFA36F9A36694223C55473185AC76366E263766C858C90EE2F0A1EA44789D5925B252EA00A26820462DB14101ABD5F5476DE69ED4319B35FD11A504933AA4543540CA7A1A4943C87AC55A78068DEA29FA73501347EAE86A6D7F644D0A491D5A53BD06B64666B9AE3FAA26CBA40EACA9EE8F5DA59CC86BE81EEF5BC663CBBA1B577EB0DD6CE73260BCCE8238CEC657BBBFAF03D58A0762891B7A054C94EFA531194F77EB1A531ECED8CC980C18E675A771F1DD5C765A6FEBCD988DDBECC6D2DE769B6FC61B66B2AF6A18CAD94E2629B997673CE92C3715E7AAEEC733CA412B27B1AD428D604E2FDC9C269C6032FFCD9FF904F345BC20B841942C71C2F20C0EFBF8F0E8587A80B33F8F619C24F17CCDB9D4F422A639665B48C6A24F28761F51ACA6466CF060A40255A2CED7D4C3CF67F6BFB356A7590083FFCA8A0FACEBE43325BFA550F110A7D8FA434DF51C2781BEC7938D52D03FDEC45B88FE2ABFFEF54BDEF4C0BA8B613A9D5A8792A2D719FEE60B8941D2E44D379066ED77136F77B6359E256851A5D9B2FE2B840561A3BC4028A4FC3640CFDF0D154DFBCA602344CD4B82B1F04651A1E9A5C03A58C657021E7CB2EC95C0B0CEEA5F0DAC239AF1C500A1C3C1E4F702FD97A1A2E50EF721CD79691B4B52A6E7CE7CEB8D922F77BD372969D91B4D7435F57A00DCA8E9D59BB9286F2C6D79B4AD5393953C1AF62EEDFED55391F725FBB872DA779B74BCCD3CE396DBA43F557AF11E24C469127C769F44BC6D5B330580F73C137358AAF09E199BD8E6779F10BC6D63330588F7DCD806A5FDEE99ADED6AFFDCB1A5F5DE42779EC4ABE623192E727451E4AE24DD3CE40EC7FF450846907B94F9DB4A7D56585B466B07C38AC4CCD49C8E263356268EC257A168673BACAF62C36FEDACA069676B48E26CE32DD6FF56DE82A69DB721357217E9C5DAE4445DCA77C73AD6963BF596D2891B3DE9C85EEFF2595B6FE5DF52F6F0284A69CC1EC3EDF2DB49161E4525634E9D01C9C1EA4531EC9DB5BFC508FB7742561504FFCB8C14BB8D5DB3A4B9A6CBB0D8BC25890A122942738319F2604B3D8F1959229741350F40678FC3B3A01EBF065960EF9ADEA52C4A197419070BBF11F0E24E401BFF2C03BA29F3F42EE25FC9185D0031090FDCDFD19F52E27BA5DC579A989001827B1722DCCBC792F1B0EFEAA544BA0D694F20A1BED2297AC041E403587247E7E809AF231B98DF47BC42EE4B15013481740F4453EDD30B8256310A128151B5874FB0612F78FEE1FFEAC12BF292540000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[anolectivo] ON 

INSERT [dbo].[anolectivo] ([cod_ano], [ano], [activo]) VALUES (1, N'2019', N'no')
INSERT [dbo].[anolectivo] ([cod_ano], [ano], [activo]) VALUES (2, N'2020', N'si')
INSERT [dbo].[anolectivo] ([cod_ano], [ano], [activo]) VALUES (4, N'2021', N'no')
SET IDENTITY_INSERT [dbo].[anolectivo] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3dfb6a2e-f2d3-4e61-866b-e0c25c7d8131', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'64316cd1-732b-49ec-abbb-a60711260d9a', N'Manager')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff8cb90f-2cf0-4a48-80c9-8b147a488bee', N'Secretaria')
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] ON 

INSERT [dbo].[AspNetUserRoles] ([id], [UserId], [RoleId]) VALUES (1, N'45ff397e-a319-4643-adcb-a39907087c0c', N'3dfb6a2e-f2d3-4e61-866b-e0c25c7d8131')
INSERT [dbo].[AspNetUserRoles] ([id], [UserId], [RoleId]) VALUES (2, N'633dd341-cdaf-4429-ac60-3cd775a16105', N'64316cd1-732b-49ec-abbb-a60711260d9a')
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] OFF
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45ff397e-a319-4643-adcb-a39907087c0c', N'luiscaballero9628@gmial.com', 0, N'AG0M6mzatPJfqXmmNnv/vDFTWMs4VfTMtDYDwLAbvCEkn67CfkKtPvTjy3WfG9q3LQ==', N'568a35ba-de79-483e-aad6-bce4456bd724', NULL, 0, 0, NULL, 0, 0, N'luis')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'633dd341-cdaf-4429-ac60-3cd775a16105', N'alejandro@gmail.com', 0, N'ABIS13YGnOm/8NZxpLAx9vUsUFt67zxyOwL6IpnMtiP+fpbuWn9glUaKVZgjtHZ6mw==', N'49744e0c-0d57-478a-b6b1-3f9b5f4a6bf7', NULL, 0, 0, NULL, 1, 0, N'alejandro@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'86fb1923-951c-42d5-9880-e160fb05af4c', N'laura123@hotmail.com', 0, N'AOHByt6SGP2KFj/PgPQw4a1NQ1OUUa4eEurh9WioVkVbSM2Fd+eGQOM3DvuMnh/XNg==', N'88a16fd9-c069-456f-b45e-76382b2b8f13', NULL, 0, 0, NULL, 0, 0, N'Laura')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bb78424-f768-40d0-9712-018127a5bb73', N'maria123@hotmail.com', 0, N'AF5XHFLWFVNFX41/iziF492WG/xrNKOanoKSUh+nz/ra3metdvbE5xN3J3xWURb6hw==', N'cf948cdf-2313-44d2-83fc-f63a43a5f836', NULL, 0, 0, NULL, 0, 0, N'Maria')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc1cbbec-b74c-430a-b192-accdceaa7f3f', N'ale@gmail.com', 0, N'AGOAd+vhkfMnTQ40+DprqXFiFZMXgN6X7YVpsGv1ZZJD1iRyj3fwDbdpvoH/cJGH9g==', N'f7c868d4-9e74-437a-8f99-614ac9a8dc9b', NULL, 0, 0, NULL, 1, 0, N'ale@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'new', N'ale1@gmail.com', 0, N'A89682528', N'1', N'89682528', 0, 0, NULL, 0, 0, N'Alejandro')
SET IDENTITY_INSERT [dbo].[aula] ON 

INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (4, N'Alcala 1', N'CIDS', N'nose', 30, 0, 1, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (5, N'Alcala 2', N'ATM', N'nose', 30, 0, 1, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (6, N'Hardware', N'CIDS', N'nose', 28, 0, 1, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (7, N'C - 6', N'CIDS', N'nose', 28, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (8, N'N - 9', N'ATM', N'nose', 30, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (9, N'C - 2', N'ATM', N'nose', 30, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (10, N'C - 3', N'ATM', N'nose', 30, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (11, N'C - 4', N'ATM', N'nose', 30, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (12, N'C - 5', N'ATM', N'nose', 30, 0, 2, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (13, N'Cisco', N'Ciencias y tecnologia', N'nose', 30, 0, 1, 3)
INSERT [dbo].[aula] ([cod_aula], [nombre], [ubicasion], [ac], [capacidad], [n_equipo], [cod_tipoaula], [cod_dpto]) VALUES (14, N'Alcaila', N'Quimica', N'nose', 30, 0, 1, 3)
SET IDENTITY_INSERT [dbo].[aula] OFF
SET IDENTITY_INSERT [dbo].[carrera] ON 

INSERT [dbo].[carrera] ([cod_carrera], [nombre], [tipo_carrera], [modalidad], [cod_dpto]) VALUES (2, N'INGENIERIA EN SISTEMAS ', N'Regular', N'Regular', 3)
INSERT [dbo].[carrera] ([cod_carrera], [nombre], [tipo_carrera], [modalidad], [cod_dpto]) VALUES (3, N'INGENIERIA EN TELEMATICA', N'regular', N'regular', 3)
SET IDENTITY_INSERT [dbo].[carrera] OFF
SET IDENTITY_INSERT [dbo].[dia] ON 

INSERT [dbo].[dia] ([id], [dias]) VALUES (1, N'Lunes')
INSERT [dbo].[dia] ([id], [dias]) VALUES (2, N'Martes')
INSERT [dbo].[dia] ([id], [dias]) VALUES (3, N'Miercoles')
INSERT [dbo].[dia] ([id], [dias]) VALUES (4, N'Jueves')
INSERT [dbo].[dia] ([id], [dias]) VALUES (5, N'Viernes')
SET IDENTITY_INSERT [dbo].[dia] OFF
SET IDENTITY_INSERT [dbo].[dpto] ON 

INSERT [dbo].[dpto] ([cod_dpto], [nombre], [cod_faculta]) VALUES (3, N'departamento de computacion', 5)
SET IDENTITY_INSERT [dbo].[dpto] OFF
SET IDENTITY_INSERT [dbo].[faculta] ON 

INSERT [dbo].[faculta] ([cod_faculta], [nombre], [telefono], [direccion]) VALUES (5, N'Ciencia y Tecnologia', N'89682528', N'Leon')
SET IDENTITY_INSERT [dbo].[faculta] OFF
SET IDENTITY_INSERT [dbo].[grupo] ON 

INSERT [dbo].[grupo] ([cod_grupo], [nombre], [capacidad], [tipo_ciclo], [cod_asig], [hora_grupo], [tipo_grupo]) VALUES (4163, N'Gp1', 30, N'1', 36, 2, N'Practico  ')
SET IDENTITY_INSERT [dbo].[grupo] OFF
SET IDENTITY_INSERT [dbo].[inportarcion] ON 

INSERT [dbo].[inportarcion] ([id], [inss], [cod_dpto], [cod_asignatura], [cod_carrera], [grupo], [hora_grupo], [tipo_ciclo], [tipo_grupo], [cod_asig]) VALUES (205, N'134252ywrtsyw', 3, 39, 2, 2, 4, N'1', N'Teorico', 36)
INSERT [dbo].[inportarcion] ([id], [inss], [cod_dpto], [cod_asignatura], [cod_carrera], [grupo], [hora_grupo], [tipo_ciclo], [tipo_grupo], [cod_asig]) VALUES (206, N'2334ssddfgd', 3, 70, 2, 1, 4, N'1', N'Teorico', 67)
INSERT [dbo].[inportarcion] ([id], [inss], [cod_dpto], [cod_asignatura], [cod_carrera], [grupo], [hora_grupo], [tipo_ciclo], [tipo_grupo], [cod_asig]) VALUES (207, N'2334ssddfgd', 3, 70, 2, 3, 2, N'1', N'Practico', 67)
INSERT [dbo].[inportarcion] ([id], [inss], [cod_dpto], [cod_asignatura], [cod_carrera], [grupo], [hora_grupo], [tipo_ciclo], [tipo_grupo], [cod_asig]) VALUES (208, N'134252ywrtsyw', 3, 39, 2, 1, 2, N'1', N'Practico', 36)
SET IDENTITY_INSERT [dbo].[inportarcion] OFF
SET IDENTITY_INSERT [dbo].[materia] ON 

INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (1, N'ELECTIVA IX:INTRODUCCION A LOS CMS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (2, N'PATRONES DE DISEÑO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (3, N'ACTIVIDAD ESTUDIANTIL I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (4, N'BIOLOGIA GENERAL')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (5, N'COMUNICACION Y LENGUAJE')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (6, N'FILOSOFIA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (7, N'HISTORIA DE NICARAGUA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (8, N'INGLES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (9, N'MATEMATICA BASICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (10, N'CALCULO I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (11, N'EDUCACION AMBIENTAL')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (12, N'ELECTIVA DE ACTIVIDAD ESTUDIANTIL II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (14, N'FUNDAMENTOS DE INFORMATICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (15, N'INGLES APLICADO I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (16, N'LABORATORIO DE LOGICA DE PROGRAMACION')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (17, N'LOGICA DE PROGRAMACION')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (18, N'OFIMATICA APLICADA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (19, N'CALCULO II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (20, N'FISICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (21, N'INGLES APLICADO II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (22, N'LABORATORIO DE PROGRAMACION ESTRUCTURADA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (23, N'MATEMATICA DISCRETA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (24, N'PROGRAMACION ESTRUCTURADA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (25, N'OPTATIVA I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (26, N'ALGEBRA LINEAL')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (27, N'ALGORITMOS Y ESTRUCTURAS DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (28, N'APLICACIONES DE ESTRUCTURAS DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (29, N'CIRCUITOS LOGICOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (30, N'INGLES APLICADO III')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (31, N'INVESTIGACION I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (32, N'ELECTIVA FEI: DISEÑO DE PAGINA WEB')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (33, N'ELECTIVA FEI: TOPICOS AVANZADOS DE OFIMATICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (34, N'ARQUITECTURA DE COMPUTADORES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (35, N'DISEÑO DE BASE DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (36, N'ELECTIVA DE ACTIVIDAD ESTUDIANTIL III')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (37, N'INFRAESTRUCTURA TIC I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (38, N'PROGRAMACION ORIENTADA A OBJETOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (39, N'SISTEMAS GESTORES DE BASE DE DATOS I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (40, N'ELECTIVA II: ADMINISTRACION GENERAL')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (41, N'ELECTIVA II: CONTABILIDAD FINANCIERA I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (42, N'INFRAESTRUCTURA TIC II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (43, N'INTRODUCCION A LAS ESTRUCTURAS DE BASES DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (44, N'INVESTIGACION II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (45, N'PROGRAMACION VISUAL I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (46, N'SISTEMAS GESTORES DE BASES DE DATOS II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (47, N'SISTEMAS OPERATIVOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (48, N'ELECTIVA III:CONTABILIDAD DE COSTO I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (49, N'ELECTIVA III:ESTADISTICA INTRODUCTORIA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (50, N'ADMINISTRACION DE SISTEMAS OPERATIVOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (51, N'DISEÑO DE REDES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (52, N'PROGRAMACION ORIENTADA A LA WEB I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (53, N'PROGRAMACION VISUAL II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (54, N'ELECTIVA IV: REPARACION Y MANTENIMIENTO DE COMPUTADORES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (55, N'ELECTIVA IV:TRATAMIENTO DIGITAL DE IMAGENES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (56, N'ELECTIVA V: PLATAFORMAS LMS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (57, N'ELECTIVA V (ROBOTICA EDUCACTIVA)')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (58, N'OPTATIVA II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (59, N'ADMINISTRACION DE SERVICIOS DE REDES I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (60, N'ANALISIS Y DISEÑO DE SISTEMAS DE INFORMACION')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (61, N'FORMULACION DE PROYECTOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (62, N'PROGRAMACION ORIENTADA A LA WEB II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (63, N'SISTEMAS DE INFORMACION GEOGRAFICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (64, N'ELECTIVA VI: DIRECCION DE RRHH')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (65, N'ELECTIVA VI: MERCADOTECNIA I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (66, N'ELECTIVA VII:CALCULO DE PROBABILIDAD')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (67, N'ELECTIVA VII: PROCESOS ALEATORIOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (68, N'ADMINISTRACION DE SERVICIOS DE REDES II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (69, N'INGENIERIA DEL SOFTWARE')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (70, N'INTRODUCCION A LA SEGURIDAD EN REDES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (71, N'PROYECTO INTEGRADOR I')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (72, N'ELECTIVA VIII: PROGRAMACION EN ANDROID')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (73, N'ELECTIVA VIII: PROGRAMACION PARA WINDOWS PHONE')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (74, N'OPTATIVA III')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (75, N'PRACTICAS PROFESIONALES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (76, N'PROYECTO INTEGRADOR II')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (77, N'ELECTIVA IX: VALIDACION DE APLICACIONES BAJO FILOSOFIA OWASP')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (78, N'ELECTIVA II: ADMINISTRACION GENERAL')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (79, N'MEDIO DE TRANSMISION DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (80, N'SISTEMAS TELEMATICOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (81, N'TECNOLOGIAS DE NIVEL FISICO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (82, N'ELECTIVA III: ESTADISTICA INTRODUCTORIA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (83, N'COMUNICACION DE DATOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (84, N'PROGRAMACION DE SISTEMAS DISTRIBUIDOS EN UNIX')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (85, N'SISTEMAS DISTRIBUIDOS')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (86, N'ELECTIVA IV: TRATAMIENTO DIGITAL DE IMAGENES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (87, N'ELECTIVA V: REDACCION Y COMUNICACION CIENTIFICA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (88, N'GESTION DE SISTEMAS UNIX')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (89, N'REDES DE COMPUTADORES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (90, N'SOFTWARE COMO UN SERVICIO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (91, N'ELECTIVA VI: COMERCIO ELECTRONICO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (92, N'ELECTIVA VI: EDICION DE VIDEO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (94, N'ADMINISTRACION DE SERVICIOS DE RED ')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (95, N'GESTION DE RED')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (96, N'INVESTIGACION III')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (97, N'ELECTIVA VIII: COMPUTACION EN LA NUBE')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (98, N'ELECTIVA IX: REDES DE AREAS EXTENSA')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (99, N'ELECTIVA IX: TECNOLOGIA DE REDES CELULARES')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (100, N'SEMINARIO MONOGRAFICO')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (101, N'ELECTIVA X: ADMINISTRACION DE SERVIDORES')
GO
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (102, N'ELECTIVA X: DESPLIEGUE DE IPV6')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (103, N'ELECTIVA V: INFRAESTUCTURA TIC')
INSERT [dbo].[materia] ([cod_materia], [nombre]) VALUES (104, N'SEGURIDAD DE REDES')
SET IDENTITY_INSERT [dbo].[materia] OFF
SET IDENTITY_INSERT [dbo].[pensum] ON 

INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (1, 1, 1, N'1', NULL, NULL, 2, 3, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (2, 4, 1, N'1', NULL, NULL, 2, 4, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (3, 4, 1, N'1', NULL, NULL, 2, 5, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (4, 3, 1, N'1', NULL, NULL, 2, 6, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (5, 3, 1, N'1', NULL, NULL, 2, 7, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (6, 2, 1, N'1', NULL, NULL, 2, 8, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (7, 4, 1, N'1', NULL, NULL, 2, 9, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (8, 4, 2, N'1', N'MATEMATICA BASICA', NULL, 2, 10, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (9, 3, 2, N'1', NULL, NULL, 2, 11, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (10, 1, 2, N'1', NULL, NULL, 2, 12, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (11, 3, 2, N'1', NULL, NULL, 2, 14, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (12, 2, 2, N'1', NULL, NULL, 2, 15, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (13, 2, 2, N'1', NULL, NULL, 2, 16, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (14, 4, 2, N'1', NULL, NULL, 2, 17, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (15, 2, 2, N'1', NULL, NULL, 2, 18, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (16, 4, 3, N'2', N'CALCULO I', NULL, 2, 19, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (17, 4, 3, N'2', N'MATEMATICA BASICA', NULL, 2, 20, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (18, 2, 3, N'2', N'INGLES APLICADO I', NULL, 2, 21, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (19, 2, 3, N'2', N'LABORATORIO DE LOGICA DE PROGRAMACION', N'LOGICA DE PROGRAMACION', 2, 22, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (20, 4, 3, N'2', N'MATEMATICA BASICA', NULL, 2, 23, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (21, 4, 3, N'2', N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 2, 24, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (22, 2, 3, N'2', NULL, NULL, 2, 25, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (23, 3, 4, N'2', N'MATEMATICA BASICA', NULL, 2, 26, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (24, 3, 4, N'2', N'PROGRAMACION ESTRUCTURADA', N'LABORATORIO DE PROGRAMACION ESTRUCTURADA', 2, 27, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (25, 2, 4, N'2', N'PROGRAMACION ESTRUCTURADA', N'LABORATORIO DE PROGRAMACION ESTRUCTURADA', 2, 28, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (26, 3, 4, N'2', N'MATEMATICA DISCRETA', NULL, 2, 29, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (27, 2, 4, N'2', N'INGLES APLICADO II', NULL, 2, 30, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (28, 2, 4, N'2', NULL, NULL, 2, 31, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (29, 3, 4, N'2', NULL, NULL, 2, 32, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (30, 3, 4, N'2', NULL, NULL, 2, 33, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (31, 3, 5, N'3', N'CIRCUITOS LOGICOS', NULL, 2, 34, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (32, 3, 5, N'3', N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 2, 35, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (33, 1, 5, N'3', NULL, NULL, 2, 36, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (34, 2, 5, N'3', N'CIRCUITOS LOGICOS', NULL, 2, 37, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (35, 4, 5, N'3', N'PROGRAMACION ESTRUCTURADA', N'LABORATORIO DE PROGRAMACION ESTRUCTURADA', 2, 38, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (36, 3, 5, N'3', N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 2, 39, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (37, 4, 5, N'3', NULL, NULL, 2, 40, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (38, 4, 5, N'3', NULL, NULL, 2, 41, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (39, 2, 6, N'3', N'INFRAESTRUCTURA TIC I', NULL, 2, 42, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (40, 2, 6, N'3', N'DISEÑO DE BASE DE DATOS', NULL, 2, 43, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (41, 2, 6, N'3', N'INVESTIGACION I', NULL, 2, 44, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (42, 4, 6, N'3', N'PROGRAMACION ORIENTADA A OBJETOS', NULL, 2, 45, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (43, 3, 6, N'3', N'SISTEMAS GESTORES DE BASE DE DATOS I', NULL, 2, 46, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (44, 4, 6, N'3', N'ARQUITECTURA DE COMPUTADORES', NULL, 2, 47, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (45, 4, 6, N'3', NULL, NULL, 2, 48, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (46, 4, 6, N'3', NULL, NULL, 2, 49, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (47, 3, 7, N'4', N'SISTEMAS OPERATIVOS', NULL, 2, 50, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (48, 3, 7, N'4', N'INFRAESTRUCTURA TIC II', NULL, 2, 51, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (49, 3, 7, N'4', N'PROGRAMACION ORIENTADA A OBJETOS', NULL, 2, 52, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (50, 3, 7, N'4', N'PROGRAMACION VISUAL I', NULL, 2, 53, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (51, 3, 7, N'4', NULL, NULL, 2, 54, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (52, 3, 7, N'4', NULL, NULL, 2, 55, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (53, 3, 7, N'4', NULL, NULL, 2, 56, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (54, 3, 7, N'4', NULL, NULL, 2, 57, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (55, 3, 7, N'4', NULL, NULL, 2, 58, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (56, 3, 8, N'4', N'DISEÑO DE REDES', NULL, 2, 59, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (57, 3, 8, N'4', N'PROGRAMACION VISUAL I', NULL, 2, 60, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (58, 2, 8, N'4', N'INVESTIGACION I', NULL, 2, 61, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (59, 3, 8, N'4', N'PROGRAMACION VISUAL II', NULL, 2, 62, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (60, 3, 8, N'4', N'DISEÑO DE BASE DE DATOS', NULL, 2, 63, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (61, 3, 8, N'4', NULL, NULL, 2, 64, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (62, 3, 8, N'4', NULL, NULL, 2, 65, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (63, 4, 8, N'4', NULL, NULL, 2, 66, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (64, 4, 8, N'4', NULL, NULL, 2, 67, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (65, 3, 9, N'5', N'ADMINISTRACION DE SERVICIOS DE REDES I', NULL, 2, 68, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (66, 3, 9, N'5', N'ANALISIS Y DISEÑO DE SISTEMAS DE INFORMACION', NULL, 2, 69, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (67, 3, 9, N'5', N'ADMINISTRACION DE SERVICIOS DE REDES I', NULL, 2, 70, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (68, 3, 9, N'5', N'ANALISIS Y DISEÑO DE SISTEMAS DE INFORMACION', N'DISEÑO DE REDES', 2, 71, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (69, 3, 9, N'5', NULL, NULL, 2, 72, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (70, 3, 9, N'5', NULL, NULL, 2, 73, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (71, 3, 9, N'5', NULL, NULL, 2, 74, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (72, 3, 10, N'5', NULL, NULL, 2, 2, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (73, 10, 10, N'5', N'PROYECTO INTEGRADOR I', NULL, 2, 75, 450)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (74, 2, 10, N'5', N'PROYECTO INTEGRADOR I', NULL, 2, 76, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (75, 3, 10, N'5', NULL, NULL, 2, 1, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (76, 3, 10, N'5', NULL, NULL, 2, 77, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (77, 1, 1, NULL, NULL, NULL, 3, 3, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (78, 4, 1, NULL, NULL, NULL, 3, 4, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (79, 4, 1, NULL, NULL, NULL, 3, 5, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (80, 3, 1, NULL, NULL, NULL, 3, 6, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (81, 3, 1, NULL, NULL, NULL, 3, 7, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (82, 2, 1, NULL, NULL, NULL, 3, 8, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (83, 4, 1, NULL, NULL, NULL, 3, 9, 0)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (84, 4, 2, NULL, N'MATEMATICA BASICA', NULL, 3, 10, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (85, 3, 2, NULL, NULL, NULL, 3, 11, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (86, 1, 2, NULL, NULL, NULL, 3, 12, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (87, 3, 2, NULL, NULL, NULL, 3, 14, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (88, 2, 2, NULL, NULL, NULL, 3, 15, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (89, 2, 2, NULL, NULL, NULL, 3, 16, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (90, 4, 2, NULL, NULL, NULL, 3, 17, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (91, 2, 2, NULL, NULL, NULL, 3, 18, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (92, 4, 3, NULL, N'CALCULO I', NULL, 3, 19, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (93, 4, 3, NULL, N'MATEMATICA BASICA', NULL, 3, 20, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (94, 2, 3, NULL, N'INGLES APLICADO I', NULL, 3, 21, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (95, 2, 3, NULL, N'LABORATORIO DE LOGICA DE PROGRAMACION', N'LOGICA DE PROGRAMACION', 3, 22, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (96, 4, 3, NULL, N'MATEMATICA BASICA', NULL, 3, 23, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (97, 4, 3, NULL, N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 3, 24, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (98, 2, 3, NULL, NULL, NULL, 3, 25, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (99, 3, 4, NULL, N'MATEMATICA BASICA', NULL, 3, 26, 60)
GO
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (100, 3, 4, NULL, N'PROGRAMACION ESTRUCTURADA', N'LABORATORIO DE PROGRAMACION ESTRUCTURADA', 3, 27, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (101, 2, 4, NULL, N'LABORATORIO DE PROGRAMACIÓN ESTRUCTURADA', N'PROGRAMACIÓN ESTRUCTURADA', 3, 28, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (102, 3, 4, NULL, NULL, NULL, 3, 29, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (103, 2, 4, NULL, N'INGLES APLICADO II', NULL, 3, 30, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (104, 2, 4, NULL, NULL, NULL, 3, 31, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (105, 3, 4, NULL, NULL, NULL, 3, 32, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (106, 3, 4, NULL, NULL, NULL, 3, 33, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (107, 3, 5, NULL, N'CIRCUITOS LOGICOS', NULL, 3, 34, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (108, 3, 5, NULL, N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 3, 35, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (109, 1, 5, NULL, NULL, NULL, 3, 36, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (110, 4, 5, NULL, N'PROGRAMACION ESTRUCTURADA', N'LABORATORIO DE PROGRAMACION ESTRUCTURADA', 3, 38, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (111, 3, 5, NULL, N'LOGICA DE PROGRAMACION', N'LABORATORIO DE LOGICA DE PROGRAMACION', 3, 39, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (112, 4, 5, NULL, NULL, NULL, 3, 40, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (113, 4, 5, NULL, NULL, NULL, 3, 41, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (114, 2, 6, NULL, N'INVESTIGACION I', NULL, 3, 44, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (115, 2, 6, NULL, N'ARQUITECTURA DE COMPUTADORES', NULL, 3, 79, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (116, 4, 6, NULL, N'PROGRAMACION ORIENTADA A OBJETOS', NULL, 3, 45, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (117, 4, 6, NULL, N'ARQUITECTURA DE COMPUTADORES', NULL, 3, 80, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (118, 3, 6, NULL, N'ARQUITECTURA DE COMPUTADORES', NULL, 3, 81, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (119, 4, 6, NULL, NULL, NULL, 3, 48, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (120, 4, 6, NULL, NULL, NULL, 3, 49, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (121, 3, 7, NULL, N'TECNOLOGIAS DE NIVEL FISICO', NULL, 3, 83, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (122, 2, 7, NULL, N'SISTEMAS TELEMATICOS', NULL, 3, 84, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (123, 3, 7, NULL, N'PROGRAMACION ORIENTADA A OBJETOS', NULL, 3, 52, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (124, 3, 7, NULL, N'SISTEMAS TELEMATICOS', NULL, 3, 85, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (125, 3, 7, NULL, NULL, NULL, 3, 54, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (126, 3, 7, NULL, NULL, NULL, 3, 55, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (127, 2, 7, NULL, NULL, NULL, 3, 103, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (128, 2, 7, NULL, NULL, NULL, 3, 87, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (129, 2, 7, NULL, NULL, NULL, 3, 58, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (130, 2, 8, NULL, N'INVESTIGACION II', NULL, 3, 61, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (131, 3, 8, NULL, N'SISTEMAS TELEMATICOS', NULL, 3, 88, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (132, 3, 8, NULL, N'COMUNICACION DE DATOS', NULL, 3, 89, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (133, 3, 8, NULL, N'PROGRAMACION ORIENTADA A LA WEB', NULL, 3, 52, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (134, 3, 8, NULL, NULL, NULL, 3, 91, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (135, 3, 8, NULL, NULL, NULL, 3, 92, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (136, 3, 8, NULL, NULL, NULL, 3, 66, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (137, 3, 8, NULL, NULL, NULL, 3, 67, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (138, 2, 8, NULL, NULL, NULL, 3, 74, 45)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (139, 4, 9, NULL, N'GESTION DE SISTEMAS UNIX', NULL, 3, 94, 90)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (140, 3, 9, NULL, N'REDES DE COMPUTADORES', NULL, 3, 95, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (141, 2, 9, NULL, N'INVESTIGACION II', NULL, 2, 96, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (142, 3, 9, NULL, N'REDES DE COMPUTADORES', NULL, 3, 104, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (143, 3, 9, NULL, NULL, NULL, 3, 97, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (144, 3, 9, NULL, NULL, NULL, 3, 72, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (145, 3, 9, NULL, NULL, NULL, 3, 98, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (146, 3, 9, NULL, NULL, NULL, 3, 99, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (147, 10, 10, NULL, N'GESTION DE RED', N'ADMINISTRACION DE SERVICIOS DE RED', 3, 75, 450)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (148, 2, 10, NULL, N'INVESTIGACION III', NULL, 3, 100, 30)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (149, 3, 10, NULL, NULL, NULL, 3, 101, 60)
INSERT [dbo].[pensum] ([cod_asig], [N_credito], [ciclo], [anio_est], [prerrequisito1], [prerrequisito2], [cod_plan], [cod_materia], [total_horas]) VALUES (150, 3, 10, NULL, NULL, NULL, 3, 102, 60)
SET IDENTITY_INSERT [dbo].[pensum] OFF
SET IDENTITY_INSERT [dbo].[periodo] ON 

INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (1, N'7 a 8 am')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (2, N'8 a 9 am')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (3, N'9 a 10 am')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (4, N'10 a 11 am')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (5, N'11 a 12 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (6, N'12 a 1 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (7, N'1 a 2 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (8, N'2 a 3 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (9, N'3 a 4 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (10, N'4 a 5 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (11, N'5 a 6 pm')
INSERT [dbo].[periodo] ([cod_periodo], [periodo]) VALUES (12, N'6 a 7 pm')
SET IDENTITY_INSERT [dbo].[periodo] OFF
SET IDENTITY_INSERT [dbo].[Plans] ON 

INSERT [dbo].[Plans] ([cod_plan], [nombre], [total_credito], [fecha_ini], [fecha_fin], [Nciclos], [cod_carrera]) VALUES (2, N'PLAN DE ESTUDIO 2011 - CREDITO ING SISTEMA', 201, NULL, NULL, 10, 2)
INSERT [dbo].[Plans] ([cod_plan], [nombre], [total_credito], [fecha_ini], [fecha_fin], [Nciclos], [cod_carrera]) VALUES (3, N'PLAN DE ESTUDIO 2011 - CREDITO ING TELEMATICA', 189, NULL, NULL, 10, 3)
SET IDENTITY_INSERT [dbo].[Plans] OFF
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'134252ywrtsyw', N'281-190596-0004T', N'Francisco', N'Zepeda', 89682528, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'2334ssddfgd', N'281-250478-0004T', N'Denis', N'Espinosa', 78766565, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'A866847', N'281-280667-9886t', N'Alvaro', N'Altamirano', 87555754, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'D8566jfu', N'281-020267-0585R', N'Denis', N'Berrios', 89575684, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'Kjdhf47567', N'281-050668-0008K', N'Karina', N'Esquibel', 86948738, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'M75fhyr', N'281-040676-0037M', N'Marvin', N'Zomarriba', 86985784, N'Leon', NULL, 3)
INSERT [dbo].[profesores] ([inss], [cedula], [nombre], [apellido], [telefono], [direccion], [foto_ruta], [cod_dpto]) VALUES (N'w8375793', N'281-130876-0045u', N'Willian', N'Martines', 87657656, N'Leon', NULL, 3)
SET IDENTITY_INSERT [dbo].[tipoaula] ON 

INSERT [dbo].[tipoaula] ([cod_tipoaula], [nombre_tipo]) VALUES (1, N'Laboratorio')
INSERT [dbo].[tipoaula] ([cod_tipoaula], [nombre_tipo]) VALUES (2, N'Aula')
SET IDENTITY_INSERT [dbo].[tipoaula] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 30/8/2020 10:45:14 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 30/8/2020 10:45:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 30/8/2020 10:45:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 30/8/2020 10:45:14 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[AspNetUserRoles] NOCHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[aula]  WITH CHECK ADD  CONSTRAINT [cod_dptos] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aula] CHECK CONSTRAINT [cod_dptos]
GO
ALTER TABLE [dbo].[aula]  WITH CHECK ADD  CONSTRAINT [FK_aula_tipoaula] FOREIGN KEY([cod_tipoaula])
REFERENCES [dbo].[tipoaula] ([cod_tipoaula])
GO
ALTER TABLE [dbo].[aula] CHECK CONSTRAINT [FK_aula_tipoaula]
GO
ALTER TABLE [dbo].[aulaDpto]  WITH CHECK ADD  CONSTRAINT [FK_aulaDpto_aula] FOREIGN KEY([cod_aula])
REFERENCES [dbo].[aula] ([cod_aula])
GO
ALTER TABLE [dbo].[aulaDpto] CHECK CONSTRAINT [FK_aulaDpto_aula]
GO
ALTER TABLE [dbo].[aulaDpto]  WITH CHECK ADD  CONSTRAINT [FK_aulaDpto_dpto] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
GO
ALTER TABLE [dbo].[aulaDpto] CHECK CONSTRAINT [FK_aulaDpto_dpto]
GO
ALTER TABLE [dbo].[carrera]  WITH CHECK ADD  CONSTRAINT [cod_dpto] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[carrera] CHECK CONSTRAINT [cod_dpto]
GO
ALTER TABLE [dbo].[dpto]  WITH CHECK ADD  CONSTRAINT [cod_faculta] FOREIGN KEY([cod_faculta])
REFERENCES [dbo].[faculta] ([cod_faculta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dpto] CHECK CONSTRAINT [cod_faculta]
GO
ALTER TABLE [dbo].[grupo]  WITH CHECK ADD  CONSTRAINT [FK_grupo_pensum] FOREIGN KEY([cod_asig])
REFERENCES [dbo].[pensum] ([cod_asig])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[grupo] CHECK CONSTRAINT [FK_grupo_pensum]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_aula] FOREIGN KEY([cod_aula])
REFERENCES [dbo].[aula] ([cod_aula])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_aula]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_dia] FOREIGN KEY([cod_dias])
REFERENCES [dbo].[dia] ([id])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_dia]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_grupo] FOREIGN KEY([cod_grupo])
REFERENCES [dbo].[grupo] ([cod_grupo])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_grupo]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_pensum] FOREIGN KEY([cod_asig])
REFERENCES [dbo].[pensum] ([cod_asig])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_pensum]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_periodo] FOREIGN KEY([cod_periodo])
REFERENCES [dbo].[periodo] ([cod_periodo])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_periodo]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_profesores] FOREIGN KEY([inss])
REFERENCES [dbo].[profesores] ([inss])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_profesores]
GO
ALTER TABLE [dbo].[inportarcion]  WITH CHECK ADD  CONSTRAINT [FK_inportarcion_carrera] FOREIGN KEY([cod_carrera])
REFERENCES [dbo].[carrera] ([cod_carrera])
GO
ALTER TABLE [dbo].[inportarcion] CHECK CONSTRAINT [FK_inportarcion_carrera]
GO
ALTER TABLE [dbo].[inportarcion]  WITH CHECK ADD  CONSTRAINT [FK_inportarcion_dpto] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
GO
ALTER TABLE [dbo].[inportarcion] CHECK CONSTRAINT [FK_inportarcion_dpto]
GO
ALTER TABLE [dbo].[inportarcion]  WITH CHECK ADD  CONSTRAINT [FK_inportarcion_materia] FOREIGN KEY([cod_asignatura])
REFERENCES [dbo].[materia] ([cod_materia])
GO
ALTER TABLE [dbo].[inportarcion] CHECK CONSTRAINT [FK_inportarcion_materia]
GO
ALTER TABLE [dbo].[inportarcion]  WITH CHECK ADD  CONSTRAINT [FK_inportarcion_pensum] FOREIGN KEY([cod_asig])
REFERENCES [dbo].[pensum] ([cod_asig])
GO
ALTER TABLE [dbo].[inportarcion] CHECK CONSTRAINT [FK_inportarcion_pensum]
GO
ALTER TABLE [dbo].[inportarcion]  WITH CHECK ADD  CONSTRAINT [FK_inportarcion_profesores] FOREIGN KEY([inss])
REFERENCES [dbo].[profesores] ([inss])
GO
ALTER TABLE [dbo].[inportarcion] CHECK CONSTRAINT [FK_inportarcion_profesores]
GO
ALTER TABLE [dbo].[pensum]  WITH CHECK ADD  CONSTRAINT [FK_pensum_materia] FOREIGN KEY([cod_materia])
REFERENCES [dbo].[materia] ([cod_materia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[pensum] CHECK CONSTRAINT [FK_pensum_materia]
GO
ALTER TABLE [dbo].[pensum]  WITH CHECK ADD  CONSTRAINT [FK_pensum_Plans] FOREIGN KEY([cod_plan])
REFERENCES [dbo].[Plans] ([cod_plan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[pensum] CHECK CONSTRAINT [FK_pensum_Plans]
GO
ALTER TABLE [dbo].[Plans]  WITH CHECK ADD  CONSTRAINT [FK_Plans_carrera] FOREIGN KEY([cod_carrera])
REFERENCES [dbo].[carrera] ([cod_carrera])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plans] CHECK CONSTRAINT [FK_Plans_carrera]
GO
ALTER TABLE [dbo].[profesorDepartameto]  WITH CHECK ADD  CONSTRAINT [FK_profesorDepartameto_dpto] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
GO
ALTER TABLE [dbo].[profesorDepartameto] CHECK CONSTRAINT [FK_profesorDepartameto_dpto]
GO
ALTER TABLE [dbo].[profesorDepartameto]  WITH CHECK ADD  CONSTRAINT [FK_profesorDepartameto_profesores] FOREIGN KEY([inss])
REFERENCES [dbo].[profesores] ([inss])
GO
ALTER TABLE [dbo].[profesorDepartameto] CHECK CONSTRAINT [FK_profesorDepartameto_profesores]
GO
ALTER TABLE [dbo].[profesores]  WITH CHECK ADD  CONSTRAINT [FK_profesores_dpto] FOREIGN KEY([cod_dpto])
REFERENCES [dbo].[dpto] ([cod_dpto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[profesores] CHECK CONSTRAINT [FK_profesores_dpto]
GO
ALTER TABLE [dbo].[usuarios_roles]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles_AspNetRoles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[usuarios_roles] CHECK CONSTRAINT [FK_usuarios_roles_AspNetRoles]
GO
ALTER TABLE [dbo].[usuarios_roles]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles_AspNetUsers] FOREIGN KEY([id_user])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[usuarios_roles] CHECK CONSTRAINT [FK_usuarios_roles_AspNetUsers]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "materia"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 101
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'componentes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'componentes'
GO
USE [master]
GO
ALTER DATABASE [sistema_horario] SET  READ_WRITE 
GO
