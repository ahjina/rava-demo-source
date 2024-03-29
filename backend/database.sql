USE [master]
GO
/****** Object:  Database [dbDemo]    Script Date: 07-Oct-19 11:14:41 PM ******/
CREATE DATABASE [dbDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.KURORYUU\MSSQL\DATA\dbDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.KURORYUU\MSSQL\DATA\dbDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbDemo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbDemo] SET  MULTI_USER 
GO
ALTER DATABASE [dbDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbDemo] SET QUERY_STORE = OFF
GO
USE [dbDemo]
GO
/****** Object:  UserDefinedTableType [dbo].[AttributeDetailModel]    Script Date: 07-Oct-19 11:14:41 PM ******/
CREATE TYPE [dbo].[AttributeDetailModel] AS TABLE(
	[Code] [varchar](32) NULL,
	[AttributeCode] [varchar](32) NULL,
	[Value] [varchar](128) NULL
)
GO
/****** Object:  Table [dbo].[Account]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[PhoneNumber] [varchar](32) NOT NULL,
	[FirstName] [nvarchar](64) NULL,
	[LastName] [nvarchar](64) NULL,
	[Email] [varchar](256) NULL,
	[Password] [varchar](32) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblAccount] PRIMARY KEY CLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributeDetail]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeDetail](
	[ProductCode] [varchar](32) NOT NULL,
	[AttributeCode] [varchar](32) NOT NULL,
	[Value] [varchar](128) NOT NULL,
 CONSTRAINT [PK_tblAttributeDetail] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC,
	[AttributeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[PhoneNumber] [varchar](32) NOT NULL,
	[ProductCode] [varchar](32) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PromotionId] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblCart] PRIMARY KEY CLUSTERED 
(
	[PhoneNumber] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [varchar](32) NOT NULL,
	[ImagePath] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblImage] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterData]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterData](
	[GroupCode] [varchar](64) NOT NULL,
	[Id] [int] NOT NULL,
	[Code] [varchar](32) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Order] [int] NULL,
 CONSTRAINT [PK_tblMasterData] PRIMARY KEY CLUSTERED 
(
	[GroupCode] ASC,
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderCode] [varchar](32) NOT NULL,
	[PhoneNumber] [varchar](32) NOT NULL,
	[TotalQuantity] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[OrderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [varchar](32) NOT NULL,
	[ProductCode] [varchar](32) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PromotionCode] [varchar](32) NULL,
 CONSTRAINT [PK_tblOrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductCode] [varchar](32) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Type] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[PromotionCode] [varchar](64) NOT NULL,
	[PromotionType] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[CreatedBy] [varchar](32) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblPromotion] PRIMARY KEY CLUSTERED 
(
	[PromotionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PromotionDetail]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PromotionCode] [varchar](64) NOT NULL,
	[ProductCode] [varchar](32) NOT NULL,
	[SellOffPercentage] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblPromotionDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'AccountType', 2, N'Admin', N'Admin account', 2)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'AccountType', 1, N'User', N'User account', 1)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'ProductAttribute', 1, N'Temperature', N'Nhiệt độ', 1)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'PromotionType', 2, N'Coupon', N'Coupon', 2)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'PromotionType', 3, N'Sale off', N'Sale off', 3)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'PromotionType', 1, N'Voucher', N'Voucher', 1)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'Temperature', 2, N'Cold', N'Lạnh', 2)
INSERT [dbo].[MasterData] ([GroupCode], [Id], [Code], [Name], [Order]) VALUES (N'Temperature', 1, N'Hot', N'Nóng', 1)
INSERT [dbo].[Product] ([ProductCode], [Name], [Type], [Price], [CreatedDate], [Status]) VALUES (N'PRODUCT-001', N'Cà phê', 1, CAST(18000.00 AS Decimal(18, 2)), CAST(N'2019-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Product] ([ProductCode], [Name], [Type], [Price], [CreatedDate], [Status]) VALUES (N'PRODUCT-002', N'Trà', 2, CAST(20000.00 AS Decimal(18, 2)), CAST(N'2019-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Product] ([ProductCode], [Name], [Type], [Price], [CreatedDate], [Status]) VALUES (N'ProductCode-003', N'Latte', 3, CAST(25000.00 AS Decimal(18, 2)), NULL, 1)
INSERT [dbo].[Product] ([ProductCode], [Name], [Type], [Price], [CreatedDate], [Status]) VALUES (N'ProductCode-004', N'Capuchino', 1, CAST(25000.00 AS Decimal(18, 2)), CAST(N'2019-10-07T23:12:36.897' AS DateTime), 1)
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_tblAccount_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_tblImage_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_tblOrder_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_tblProduct_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  StoredProcedure [dbo].[Product.Insert]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Product.Insert]
	@ProductCode VARCHAR(32),
	@Name NVARCHAR(256),
	@Type INT = NULL,
	@Price DECIMAL(18, 2),
	@TbDetail [dbo].[AttributeDetailModel] READONLY
AS
BEGIN
	INSERT INTO Product
	(
		ProductCode,
		Name,
		[Type],
		Price,
		CreatedDate
	)
	VALUES
	(
		@ProductCode,
		@Name,
		@Type,
		@Price,
		GETDATE()
	)
	
	IF (SELECT COUNT(*) FROM @TbDetail) > 0
	BEGIN
		INSERT INTO AttributeDetail
		(
			ProductCode,
			AttributeCode,
			[Value]
		)
		SELECT t.Code, t.AttributeCode, t.[Value]
		FROM @TbDetail AS t
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[Products.Filter]    Script Date: 07-Oct-19 11:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Products.Filter]
	@ProductCode VARCHAR(32) = NULL,
	@Name NVARCHAR(256) = NULL,
	@Type INT = NULL
AS
BEGIN
	SELECT *
	FROM Product AS p
	WHERE p.[Status] = 1
	AND (@ProductCode IS NULL OR p.ProductCode = @ProductCode)
	AND (@Name IS NULL OR p.Name LIKE N'%' + @Name + '%')
	AND (@Type IS NULL OR p.[Type] = @Type)
END
GO
USE [master]
GO
ALTER DATABASE [dbDemo] SET  READ_WRITE 
GO
