USE [BancoProductos]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[telefono] [nvarchar](20) NULL,
	[direccion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes_Productos]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes_Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_producto] [int] NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_vencimiento] [date] NULL,
	[saldo] [decimal](15, 2) NULL,
	[limite_credito] [decimal](15, 2) NULL,
	[tasa_interes] [decimal](5, 2) NULL,
	[prima] [decimal](15, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[tipo] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_transaccion] [nvarchar](50) NOT NULL,
	[monto] [decimal](15, 2) NOT NULL,
	[fecha_transaccion] [datetime] NOT NULL,
	[id_cliente_producto_origen] [int] NULL,
	[id_cliente_producto_destino] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [fecha_nacimiento], [email], [telefono], [direccion]) VALUES (1, N'Alvaro', N'Gallegos', CAST(N'1999-06-06' AS Date), N'alvaro@upt.pe', N'900860352', N'Av.lilo')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes_Productos] ON 

INSERT [dbo].[Clientes_Productos] ([id], [id_cliente], [id_producto], [fecha_inicio], [fecha_vencimiento], [saldo], [limite_credito], [tasa_interes], [prima]) VALUES (2, 1, 1, CAST(N'2023-05-06' AS Date), CAST(N'2023-12-12' AS Date), CAST(12.00 AS Decimal(15, 2)), CAST(12.00 AS Decimal(15, 2)), CAST(12.00 AS Decimal(5, 2)), CAST(12.00 AS Decimal(15, 2)))
INSERT [dbo].[Clientes_Productos] ([id], [id_cliente], [id_producto], [fecha_inicio], [fecha_vencimiento], [saldo], [limite_credito], [tasa_interes], [prima]) VALUES (3, 1, 1, CAST(N'2023-05-06' AS Date), CAST(N'2023-10-12' AS Date), CAST(15.00 AS Decimal(15, 2)), CAST(15.00 AS Decimal(15, 2)), CAST(15.00 AS Decimal(5, 2)), CAST(15.00 AS Decimal(15, 2)))
SET IDENTITY_INSERT [dbo].[Clientes_Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [tipo]) VALUES (1, N'Cuenta corriente', N'Cuenta corriente para gestionar las operaciones del día a día', N'Cuenta corriente')
INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [tipo]) VALUES (2, N'Cuenta ahorro', N'Cuenta de ahorro para acumular ahorros a largo plazo', N'Cuenta ahorro')
INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [tipo]) VALUES (3, N'Seguro', N'Producto de seguro para protección de bienes y personas', N'Seguro')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__AB6E6164F809DF21]    Script Date: 06/05/2023 22:23:06 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes_Productos]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Clientes_Productos]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD FOREIGN KEY([id_cliente_producto_origen])
REFERENCES [dbo].[Clientes_Productos] ([id])
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD FOREIGN KEY([id_cliente_producto_destino])
REFERENCES [dbo].[Clientes_Productos] ([id])
GO
/****** Object:  StoredProcedure [dbo].[ups_listar_ClienteProducto]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ups_listar_ClienteProducto]
as
begin

select * from Clientes_Productos
end
GO
/****** Object:  StoredProcedure [dbo].[ups_obtener_ClienteProducto]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ups_obtener_ClienteProducto](@id int)
as
begin

select * from Clientes_Productos where Id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[ups_registrar_ClienteProducto]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ups_registrar_ClienteProducto]
    @id_cliente INT,
    @id_producto INT,
    @fecha_inicio DATE,
    @fecha_vencimiento DATE,
    @saldo DECIMAL(15, 2),
    @limite_credito DECIMAL(15, 2),
    @tasa_interes DECIMAL(5, 2),
    @prima DECIMAL(15, 2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes_Productos (
        id_cliente, id_producto, fecha_inicio, fecha_vencimiento, saldo,
        limite_credito, tasa_interes, prima
    )
    VALUES (
        @id_cliente, @id_producto, @fecha_inicio, @fecha_vencimiento, @saldo,
        @limite_credito, @tasa_interes, @prima
    );
END
GO
/****** Object:  StoredProcedure [dbo].[usp_listar]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_listar]
as
begin

select * from Productos
end
GO
/****** Object:  StoredProcedure [dbo].[usp_obtener]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_obtener](@id int)
as
begin

select * from Productos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar]    Script Date: 06/05/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure [dbo].[usp_registrar]
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @tipo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Productos (nombre, descripcion, tipo)
    VALUES (@nombre, @descripcion, @tipo);
END
GO
