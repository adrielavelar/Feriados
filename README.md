# Feriados

Para subir o banco local com docker:

docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=4dr13lAMARAL" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

Entrar no servidor de banco de dados e executar

USE master
GO
IF NOT EXISTS (SELECT [name]
FROM sys.databases
WHERE [name] = N'FeriadosDb')
CREATE DATABASE FeriadosDb
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariableDates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ano2016] [nvarchar](10) NULL,
	[Ano2017] [nvarchar](10) NULL,
	[Ano2018] [nvarchar](10) NULL,
	[Ano2019] [nvarchar](10) NULL,
	[Ano2020] [nvarchar](10) NULL,
	[Ano2015] [nvarchar](10) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VariableDates] ADD  CONSTRAINT [PK_NewTable-1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feriados](
	[Title] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Legislation] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[StartTime] [nvarchar](30) NOT NULL,
	[EndTime] [nvarchar](30) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VariableId] [int] NOT NULL,
	[Date] [nvarchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feriados] ADD  CONSTRAINT [PK_Feriados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
