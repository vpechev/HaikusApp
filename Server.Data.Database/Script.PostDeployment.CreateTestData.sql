/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Users] ([Username], [PublishCode]) VALUES ('FirstUser', 'some publish code');
DECLARE @UserId BIGINT = SCOPE_IDENTITY();
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 1', @UserId);
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 2', @UserId);
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 3', @UserId);
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 4', @UserId);
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 5', @UserId);
INSERT INTO [dbo].[Haikus] ([Text], [UserId]) VALUES ('some dummy dummy haiku 6', @UserId);



--insert custom error messages
	BEGIN TRY
		EXEC sp_addmessage 100000, 16, N'Not authorized';
	END TRY
	BEGIN CATCH
	END CATCH