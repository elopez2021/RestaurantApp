USE [Restaurante]
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 22/8/2024 1:09:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[idtipocliente] [int] NOT NULL,
	[idtipodocumento] [int] NOT NULL,
	[nodocumento] [varchar](20) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[razonsocial] [varchar](100) NULL,
	[girocliente] [varchar](100) NULL,
	[telefono] [varchar](20) NOT NULL,
	[correo] [varchar](100) NULL,
	[direccion] [text] NULL,
	[estado] [bit] NOT NULL,
	[idprovincia] [int] NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[limitecredito] [decimal](10, 2) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamentos]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamentos](
	[iddepartamento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[idsucursal] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_departamento_sucursal] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[idsucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[idfactura] [int] IDENTITY(1,1) NOT NULL,
	[idpedido] [int] NULL,
	[total] [decimal](10, 2) NOT NULL,
	[impuesto] [decimal](10, 2) NOT NULL,
	[subtotal] [decimal](10, 2) NOT NULL,
	[estado] [bit] NULL,
	[fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idfactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[impuestos]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impuestos](
	[idimpuesto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[porcentaje] [decimal](5, 2) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idimpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medidas]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medidas](
	[idmedida] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[sigla] [varchar](5) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idmedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_nombre_sigla_medidas] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[sigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mesas]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesas](
	[idmesa] [int] IDENTITY(1,1) NOT NULL,
	[idsala] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cantpersonas] [int] NOT NULL,
	[disponible] [bit] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idmesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_sala_mesa] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[idsala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[monedas]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[monedas](
	[idmoneda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[sigla] [varchar](10) NOT NULL,
	[simbolo] [varchar](5) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idmoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_nombre_sigla_monedas] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[sigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedidoproducto]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedidoproducto](
	[idpedido] [int] NOT NULL,
	[idproducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[preciounitario] [decimal](10, 2) NOT NULL,
	[preciototal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [pk_pedidoproducto] PRIMARY KEY CLUSTERED 
(
	[idpedido] ASC,
	[idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedidos]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedidos](
	[idpedido] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NOT NULL,
	[idcliente] [int] NULL,
	[cliente] [varchar](100) NULL,
	[idmesa] [int] NOT NULL,
	[total] [decimal](10, 2) NOT NULL,
	[fecha] [datetime] NULL,
	[estado] [bit] NULL,
	[subtotal] [decimal](10, 2) NULL,
	[impuesto] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idpedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[IdImpuesto] [int] NULL,
	[IdProveedor] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[descuento] [decimal](10, 2) NULL,
	[Existencia] [int] NULL,
	[NoLote] [nvarchar](50) NULL,
	[StockMinimo] [int] NULL,
	[StockMaximo] [int] NULL,
	[FechaElaboracion] [date] NULL,
	[FechaExpiracion] [date] NULL,
	[CodigoDeBarra] [nvarchar](50) NULL,
	[RutaFoto] [nvarchar](255) NOT NULL,
	[estado] [bit] NULL,
	[esproductofinal] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[nodocumento] [varchar](20) NOT NULL,
	[idtipodocumento] [int] NULL,
	[nombre] [varchar](50) NOT NULL,
	[telefono] [varchar](11) NOT NULL,
	[idprovincia] [int] NOT NULL,
	[iddepartamento] [int] NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[correo] [varchar](100) NOT NULL,
	[nombre_vendedor] [varchar](100) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_no_documento_proveedor] UNIQUE NONCLUSTERED 
(
	[nodocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[idprovincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[codigo] [varchar](10) NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idprovincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salas]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salas](
	[idsala] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[idsucursal] [int] NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_nombre_idsucursal] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[idsucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sexo]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sexo](
	[idsexo] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idsexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sucursal]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sucursal](
	[idsucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[codigo_postal] [varchar](10) NOT NULL,
	[fecha_apertura] [date] NOT NULL,
	[gerente] [varchar](50) NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_cliente]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_cliente](
	[idtipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[idtipo] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_usuario]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_usuario](
	[idtipo] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[no_documento] [varchar](50) NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[contrasena] [varchar](100) NOT NULL,
	[telefono] [varchar](11) NOT NULL,
	[idtipo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correo] [varchar](100) NOT NULL,
	[idsexo] [int] NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[idsucursal] [int] NOT NULL,
	[comision] [decimal](10, 2) NULL,
	[estatus] [bit] NOT NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_no_documento_usuarios] UNIQUE NONCLUSTERED 
(
	[no_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_usuario_usuarios] UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[categorias] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF_clientes_estado]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[clientes] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[clientes] ADD  DEFAULT ((0.0)) FOR [limitecredito]
GO
ALTER TABLE [dbo].[departamentos] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[facturas] ADD  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[facturas] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[impuestos] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[medidas] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[mesas] ADD  DEFAULT ((1)) FOR [disponible]
GO
ALTER TABLE [dbo].[mesas] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[monedas] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[pedidos] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[pedidos] ADD  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[proveedor] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[provincia] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[salas] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[sucursal] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((1)) FOR [estatus]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[departamentos]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([idsucursal])
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD FOREIGN KEY([idpedido])
REFERENCES [dbo].[pedidos] ([idpedido])
GO
ALTER TABLE [dbo].[mesas]  WITH CHECK ADD FOREIGN KEY([idsala])
REFERENCES [dbo].[salas] ([idsala])
GO
ALTER TABLE [dbo].[pedidoproducto]  WITH CHECK ADD  CONSTRAINT [fk_pedidoproducto_pedido] FOREIGN KEY([idpedido])
REFERENCES [dbo].[pedidos] ([idpedido])
GO
ALTER TABLE [dbo].[pedidoproducto] CHECK CONSTRAINT [fk_pedidoproducto_pedido]
GO
ALTER TABLE [dbo].[pedidoproducto]  WITH CHECK ADD  CONSTRAINT [fk_pedidoproducto_producto] FOREIGN KEY([idproducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[pedidoproducto] CHECK CONSTRAINT [fk_pedidoproducto_producto]
GO
ALTER TABLE [dbo].[pedidos]  WITH CHECK ADD FOREIGN KEY([idcliente])
REFERENCES [dbo].[clientes] ([idcliente])
GO
ALTER TABLE [dbo].[pedidos]  WITH CHECK ADD FOREIGN KEY([idmesa])
REFERENCES [dbo].[mesas] ([idmesa])
GO
ALTER TABLE [dbo].[pedidos]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuarios] ([idusuario])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdImpuesto])
REFERENCES [dbo].[impuestos] ([idimpuesto])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaProducto] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[categorias] ([idcategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_CategoriaProducto]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([iddepartamento])
REFERENCES [dbo].[departamentos] ([iddepartamento])
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idprovincia])
REFERENCES [dbo].[provincia] ([idprovincia])
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idtipodocumento])
REFERENCES [dbo].[tipo_documento] ([idtipo])
GO
ALTER TABLE [dbo].[salas]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([idsucursal])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([idsexo])
REFERENCES [dbo].[sexo] ([idsexo])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([idsucursal])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([idtipo])
REFERENCES [dbo].[tipo_usuario] ([idtipo])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([Existencia]>=(0)))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([PrecioVenta]>=(0)))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([PrecioCompra]>=(0)))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([StockMinimo]>=(0)))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([StockMaximo]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[GetVentasPorCategoria]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVentasPorCategoria]
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        c.nombre AS Categoria, 
        SUM(pp.cantidad) AS Cantidad, 
        SUM(pp.cantidad * pp.preciounitario) AS SubTotal,
        SUM(pp.cantidad * pp.preciounitario * (i.porcentaje / 100)) AS Impuesto,
        SUM(pp.preciototal) AS Total
    FROM 
        pedidoproducto pp
    INNER JOIN 
        productos p ON pp.idproducto = p.idproducto
    INNER JOIN 
        categorias c ON p.idcategoria = c.idcategoria
    INNER JOIN 
        impuestos i ON p.idimpuesto = i.idimpuesto
    INNER JOIN 
        pedidos pe ON pp.idpedido = pe.idpedido
    WHERE 
        MONTH(pe.fecha) = @Month 
        AND YEAR(pe.fecha) = @Year
    GROUP BY 
        c.nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVentasPorProducto]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetVentasPorProducto]
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        p.nombre AS Producto, 
        SUM(pp.cantidad) AS Cantidad, 
        SUM(pp.cantidad * pp.preciounitario) AS SubTotal,
        SUM(pp.cantidad * pp.preciounitario * (i.porcentaje / 100)) AS Impuesto,
        SUM(pp.preciototal) AS Total
    FROM 
        pedidoproducto pp
    INNER JOIN 
        productos p ON pp.idproducto = p.idproducto
    INNER JOIN 
        impuestos i ON p.idimpuesto = i.idimpuesto
    INNER JOIN 
        pedidos pe ON pp.idpedido = pe.idpedido
    WHERE 
        MONTH(pe.fecha) = @Month 
        AND YEAR(pe.fecha) = @Year
    GROUP BY 
        p.nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVentasPorUsuario]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetVentasPorUsuario]
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        u.nombre AS Usuario, 
        SUM(pp.cantidad) AS Cantidad, 
        SUM(pp.cantidad * pp.preciounitario) AS SubTotal,
        SUM(pp.cantidad * pp.preciounitario * (i.porcentaje / 100)) AS Impuesto,
        SUM(pp.preciototal) AS Total
    FROM 
        pedidoproducto pp
    INNER JOIN 
        pedidos pe ON pp.idpedido = pe.idpedido
    INNER JOIN 
        usuarios u ON pe.idusuario = u.idusuario
    INNER JOIN 
        productos p ON pp.idproducto = p.idproducto
    INNER JOIN 
        impuestos i ON p.idimpuesto = i.idimpuesto
    WHERE 
        MONTH(pe.fecha) = @Month 
        AND YEAR(pe.fecha) = @Year
    GROUP BY 
        u.nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HashPassword]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HashPassword]
    @Password NVARCHAR(100),
    @HashedPassword NVARCHAR(200) OUTPUT
AS
BEGIN
    -- Declare variables
    DECLARE @Salt VARBINARY(16);
    DECLARE @PasswordBytes VARBINARY(100);
    DECLARE @PasswordWithSalt VARBINARY(116);
    DECLARE @HashBytes VARBINARY(32);
    DECLARE @HashWithSalt VARBINARY(48);

    -- Generate a random salt
    SET @Salt = CRYPT_GEN_RANDOM(16);

    -- Convert the password to bytes
    SET @PasswordBytes = CAST(@Password AS VARBINARY(100));

    -- Combine salt and password bytes
    SET @PasswordWithSalt = @Salt + @PasswordBytes;

    -- Hash the combined password and salt using SHA2_256
    SET @HashBytes = HASHBYTES('SHA2_256', @PasswordWithSalt);

    -- Combine the salt and hash
    SET @HashWithSalt = @Salt + @HashBytes;

    -- Convert the combined salt and hash to Base64 for storage
    SET @HashedPassword = CAST(N'' AS XML).value('xs:base64Binary(sql:variable("@HashWithSalt"))', 'NVARCHAR(200)');
END;
GO
/****** Object:  Trigger [dbo].[trg_DecrementProductExistencia]    Script Date: 22/8/2024 1:09:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_DecrementProductExistencia]
ON [dbo].[pedidoproducto]
AFTER INSERT
AS
BEGIN
    UPDATE productos
    SET existencia = existencia - inserted.cantidad
    FROM productos
    INNER JOIN inserted ON productos.idproducto = inserted.idproducto;
    
    IF EXISTS (SELECT 1 FROM productos WHERE existencia < 0)
    BEGIN
        RAISERROR ('Existencia no puede ser negativa', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
ALTER TABLE [dbo].[pedidoproducto] ENABLE TRIGGER [trg_DecrementProductExistencia]
GO
