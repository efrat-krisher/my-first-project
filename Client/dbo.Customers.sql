CREATE TABLE [dbo].[Customers] (
    [Id]    INT           NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [phone] NCHAR (10)    NOT NULL,
    [adresss] NVARCHAR(50) NULL, 
    [mail] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

