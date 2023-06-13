CREATE TABLE [dbo].[TempTable] (
    [id]          INT IDENTITY(1,1) NOT NULL,
    [title]       CHAR (10)     NOT NULL,
    [values]      NVARCHAR (20) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([id] ASC)
);

