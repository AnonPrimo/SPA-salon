
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2018 17:32:47
-- Generated from EDMX file: Z:\StudentsFiles\RPZ\RPZ3\Чубіна\SPA-salon\SPA-salon\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SPA];
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

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name_cat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ServicesSet'
CREATE TABLE [dbo].[ServicesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name_ser] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [Time] time  NOT NULL,
    [Id_cat] int  NOT NULL
);
GO

-- Creating table 'PurchaseSet'
CREATE TABLE [dbo].[PurchaseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_ser] int  NOT NULL,
    [Person] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServicesSet'
ALTER TABLE [dbo].[ServicesSet]
ADD CONSTRAINT [PK_ServicesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchaseSet'
ALTER TABLE [dbo].[PurchaseSet]
ADD CONSTRAINT [PK_PurchaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_cat] in table 'ServicesSet'
ALTER TABLE [dbo].[ServicesSet]
ADD CONSTRAINT [FK_CategoryServices]
    FOREIGN KEY ([Id_cat])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryServices'
CREATE INDEX [IX_FK_CategoryServices]
ON [dbo].[ServicesSet]
    ([Id_cat]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------