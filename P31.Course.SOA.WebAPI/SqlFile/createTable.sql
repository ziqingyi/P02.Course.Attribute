USE [SqlDemos]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 2020/11/26 21:34:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](32) NULL,
	[ParentCatId] [int] NULL,
	[DelFlag] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [DelFlag]
GO

USE [SqlDemos]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 2020/11/26 21:34:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProId] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [nvarchar](32) NULL,
	[ProCreateOn] [datetime] NULL,
	[CategoryId] [int] NULL,
	[Price] [nvarchar](30) NULL,
 CONSTRAINT [PK_Product_ProId] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [ProCreateOn]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CatId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO









