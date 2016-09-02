CREATE PROCEDURE p_GetContactByID
@ID int
AS

BEGIN
	SELECT [ID],[Name],[Designation],[ContactNumber]
		  ,[Category],[MailID],[OfficeAddress]
		  ,[ImageID], [IsActive]
	FROM Contact
	WHERE [ID] = @ID

END
Go