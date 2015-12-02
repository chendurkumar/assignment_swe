CREATE TABLE [dbo].[Transaction] (
    [Transaction_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Account_Id]       INT          NOT NULL,
    [Transaction_Type] INT          NOT NULL,
    [Amount]           MONEY        NOT NULL,
    [Message]          TEXT         NULL,
    [Timestamp]        VARCHAR (30) NULL,
    [Details]          TEXT         NULL,
    PRIMARY KEY CLUSTERED ([Transaction_Id] ASC),
    CONSTRAINT [FK_Transaction_To_Account] FOREIGN KEY ([Account_Id]) REFERENCES [dbo].[Account] ([Account_Id])
);