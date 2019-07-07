CREATE TABLE [dbo].[main_table] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [employee_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_main_table_ToEmployeeTable] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[employee] ([employee_id])
);