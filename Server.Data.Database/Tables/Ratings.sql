CREATE TABLE [dbo].[Ratings]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Value] INT NOT NULL,
	[HaikuId] BIGINT NOT NULL,
	--[UserId] BIGINT NOT NULL,
	[IsDeleted] BIT DEFAULT 0 NOT NULL, 
    CONSTRAINT [FK_Ratings_Haikus] FOREIGN KEY ([HaikuId]) REFERENCES [Haikus]([Id]),
	--CONSTRAINT [FK_Ratings_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
