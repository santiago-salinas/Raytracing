USE [master]
GO
/****** Object:  Database [EFDatabase]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE DATABASE [EFDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFDatabase2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EFDatabase2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EFDatabase2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EFDatabase2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EFDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EFDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EFDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EFDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EFDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EFDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [EFDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EFDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EFDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EFDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EFDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EFDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EFDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EFDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EFDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EFDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EFDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EFDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EFDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EFDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EFDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EFDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EFDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EFDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EFDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [EFDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EFDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EFDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EFDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EFDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EFDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EFDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [EFDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EFDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CameraEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CameraEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[LookFrom_FirstValue] [float] NOT NULL,
	[LookFrom_SecondValue] [float] NOT NULL,
	[LookFrom_ThirdValue] [float] NOT NULL,
	[LookAt_FirstValue] [float] NOT NULL,
	[LookAt_SecondValue] [float] NOT NULL,
	[LookAt_ThirdValue] [float] NOT NULL,
	[Up_FirstValue] [float] NOT NULL,
	[Up_SecondValue] [float] NOT NULL,
	[Up_ThirdValue] [float] NOT NULL,
	[FieldOfView] [int] NOT NULL,
	[ResolutionX] [int] NOT NULL,
	[ResolutionY] [int] NOT NULL,
	[SamplesPerPixel] [int] NOT NULL,
	[MaxDepth] [int] NOT NULL,
	[Aperture] [float] NOT NULL,
 CONSTRAINT [PK_dbo.CameraEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LambertianEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LambertianEntities](
	[MaterialName] [nvarchar](128) NOT NULL,
	[MaterialOwnerId] [nvarchar](128) NOT NULL,
	[RedValue] [int] NOT NULL,
	[GreenValue] [int] NOT NULL,
	[BlueValue] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LambertianEntities] PRIMARY KEY CLUSTERED 
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialEntities](
	[Name] [nvarchar](128) NOT NULL,
	[OwnerId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.MaterialEntities] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetallicEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetallicEntities](
	[MaterialName] [nvarchar](128) NOT NULL,
	[MaterialOwnerId] [nvarchar](128) NOT NULL,
	[RedValue] [int] NOT NULL,
	[GreenValue] [int] NOT NULL,
	[BlueValue] [int] NOT NULL,
	[Roughness] [float] NOT NULL,
 CONSTRAINT [PK_dbo.MetallicEntities] PRIMARY KEY CLUSTERED 
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelEntities](
	[Name] [nvarchar](128) NOT NULL,
	[OwnerId] [nvarchar](128) NOT NULL,
	[Material_Name] [nvarchar](128) NULL,
	[Material_OwnerId] [nvarchar](128) NULL,
	[PPMEntity_Id] [uniqueidentifier] NULL,
	[Shape_Name] [nvarchar](128) NULL,
	[Shape_OwnerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ModelEntities] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionedModelEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionedModelEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[PositionX] [float] NOT NULL,
	[PositionY] [float] NOT NULL,
	[PositionZ] [float] NOT NULL,
	[Model_Name] [nvarchar](128) NULL,
	[Model_OwnerId] [nvarchar](128) NULL,
	[SceneEntity_Name] [nvarchar](128) NULL,
	[SceneEntity_OwnerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.PositionedModelEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PPMEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PPMEntities](
	[Id] [uniqueidentifier] NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[RenderBytes] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.PPMEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SceneEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SceneEntities](
	[Name] [nvarchar](128) NOT NULL,
	[OwnerId] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NULL,
	[LastModificationDate] [datetime] NULL,
	[LastRenderDate] [datetime] NULL,
	[Blur] [bit] NOT NULL,
	[CameraDTO_Id] [uniqueidentifier] NULL,
	[PPMEntity_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.SceneEntities] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SphereEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SphereEntities](
	[Name] [nvarchar](128) NOT NULL,
	[OwnerId] [nvarchar](128) NOT NULL,
	[Radius] [float] NOT NULL,
 CONSTRAINT [PK_dbo.SphereEntities] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEntities]    Script Date: 14-Jun-23 3:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEntities](
	[Username] [nvarchar](128) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserEntities] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaterialName_MaterialOwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_MaterialName_MaterialOwnerId] ON [dbo].[LambertianEntities]
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_OwnerId] ON [dbo].[MaterialEntities]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaterialName_MaterialOwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_MaterialName_MaterialOwnerId] ON [dbo].[MetallicEntities]
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Material_Name_Material_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_Material_Name_Material_OwnerId] ON [dbo].[ModelEntities]
(
	[Material_Name] ASC,
	[Material_OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_OwnerId] ON [dbo].[ModelEntities]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PPMEntity_Id]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_PPMEntity_Id] ON [dbo].[ModelEntities]
(
	[PPMEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Shape_Name_Shape_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_Shape_Name_Shape_OwnerId] ON [dbo].[ModelEntities]
(
	[Shape_Name] ASC,
	[Shape_OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Model_Name_Model_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_Model_Name_Model_OwnerId] ON [dbo].[PositionedModelEntities]
(
	[Model_Name] ASC,
	[Model_OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SceneEntity_Name_SceneEntity_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_SceneEntity_Name_SceneEntity_OwnerId] ON [dbo].[PositionedModelEntities]
(
	[SceneEntity_Name] ASC,
	[SceneEntity_OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CameraDTO_Id]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_CameraDTO_Id] ON [dbo].[SceneEntities]
(
	[CameraDTO_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_OwnerId] ON [dbo].[SceneEntities]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PPMEntity_Id]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_PPMEntity_Id] ON [dbo].[SceneEntities]
(
	[PPMEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OwnerId]    Script Date: 14-Jun-23 3:57:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_OwnerId] ON [dbo].[SphereEntities]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LambertianEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LambertianEntities_dbo.MaterialEntities_MaterialName_MaterialOwnerId] FOREIGN KEY([MaterialName], [MaterialOwnerId])
REFERENCES [dbo].[MaterialEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[LambertianEntities] CHECK CONSTRAINT [FK_dbo.LambertianEntities_dbo.MaterialEntities_MaterialName_MaterialOwnerId]
GO
ALTER TABLE [dbo].[MaterialEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MaterialEntities_dbo.UserEntities_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[UserEntities] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MaterialEntities] CHECK CONSTRAINT [FK_dbo.MaterialEntities_dbo.UserEntities_OwnerId]
GO
ALTER TABLE [dbo].[MetallicEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MetallicEntities_dbo.MaterialEntities_MaterialName_MaterialOwnerId] FOREIGN KEY([MaterialName], [MaterialOwnerId])
REFERENCES [dbo].[MaterialEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[MetallicEntities] CHECK CONSTRAINT [FK_dbo.MetallicEntities_dbo.MaterialEntities_MaterialName_MaterialOwnerId]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.MaterialEntities_Material_Name_Material_OwnerId] FOREIGN KEY([Material_Name], [Material_OwnerId])
REFERENCES [dbo].[MaterialEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.MaterialEntities_Material_Name_Material_OwnerId]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.PPMEntities_PPMEntity_Id] FOREIGN KEY([PPMEntity_Id])
REFERENCES [dbo].[PPMEntities] ([Id])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.PPMEntities_PPMEntity_Id]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.SphereEntities_Shape_Name_Shape_OwnerId] FOREIGN KEY([Shape_Name], [Shape_OwnerId])
REFERENCES [dbo].[SphereEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.SphereEntities_Shape_Name_Shape_OwnerId]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.UserEntities_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[UserEntities] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.UserEntities_OwnerId]
GO
ALTER TABLE [dbo].[PositionedModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionedModelEntities_dbo.ModelEntities_Model_Name_Model_OwnerId] FOREIGN KEY([Model_Name], [Model_OwnerId])
REFERENCES [dbo].[ModelEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[PositionedModelEntities] CHECK CONSTRAINT [FK_dbo.PositionedModelEntities_dbo.ModelEntities_Model_Name_Model_OwnerId]
GO
ALTER TABLE [dbo].[PositionedModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionedModelEntities_dbo.SceneEntities_SceneEntity_Name_SceneEntity_OwnerId] FOREIGN KEY([SceneEntity_Name], [SceneEntity_OwnerId])
REFERENCES [dbo].[SceneEntities] ([Name], [OwnerId])
GO
ALTER TABLE [dbo].[PositionedModelEntities] CHECK CONSTRAINT [FK_dbo.PositionedModelEntities_dbo.SceneEntities_SceneEntity_Name_SceneEntity_OwnerId]
GO
ALTER TABLE [dbo].[SceneEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SceneEntities_dbo.CameraEntities_CameraDTO_Id] FOREIGN KEY([CameraDTO_Id])
REFERENCES [dbo].[CameraEntities] ([Id])
GO
ALTER TABLE [dbo].[SceneEntities] CHECK CONSTRAINT [FK_dbo.SceneEntities_dbo.CameraEntities_CameraDTO_Id]
GO
ALTER TABLE [dbo].[SceneEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SceneEntities_dbo.PPMEntities_PPMEntity_Id] FOREIGN KEY([PPMEntity_Id])
REFERENCES [dbo].[PPMEntities] ([Id])
GO
ALTER TABLE [dbo].[SceneEntities] CHECK CONSTRAINT [FK_dbo.SceneEntities_dbo.PPMEntities_PPMEntity_Id]
GO
ALTER TABLE [dbo].[SceneEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SceneEntities_dbo.UserEntities_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[UserEntities] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SceneEntities] CHECK CONSTRAINT [FK_dbo.SceneEntities_dbo.UserEntities_OwnerId]
GO
ALTER TABLE [dbo].[SphereEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SphereEntities_dbo.UserEntities_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[UserEntities] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SphereEntities] CHECK CONSTRAINT [FK_dbo.SphereEntities_dbo.UserEntities_OwnerId]
GO
USE [master]
GO
ALTER DATABASE [EFDatabase] SET  READ_WRITE 
GO
