CREATE TABLE [dbo].[Account] (
    [Account_Id]      INT        IDENTITY (1, 1) NOT NULL,
    [Account_Type]    NCHAR (10) NOT NULL,
    [Account_Number]  NCHAR (20) NOT NULL,
    [Account_Balance] MONEY      NOT NULL,
    [Customer_Id]     INT        NOT NULL,
    [Deleted]         BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Account_Id] ASC),
    CONSTRAINT [FK_Account_To_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Customer_Id])
);

