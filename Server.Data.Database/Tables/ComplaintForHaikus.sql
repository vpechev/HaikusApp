CREATE TABLE [dbo].[ComplaintForHaikus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[HaikuId] BIGINT NOT NULL, 
	[Date] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [FK_ComplaintForHaikus_Haikus] FOREIGN KEY ([HaikuId]) REFERENCES [Haikus]([Id])
)
