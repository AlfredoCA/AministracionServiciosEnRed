
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2014 13:34:28
-- Generated from EDMX file: C:\Users\JuanCarlos\Documents\GitHub\AministracionServiciosEnRed\Inventarios\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cmdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Articulos__IdLoc__22751F6C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK__Articulos__IdLoc__22751F6C];
GO
IF OBJECT_ID(N'[dbo].[FK__Articulos__IdMod__236943A5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK__Articulos__IdMod__236943A5];
GO
IF OBJECT_ID(N'[dbo].[FK__Contratos__IdArt__40058253]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK__Contratos__IdArt__40058253];
GO
IF OBJECT_ID(N'[dbo].[FK__Contratos__IdTer__41EDCAC5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK__Contratos__IdTer__41EDCAC5];
GO
IF OBJECT_ID(N'[dbo].[FK__Contratos__IdTip__42E1EEFE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK__Contratos__IdTip__42E1EEFE];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentoPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personals] DROP CONSTRAINT [FK_DepartamentoPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK__TercerasP__IdTip__2BFE89A6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TercerasPersonas] DROP CONSTRAINT [FK__TercerasP__IdTip__2BFE89A6];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticulosPersonals]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_ArticulosPersonals];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelosTipoArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Modelos] DROP CONSTRAINT [FK_ModelosTipoArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticulosTercerasPersonas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_ArticulosTercerasPersonas];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticulosRelacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelacionSet] DROP CONSTRAINT [FK_ArticulosRelacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticulosRelacion1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelacionSet] DROP CONSTRAINT [FK_ArticulosRelacion1];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketArticulos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet] DROP CONSTRAINT [FK_TicketArticulos];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketPersonals]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet] DROP CONSTRAINT [FK_TicketPersonals];
GO
IF OBJECT_ID(N'[dbo].[FK_KnowledgeItemTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketSet] DROP CONSTRAINT [FK_KnowledgeItemTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_ComentarioKnowledgeItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComentarioSet] DROP CONSTRAINT [FK_ComentarioKnowledgeItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Contratos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contratos];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Localizaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localizaciones];
GO
IF OBJECT_ID(N'[dbo].[Modelos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modelos];
GO
IF OBJECT_ID(N'[dbo].[Personals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personals];
GO
IF OBJECT_ID(N'[dbo].[TercerasPersonas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TercerasPersonas];
GO
IF OBJECT_ID(N'[dbo].[TipoArticulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoArticulos];
GO
IF OBJECT_ID(N'[dbo].[TipoCompania]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCompania];
GO
IF OBJECT_ID(N'[dbo].[TipoContrato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoContrato];
GO
IF OBJECT_ID(N'[dbo].[RelacionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelacionSet];
GO
IF OBJECT_ID(N'[dbo].[TicketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet];
GO
IF OBJECT_ID(N'[dbo].[KnowledgeItemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KnowledgeItemSet];
GO
IF OBJECT_ID(N'[dbo].[ComentarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComentarioSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [IdArticulo] int  NOT NULL,
    [CodigoStatus] int  NULL,
    [IdLocalizacion] int  NULL,
    [FechaAdquisicion] datetime  NULL,
    [FechaUltimoMovimiento] datetime  NULL,
    [OtrosDetalles] varchar(500)  NULL,
    [IdModelo] int  NOT NULL,
    [IdPersonal] int  NULL,
    [IdProveedor] int  NOT NULL,
    [CostoAdquisicion] float  NOT NULL
);
GO

-- Creating table 'Contratos'
CREATE TABLE [dbo].[Contratos] (
    [IdContrato] int IDENTITY(1,1) NOT NULL,
    [IdArticulo] int  NOT NULL,
    [IdTerceraPersona] int  NOT NULL,
    [IdTipoContrato] int  NOT NULL,
    [FechaContrato] datetime  NOT NULL,
    [Detalles] varchar(500)  NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [IdDepartamento] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL
);
GO

-- Creating table 'Localizaciones'
CREATE TABLE [dbo].[Localizaciones] (
    [IdLocalizacion] int IDENTITY(1,1) NOT NULL,
    [Direccion] varchar(45)  NOT NULL,
    [Descripcion] varchar(45)  NOT NULL,
    [Detalles] varchar(45)  NULL
);
GO

-- Creating table 'Modelos'
CREATE TABLE [dbo].[Modelos] (
    [IdModelo] int IDENTITY(1,1) NOT NULL,
    [Fabricante] varchar(45)  NOT NULL,
    [Modelo] varchar(45)  NOT NULL,
    [Especificaciones] varchar(500)  NULL,
    [IdTipoArticulo] int  NOT NULL
);
GO

-- Creating table 'Personals'
CREATE TABLE [dbo].[Personals] (
    [IdPersonal] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Telefono] nvarchar(20)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Puesto] nvarchar(30)  NOT NULL,
    [IdDepartamento] int  NOT NULL
);
GO

-- Creating table 'TercerasPersonas'
CREATE TABLE [dbo].[TercerasPersonas] (
    [IdTerceraPersona] int IDENTITY(1,1) NOT NULL,
    [IdTipoCompania] int  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Direccion] varchar(100)  NULL,
    [Rfc] varchar(15)  NULL,
    [Detalles] varchar(500)  NULL
);
GO

-- Creating table 'TipoArticulos'
CREATE TABLE [dbo].[TipoArticulos] (
    [IdTipo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL
);
GO

-- Creating table 'TipoCompania'
CREATE TABLE [dbo].[TipoCompania] (
    [IdTipoCompania] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL
);
GO

-- Creating table 'TipoContrato'
CREATE TABLE [dbo].[TipoContrato] (
    [IdTipoContrato] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL
);
GO

-- Creating table 'RelacionSet'
CREATE TABLE [dbo].[RelacionSet] (
    [IdArticulo1] int  NOT NULL,
    [IdArticulo2] int  NOT NULL,
    [IdRelacion] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TicketSet'
CREATE TABLE [dbo].[TicketSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Categoria] nvarchar(max)  NOT NULL,
    [Prioridad] nvarchar(max)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [IdCreador] nvarchar(max)  NOT NULL,
    [FechaUltimaActualizacion] datetime  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [KnowledgeItemId] int  NULL,
    [Articulo_IdArticulo] int  NOT NULL,
    [Personals_IdPersonal] int  NOT NULL
);
GO

-- Creating table 'KnowledgeItemSet'
CREATE TABLE [dbo].[KnowledgeItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaUltimaModificacion] datetime  NOT NULL,
    [Creador] nvarchar(max)  NOT NULL,
    [Keywords] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComentarioSet'
CREATE TABLE [dbo].[ComentarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Texto] nvarchar(max)  NOT NULL,
    [Creador] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [KnowledgeItem_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdArticulo] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([IdArticulo] ASC);
GO

-- Creating primary key on [IdContrato] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [PK_Contratos]
    PRIMARY KEY CLUSTERED ([IdContrato] ASC);
GO

-- Creating primary key on [IdDepartamento] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([IdDepartamento] ASC);
GO

-- Creating primary key on [IdLocalizacion] in table 'Localizaciones'
ALTER TABLE [dbo].[Localizaciones]
ADD CONSTRAINT [PK_Localizaciones]
    PRIMARY KEY CLUSTERED ([IdLocalizacion] ASC);
GO

-- Creating primary key on [IdModelo] in table 'Modelos'
ALTER TABLE [dbo].[Modelos]
ADD CONSTRAINT [PK_Modelos]
    PRIMARY KEY CLUSTERED ([IdModelo] ASC);
GO

-- Creating primary key on [IdPersonal] in table 'Personals'
ALTER TABLE [dbo].[Personals]
ADD CONSTRAINT [PK_Personals]
    PRIMARY KEY CLUSTERED ([IdPersonal] ASC);
GO

-- Creating primary key on [IdTerceraPersona] in table 'TercerasPersonas'
ALTER TABLE [dbo].[TercerasPersonas]
ADD CONSTRAINT [PK_TercerasPersonas]
    PRIMARY KEY CLUSTERED ([IdTerceraPersona] ASC);
GO

-- Creating primary key on [IdTipo] in table 'TipoArticulos'
ALTER TABLE [dbo].[TipoArticulos]
ADD CONSTRAINT [PK_TipoArticulos]
    PRIMARY KEY CLUSTERED ([IdTipo] ASC);
GO

-- Creating primary key on [IdTipoCompania] in table 'TipoCompania'
ALTER TABLE [dbo].[TipoCompania]
ADD CONSTRAINT [PK_TipoCompania]
    PRIMARY KEY CLUSTERED ([IdTipoCompania] ASC);
GO

-- Creating primary key on [IdTipoContrato] in table 'TipoContrato'
ALTER TABLE [dbo].[TipoContrato]
ADD CONSTRAINT [PK_TipoContrato]
    PRIMARY KEY CLUSTERED ([IdTipoContrato] ASC);
GO

-- Creating primary key on [IdRelacion] in table 'RelacionSet'
ALTER TABLE [dbo].[RelacionSet]
ADD CONSTRAINT [PK_RelacionSet]
    PRIMARY KEY CLUSTERED ([IdRelacion] ASC);
GO

-- Creating primary key on [Id] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [PK_TicketSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KnowledgeItemSet'
ALTER TABLE [dbo].[KnowledgeItemSet]
ADD CONSTRAINT [PK_KnowledgeItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [PK_ComentarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdLocalizacion] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK__Articulos__IdLoc__22751F6C]
    FOREIGN KEY ([IdLocalizacion])
    REFERENCES [dbo].[Localizaciones]
        ([IdLocalizacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Articulos__IdLoc__22751F6C'
CREATE INDEX [IX_FK__Articulos__IdLoc__22751F6C]
ON [dbo].[Articulos]
    ([IdLocalizacion]);
GO

-- Creating foreign key on [IdModelo] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK__Articulos__IdMod__236943A5]
    FOREIGN KEY ([IdModelo])
    REFERENCES [dbo].[Modelos]
        ([IdModelo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Articulos__IdMod__236943A5'
CREATE INDEX [IX_FK__Articulos__IdMod__236943A5]
ON [dbo].[Articulos]
    ([IdModelo]);
GO

-- Creating foreign key on [IdArticulo] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [FK__Contratos__IdArt__40058253]
    FOREIGN KEY ([IdArticulo])
    REFERENCES [dbo].[Articulos]
        ([IdArticulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contratos__IdArt__40058253'
CREATE INDEX [IX_FK__Contratos__IdArt__40058253]
ON [dbo].[Contratos]
    ([IdArticulo]);
GO

-- Creating foreign key on [IdTerceraPersona] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [FK__Contratos__IdTer__41EDCAC5]
    FOREIGN KEY ([IdTerceraPersona])
    REFERENCES [dbo].[TercerasPersonas]
        ([IdTerceraPersona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contratos__IdTer__41EDCAC5'
CREATE INDEX [IX_FK__Contratos__IdTer__41EDCAC5]
ON [dbo].[Contratos]
    ([IdTerceraPersona]);
GO

-- Creating foreign key on [IdTipoContrato] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [FK__Contratos__IdTip__42E1EEFE]
    FOREIGN KEY ([IdTipoContrato])
    REFERENCES [dbo].[TipoContrato]
        ([IdTipoContrato])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contratos__IdTip__42E1EEFE'
CREATE INDEX [IX_FK__Contratos__IdTip__42E1EEFE]
ON [dbo].[Contratos]
    ([IdTipoContrato]);
GO

-- Creating foreign key on [IdDepartamento] in table 'Personals'
ALTER TABLE [dbo].[Personals]
ADD CONSTRAINT [FK_DepartamentoPersonal]
    FOREIGN KEY ([IdDepartamento])
    REFERENCES [dbo].[Departamentos]
        ([IdDepartamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoPersonal'
CREATE INDEX [IX_FK_DepartamentoPersonal]
ON [dbo].[Personals]
    ([IdDepartamento]);
GO

-- Creating foreign key on [IdTipoCompania] in table 'TercerasPersonas'
ALTER TABLE [dbo].[TercerasPersonas]
ADD CONSTRAINT [FK__TercerasP__IdTip__2BFE89A6]
    FOREIGN KEY ([IdTipoCompania])
    REFERENCES [dbo].[TipoCompania]
        ([IdTipoCompania])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TercerasP__IdTip__2BFE89A6'
CREATE INDEX [IX_FK__TercerasP__IdTip__2BFE89A6]
ON [dbo].[TercerasPersonas]
    ([IdTipoCompania]);
GO

-- Creating foreign key on [IdPersonal] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_ArticulosPersonals]
    FOREIGN KEY ([IdPersonal])
    REFERENCES [dbo].[Personals]
        ([IdPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticulosPersonals'
CREATE INDEX [IX_FK_ArticulosPersonals]
ON [dbo].[Articulos]
    ([IdPersonal]);
GO

-- Creating foreign key on [IdTipoArticulo] in table 'Modelos'
ALTER TABLE [dbo].[Modelos]
ADD CONSTRAINT [FK_ModelosTipoArticulos]
    FOREIGN KEY ([IdTipoArticulo])
    REFERENCES [dbo].[TipoArticulos]
        ([IdTipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelosTipoArticulos'
CREATE INDEX [IX_FK_ModelosTipoArticulos]
ON [dbo].[Modelos]
    ([IdTipoArticulo]);
GO

-- Creating foreign key on [IdProveedor] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_ArticulosTercerasPersonas]
    FOREIGN KEY ([IdProveedor])
    REFERENCES [dbo].[TercerasPersonas]
        ([IdTerceraPersona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticulosTercerasPersonas'
CREATE INDEX [IX_FK_ArticulosTercerasPersonas]
ON [dbo].[Articulos]
    ([IdProveedor]);
GO

-- Creating foreign key on [IdArticulo1] in table 'RelacionSet'
ALTER TABLE [dbo].[RelacionSet]
ADD CONSTRAINT [FK_ArticulosRelacion]
    FOREIGN KEY ([IdArticulo1])
    REFERENCES [dbo].[Articulos]
        ([IdArticulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticulosRelacion'
CREATE INDEX [IX_FK_ArticulosRelacion]
ON [dbo].[RelacionSet]
    ([IdArticulo1]);
GO

-- Creating foreign key on [IdArticulo2] in table 'RelacionSet'
ALTER TABLE [dbo].[RelacionSet]
ADD CONSTRAINT [FK_ArticulosRelacion1]
    FOREIGN KEY ([IdArticulo2])
    REFERENCES [dbo].[Articulos]
        ([IdArticulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticulosRelacion1'
CREATE INDEX [IX_FK_ArticulosRelacion1]
ON [dbo].[RelacionSet]
    ([IdArticulo2]);
GO

-- Creating foreign key on [Articulo_IdArticulo] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_TicketArticulos]
    FOREIGN KEY ([Articulo_IdArticulo])
    REFERENCES [dbo].[Articulos]
        ([IdArticulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketArticulos'
CREATE INDEX [IX_FK_TicketArticulos]
ON [dbo].[TicketSet]
    ([Articulo_IdArticulo]);
GO

-- Creating foreign key on [Personals_IdPersonal] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_TicketPersonals]
    FOREIGN KEY ([Personals_IdPersonal])
    REFERENCES [dbo].[Personals]
        ([IdPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketPersonals'
CREATE INDEX [IX_FK_TicketPersonals]
ON [dbo].[TicketSet]
    ([Personals_IdPersonal]);
GO

-- Creating foreign key on [KnowledgeItemId] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_KnowledgeItemTicket]
    FOREIGN KEY ([KnowledgeItemId])
    REFERENCES [dbo].[KnowledgeItemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnowledgeItemTicket'
CREATE INDEX [IX_FK_KnowledgeItemTicket]
ON [dbo].[TicketSet]
    ([KnowledgeItemId]);
GO

-- Creating foreign key on [KnowledgeItem_Id] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_ComentarioKnowledgeItem]
    FOREIGN KEY ([KnowledgeItem_Id])
    REFERENCES [dbo].[KnowledgeItemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioKnowledgeItem'
CREATE INDEX [IX_FK_ComentarioKnowledgeItem]
ON [dbo].[ComentarioSet]
    ([KnowledgeItem_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------