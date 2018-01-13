CREATE TABLE [dbo].[Photo]
(
	[Id] INT NOT NULL 
		IDENTITY (1, 1)
		CONSTRAINT PK__Photo
		PRIMARY KEY CLUSTERED,
	[IpAddress] char(15) NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Description] nvarchar(255) NULL,
	[FileName] nvarchar(255) NOT NULL,
	[File] varbinary(max) NOT NULL
)
