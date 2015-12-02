CREATE TABLE [dbo].[Employee] (
    [Employee_Id] INT        IDENTITY (1, 1) NOT NULL,
    [Name]        TEXT       NOT NULL,
    [Username]    NCHAR (30) NOT NULL,
    [Password]    CHAR (32)  NOT NULL,
    [Deleted]     BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC)
);