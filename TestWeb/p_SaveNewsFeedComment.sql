CREATE PROCEDURE p_SaveNewsFeedComment
(
@NewsFeedID int,
@UserName nvarchar(max),
@UserImageID nvarchar(max),
@Comment nvarchar(max),
@CommentDateTime DateTime,
@IsActive bit
)
AS

BEGIN
	INSERT INTO [Auradies].[dbo].[NewsFeedComment]
           (
           [NewsFeedID]
           ,[UserName]
           ,[UserImageID]
           ,[Comment]
           ,[CommentDateTime]
           ,[IsActive]
           )
	VALUES
			(
			@NewsFeedID
           ,@UserName
           ,@UserImageID
           ,@Comment
           ,@CommentDateTime
           ,@IsActive
           )

END
Go
