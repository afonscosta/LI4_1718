USE [master]
GO
/****** Object:  Database [BreadSpread]    Script Date: 12/04/18 09:55:04 ******/
CREATE DATABASE [BreadSpread]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BreadSpread', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BreadSpread.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BreadSpread_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BreadSpread_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BreadSpread] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BreadSpread].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BreadSpread] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BreadSpread] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BreadSpread] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BreadSpread] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BreadSpread] SET ARITHABORT OFF 
GO
ALTER DATABASE [BreadSpread] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BreadSpread] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BreadSpread] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BreadSpread] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BreadSpread] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BreadSpread] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BreadSpread] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BreadSpread] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BreadSpread] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BreadSpread] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BreadSpread] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BreadSpread] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BreadSpread] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BreadSpread] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BreadSpread] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BreadSpread] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BreadSpread] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BreadSpread] SET RECOVERY FULL 
GO
ALTER DATABASE [BreadSpread] SET  MULTI_USER 
GO
ALTER DATABASE [BreadSpread] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BreadSpread] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BreadSpread] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BreadSpread] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BreadSpread] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BreadSpread', N'ON'
GO
ALTER DATABASE [BreadSpread] SET QUERY_STORE = OFF
GO
USE [BreadSpread]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BreadSpread]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/04/18 09:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCli] [int] NOT NULL,
	[nome] [nchar](100) NOT NULL,
	[dataNasc] [date] NOT NULL,
	[NIF] [nchar](9) NOT NULL,
	[genero] [char](1) NOT NULL,
	[email] [nchar](30) NOT NULL,
	[idMorada] [int] NOT NULL,
	[idSub] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda](
	[idEnc] [int] NOT NULL,
	[idCli] [int] NOT NULL,
	[data] [date] NOT NULL,
	[valor] [float] NOT NULL,
 CONSTRAINT [PK_Encomenda] PRIMARY KEY CLUSTERED 
(
	[idEnc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encomenda_Produto]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda_Produto](
	[idEnc] [int] NOT NULL,
	[idProd] [int] NOT NULL,
	[quant] [int] NOT NULL,
 CONSTRAINT [PK_Encomenda_Produto] PRIMARY KEY CLUSTERED 
(
	[idEnc] ASC,
	[idProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[idEntrega] [int] NOT NULL,
	[idMorada] [int] NOT NULL,
	[idCli] [int] NOT NULL,
	[idEnc] [int] NOT NULL,
	[idFunc] [int] NOT NULL,
 CONSTRAINT [PK_Entrega] PRIMARY KEY CLUSTERED 
(
	[idEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[idFunc] [int] NOT NULL,
	[nome] [nchar](100) NOT NULL,
	[dataNasc] [date] NOT NULL,
	[contacto] [nchar](13) NOT NULL,
	[idMorada] [int] NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[idFunc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Morada]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Morada](
	[idMorada] [int] NOT NULL,
	[rua] [nchar](100) NOT NULL,
	[numPorta] [int] NOT NULL,
	[codPostal] [nchar](10) NOT NULL,
	[cidade] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Morada] PRIMARY KEY CLUSTERED 
(
	[idMorada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagamento]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamento](
	[idPag] [int] NOT NULL,
	[data] [date] NOT NULL,
	[idCli] [int] NOT NULL,
	[idEntrega] [int] NOT NULL,
	[modo_pag] [nchar](20) NOT NULL,
	[valor] [float] NOT NULL,
	[fatura] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Pagamento] PRIMARY KEY CLUSTERED 
(
	[idPag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[idProd] [int] NOT NULL,
	[descr] [nchar](50) NOT NULL,
	[ingredientes] [nchar](200) NOT NULL,
	[info_nut] [nchar](200) NOT NULL,
	[preco] [float] NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[idProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscricao]    Script Date: 12/04/18 09:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscricao](
	[idSub] [int] NOT NULL,
	[designacao] [nchar](50) NOT NULL,
	[custo] [float] NOT NULL,
	[plano_ent] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Subscricao] PRIMARY KEY CLUSTERED 
(
	[idSub] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Morada] FOREIGN KEY([idMorada])
REFERENCES [dbo].[Morada] ([idMorada])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Morada]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Subscricao] FOREIGN KEY([idSub])
REFERENCES [dbo].[Subscricao] ([idSub])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Subscricao]
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Cliente] FOREIGN KEY([idCli])
REFERENCES [dbo].[Cliente] ([idCli])
GO
ALTER TABLE [dbo].[Encomenda] CHECK CONSTRAINT [FK_Encomenda_Cliente]
GO
ALTER TABLE [dbo].[Encomenda_Produto]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Produto_Encomenda] FOREIGN KEY([idEnc])
REFERENCES [dbo].[Encomenda] ([idEnc])
GO
ALTER TABLE [dbo].[Encomenda_Produto] CHECK CONSTRAINT [FK_Encomenda_Produto_Encomenda]
GO
ALTER TABLE [dbo].[Encomenda_Produto]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Produto_Produto] FOREIGN KEY([idProd])
REFERENCES [dbo].[Produto] ([idProd])
GO
ALTER TABLE [dbo].[Encomenda_Produto] CHECK CONSTRAINT [FK_Encomenda_Produto_Produto]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_Cliente] FOREIGN KEY([idCli])
REFERENCES [dbo].[Cliente] ([idCli])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_Cliente]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_Funcionario] FOREIGN KEY([idFunc])
REFERENCES [dbo].[Funcionario] ([idFunc])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_Funcionario]
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD  CONSTRAINT [FK_Entrega_Morada] FOREIGN KEY([idMorada])
REFERENCES [dbo].[Morada] ([idMorada])
GO
ALTER TABLE [dbo].[Entrega] CHECK CONSTRAINT [FK_Entrega_Morada]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Morada] FOREIGN KEY([idMorada])
REFERENCES [dbo].[Morada] ([idMorada])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Morada]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD  CONSTRAINT [FK_Pagamento_Cliente] FOREIGN KEY([idCli])
REFERENCES [dbo].[Cliente] ([idCli])
GO
ALTER TABLE [dbo].[Pagamento] CHECK CONSTRAINT [FK_Pagamento_Cliente]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD  CONSTRAINT [FK_Pagamento_Entrega] FOREIGN KEY([idEntrega])
REFERENCES [dbo].[Entrega] ([idEntrega])
GO
ALTER TABLE [dbo].[Pagamento] CHECK CONSTRAINT [FK_Pagamento_Entrega]
GO
USE [master]
GO
ALTER DATABASE [BreadSpread] SET  READ_WRITE 
GO
