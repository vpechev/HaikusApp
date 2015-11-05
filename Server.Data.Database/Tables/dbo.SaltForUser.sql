CREATE TABLE [dbo].[SaltForUser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Salt] NVARCHAR(500) NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    CONSTRAINT [FK_SaltForUser_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_SaltForUser_UserId] ON [dbo].[SaltForUser] ([UserId])
