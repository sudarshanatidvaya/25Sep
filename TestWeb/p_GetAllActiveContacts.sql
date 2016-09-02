CREATE PROCEDURE p_GetAllActiveContacts

AS

BEGIN
	SELECT [ID],[Name],[Designation],[ContactNumber]
		  ,[Category],[MailID],[OfficeAddress]
		  ,[ImageID], [IsActive]
	FROM Contact
	WHERE [IsActive] = 1

END
GO