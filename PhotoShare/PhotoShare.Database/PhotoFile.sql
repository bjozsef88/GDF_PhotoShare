CREATE TABLE [dbo].[PhotoFile]
(
	[Id] INT NOT NULL 
		CONSTRAINT FK__PhotoFile__Photo
		FOREIGN KEY
		REFERENCES [dbo].[Photo]
		CONSTRAINT PK__PhotoFile
		PRIMARY KEY CLUSTERED,
	[FileName] nvarchar(255) NOT NULL,
	[File] varbinary(max) NOT NULL,
	[Thumbnail] varbinary(max) NOT NULL
)
