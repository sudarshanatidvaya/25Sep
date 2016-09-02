CREATE PROCEDURE p_UpdateNewsFeedInactiveById
@ID INT
AS

BEGIN
	UPDATE NewsFeedMaster
	SET [IsActive] = 0
	WHERE ID = @ID

END
GO