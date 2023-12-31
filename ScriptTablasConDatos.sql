USE [master]
GO
/****** Object:  Database [AcopioExpressDB]    Script Date: 30/06/2023 9:59:47 a. m. ******/
CREATE DATABASE [AcopioExpressDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcopioExpressDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcopioExpressDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcopioExpressDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcopioExpressDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcopioExpressDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcopioExpressDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcopioExpressDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AcopioExpressDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcopioExpressDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcopioExpressDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AcopioExpressDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcopioExpressDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AcopioExpressDB] SET  MULTI_USER 
GO
ALTER DATABASE [AcopioExpressDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcopioExpressDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcopioExpressDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcopioExpressDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AcopioExpressDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcopioExpressDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AcopioExpressDB] SET QUERY_STORE = OFF
GO
USE [AcopioExpressDB]
GO
/****** Object:  Table [dbo].[Acopio]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acopio](
	[idAcopio] [int] IDENTITY(1,1) NOT NULL,
	[nombreAcopi] [varchar](50) NOT NULL,
	[ubicacion] [varchar](50) NOT NULL,
	[cantidadEmpleados] [int] NOT NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAcopio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bodega]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bodega](
	[idBodega] [int] IDENTITY(1,1) NOT NULL,
	[cantidadAlmacenada] [int] NOT NULL,
	[estado] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVentaInsumo]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVentaInsumo](
	[idDetalleVentaInsumo] [int] IDENTITY(1,1) NOT NULL,
	[id_Insumo] [int] NOT NULL,
	[id_VentaInsumo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[totalVentaInsumo] [bigint] NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleVentaInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EgresosAcopio]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EgresosAcopio](
	[idEgresosAcopio] [int] IDENTITY(1,1) NOT NULL,
	[id_acopio] [int] NOT NULL,
	[arriendo] [bigint] NOT NULL,
	[sumatoriaNominas] [int] NOT NULL,
	[servicios] [int] NOT NULL,
	[sumatoriaLiquidacion] [int] NOT NULL,
	[gastosExtras] [int] NOT NULL,
	[TotalEgresos] [bigint] NOT NULL,
	[fechaInicailEgresos] [date] NOT NULL,
	[fechaFinalIngresosEgresos] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEgresosAcopio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngresosAcopio]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngresosAcopio](
	[idIngresosAcopio] [int] IDENTITY(1,1) NOT NULL,
	[id_acopio] [int] NOT NULL,
	[totalGananciaInsumos] [int] NOT NULL,
	[TotalGananciaProduccion] [int] NOT NULL,
	[fechaInicailIngresos] [date] NOT NULL,
	[fechaFinalIngresosLiquidacion] [date] NOT NULL,
	[TotalIngresos] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idIngresosAcopio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[idInsumo] [int] IDENTITY(1,1) NOT NULL,
	[nombreInsumo] [varchar](50) NOT NULL,
	[descripcion] [text] NOT NULL,
	[valorUnitarioVenta] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[valorTotalInsumosV]  AS ([valorUnitarioVenta]*[stock]),
	[valorUnitarioCompra] [int] NOT NULL,
	[valorTotalUCompra]  AS ([valorUnitarioCompra]*[stock]),
	[gananciaUnitaria] [int] NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiquidacionProductor]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiquidacionProductor](
	[idLiquidacion] [int] IDENTITY(1,1) NOT NULL,
	[fechaLiquidacion] [date] NOT NULL,
	[totalProduccion] [bigint] NOT NULL,
	[totalInsumos] [int] NOT NULL,
	[TotalPagar]  AS ([totalProduccion]-[totalInsumos]),
	[id_persona] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLiquidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[idLogin] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[id_Acopio] [int] NOT NULL,
	[id_Rol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[idNomina] [int] IDENTITY(1,1) NOT NULL,
	[id_Persona] [int] NOT NULL,
	[salario] [decimal](18, 0) NOT NULL,
	[fechaPago] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idNomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](12) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[telefono] [varchar](25) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[id_Acopio] [int] NOT NULL,
	[id_TipoProducto] [int] NOT NULL,
	[id_Rol] [int] NOT NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produccion]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produccion](
	[idProduccion] [int] IDENTITY(1,1) NOT NULL,
	[diaIngresoProducto] [date] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioProducto] [int] NOT NULL,
	[observaciones] [varchar](150) NOT NULL,
	[valorProducto]  AS ([cantidad]*[precioProducto]),
	[id_Persona] [int] NOT NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_User]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_User](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombreRol] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[idTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[nombreTipoProducto] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[idTipoProducto] [int] IDENTITY(1,1) NOT NULL,
	[tipoProducto] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaInsumo]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaInsumo](
	[idVentaInsumo] [int] IDENTITY(1000,1) NOT NULL,
	[id_Persona] [int] NOT NULL,
	[id_tipoPago] [int] NULL,
	[observacion] [varchar](150) NOT NULL,
	[fechaRegistro] [datetime] NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idVentaInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaProduccion]    Script Date: 30/06/2023 9:59:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaProduccion](
	[idVentaProduccion] [int] IDENTITY(1000,1) NOT NULL,
	[id_Acopio] [int] NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](10, 2) NULL,
	[totalVentaProduccion]  AS ([cantidad]*[precio]),
	[observaciones] [varchar](250) NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idVentaProduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Acopio] ON 

INSERT [dbo].[Acopio] ([idAcopio], [nombreAcopi], [ubicacion], [cantidadEmpleados], [estado]) VALUES (1, N'AcopiMilk', N'Valdivia', 1, 1)
SET IDENTITY_INSERT [dbo].[Acopio] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleVentaInsumo] ON 

INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (5, 1, 1004, 5, 92000, 460000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (6, 1, 1005, 3, 92000, 276000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (7, 5, 1006, 1, 8500, 8500, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (8, 2, 1007, 2, 84000, 168000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (9, 1, 1008, 3, 92000, 276000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (10, 3, 1009, 2, 12500, 25000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (11, 1, 1010, 3, 92000, 276000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (12, 2, 1011, 1, 84000, 84000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (13, 1, 1012, 2, 92000, 184000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (14, 1, 1013, 4, 92000, 368000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (15, 3, 1014, 2, 12500, 25000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (16, 1, 1015, 3, 92000, 276000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (17, 3, 1016, 3, 12500, 37500, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (18, 5, 1017, 10, 8500, 85000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (19, 1, 1018, 3, 92000, 276000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (20, 4, 1019, 2, 72000, 144000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (21, 2, 1020, 2, 84000, 168000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (22, 1, 1021, 1, 92000, 92000, 1)
INSERT [dbo].[DetalleVentaInsumo] ([idDetalleVentaInsumo], [id_Insumo], [id_VentaInsumo], [cantidad], [precio], [totalVentaInsumo], [estado]) VALUES (23, 2, 1022, 1, 84000, 84000, 1)
SET IDENTITY_INSERT [dbo].[DetalleVentaInsumo] OFF
GO
SET IDENTITY_INSERT [dbo].[EgresosAcopio] ON 

INSERT [dbo].[EgresosAcopio] ([idEgresosAcopio], [id_acopio], [arriendo], [sumatoriaNominas], [servicios], [sumatoriaLiquidacion], [gastosExtras], [TotalEgresos], [fechaInicailEgresos], [fechaFinalIngresosEgresos]) VALUES (8, 1, 1500000, 1400000, 500000, 13077500, 250000, 16727500, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-15' AS Date))
SET IDENTITY_INSERT [dbo].[EgresosAcopio] OFF
GO
SET IDENTITY_INSERT [dbo].[IngresosAcopio] ON 

INSERT [dbo].[IngresosAcopio] ([idIngresosAcopio], [id_acopio], [totalGananciaInsumos], [TotalGananciaProduccion], [fechaInicailIngresos], [fechaFinalIngresosLiquidacion], [TotalIngresos]) VALUES (3, 1, 2886500, 20522400, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-15' AS Date), 23408900)
INSERT [dbo].[IngresosAcopio] ([idIngresosAcopio], [id_acopio], [totalGananciaInsumos], [TotalGananciaProduccion], [fechaInicailIngresos], [fechaFinalIngresosLiquidacion], [TotalIngresos]) VALUES (6, 1, 886500, 19734000, CAST(N'2023-06-16' AS Date), CAST(N'2023-06-30' AS Date), 20620500)
SET IDENTITY_INSERT [dbo].[IngresosAcopio] OFF
GO
SET IDENTITY_INSERT [dbo].[Insumo] ON 

INSERT [dbo].[Insumo] ([idInsumo], [nombreInsumo], [descripcion], [valorUnitarioVenta], [stock], [valorUnitarioCompra], [gananciaUnitaria], [estado]) VALUES (1, N'Bulto de Fertileche', N'concentrado para vacas en produccion', 92000, 31, 87000, 5000, 1)
INSERT [dbo].[Insumo] ([idInsumo], [nombreInsumo], [descripcion], [valorUnitarioVenta], [stock], [valorUnitarioCompra], [gananciaUnitaria], [estado]) VALUES (2, N'Bulto de sal  8% X50kg', N'sal al 8% de fosforo', 84000, 19, 78000, 6000, 1)
INSERT [dbo].[Insumo] ([idInsumo], [nombreInsumo], [descripcion], [valorUnitarioVenta], [stock], [valorUnitarioCompra], [gananciaUnitaria], [estado]) VALUES (3, N'Premezcla X2kg', N'sal mineralizada para vacas', 12500, 33, 8500, 4000, 1)
INSERT [dbo].[Insumo] ([idInsumo], [nombreInsumo], [descripcion], [valorUnitarioVenta], [stock], [valorUnitarioCompra], [gananciaUnitaria], [estado]) VALUES (4, N'Bulto de Deltaleche', N'Concentrado para vacas', 72000, 8, 65000, 7000, 1)
INSERT [dbo].[Insumo] ([idInsumo], [nombreInsumo], [descripcion], [valorUnitarioVenta], [stock], [valorUnitarioCompra], [gananciaUnitaria], [estado]) VALUES (5, N'Filtro redondo', N'Filtro para leche Farmer', 8500, 14, 6000, 2500, 1)
SET IDENTITY_INSERT [dbo].[Insumo] OFF
GO
SET IDENTITY_INSERT [dbo].[LiquidacionProductor] ON 

INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (10, CAST(N'2023-06-15' AS Date), 3412000, 544000, 3)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (11, CAST(N'2023-06-15' AS Date), 6654000, 393000, 4)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (12, CAST(N'2023-06-15' AS Date), 3346000, 276000, 5)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (13, CAST(N'2023-06-30' AS Date), 1448000, 253000, 1)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (14, CAST(N'2023-06-30' AS Date), 1334000, 37500, 2)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (15, CAST(N'2023-06-30' AS Date), 3136800, 276000, 3)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (16, CAST(N'2023-06-30' AS Date), 6538000, 176000, 4)
INSERT [dbo].[LiquidacionProductor] ([idLiquidacion], [fechaLiquidacion], [totalProduccion], [totalInsumos], [id_persona]) VALUES (17, CAST(N'2023-06-30' AS Date), 3502000, 144000, 5)
SET IDENTITY_INSERT [dbo].[LiquidacionProductor] OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([idLogin], [usuario], [password], [id_Acopio], [id_Rol]) VALUES (3, N'admin', N'admin', 1, 2)
INSERT [dbo].[Login] ([idLogin], [usuario], [password], [id_Acopio], [id_Rol]) VALUES (4, N'emple', N'emple', 1, 2)
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Nomina] ON 

INSERT [dbo].[Nomina] ([idNomina], [id_Persona], [salario], [fechaPago]) VALUES (1, 6, CAST(1400000 AS Decimal(18, 0)), CAST(N'2023-06-15' AS Date))
SET IDENTITY_INSERT [dbo].[Nomina] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (1, N'15445587', N'Javier', N'Martinez', N'314057829', N'Puerto Valdivia', 1, 1, 3, 1)
INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (2, N'15452445', N'Guillermo', N'Cañas', N'3137745483', N'Puerto valdivia', 1, 1, 3, 1)
INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (3, N'9044572', N'Santiago', N'Zapata', N'3147589635', N'Puerto valdivia', 1, 1, 3, 1)
INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (4, N'1439658', N'Ovidio ', N'Osorio', N'3137746935', N'Puerto valdivia', 1, 1, 3, 1)
INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (5, N'34154363', N'Yolanda Edith', N'Castaño', N'3145832617', N'El doce', 1, 1, 3, 1)
INSERT [dbo].[Persona] ([idPersona], [cedula], [nombres], [apellidos], [telefono], [direccion], [id_Acopio], [id_TipoProducto], [id_Rol], [estado]) VALUES (6, N'1532411', N'Juan David', N'Hernandez', N'3134758963', N'Puerto Valdivia', 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Produccion] ON 

INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (1, CAST(N'2023-06-01' AS Date), 46, 2000, N'buena', 1, 0)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (2, CAST(N'2023-06-02' AS Date), 52, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (3, CAST(N'2023-06-03' AS Date), 46, 2000, N'buena', 1, 0)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (4, CAST(N'2023-06-04' AS Date), 47, 2000, N'buena', 1, 0)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (5, CAST(N'2023-06-05' AS Date), 45, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (6, CAST(N'2023-06-06' AS Date), 48, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (7, CAST(N'2023-06-07' AS Date), 43, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (8, CAST(N'2023-06-08' AS Date), 45, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (9, CAST(N'2023-06-09' AS Date), 41, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (10, CAST(N'2023-06-10' AS Date), 43, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (11, CAST(N'2023-06-12' AS Date), 43, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (12, CAST(N'2023-06-13' AS Date), 41, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (13, CAST(N'2023-06-14' AS Date), 41, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (14, CAST(N'2023-06-26' AS Date), 41, 2000, N'buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (15, CAST(N'2023-06-01' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (16, CAST(N'2023-06-02' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (17, CAST(N'2023-06-03' AS Date), 36, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (18, CAST(N'2023-06-04' AS Date), 41, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (19, CAST(N'2023-06-05' AS Date), 45, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (20, CAST(N'2023-06-06' AS Date), 41, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (21, CAST(N'2023-06-07' AS Date), 50, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (22, CAST(N'2023-06-08' AS Date), 52, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (23, CAST(N'2023-06-09' AS Date), 53, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (24, CAST(N'2023-06-10' AS Date), 57, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (25, CAST(N'2023-06-11' AS Date), 50, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (26, CAST(N'2023-06-12' AS Date), 45, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (27, CAST(N'2023-06-13' AS Date), 47, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (28, CAST(N'2023-06-14' AS Date), 49, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (29, CAST(N'2023-06-15' AS Date), 49, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (30, CAST(N'2023-06-01' AS Date), 100, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (31, CAST(N'2023-06-02' AS Date), 110, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (32, CAST(N'2023-06-03' AS Date), 115, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (33, CAST(N'2023-06-04' AS Date), 110, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (34, CAST(N'2023-06-05' AS Date), 110, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (35, CAST(N'2023-06-06' AS Date), 115, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (36, CAST(N'2023-06-07' AS Date), 113, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (37, CAST(N'2023-06-08' AS Date), 118, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (38, CAST(N'2023-06-09' AS Date), 110, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (39, CAST(N'2023-06-10' AS Date), 115, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (40, CAST(N'2023-06-11' AS Date), 117, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (41, CAST(N'2023-06-12' AS Date), 111, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (42, CAST(N'2023-06-13' AS Date), 120, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (43, CAST(N'2023-06-14' AS Date), 125, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (44, CAST(N'2023-06-15' AS Date), 117, 2000, N'buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (45, CAST(N'2023-06-01' AS Date), 200, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (46, CAST(N'2023-06-02' AS Date), 220, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (47, CAST(N'2023-06-03' AS Date), 225, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (48, CAST(N'2023-06-04' AS Date), 224, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (49, CAST(N'2023-06-05' AS Date), 215, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (50, CAST(N'2023-06-06' AS Date), 223, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (51, CAST(N'2023-06-07' AS Date), 210, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (52, CAST(N'2023-06-08' AS Date), 230, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (53, CAST(N'2023-06-09' AS Date), 235, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (54, CAST(N'2023-06-10' AS Date), 240, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (55, CAST(N'2023-06-11' AS Date), 210, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (56, CAST(N'2023-06-12' AS Date), 230, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (57, CAST(N'2023-06-13' AS Date), 220, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (58, CAST(N'2023-06-14' AS Date), 215, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (59, CAST(N'2023-06-15' AS Date), 230, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (60, CAST(N'2023-06-01' AS Date), 100, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (61, CAST(N'2023-06-02' AS Date), 100, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (62, CAST(N'2023-06-03' AS Date), 99, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (63, CAST(N'2023-06-04' AS Date), 110, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (64, CAST(N'2023-06-05' AS Date), 115, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (65, CAST(N'2023-06-06' AS Date), 107, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (66, CAST(N'2023-06-07' AS Date), 114, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (67, CAST(N'2023-06-08' AS Date), 118, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (68, CAST(N'2023-06-09' AS Date), 113, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (69, CAST(N'2023-06-10' AS Date), 120, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (70, CAST(N'2023-06-11' AS Date), 113, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (71, CAST(N'2023-06-12' AS Date), 110, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (72, CAST(N'2023-06-13' AS Date), 110, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (73, CAST(N'2023-06-14' AS Date), 114, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (74, CAST(N'2023-06-15' AS Date), 130, 2000, N'buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (75, CAST(N'2023-06-16' AS Date), 40, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (76, CAST(N'2023-06-17' AS Date), 45, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (77, CAST(N'2023-06-18' AS Date), 48, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (78, CAST(N'2023-06-19' AS Date), 55, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (79, CAST(N'2023-06-20' AS Date), 43, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (80, CAST(N'2023-06-21' AS Date), 46, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (81, CAST(N'2023-06-22' AS Date), 46, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (82, CAST(N'2023-06-23' AS Date), 52, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (83, CAST(N'2023-06-24' AS Date), 43, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (84, CAST(N'2023-06-25' AS Date), 45, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (85, CAST(N'2023-06-26' AS Date), 41, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (86, CAST(N'2023-06-27' AS Date), 43, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (87, CAST(N'2023-06-28' AS Date), 43, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (88, CAST(N'2023-06-29' AS Date), 47, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (89, CAST(N'2023-06-30' AS Date), 46, 2000, N'Buena', 1, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (90, CAST(N'2023-06-16' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (91, CAST(N'2023-06-17' AS Date), 42, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (92, CAST(N'2023-06-18' AS Date), 45, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (93, CAST(N'2023-06-19' AS Date), 47, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (94, CAST(N'2023-06-20' AS Date), 50, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (95, CAST(N'2023-06-21' AS Date), 45, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (96, CAST(N'2023-06-22' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (97, CAST(N'2023-06-23' AS Date), 43, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (98, CAST(N'2023-06-24' AS Date), 47, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (99, CAST(N'2023-06-25' AS Date), 49, 2000, N'buena', 2, 1)
GO
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (100, CAST(N'2023-06-26' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (101, CAST(N'2023-06-27' AS Date), 49, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (102, CAST(N'2023-06-28' AS Date), 40, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (103, CAST(N'2023-06-29' AS Date), 47, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (104, CAST(N'2023-06-30' AS Date), 43, 2000, N'buena', 2, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (105, CAST(N'2023-06-16' AS Date), 115, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (106, CAST(N'2023-06-17' AS Date), 117, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (107, CAST(N'2023-06-18' AS Date), 120, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (108, CAST(N'2023-06-19' AS Date), 125, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (109, CAST(N'2023-06-20' AS Date), 118, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (110, CAST(N'2023-06-21' AS Date), 118, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (111, CAST(N'2023-06-22' AS Date), 123, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (112, CAST(N'2023-06-23' AS Date), 116, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (113, CAST(N'2023-06-24' AS Date), 116, 200, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (114, CAST(N'2023-06-25' AS Date), 116, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (115, CAST(N'2023-06-26' AS Date), 118, 200, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (116, CAST(N'2023-06-28' AS Date), 120, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (117, CAST(N'2023-06-27' AS Date), 116, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (118, CAST(N'2023-06-29' AS Date), 116, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (119, CAST(N'2023-06-30' AS Date), 125, 2000, N'Buena', 3, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (120, CAST(N'2023-06-16' AS Date), 200, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (121, CAST(N'2023-06-17' AS Date), 215, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (122, CAST(N'2023-06-18' AS Date), 220, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (123, CAST(N'2023-06-19' AS Date), 207, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (124, CAST(N'2023-06-20' AS Date), 213, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (125, CAST(N'2023-06-21' AS Date), 220, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (126, CAST(N'2023-06-22' AS Date), 225, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (127, CAST(N'2023-06-23' AS Date), 223, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (128, CAST(N'2023-06-24' AS Date), 224, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (129, CAST(N'2023-06-25' AS Date), 220, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (130, CAST(N'2023-06-26' AS Date), 223, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (131, CAST(N'2023-06-27' AS Date), 230, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (132, CAST(N'2023-06-28' AS Date), 224, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (133, CAST(N'2023-06-29' AS Date), 225, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (134, CAST(N'2023-06-30' AS Date), 200, 2000, N'buena', 4, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (135, CAST(N'2023-06-15' AS Date), 131, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (136, CAST(N'2023-06-17' AS Date), 122, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (137, CAST(N'2023-06-18' AS Date), 128, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (138, CAST(N'2023-06-19' AS Date), 117, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (139, CAST(N'2023-06-20' AS Date), 135, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (140, CAST(N'2023-06-21' AS Date), 120, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (141, CAST(N'2023-06-22' AS Date), 131, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (142, CAST(N'2023-06-23' AS Date), 118, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (143, CAST(N'2023-06-24' AS Date), 126, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (144, CAST(N'2023-06-25' AS Date), 132, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (145, CAST(N'2023-06-26' AS Date), 116, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (146, CAST(N'2023-06-27' AS Date), 126, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (147, CAST(N'2023-06-28' AS Date), 132, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (148, CAST(N'2023-06-29' AS Date), 133, 2000, N'Buena', 5, 1)
INSERT [dbo].[Produccion] ([idProduccion], [diaIngresoProducto], [cantidad], [precioProducto], [observaciones], [id_Persona], [estado]) VALUES (149, CAST(N'2023-06-30' AS Date), 115, 2000, N'Buena', 5, 1)
SET IDENTITY_INSERT [dbo].[Produccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_User] ON 

INSERT [dbo].[Rol_User] ([idRol], [nombreRol]) VALUES (1, N'ADMINISTRADOR')
INSERT [dbo].[Rol_User] ([idRol], [nombreRol]) VALUES (2, N'EMPLEADO')
INSERT [dbo].[Rol_User] ([idRol], [nombreRol]) VALUES (3, N'PRODUCTOR')
SET IDENTITY_INSERT [dbo].[Rol_User] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPago] ON 

INSERT [dbo].[TipoPago] ([idTipoPago], [nombreTipoProducto]) VALUES (1, N'CONTADO')
INSERT [dbo].[TipoPago] ([idTipoPago], [nombreTipoProducto]) VALUES (2, N'FIADO')
SET IDENTITY_INSERT [dbo].[TipoPago] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoProducto] ON 

INSERT [dbo].[TipoProducto] ([idTipoProducto], [tipoProducto], [estado]) VALUES (1, N'LECHE', 1)
SET IDENTITY_INSERT [dbo].[TipoProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[VentaInsumo] ON 

INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1004, 1, 1, N'ASDSAD', CAST(N'2023-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1005, 1, 1, N'ninguna', CAST(N'2023-06-04T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1006, 1, 1, N'ninguna', CAST(N'2023-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1007, 2, 1, N'ninguna', CAST(N'2023-06-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1008, 2, 2, N'ninguna', CAST(N'2023-06-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1009, 2, 2, N'ninguna', CAST(N'2023-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1010, 3, 2, N'ninguna', CAST(N'2023-06-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1011, 3, 2, N'ninguna', CAST(N'2023-06-10T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1012, 3, 2, N'ninguna', CAST(N'2023-06-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1013, 4, 2, N'ninguna', CAST(N'2023-06-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1014, 4, 2, N'ninguna', CAST(N'2023-06-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1015, 5, 2, N'ninguna', CAST(N'2023-06-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1016, 2, 1, N'Ninguna', CAST(N'2023-06-22T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1017, 1, 2, N'Ninguno', CAST(N'2023-06-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1018, 3, 2, N'Ninguno', CAST(N'2023-06-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1019, 5, 2, N'Ninguna', CAST(N'2023-06-26T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1020, 1, 2, N'Ninguna', CAST(N'2023-06-24T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1021, 4, 2, N'Ninguna', CAST(N'2023-06-28T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[VentaInsumo] ([idVentaInsumo], [id_Persona], [id_tipoPago], [observacion], [fechaRegistro], [estado]) VALUES (1022, 4, 2, N'Ninguno', CAST(N'2023-06-24T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[VentaInsumo] OFF
GO
SET IDENTITY_INSERT [dbo].[VentaProduccion] ON 

INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1000, 1, CAST(N'2023-06-06' AS Date), 270, CAST(2400.00 AS Decimal(10, 2)), N'buena', 0)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1001, 1, CAST(N'2023-06-14' AS Date), 300, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 0)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1002, 1, CAST(N'2023-06-03' AS Date), 2000, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1003, 1, CAST(N'2023-06-07' AS Date), 1700, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1004, 1, CAST(N'2023-06-09' AS Date), 1427, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1005, 1, CAST(N'2023-06-12' AS Date), 1427, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1006, 1, CAST(N'2023-06-14' AS Date), 1427, CAST(2400.00 AS Decimal(10, 2)), N'ninguna', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1007, 1, CAST(N'2023-06-18' AS Date), 1550, CAST(2400.00 AS Decimal(10, 2)), N'Buena', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1008, 1, CAST(N'2023-06-21' AS Date), 1875, CAST(2000.00 AS Decimal(10, 2)), N'Leche Acida', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1009, 1, CAST(N'2023-06-24' AS Date), 2000, CAST(2400.00 AS Decimal(10, 2)), N'Buena', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1010, 1, CAST(N'2023-06-28' AS Date), 1710, CAST(2400.00 AS Decimal(10, 2)), N'Buena', 1)
INSERT [dbo].[VentaProduccion] ([idVentaProduccion], [id_Acopio], [fechaVenta], [cantidad], [precio], [observaciones], [estado]) VALUES (1011, 1, CAST(N'2023-06-30' AS Date), 1400, CAST(2400.00 AS Decimal(10, 2)), N'Leche Buena', 1)
SET IDENTITY_INSERT [dbo].[VentaProduccion] OFF
GO
ALTER TABLE [dbo].[Acopio] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Bodega] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[DetalleVentaInsumo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Insumo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[LiquidacionProductor] ADD  DEFAULT (getdate()) FOR [fechaLiquidacion]
GO
ALTER TABLE [dbo].[Nomina] ADD  DEFAULT (getdate()) FOR [fechaPago]
GO
ALTER TABLE [dbo].[Persona] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Produccion] ADD  DEFAULT (getdate()) FOR [diaIngresoProducto]
GO
ALTER TABLE [dbo].[Produccion] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TipoProducto] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[VentaInsumo] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[VentaInsumo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[VentaProduccion] ADD  DEFAULT (getdate()) FOR [fechaVenta]
GO
ALTER TABLE [dbo].[VentaProduccion] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[DetalleVentaInsumo]  WITH CHECK ADD FOREIGN KEY([id_Insumo])
REFERENCES [dbo].[Insumo] ([idInsumo])
GO
ALTER TABLE [dbo].[DetalleVentaInsumo]  WITH CHECK ADD FOREIGN KEY([id_VentaInsumo])
REFERENCES [dbo].[VentaInsumo] ([idVentaInsumo])
GO
ALTER TABLE [dbo].[EgresosAcopio]  WITH CHECK ADD FOREIGN KEY([id_acopio])
REFERENCES [dbo].[Acopio] ([idAcopio])
GO
ALTER TABLE [dbo].[IngresosAcopio]  WITH CHECK ADD FOREIGN KEY([id_acopio])
REFERENCES [dbo].[Acopio] ([idAcopio])
GO
ALTER TABLE [dbo].[LiquidacionProductor]  WITH CHECK ADD FOREIGN KEY([id_persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD FOREIGN KEY([id_Acopio])
REFERENCES [dbo].[Acopio] ([idAcopio])
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD FOREIGN KEY([id_Rol])
REFERENCES [dbo].[Rol_User] ([idRol])
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD FOREIGN KEY([id_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([id_Acopio])
REFERENCES [dbo].[Acopio] ([idAcopio])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([id_Rol])
REFERENCES [dbo].[Rol_User] ([idRol])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([id_TipoProducto])
REFERENCES [dbo].[TipoProducto] ([idTipoProducto])
GO
ALTER TABLE [dbo].[Produccion]  WITH CHECK ADD FOREIGN KEY([id_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[VentaInsumo]  WITH CHECK ADD FOREIGN KEY([id_Persona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[VentaInsumo]  WITH CHECK ADD FOREIGN KEY([id_tipoPago])
REFERENCES [dbo].[TipoPago] ([idTipoPago])
GO
ALTER TABLE [dbo].[VentaProduccion]  WITH CHECK ADD FOREIGN KEY([id_Acopio])
REFERENCES [dbo].[Acopio] ([idAcopio])
GO
ALTER TABLE [dbo].[Rol_User]  WITH CHECK ADD CHECK  (([nombreRol]='PRODUCTOR' OR [nombreRol]='EMPLEADO' OR [nombreRol]='ADMINISTRADOR'))
GO
USE [master]
GO
ALTER DATABASE [AcopioExpressDB] SET  READ_WRITE 
GO
