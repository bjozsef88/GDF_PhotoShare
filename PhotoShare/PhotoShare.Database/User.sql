CREATE USER [PhotoShare_User]
	FROM LOGIN [PhotoShare_Login]

GO

GRANT CONNECT TO [PhotoShare_User]
GO

ALTER ROLE [db_datareader]
ADD MEMBER [PhotoShare_User]
GO

ALTER ROLE [db_datawriter]
ADD MEMBER [PhotoShare_User]
GO

CREATE ROLE [db_definitionviewer]
GO

GRANT VIEW DEFINITION TO [db_definitionviewer]
GO

ALTER ROLE [db_definitionviewer]
ADD MEMBER [PhotoShare_User]
GO
