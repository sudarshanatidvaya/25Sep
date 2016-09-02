CREATE PROCEDURE p_SaveNewsFeed
(
@UserName nvarchar(max),
@UserImageID nvarchar(max),
@StatusMessage nvarchar(max),
@StatusImageID nvarchar(max),
@StatusLink nvarchar(max),
@StatusDateTime DateTime,
@IsActive bit
)
AS

BEGIN
	INSERT INTO [Auradies].[dbo].[NewsFeedMaster]
           (
           [UserName]
           ,[UserImageID]
           ,[StatusMessage]
           ,[StatusImageID]
           ,[StatusLink]
           ,[StatusDateTime]
           ,[IsActive]
           )
	VALUES
			(
			@UserName
           ,@UserImageID
           ,@StatusMessage
           ,@StatusImageID
           ,@StatusLink
           ,@StatusDateTime
           ,@IsActive
           )

END
Go
