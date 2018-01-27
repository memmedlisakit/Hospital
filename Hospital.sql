USE [PatintDB]
GO
/****** Object:  Table [dbo].[Card_Type]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[card_type_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Existing_Account]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Existing_Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[existing_account_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Status]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[materil_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Occupation]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[occupation_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title_id] [int] NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[middle_name] [nvarchar](100) NOT NULL,
	[surname] [nvarchar](100) NOT NULL,
	[gender_type] [bit] NOT NULL,
	[material_id] [int] NOT NULL,
	[date_of_birth] [datetime] NOT NULL,
	[state_of_origin_id] [int] NULL,
	[tribe] [nvarchar](500) NULL,
	[religion_id] [int] NOT NULL,
	[occupation_id] [int] NOT NULL,
	[permanent_adress] [nvarchar](500) NOT NULL,
	[home_adress] [nvarchar](200) NOT NULL,
	[photo] [nvarchar](500) NULL,
	[family_id] [int] NOT NULL,
	[old_file_number] [nvarchar](250) NULL,
	[card_type_id] [int] NOT NULL,
	[patient_category_id] [int] NOT NULL,
	[existing_account_id] [int] NULL,
	[account_number] [int] NOT NULL,
 CONSTRAINT [PK__Patient__3213E83F36379FDD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient_Category]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient_Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patient_category_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient_Family]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient_Family](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](300) NOT NULL,
	[gender_type] [bit] NOT NULL,
	[state_of_origin_id] [int] NULL,
	[phone] [nvarchar](100) NOT NULL,
	[adress] [nvarchar](300) NOT NULL,
	[relitionship_with_patient] [nvarchar](300) NOT NULL,
	[same_as_patient] [bit] NULL,
 CONSTRAINT [PK__Patient___3213E83FD576798E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Religion]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Religion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[religion_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State_of_Origin]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State_of_Origin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[state_of_origin_name] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 28-Jan-18 12:47:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title_name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Card_Type] FOREIGN KEY([card_type_id])
REFERENCES [dbo].[Card_Type] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Card_Type]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Existing_Account] FOREIGN KEY([existing_account_id])
REFERENCES [dbo].[Existing_Account] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Existing_Account]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Material_Status] FOREIGN KEY([material_id])
REFERENCES [dbo].[Material_Status] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Material_Status]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Occupation] FOREIGN KEY([occupation_id])
REFERENCES [dbo].[Occupation] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Occupation]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient] FOREIGN KEY([id])
REFERENCES [dbo].[Patient] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Patient]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient_Category] FOREIGN KEY([patient_category_id])
REFERENCES [dbo].[Patient_Category] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Patient_Category]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient_Family] FOREIGN KEY([family_id])
REFERENCES [dbo].[Patient_Family] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Patient_Family]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Religion] FOREIGN KEY([religion_id])
REFERENCES [dbo].[Religion] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Religion]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_State_of_Origin] FOREIGN KEY([state_of_origin_id])
REFERENCES [dbo].[State_of_Origin] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_State_of_Origin]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Title] FOREIGN KEY([title_id])
REFERENCES [dbo].[Title] ([id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Title]
GO
ALTER TABLE [dbo].[Patient_Family]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Family_State_of_Origin] FOREIGN KEY([state_of_origin_id])
REFERENCES [dbo].[State_of_Origin] ([id])
GO
ALTER TABLE [dbo].[Patient_Family] CHECK CONSTRAINT [FK_Patient_Family_State_of_Origin]
GO
