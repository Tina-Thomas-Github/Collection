CREATE DATABASE [InvestmentForms];
CREATE TABLE [dbo].[UserMaster] (
    [UserId]        INT          IDENTITY (1, 1) NOT NULL,
    [UserCode]      VARCHAR (10) NULL,
    [UserName]      VARCHAR (50) NULL,
    [Password]      VARCHAR (50) NULL,
    [Role]          VARCHAR (10) NULL,
    [Created_by]    VARCHAR (10) NULL,
    [Created_Date]  DATETIME     NULL,
    [Modified_by]   VARCHAR (10) NULL,
    [Modified_Date] DATETIME     NULL,
    [IsActive]      BIT          NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


CREATE TABLE [dbo].[InvestmentFormMaster] (
    [InvestmentTypeID] INT            IDENTITY (1, 1) NOT NULL,
    [InvestmentType]   NVARCHAR (100) NOT NULL,
    [Created_by]       VARCHAR (10)   NULL,
    [Created_Date]     DATETIME       NULL,
    [Modified_by]      VARCHAR (10)   NULL,
    [Modified_Date]    DATETIME       NULL,
    [IsActive]         BIT            NULL
);

CREATE TABLE [dbo].[SchemeFormMaster] (
    [SchemeFormID]     INT            IDENTITY (1, 1) NOT NULL,
    [InvestmentTypeID] INT            NOT NULL,
    [SchemeCategory]   NVARCHAR (100) NOT NULL,
    [SchemeFormName]   NVARCHAR (100) NOT NULL,
    [Created_by]       VARCHAR (10)   NULL,
    [Created_Date]     DATETIME       NULL,
    [Modified_by]      VARCHAR (10)   NULL,
    [Modified_Date]    DATETIME       NULL,
    [IsActive]         BIT            NULL
);


CREATE TABLE [dbo].[SchemeConfigFormMaster] (
    [SchemeConfigID]   INT            IDENTITY (1, 1) NOT NULL,
    [InvestmentTypeID] INT            NOT NULL,
    [SchemeCategoryID] NVARCHAR (100) NOT NULL,
    [SchemeFormName]   NVARCHAR (100) NOT NULL,
    [StartDate]        DATETIME       NOT NULL,
    [EndDate]          DATETIME       NOT NULL,
    [TotalPages]       INT            NOT NULL,
    [EUINApplicable]   BIT            NOT NULL,
    [EUINNo]           NVARCHAR (100) NOT NULL,
    [FieldParamter]    NVARCHAR (100) NOT NULL,
    [FileName]         NVARCHAR (500) NOT NULL,
    [contentType]      NVARCHAR (MAX) NOT NULL,
    [Created_by]       VARCHAR (10)   NULL,
    [Created_Date]     DATETIME       NULL,
    [Modified_by]      VARCHAR (10)   NULL,
    [Modified_Date]    DATETIME       NULL,
    [IsActive]         BIT            NULL
);

CREATE TABLE [dbo].[EUINNoMappingFormMaster] (
    [EUINMappingID]    INT            IDENTITY (1, 1) NOT NULL,
    [InvestmentTypeID] INT            NOT NULL,
    [SchemeCategoryID] NVARCHAR (100) NOT NULL,
    [SchemeFormName]   NVARCHAR (100) NOT NULL,
    [EUINApplicable]   BIT            NOT NULL,
    [EUINNo]           NVARCHAR (100) NOT NULL,
    [Created_by]       VARCHAR (10)   NULL,
    [Created_Date]     DATETIME       NULL,
    [Modified_by]      VARCHAR (10)   NULL,
    [Modified_Date]    DATETIME       NULL,
    [IsActive]         BIT            NULL
);
CREATE TABLE [dbo].[FieldParameter] (
    [FieldId]       INT            NOT NULL,
    [ParameterName] NVARCHAR (MAX) NOT NULL,
    [IsActive]      BIT            NULL
);


CREATE TABLE [dbo].[mst_EUIN] (
    [EUIN_No] NVARCHAR (50) NULL,
    [NAME]    NVARCHAR (50) NULL,
    [ECN]     NVARCHAR (50) NULL
);

CREATE TABLE [dbo].[det_ClientFormDownloads] (
    [Form_Id]      NVARCHAR (50) NULL,
    [Entered_Date] NVARCHAR (50) NULL,
    [UserIP]       NVARCHAR (50) NULL,
    [CFT_Id]       NVARCHAR (50) NULL
);

CREATE TABLE [dbo].[det_ClientFormTemplateMaster] (
    [CFT_Id]          INT           NOT NULL,
    [CFT_Name]        NVARCHAR (50) NULL,
    [CFT_StartNumber] NVARCHAR (50) NULL,
    [CFT_EndNumber]   NVARCHAR (50) NULL,
    [CFT_UpperX]      NVARCHAR (50) NULL,
    [CFT_UpperY]      NVARCHAR (50) NULL,
    [CFT_LowerX]      NVARCHAR (50) NULL,
    [CFT_LowerY]      NVARCHAR (50) NULL,
    [CFT_IsActive]    INT           NULL,
    [CFT_LowerX2]     NVARCHAR (50) NULL,
    [CFT_LowerY2]     NVARCHAR (50) NULL
);

