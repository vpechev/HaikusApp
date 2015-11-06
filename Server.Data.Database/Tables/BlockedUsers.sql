CREATE TABLE [dbo].[BlockedUsers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] BIGINT NOT NULL,
	[BlockedId] BIGINT NOT NULL, 
    CONSTRAINT [FK_BlockedUsers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_BlockedUsers_Users2] FOREIGN KEY ([BlockedId]) REFERENCES [Users]([Id])
)
