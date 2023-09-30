
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2011 15:00:18
-- Generated from EDMX file: E:\proje_site\proje\Mobile_Store\Mobile_Store\Mobile_Store\Context.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database_Mobile_Store];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kalas'
CREATE TABLE [dbo].[Kalas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Model] nvarchar(max)  NULL,
    [Kharid_Id] int  NULL,
    [Forosh_Id] int  NULL
);
GO

-- Creating table 'Foroshandeghans'
CREATE TABLE [dbo].[Foroshandeghans] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Family] nvarchar(max)  NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [Foroshghah] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NULL,
    [Bedehkar] bigint  NULL,
    [Bestankar] bigint  NULL
);
GO

-- Creating table 'Coustomers'
CREATE TABLE [dbo].[Coustomers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Family] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [Foroshghah] nvarchar(max)  NULL,
    [Adress] nvarchar(max)  NULL,
    [Bedehkar] bigint  NULL,
    [Bestankar] bigint  NULL
);
GO

-- Creating table 'Kharids'
CREATE TABLE [dbo].[Kharids] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Name_Foroshandeh] nvarchar(max)  NOT NULL,
    [Name_kala] nvarchar(max)  NOT NULL,
    [Model_kala] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Ghimat_vahed] bigint  NOT NULL,
    [Ghimat_forosh] bigint  NOT NULL,
    [Date_kharid] nvarchar(max)  NOT NULL,
    [Serial] nvarchar(max)  NULL
);
GO

-- Creating table 'Foroshes'
CREATE TABLE [dbo].[Foroshes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Name_kala] nvarchar(max)  NOT NULL,
    [Model_kala] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Ghimat_vahed] bigint  NOT NULL,
    [Date_Forosh] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pardakhts'
CREATE TABLE [dbo].[Pardakhts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [mablegh_naghdi] bigint  NULL,
    [Date_Pardaght_naghdi] nvarchar(max)  NULL,
    [Date_sodoor] nvarchar(max)  NULL,
    [Date_check] nvarchar(max)  NULL,
    [Shomareh_Hesab] nvarchar(max)  NULL,
    [Shomareh_check] nvarchar(max)  NULL,
    [Mablegh_check] bigint  NULL,
    [Dar_vajhe] nvarchar(max)  NULL,
    [Type_pardakht] nvarchar(max)  NOT NULL,
    [Kharid_Id] int  NULL,
    [Foroshandeghan_Id] int  NULL
);
GO

-- Creating table 'Daryafts'
CREATE TABLE [dbo].[Daryafts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Mablegh_naghdi] bigint  NULL,
    [Date_Daryaft_naghdi] nvarchar(max)  NULL,
    [Mablegh_Dafteri] bigint  NULL,
    [Date_Dafteri] nvarchar(max)  NULL,
    [Name_shakhs] nvarchar(max)  NULL,
    [Date_sodoor] nvarchar(max)  NULL,
    [Date_check] nvarchar(max)  NULL,
    [Shomareh_Hesab] nvarchar(max)  NULL,
    [Shomareh_check] nvarchar(max)  NULL,
    [Mablegh_check] bigint  NULL,
    [Saheb_Hesab] nvarchar(max)  NULL,
    [Pas_check] nvarchar(max)  NULL,
    [Type_daryaft] nvarchar(max)  NOT NULL,
    [Forosh_Id] int  NULL,
    [Coustomer_Id] int  NULL
);
GO

-- Creating table 'EsterdadKalas'
CREATE TABLE [dbo].[EsterdadKalas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Name_Foroshandeh] nvarchar(max)  NOT NULL,
    [Name_kala] nvarchar(max)  NOT NULL,
    [Model_kala] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Ghimat_vahed] bigint  NOT NULL,
    [Ghimat_forosh] bigint  NOT NULL,
    [Date_Esterdad] nvarchar(max)  NOT NULL,
    [Serial] nvarchar(max)  NULL
);
GO

-- Creating table 'Aghsats'
CREATE TABLE [dbo].[Aghsats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Eshterak] bigint  NOT NULL,
    [Factor] int  NOT NULL,
    [Shomare_ghest] int  NOT NULL,
    [Mablegh_ghest] bigint  NOT NULL,
    [Date_pardakht] nvarchar(max)  NOT NULL,
    [Pass] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SodoorChecks'
CREATE TABLE [dbo].[SodoorChecks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date_Sodor] nvarchar(max)  NOT NULL,
    [Date_check] nvarchar(max)  NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [Shomareh_check] nvarchar(max)  NOT NULL,
    [Mablegh_check] bigint  NOT NULL,
    [Dar_vajhe] nvarchar(max)  NOT NULL,
    [Tozih] nvarchar(max)  NULL
);
GO

-- Creating table 'DaryaftChecks'
CREATE TABLE [dbo].[DaryaftChecks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date_sodoor] nvarchar(max)  NOT NULL,
    [Date_check] nvarchar(max)  NOT NULL,
    [Name_Moshtari] nvarchar(max)  NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [Shomareh_check] nvarchar(max)  NOT NULL,
    [Mablegh_check] bigint  NOT NULL,
    [Tozih] nvarchar(max)  NULL
);
GO

-- Creating table 'BardashtMots'
CREATE TABLE [dbo].[BardashtMots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Mablagh] bigint  NOT NULL,
    [Tozih] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ParDarMots'
CREATE TABLE [dbo].[ParDarMots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Name_shakhs] nvarchar(max)  NOT NULL,
    [Bedehkar] bigint  NOT NULL,
    [Bestankar] bigint  NOT NULL,
    [Tozih] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SanadForoshandeghans'
CREATE TABLE [dbo].[SanadForoshandeghans] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Shomareh_sanad] int  NOT NULL,
    [Name_Foroshandeh] nvarchar(max)  NOT NULL,
    [Bedehkar] bigint  NOT NULL,
    [Bestankar] bigint  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Tozih] nvarchar(max)  NULL
);
GO

-- Creating table 'SanadMoshtaris'
CREATE TABLE [dbo].[SanadMoshtaris] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Shomareh_sanad] int  NOT NULL,
    [Name_Moshtari] nvarchar(max)  NOT NULL,
    [Bedehkar] bigint  NOT NULL,
    [Bestankar] bigint  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Tozih] nvarchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Takhfifs'
CREATE TABLE [dbo].[Takhfifs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Mablegh_Takhfif] bigint  NOT NULL
);
GO

-- Creating table 'Nkalas'
CREATE TABLE [dbo].[Nkalas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Anbars'
CREATE TABLE [dbo].[Anbars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name_kala] nvarchar(max)  NOT NULL,
    [Model_kala] nvarchar(max)  NOT NULL,
    [Count_kala] int  NOT NULL,
    [Ghimat_vahed] bigint  NOT NULL,
    [Ghimat_forosh] bigint  NOT NULL
);
GO

-- Creating table 'Varizs'
CREATE TABLE [dbo].[Varizs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [PardakhtKonandeh] nvarchar(max)  NOT NULL,
    [Mablagh] bigint  NOT NULL,
    [Shomareh_Fish] int  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Tozih] nvarchar(max)  NULL,
    [Bank_Id] int  NOT NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Shohbeh] nvarchar(max)  NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [Mojodi] bigint  NOT NULL,
    [Saheb_Hesab] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bardashts'
CREATE TABLE [dbo].[Bardashts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [DaryaftKonandeh] nvarchar(max)  NOT NULL,
    [Mablagh] bigint  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Tozih] nvarchar(max)  NULL,
    [Bank_Id] int  NOT NULL
);
GO

-- Creating table 'BarForoshes'
CREATE TABLE [dbo].[BarForoshes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Factor] int  NOT NULL,
    [Name_kala] nvarchar(max)  NOT NULL,
    [Model_kala] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Ghimat_vahed] bigint  NOT NULL,
    [Date_barForosh] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Moshtarekins'
CREATE TABLE [dbo].[Moshtarekins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Eshterak] bigint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Family] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [Shomareh_check] nvarchar(max)  NOT NULL,
    [Shomareh_Hesab] nvarchar(max)  NOT NULL,
    [Adress_kar] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Foroshes_ForoshAghsat'
CREATE TABLE [dbo].[Foroshes_ForoshAghsat] (
    [Eshterak] bigint  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Foroshes_ForoshNaghdi'
CREATE TABLE [dbo].[Foroshes_ForoshNaghdi] (
    [Name_Moshtari] nvarchar(max)  NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Kalas'
ALTER TABLE [dbo].[Kalas]
ADD CONSTRAINT [PK_Kalas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Foroshandeghans'
ALTER TABLE [dbo].[Foroshandeghans]
ADD CONSTRAINT [PK_Foroshandeghans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Coustomers'
ALTER TABLE [dbo].[Coustomers]
ADD CONSTRAINT [PK_Coustomers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kharids'
ALTER TABLE [dbo].[Kharids]
ADD CONSTRAINT [PK_Kharids]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Foroshes'
ALTER TABLE [dbo].[Foroshes]
ADD CONSTRAINT [PK_Foroshes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pardakhts'
ALTER TABLE [dbo].[Pardakhts]
ADD CONSTRAINT [PK_Pardakhts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Daryafts'
ALTER TABLE [dbo].[Daryafts]
ADD CONSTRAINT [PK_Daryafts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EsterdadKalas'
ALTER TABLE [dbo].[EsterdadKalas]
ADD CONSTRAINT [PK_EsterdadKalas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Aghsats'
ALTER TABLE [dbo].[Aghsats]
ADD CONSTRAINT [PK_Aghsats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SodoorChecks'
ALTER TABLE [dbo].[SodoorChecks]
ADD CONSTRAINT [PK_SodoorChecks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DaryaftChecks'
ALTER TABLE [dbo].[DaryaftChecks]
ADD CONSTRAINT [PK_DaryaftChecks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BardashtMots'
ALTER TABLE [dbo].[BardashtMots]
ADD CONSTRAINT [PK_BardashtMots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParDarMots'
ALTER TABLE [dbo].[ParDarMots]
ADD CONSTRAINT [PK_ParDarMots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SanadForoshandeghans'
ALTER TABLE [dbo].[SanadForoshandeghans]
ADD CONSTRAINT [PK_SanadForoshandeghans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SanadMoshtaris'
ALTER TABLE [dbo].[SanadMoshtaris]
ADD CONSTRAINT [PK_SanadMoshtaris]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Takhfifs'
ALTER TABLE [dbo].[Takhfifs]
ADD CONSTRAINT [PK_Takhfifs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Nkalas'
ALTER TABLE [dbo].[Nkalas]
ADD CONSTRAINT [PK_Nkalas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Anbars'
ALTER TABLE [dbo].[Anbars]
ADD CONSTRAINT [PK_Anbars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Varizs'
ALTER TABLE [dbo].[Varizs]
ADD CONSTRAINT [PK_Varizs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bardashts'
ALTER TABLE [dbo].[Bardashts]
ADD CONSTRAINT [PK_Bardashts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BarForoshes'
ALTER TABLE [dbo].[BarForoshes]
ADD CONSTRAINT [PK_BarForoshes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Moshtarekins'
ALTER TABLE [dbo].[Moshtarekins]
ADD CONSTRAINT [PK_Moshtarekins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Foroshes_ForoshAghsat'
ALTER TABLE [dbo].[Foroshes_ForoshAghsat]
ADD CONSTRAINT [PK_Foroshes_ForoshAghsat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Foroshes_ForoshNaghdi'
ALTER TABLE [dbo].[Foroshes_ForoshNaghdi]
ADD CONSTRAINT [PK_Foroshes_ForoshNaghdi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kharid_Id] in table 'Kalas'
ALTER TABLE [dbo].[Kalas]
ADD CONSTRAINT [FK_KharidKala]
    FOREIGN KEY ([Kharid_Id])
    REFERENCES [dbo].[Kharids]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KharidKala'
CREATE INDEX [IX_FK_KharidKala]
ON [dbo].[Kalas]
    ([Kharid_Id]);
GO

-- Creating foreign key on [Forosh_Id] in table 'Kalas'
ALTER TABLE [dbo].[Kalas]
ADD CONSTRAINT [FK_ForoshKala]
    FOREIGN KEY ([Forosh_Id])
    REFERENCES [dbo].[Foroshes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ForoshKala'
CREATE INDEX [IX_FK_ForoshKala]
ON [dbo].[Kalas]
    ([Forosh_Id]);
GO

-- Creating foreign key on [Kharid_Id] in table 'Pardakhts'
ALTER TABLE [dbo].[Pardakhts]
ADD CONSTRAINT [FK_KharidPardakht]
    FOREIGN KEY ([Kharid_Id])
    REFERENCES [dbo].[Kharids]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KharidPardakht'
CREATE INDEX [IX_FK_KharidPardakht]
ON [dbo].[Pardakhts]
    ([Kharid_Id]);
GO

-- Creating foreign key on [Forosh_Id] in table 'Daryafts'
ALTER TABLE [dbo].[Daryafts]
ADD CONSTRAINT [FK_ForoshDaryaft]
    FOREIGN KEY ([Forosh_Id])
    REFERENCES [dbo].[Foroshes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ForoshDaryaft'
CREATE INDEX [IX_FK_ForoshDaryaft]
ON [dbo].[Daryafts]
    ([Forosh_Id]);
GO

-- Creating foreign key on [Foroshandeghan_Id] in table 'Pardakhts'
ALTER TABLE [dbo].[Pardakhts]
ADD CONSTRAINT [FK_ForoshandeghanPardakht]
    FOREIGN KEY ([Foroshandeghan_Id])
    REFERENCES [dbo].[Foroshandeghans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ForoshandeghanPardakht'
CREATE INDEX [IX_FK_ForoshandeghanPardakht]
ON [dbo].[Pardakhts]
    ([Foroshandeghan_Id]);
GO

-- Creating foreign key on [Coustomer_Id] in table 'Daryafts'
ALTER TABLE [dbo].[Daryafts]
ADD CONSTRAINT [FK_CoustomerDaryaft]
    FOREIGN KEY ([Coustomer_Id])
    REFERENCES [dbo].[Coustomers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CoustomerDaryaft'
CREATE INDEX [IX_FK_CoustomerDaryaft]
ON [dbo].[Daryafts]
    ([Coustomer_Id]);
GO

-- Creating foreign key on [Bank_Id] in table 'Varizs'
ALTER TABLE [dbo].[Varizs]
ADD CONSTRAINT [FK_BankVariz]
    FOREIGN KEY ([Bank_Id])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankVariz'
CREATE INDEX [IX_FK_BankVariz]
ON [dbo].[Varizs]
    ([Bank_Id]);
GO

-- Creating foreign key on [Bank_Id] in table 'Bardashts'
ALTER TABLE [dbo].[Bardashts]
ADD CONSTRAINT [FK_BankBardasht]
    FOREIGN KEY ([Bank_Id])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBardasht'
CREATE INDEX [IX_FK_BankBardasht]
ON [dbo].[Bardashts]
    ([Bank_Id]);
GO

-- Creating foreign key on [Id] in table 'Foroshes_ForoshAghsat'
ALTER TABLE [dbo].[Foroshes_ForoshAghsat]
ADD CONSTRAINT [FK_ForoshAghsat_inherits_Forosh]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Foroshes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Foroshes_ForoshNaghdi'
ALTER TABLE [dbo].[Foroshes_ForoshNaghdi]
ADD CONSTRAINT [FK_ForoshNaghdi_inherits_Forosh]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Foroshes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------