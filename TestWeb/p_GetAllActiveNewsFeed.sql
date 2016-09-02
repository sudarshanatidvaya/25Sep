CREATE PROCEDURE p_GetAllActiveNewsFeed

AS

BEGIN
	SELECT [ID],[UserName],[UserImageID],[StatusMessage]
		  ,[StatusImageID],[StatusLink],[StatusDateTime]
		  ,[IsActive] 
	FROM NewsFeedMaster
	WHERE [IsActive] = 1
	ORDER BY [StatusDateTime] DESC
END
Go