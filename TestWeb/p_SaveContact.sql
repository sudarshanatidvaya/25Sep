CREATE PROCEDURE p_SaveContact
(
@Name nvarchar(max),
@Designation nvarchar(max),
@ContactNumber nvarchar(max),
@Category nvarchar(max),
@MailID nvarchar(max),
@OfficeAddress nvarchar(max),
@ImageID nvarchar(max),
@IsActive bit
)
AS

BEGIN
	INSERT INTO [Auradies].[dbo].[Contact]
           (
           [Name]
           ,[Designation]
           ,[ContactNumber]
           ,[Category]
           ,[MailID]
           ,[OfficeAddress]
           ,[ImageID]
           ,[IsActive]
           )
	VALUES
			(
			@Name
           ,@Designation
           ,@ContactNumber
           ,@Category
           ,@MailID
           ,@OfficeAddress
           ,@ImageID
           ,@IsActive
           )

END
GO