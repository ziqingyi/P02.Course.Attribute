USE [Backup]
GO

/****** Object:  Table [dbo].[Commodity]    Script Date: 11/12/2020 05:36:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Commodity](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[title] [nvarchar](1000) NULL,
	[Price] [int] NULL,
	[url] [nvarchar](50) NULL,
	[ImageUrl] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



insert into Commodity(ProductId,CategoryId,title,Price,url,ImageUrl)
values(1,2,'testbook mouse afdsss',77,'www.test.com','www.test.com'),
       (2,2,'afdafdesk fafdsfds  screen',77,'www.test.com','www.test.com'),
(3,2,'this is a book',77,'www.test.com','www.test.com'),
       (4,2,'.net book',77,'www.test.com','www.test.com'),
	   (5,1,'java book',77,'www.test.com','www.test.com'),
	   (6,2,'desk top flow aldflk',77,'www.test.com','www.test.com'),
	   (7,5,'computer ddsfa screen',77,'www.test.com','www.test.com'),
	   (8,2,'desk  computer sfadasf',77,'www.test.com','www.test.com'),
	   (9,6,'bookafsda ffdfdf dsafdsabook',77,'www.test.com','www.test.com'),
	   (10,2,'dfdafda desk afdasf',77,'www.test.com','www.test.com'),
	   (11,1,'screen mouse safdbookafdsamouse',77,'www.test.com','www.test.com')
