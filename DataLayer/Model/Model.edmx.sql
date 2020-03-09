
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2020 00:13:34
-- Generated from EDMX file: C:\Users\gabe3\source\repos\MiwTienda\DataLayer\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientePedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_ClientePedido];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteRol_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteRol] DROP CONSTRAINT [FK_ClienteRol_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteRol_Rol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteRol] DROP CONSTRAINT [FK_ClienteRol_Rol];
GO
IF OBJECT_ID(N'[dbo].[FK_EstadoPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_EstadoPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaSet] DROP CONSTRAINT [FK_FacturaPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_MetodoPagoFactura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaSet] DROP CONSTRAINT [FK_MetodoPagoFactura];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoPedido_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoPedido] DROP CONSTRAINT [FK_ProductoPedido_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoPedido_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoPedido] DROP CONSTRAINT [FK_ProductoPedido_Producto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClienteRol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteRol];
GO
IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[EstadoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoSet];
GO
IF OBJECT_ID(N'[dbo].[FacturaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacturaSet];
GO
IF OBJECT_ID(N'[dbo].[MetodoPagoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MetodoPagoSet];
GO
IF OBJECT_ID(N'[dbo].[PedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoSet];
GO
IF OBJECT_ID(N'[dbo].[ProductoPedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoPedido];
GO
IF OBJECT_ID(N'[dbo].[ProductoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoSet];
GO
IF OBJECT_ID(N'[dbo].[RolSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RolSet'
CREATE TABLE [dbo].[RolSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NOT NULL,
    [EstadoId] int  NOT NULL
);
GO

-- Creating table 'ProductoSet'
CREATE TABLE [dbo].[ProductoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Imagen] nvarchar(max)  NOT NULL,
    [Cantidad] int  NOT NULL,
    [Precio] float  NOT NULL,
    [Categoria] int  NULL
);
GO

-- Creating table 'FacturaSet'
CREATE TABLE [dbo].[FacturaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [MetodoPagoId] int  NOT NULL,
    [Pedido_Id] int  NOT NULL
);
GO

-- Creating table 'MetodoPagoSet'
CREATE TABLE [dbo].[MetodoPagoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TipoMetodo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstadoSet'
CREATE TABLE [dbo].[EstadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TipoEstado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClienteRol'
CREATE TABLE [dbo].[ClienteRol] (
    [Cliente_Id] int  NOT NULL,
    [Rol_Id] int  NOT NULL
);
GO

-- Creating table 'ProductoPedido'
CREATE TABLE [dbo].[ProductoPedido] (
    [Producto_Id] int  NOT NULL,
    [Pedido_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolSet'
ALTER TABLE [dbo].[RolSet]
ADD CONSTRAINT [PK_RolSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [PK_PedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductoSet'
ALTER TABLE [dbo].[ProductoSet]
ADD CONSTRAINT [PK_ProductoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [PK_FacturaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MetodoPagoSet'
ALTER TABLE [dbo].[MetodoPagoSet]
ADD CONSTRAINT [PK_MetodoPagoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoSet'
ALTER TABLE [dbo].[EstadoSet]
ADD CONSTRAINT [PK_EstadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Cliente_Id], [Rol_Id] in table 'ClienteRol'
ALTER TABLE [dbo].[ClienteRol]
ADD CONSTRAINT [PK_ClienteRol]
    PRIMARY KEY CLUSTERED ([Cliente_Id], [Rol_Id] ASC);
GO

-- Creating primary key on [Producto_Id], [Pedido_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [PK_ProductoPedido]
    PRIMARY KEY CLUSTERED ([Producto_Id], [Pedido_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cliente_Id] in table 'ClienteRol'
ALTER TABLE [dbo].[ClienteRol]
ADD CONSTRAINT [FK_ClienteRol_Cliente]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Rol_Id] in table 'ClienteRol'
ALTER TABLE [dbo].[ClienteRol]
ADD CONSTRAINT [FK_ClienteRol_Rol]
    FOREIGN KEY ([Rol_Id])
    REFERENCES [dbo].[RolSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteRol_Rol'
CREATE INDEX [IX_FK_ClienteRol_Rol]
ON [dbo].[ClienteRol]
    ([Rol_Id]);
GO

-- Creating foreign key on [ClienteId] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_ClientePedido]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientePedido'
CREATE INDEX [IX_FK_ClientePedido]
ON [dbo].[PedidoSet]
    ([ClienteId]);
GO

-- Creating foreign key on [MetodoPagoId] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [FK_MetodoPagoFactura]
    FOREIGN KEY ([MetodoPagoId])
    REFERENCES [dbo].[MetodoPagoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetodoPagoFactura'
CREATE INDEX [IX_FK_MetodoPagoFactura]
ON [dbo].[FacturaSet]
    ([MetodoPagoId]);
GO

-- Creating foreign key on [EstadoId] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_EstadoPedido]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[EstadoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoPedido'
CREATE INDEX [IX_FK_EstadoPedido]
ON [dbo].[PedidoSet]
    ([EstadoId]);
GO

-- Creating foreign key on [Pedido_Id] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [FK_FacturaPedido]
    FOREIGN KEY ([Pedido_Id])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaPedido'
CREATE INDEX [IX_FK_FacturaPedido]
ON [dbo].[FacturaSet]
    ([Pedido_Id]);
GO

-- Creating foreign key on [Producto_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [FK_ProductoPedido_Producto]
    FOREIGN KEY ([Producto_Id])
    REFERENCES [dbo].[ProductoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pedido_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [FK_ProductoPedido_Pedido]
    FOREIGN KEY ([Pedido_Id])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoPedido_Pedido'
CREATE INDEX [IX_FK_ProductoPedido_Pedido]
ON [dbo].[ProductoPedido]
    ([Pedido_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------