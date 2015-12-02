CREATE TABLE [dbo].[Customer] (
    [Customer_Id]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (30) NOT NULL,
    [LastName]       NVARCHAR (30) NOT NULL,
    [SSN]            NCHAR (11)    NOT NULL,
    [Email]          VARCHAR (320) NULL,
    [HouseNumber]    NCHAR (5)     NOT NULL,
    [StreetAddress1] NVARCHAR (50) NOT NULL,
    [StreetAddress2] NVARCHAR (50) NULL,
    [Phone]          TEXT          NOT NULL,
    [Username]       NCHAR (30)    NOT NULL,
    [Password]       CHAR (32)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Customer_Id] ASC)
);