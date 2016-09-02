CREATE PROCEDURE p_GetAllActiveCommentsById
@NewsFeedID int
AS

BEGIN
	SELECT 
	[ID],
	[NewsFeedID],
	[UserName] ,
	[UserImageID],
	[Comment] ,
	[CommentDateTime] ,
	[IsActive] 
	
	
	FROM NewsFeedComment
	WHERE [NewsFeedID] = @NewsFeedID
	ORDER BY [CommentDateTime] ASC

END
GO