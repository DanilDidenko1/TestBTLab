USE [master]
GO
CREATE DATABASE [TaskBTlab]
GO

USE [TaskBTlab]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [nvarchar](128) NOT NULL,
	[first_name] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [TaskBTlab]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeSheet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee] [int] NOT NULL,
	[reason] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[duration] [int] NOT NULL,
	[discounted] [bit] NOT NULL,
	[description] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheet_Employees] FOREIGN KEY([employee])
REFERENCES [dbo].[Employees] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TimeSheet] CHECK CONSTRAINT [FK_TimeSheet_Employees]
GO

USE [TaskBTlab]
GO

INSERT INTO [dbo].[Employees]
           ([last_name]
           ,[first_name])
     VALUES
           ('Петров', 'Александр'),
			('Иванов','Павел'),
			('Майстренко','Иван'),
			('Косов','Артем'),
			('Демчин','Олег'),
			('Гром','Василий'),
			('Ясин','Дмитрий')
GO

USE [TaskBTlab]
GO

INSERT INTO [dbo].[TimeSheet]
           ([employee]
           ,[reason]
           ,[start_date]
           ,[duration]
           ,[discounted]
           ,[description])
     VALUES
           (1, 1, '2020-01-01', 7, 0, 'first row'),
		   (2, 2, '2020-02-02', 12, 1, 'second row'),
		   (3, 3, '2020-03-03', 16, 0, 'third row'),
		   (4, 4, '2020-04-04', 21, 1, 'fourth row')
GO

