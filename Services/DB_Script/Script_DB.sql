USE master
GO
DECLARE @dbname nvarchar(128)
SET @dbname = N'GONZALEZ_JUAN_DB'

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname 
OR name = @dbname)))
DROP DATABASE GONZALEZ_JUAN_DB

GO

CREATE DATABASE GONZALEZ_JUAN_DB
GO
USE GONZALEZ_JUAN_DB
GO
/****** Object:  Table [dbo].[TB_ALUMNOS]    Script Date: 14/6/2019 16:24:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALUMNOS](
	[CD_ALUMNO] [int] IDENTITY(1,1) NOT NULL,
	[APELLIDO] [varchar](50) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[FECHA_NAC] [date] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_ALUMNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ALUMNOS_COMISIONES]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALUMNOS_COMISIONES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[CD_ALUMNO] [int] NOT NULL,
	[NOTA_ID] [bigint] NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CD_COMISION] ASC,
	[CD_ALUMNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CARRERAS]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CARRERAS](
	[CD_CARRERA] [smallint] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[NOMBRE_CORTO] [varchar](10) NOT NULL,
	[DURACION] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_CARRERA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMISIONES]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMISIONES](
	[CD_COMISION] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_MATERIA] [int] NOT NULL,
	[A�O] [int] NOT NULL,
	[CUATRIMESTRE] [tinyint] NULL,
	[CD_MODALIDAD] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_COMISION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMPETENCIAS]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMPETENCIAS](
	[CD_COMPETENCIA] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_COMPETENCIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMPETENCIAS_EXAMENES]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMPETENCIAS_EXAMENES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_EXAMEN] [bigint] NOT NULL,
	[CD_COMPETENCIA] [int] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_EXAMENES]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_EXAMENES](
	[CD_EXAMEN] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[CD_TIPO] [tinyint] NOT NULL,
	[FECHA] [date] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_EXAMEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_HORARIOS]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_HORARIOS](
	[CD_HORARIO] [int] IDENTITY(1,1) NOT NULL,
	[HORA_INICIO] [time](7) NOT NULL,
	[HORA_FIN] [time](7) NOT NULL,
	[DIA_SEMANA] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_HORARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_HORARIOS_COMISIONES]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_HORARIOS_COMISIONES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[CD_HORARIO] [int] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MATERIAS]    Script Date: 14/6/2019 16:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MATERIAS](
	[CD_MATERIA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[CD_CARRERA] [smallint] NOT NULL,
	[A�O] [tinyint] NOT NULL,
	[CUATRIMESTRE] [tinyint] NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_MATERIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MODALIDADES]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MODALIDADES](
	[CD_MODALIDAD] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_MODALIDAD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NOTAS]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NOTAS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NOTA] [tinyint] NOT NULL,
	[FECHA_REGISTRO] [datetime] NOT NULL,
	[COMENTARIOS] [varchar](100) NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PROFESORES]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PROFESORES](
	[CD_PROFESOR] [int] IDENTITY(1,1) NOT NULL,
	[APELLIDO] [varchar](50) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[FECHA_NAC] [date] NOT NULL,
	[FECHA_INGRESO] [date] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_PROFESOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PROFESORES_COMISIONES]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PROFESORES_COMISIONES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[CD_PROFESOR] [int] NOT NULL,
	[CD_ROL_PROFESOR] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CD_COMISION] ASC,
	[CD_PROFESOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ROL_PROFESORES]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ROL_PROFESORES](
	[CD_ROL_PROFESOR] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_ROL_PROFESOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_EXAMEN]    Script Date: 14/6/2019 16:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_EXAMEN](
	[CD_TIPO] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_ALUMNOS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_CARRERAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_COMPETENCIAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_COMPETENCIAS_EXAMENES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_EXAMENES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_HORARIOS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_MATERIAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_MODALIDADES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_NOTAS] ADD  DEFAULT (getdate()) FOR [FECHA_REGISTRO]
GO
ALTER TABLE [dbo].[TB_NOTAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_PROFESORES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_PROFESORES_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ROL_PROFESORES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_TIPO_EXAMEN] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_ALUMNO])
REFERENCES [dbo].[TB_ALUMNOS] ([CD_ALUMNO])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([NOTA_ID])
REFERENCES [dbo].[TB_NOTAS] ([ID])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_MATERIA])
REFERENCES [dbo].[TB_MATERIAS] ([CD_MATERIA])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_MODALIDAD])
REFERENCES [dbo].[TB_MODALIDADES] ([CD_MODALIDAD])
GO
ALTER TABLE [dbo].[TB_COMPETENCIAS_EXAMENES]  WITH CHECK ADD FOREIGN KEY([CD_COMPETENCIA])
REFERENCES [dbo].[TB_COMPETENCIAS] ([CD_COMPETENCIA])
GO
ALTER TABLE [dbo].[TB_COMPETENCIAS_EXAMENES]  WITH CHECK ADD FOREIGN KEY([CD_EXAMEN])
REFERENCES [dbo].[TB_EXAMENES] ([CD_EXAMEN])
GO
ALTER TABLE [dbo].[TB_EXAMENES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_EXAMENES]  WITH CHECK ADD FOREIGN KEY([CD_TIPO])
REFERENCES [dbo].[TB_TIPO_EXAMEN] ([CD_TIPO])
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_HORARIO])
REFERENCES [dbo].[TB_HORARIOS] ([CD_HORARIO])
GO
ALTER TABLE [dbo].[TB_MATERIAS]  WITH CHECK ADD FOREIGN KEY([CD_CARRERA])
REFERENCES [dbo].[TB_CARRERAS] ([CD_CARRERA])
GO
ALTER TABLE [dbo].[TB_PROFESORES_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_PROFESORES_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_PROFESOR])
REFERENCES [dbo].[TB_PROFESORES] ([CD_PROFESOR])
GO
ALTER TABLE [dbo].[TB_PROFESORES_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_ROL_PROFESOR])
REFERENCES [dbo].[TB_ROL_PROFESORES] ([CD_ROL_PROFESOR])
GO
ALTER TABLE [dbo].[TB_HORARIOS]  WITH CHECK ADD CHECK  (([DIA_SEMANA]>=(0) AND [DIA_SEMANA]<=(6)))
GO
ALTER TABLE [dbo].[TB_MATERIAS]  WITH CHECK ADD CHECK  (([CUATRIMESTRE]=(2) OR [CUATRIMESTRE]=(1) OR [CUATRIMESTRE]=(0)))
GO
