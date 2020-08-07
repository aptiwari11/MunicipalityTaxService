USE [MunicipalityTax]
GO

/****** Object:  Table [dbo].[MunicipalityTaxRecord]    Script Date: 8/7/2020 3:10:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MunicipalityTaxRecord](
	[MunicipalityName] [nvarchar](50) NOT NULL,
	[ScheduleStart] [date] NULL,
	[ScheduleEnd] [date] NULL,
	[TaxRate] [decimal](18, 0) NULL
) ON [PRIMARY]
GO


