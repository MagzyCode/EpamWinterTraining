CREATE TABLE [dbo].[EducationalSubjects] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [SubjectName] NVARCHAR (MAX) NOT NULL,
    [SubjectType] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);