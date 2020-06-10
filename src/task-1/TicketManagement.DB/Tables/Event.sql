﻿CREATE TABLE [dbo].[Event] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (120) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [LayoutId]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
