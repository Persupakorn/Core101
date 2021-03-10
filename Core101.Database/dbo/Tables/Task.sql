CREATE TABLE [dbo].[Task] (
    [TaskID]            INT             IDENTITY (1, 1) NOT NULL,
    [ProjectCode]       NVARCHAR (50)   NULL,
    [TaskCode]          NVARCHAR (50)   NULL,
    [Brand]             NVARCHAR (50)   NULL,
    [Costcenter]        NVARCHAR (50)   NULL,
    [Revenue]           DECIMAL (18, 2) NULL,
    [Cost]              DECIMAL (18, 2) NULL,
    [GenerateMARevenue] INT             NULL,
    [GenerateMACost]    INT             NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskID] ASC)
);

