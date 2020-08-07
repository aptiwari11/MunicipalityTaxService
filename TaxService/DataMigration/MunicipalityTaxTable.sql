USE [MunicipalityTaxRecord]
GO

/****** Object:  Table [dbo].[MunicipalityTaxRecord]    Script Date: 8/7/2020 7:31:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MunicipalityTaxRecord](
	[MunicipalityName] [nvarchar](50) NOT NULL,
	[ScheduleStart] [date] NULL,
	[ScheduleEnd] [date] NULL,
	[TaxRate] [decimal](3, 2) NULL,
	[Period] [int] NULL
) ON [PRIMARY]
GO


