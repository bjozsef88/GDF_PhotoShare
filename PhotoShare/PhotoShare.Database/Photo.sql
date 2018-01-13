CREATE TABLE [dbo].[Photo]
(
	[Id] INT NOT NULL 
		IDENTITY (1, 1)
		CONSTRAINT PK__Photo
		PRIMARY KEY CLUSTERED,
	[IpAddress] char(15) NOT NULL,
	[UploadedAt] datetime2 NOT NULL
		CONSTRAINT DF__Photo__UploadedAt
		DEFAULT GETDATE(),
	[Name] nvarchar(255) NOT NULL,
	[Email] varchar(255) NOT NULL,
	[Title] nvarchar(100) NOT NULL,
)
