CREATE TABLE [dbo].[Rating]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Value] INT NOT NULL,
	[HaikuId] BIGINT NOT NULL,
	[IsDeleted] BIT DEFAULT 0, 
    CONSTRAINT [FK_Ratings_Haikus] FOREIGN KEY ([HaikuId]) REFERENCES [Haikus]([Id])
)
