CREATE PROCEDURE p_UpdateContactInactiveById
@ID INT
AS

BEGIN
	UPDATE [Contact]
	SET [IsActive] = 0
	WHERE ID = @ID

END
GO