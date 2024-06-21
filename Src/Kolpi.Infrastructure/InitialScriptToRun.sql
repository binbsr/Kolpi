IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Exams] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    [StartsAt] datetime2 NOT NULL,
    [DurationHours] tinyint NOT NULL,
    [Attendees] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedAt] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Exams] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PrivilegeLookups] (
    [Id] int NOT NULL IDENTITY,
    [Label] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    [QuestionsCount] int NOT NULL,
    [SubjectiveAnswersCount] int NOT NULL,
    [ObjectiveAnswersCount] int NOT NULL,
    [ReviewsCount] int NOT NULL,
    CONSTRAINT [PK_PrivilegeLookups] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [QuestionStatuses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_QuestionStatuses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TagTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    [ColorCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TagTypes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserLogins] (
    [LoginProvider] nvarchar(max) NOT NULL,
    [ProviderKey] nvarchar(max) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(max) NULL
);
GO

CREATE TABLE [UserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId])
);
GO

CREATE TABLE [Users] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserTokens] (
    [UserId] nvarchar(max) NULL,
    [LoginProvider] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Value] nvarchar(max) NULL
);
GO

CREATE TABLE [ExamPapers] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    [ExamId] int NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedAt] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_ExamPapers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ExamPapers_Exams_ExamId] FOREIGN KEY ([ExamId]) REFERENCES [Exams] ([Id])
);
GO

CREATE TABLE [Questions] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NOT NULL,
    [QuestionStatusId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedAt] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Questions_QuestionStatuses_QuestionStatusId] FOREIGN KEY ([QuestionStatusId]) REFERENCES [QuestionStatuses] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tags] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    [IsFinalized] bit NOT NULL,
    [TagTypeId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedAt] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tags_TagTypes_TagTypeId] FOREIGN KEY ([TagTypeId]) REFERENCES [TagTypes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AnswerOptions] (
    [Id] int NOT NULL IDENTITY,
    [Body] nvarchar(max) NOT NULL,
    [IsAnswer] bit NOT NULL,
    [QuestionId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [ModifiedAt] datetime2 NULL,
    [ModifiedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_AnswerOptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AnswerOptions_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ExamPaperQuestion] (
    [ExamPapersId] int NOT NULL,
    [QuestionsId] int NOT NULL,
    CONSTRAINT [PK_ExamPaperQuestion] PRIMARY KEY ([ExamPapersId], [QuestionsId]),
    CONSTRAINT [FK_ExamPaperQuestion_ExamPapers_ExamPapersId] FOREIGN KEY ([ExamPapersId]) REFERENCES [ExamPapers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ExamPaperQuestion_Questions_QuestionsId] FOREIGN KEY ([QuestionsId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [QuestionTag] (
    [QuestionId] int NOT NULL,
    [TagsId] int NOT NULL,
    CONSTRAINT [PK_QuestionTag] PRIMARY KEY ([QuestionId], [TagsId]),
    CONSTRAINT [FK_QuestionTag_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_QuestionTag_Tags_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Details', N'Name') AND [object_id] = OBJECT_ID(N'[QuestionStatuses]'))
    SET IDENTITY_INSERT [QuestionStatuses] ON;
INSERT INTO [QuestionStatuses] ([Id], [Details], [Name])
VALUES (1, N'QUestion just added', N'New'),
(2, N'Question is being reviewed', N'Review'),
(3, N'Question finalized and can be published', N'Publish');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Details', N'Name') AND [object_id] = OBJECT_ID(N'[QuestionStatuses]'))
    SET IDENTITY_INSERT [QuestionStatuses] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ColorCode', N'Details', N'Name') AND [object_id] = OBJECT_ID(N'[TagTypes]'))
    SET IDENTITY_INSERT [TagTypes] ON;
INSERT INTO [TagTypes] ([Id], [ColorCode], [Details], [Name])
VALUES (1, N'green', N'Tags that defines complexities of the question e.g. level-1, level-2 etc.', N'Complexity'),
(2, N'orange', N'Tags that defines subject categories of the question e.g. GK, GK-History, Physics etc.', N'Subject');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ColorCode', N'Details', N'Name') AND [object_id] = OBJECT_ID(N'[TagTypes]'))
    SET IDENTITY_INSERT [TagTypes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'CreatedBy', N'Details', N'IsFinalized', N'ModifiedAt', N'ModifiedBy', N'Name', N'TagTypeId') AND [object_id] = OBJECT_ID(N'[Tags]'))
    SET IDENTITY_INSERT [Tags] ON;
INSERT INTO [Tags] ([Id], [CreatedAt], [CreatedBy], [Details], [IsFinalized], [ModifiedAt], [ModifiedBy], [Name], [TagTypeId])
VALUES (1, '2023-08-24T11:12:23.4853651+05:45', NULL, N'Defines simplest objective questions.', CAST(0 AS bit), NULL, NULL, N'Level-1', 1),
(2, '2023-08-24T11:12:23.4853664+05:45', NULL, N'Defines questions harder than level-1', CAST(0 AS bit), NULL, NULL, N'Level-2', 1),
(3, '2023-08-24T11:12:23.4853666+05:45', NULL, N'Defines general knowledge questions.', CAST(0 AS bit), NULL, NULL, N'GK', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'CreatedBy', N'Details', N'IsFinalized', N'ModifiedAt', N'ModifiedBy', N'Name', N'TagTypeId') AND [object_id] = OBJECT_ID(N'[Tags]'))
    SET IDENTITY_INSERT [Tags] OFF;
GO

CREATE INDEX [IX_AnswerOptions_QuestionId] ON [AnswerOptions] ([QuestionId]);
GO

CREATE INDEX [IX_ExamPaperQuestion_QuestionsId] ON [ExamPaperQuestion] ([QuestionsId]);
GO

CREATE INDEX [IX_ExamPapers_ExamId] ON [ExamPapers] ([ExamId]);
GO

CREATE INDEX [IX_Questions_QuestionStatusId] ON [Questions] ([QuestionStatusId]);
GO

CREATE INDEX [IX_QuestionTag_TagsId] ON [QuestionTag] ([TagsId]);
GO

CREATE INDEX [IX_Tags_TagTypeId] ON [Tags] ([TagTypeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230824052723_Initial', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AnswerOptions] ADD [Type] int NOT NULL DEFAULT 0;
GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T17:09:03.0921678+05:45'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T17:09:03.0921690+05:45'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T17:09:03.0921692+05:45'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825112403_AnsTypeCol', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Questions] ADD [Type] int NOT NULL DEFAULT 0;
GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T22:15:32.8469607+05:45'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T22:15:32.8469627+05:45'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Tags] SET [CreatedAt] = '2023-08-25T22:15:32.8469629+05:45'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825163033_QuestionType', N'8.0.6');
GO

COMMIT;
GO

