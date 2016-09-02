CREATE PROCEDURE p_GetNewsFeedById
@ID int
AS

BEGIN
	SELECT [ID],[UserName],[UserImageID],[StatusMessage]
		  ,[StatusImageID],[StatusLink],[StatusDateTime]
		  ,[IsActive] 
	FROM NewsFeedMaster
	WHERE ID = @ID

END
Go