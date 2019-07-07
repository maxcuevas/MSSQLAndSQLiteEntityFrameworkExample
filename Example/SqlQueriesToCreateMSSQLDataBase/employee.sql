CREATE TABLE [dbo].[employee] (
    [employee_id] INT        IDENTITY (1, 1) NOT NULL,
    [name]        NCHAR (10) NULL,
    [age]         INT        NULL,
    PRIMARY KEY CLUSTERED ([employee_id] ASC)
);
