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
USE [GONZALEZ_JUAN_DB]
GO
/****** Object:  Table [dbo].[TB_ALUMNOS]    Script Date: 28/7/2019 17:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALUMNOS](
	[CD_ALUMNO] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[TB_ALUMNOS_CARRERAS]    Script Date: 28/7/2019 17:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALUMNOS_CARRERAS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_ALUMNO] [int] NOT NULL,
	[CD_CARRERA] [smallint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ALUMNOS_COMISIONES]    Script Date: 28/7/2019 17:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALUMNOS_COMISIONES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[CD_ALUMNO] [int] NOT NULL,
	[CD_ESTADO] [tinyint] NOT NULL,
	[NOTA] [tinyint] NULL,
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
/****** Object:  Table [dbo].[TB_CARRERAS]    Script Date: 28/7/2019 17:37:22 ******/
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
/****** Object:  Table [dbo].[TB_COMISIONES]    Script Date: 28/7/2019 17:37:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMISIONES](
	[CD_COMISION] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_MATERIA] [int] NOT NULL,
	[A�O] [int] NOT NULL,
	[CUATRIMESTRE] [tinyint] NULL,
	[CD_TURNO] [tinyint] NOT NULL,
	[CD_MODALIDAD] [tinyint] NOT NULL,
	[CD_PROFESOR] [int] NOT NULL,
	[CD_AYUDANTE] [int] NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_COMISION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ESTADOS_MATERIA]    Script Date: 28/7/2019 17:37:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ESTADOS_MATERIA](
	[CD_ESTADO] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_ESTADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_HORARIOS]    Script Date: 28/7/2019 17:37:23 ******/
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
/****** Object:  Table [dbo].[TB_HORARIOS_COMISIONES]    Script Date: 28/7/2019 17:37:23 ******/
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
/****** Object:  Table [dbo].[TB_INSCRIPCIONES]    Script Date: 28/7/2019 17:37:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_INSCRIPCIONES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[A�O] [int] NOT NULL,
	[CUATRIMESTRE] [tinyint] NULL,
	[FECHA_APERTURA] [date] NOT NULL,
	[FECHA_CIERRE] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[A�O] ASC,
	[CUATRIMESTRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_INSTANCIAS]    Script Date: 28/7/2019 17:37:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_INSTANCIAS](
	[CD_INSTANCIA] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_COMISION] [bigint] NOT NULL,
	[NOMBRE] [varchar](30) NOT NULL,
	[CD_TIPO] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_INSTANCIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MATERIAS]    Script Date: 28/7/2019 17:37:23 ******/
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
/****** Object:  Table [dbo].[TB_MATERIAS_CORRELATIVAS]    Script Date: 28/7/2019 17:37:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MATERIAS_CORRELATIVAS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_MATERIA] [int] NOT NULL,
	[CD_MATERIA_REQUERIDA] [int] NOT NULL,
	[CD_ESTADO_REQUERIDO] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MODALIDADES]    Script Date: 28/7/2019 17:37:24 ******/
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
/****** Object:  Table [dbo].[TB_NOTAS_ALUMNOS_INSTANCIAS]    Script Date: 28/7/2019 17:37:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NOTAS_ALUMNOS_INSTANCIAS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_ALUMNO] [int] NOT NULL,
	[CD_INSTANCIA] [bigint] NOT NULL,
	[NOTA] [varchar](40) NOT NULL,
	[COMENTARIOS] [varchar](300) NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PROFESORES]    Script Date: 28/7/2019 17:37:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PROFESORES](
	[CD_PROFESOR] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[TB_TIPO_INSTANCIAS]    Script Date: 28/7/2019 17:37:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_INSTANCIAS](
	[CD_TIPO] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPOS_USUARIO]    Script Date: 28/7/2019 17:37:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPOS_USUARIO](
	[CD_TIPO] [tinyint] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NOMBRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TURNOS]    Script Date: 28/7/2019 17:37:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TURNOS](
	[CD_TURNO] [tinyint] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_TURNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DESCRIPCION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIOS]    Script Date: 28/7/2019 17:37:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIOS](
	[CD_USUARIO] [bigint] IDENTITY(1,1) NOT NULL,
	[NOMBRE_USUARIO] [varchar](30) NOT NULL,
	[CONTRASE�A] [varchar](32) NOT NULL,
	[TIPO_USUARIO] [tinyint] NOT NULL,
	[DESHABILITADO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CD_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIOS_ALUMNOS]    Script Date: 28/7/2019 17:37:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIOS_ALUMNOS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_USUARIO] [bigint] NOT NULL,
	[CD_ALUMNO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIOS_PROFESORES]    Script Date: 28/7/2019 17:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIOS_PROFESORES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CD_USUARIO] [bigint] NOT NULL,
	[CD_PROFESOR] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_ALUMNOS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ALUMNOS_CARRERAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_CARRERAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_HORARIOS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_INSTANCIAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_MATERIAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_MATERIAS_CORRELATIVAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_MODALIDADES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_NOTAS_ALUMNOS_INSTANCIAS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_PROFESORES] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_USUARIOS] ADD  DEFAULT ((0)) FOR [DESHABILITADO]
GO
ALTER TABLE [dbo].[TB_ALUMNOS_CARRERAS]  WITH CHECK ADD FOREIGN KEY([CD_ALUMNO])
REFERENCES [dbo].[TB_ALUMNOS] ([CD_ALUMNO])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_CARRERAS]  WITH CHECK ADD FOREIGN KEY([CD_CARRERA])
REFERENCES [dbo].[TB_CARRERAS] ([CD_CARRERA])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_ALUMNO])
REFERENCES [dbo].[TB_ALUMNOS] ([CD_ALUMNO])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_ALUMNOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_ESTADO])
REFERENCES [dbo].[TB_ESTADOS_MATERIA] ([CD_ESTADO])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_AYUDANTE])
REFERENCES [dbo].[TB_PROFESORES] ([CD_PROFESOR])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_MATERIA])
REFERENCES [dbo].[TB_MATERIAS] ([CD_MATERIA])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_MODALIDAD])
REFERENCES [dbo].[TB_MODALIDADES] ([CD_MODALIDAD])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_PROFESOR])
REFERENCES [dbo].[TB_PROFESORES] ([CD_PROFESOR])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_TURNO])
REFERENCES [dbo].[TB_TURNOS] ([CD_TURNO])
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_HORARIOS_COMISIONES]  WITH CHECK ADD FOREIGN KEY([CD_HORARIO])
REFERENCES [dbo].[TB_HORARIOS] ([CD_HORARIO])
GO
ALTER TABLE [dbo].[TB_INSTANCIAS]  WITH CHECK ADD FOREIGN KEY([CD_COMISION])
REFERENCES [dbo].[TB_COMISIONES] ([CD_COMISION])
GO
ALTER TABLE [dbo].[TB_INSTANCIAS]  WITH CHECK ADD FOREIGN KEY([CD_TIPO])
REFERENCES [dbo].[TB_TIPO_INSTANCIAS] ([CD_TIPO])
GO
ALTER TABLE [dbo].[TB_MATERIAS]  WITH CHECK ADD FOREIGN KEY([CD_CARRERA])
REFERENCES [dbo].[TB_CARRERAS] ([CD_CARRERA])
GO
ALTER TABLE [dbo].[TB_MATERIAS_CORRELATIVAS]  WITH CHECK ADD FOREIGN KEY([CD_ESTADO_REQUERIDO])
REFERENCES [dbo].[TB_ESTADOS_MATERIA] ([CD_ESTADO])
GO
ALTER TABLE [dbo].[TB_MATERIAS_CORRELATIVAS]  WITH CHECK ADD FOREIGN KEY([CD_MATERIA])
REFERENCES [dbo].[TB_MATERIAS] ([CD_MATERIA])
GO
ALTER TABLE [dbo].[TB_MATERIAS_CORRELATIVAS]  WITH CHECK ADD FOREIGN KEY([CD_MATERIA_REQUERIDA])
REFERENCES [dbo].[TB_MATERIAS] ([CD_MATERIA])
GO
ALTER TABLE [dbo].[TB_NOTAS_ALUMNOS_INSTANCIAS]  WITH CHECK ADD FOREIGN KEY([CD_ALUMNO])
REFERENCES [dbo].[TB_ALUMNOS] ([CD_ALUMNO])
GO
ALTER TABLE [dbo].[TB_NOTAS_ALUMNOS_INSTANCIAS]  WITH CHECK ADD FOREIGN KEY([CD_INSTANCIA])
REFERENCES [dbo].[TB_INSTANCIAS] ([CD_INSTANCIA])
GO
ALTER TABLE [dbo].[TB_USUARIOS]  WITH CHECK ADD FOREIGN KEY([TIPO_USUARIO])
REFERENCES [dbo].[TB_TIPOS_USUARIO] ([CD_TIPO])
GO
ALTER TABLE [dbo].[TB_USUARIOS_ALUMNOS]  WITH CHECK ADD FOREIGN KEY([CD_ALUMNO])
REFERENCES [dbo].[TB_ALUMNOS] ([CD_ALUMNO])
GO
ALTER TABLE [dbo].[TB_USUARIOS_ALUMNOS]  WITH CHECK ADD FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIOS] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIOS_PROFESORES]  WITH CHECK ADD FOREIGN KEY([CD_PROFESOR])
REFERENCES [dbo].[TB_PROFESORES] ([CD_PROFESOR])
GO
ALTER TABLE [dbo].[TB_USUARIOS_PROFESORES]  WITH CHECK ADD FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIOS] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_COMISIONES]  WITH CHECK ADD CHECK  (([CD_PROFESOR]<>[CD_AYUDANTE]))
GO
ALTER TABLE [dbo].[TB_HORARIOS]  WITH CHECK ADD CHECK  (([DIA_SEMANA]>=(0) AND [DIA_SEMANA]<=(6)))
GO
ALTER TABLE [dbo].[TB_INSCRIPCIONES]  WITH CHECK ADD CHECK  (([CUATRIMESTRE]=(2) OR [CUATRIMESTRE]=(1) OR [CUATRIMESTRE]=(0)))
GO
ALTER TABLE [dbo].[TB_INSCRIPCIONES]  WITH CHECK ADD CHECK  (([FECHA_APERTURA]<[FECHA_CIERRE]))
GO
ALTER TABLE [dbo].[TB_MATERIAS]  WITH CHECK ADD CHECK  (([CUATRIMESTRE]=(2) OR [CUATRIMESTRE]=(1) OR [CUATRIMESTRE]=(0)))
GO
ALTER TABLE [dbo].[TB_MATERIAS_CORRELATIVAS]  WITH CHECK ADD CHECK  (([CD_MATERIA]<>[CD_MATERIA_REQUERIDA]))
GO
/****** Object:  StoredProcedure [dbo].[SP_COMISIONES_ACTUALES_POR_MATERIA]    Script Date: 28/7/2019 17:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_COMISIONES_ACTUALES_POR_MATERIA]
(
	@p_materia_id int
)
AS
BEGIN

	Select 
		* 
	from 
		TB_COMISIONES
	where 
		CD_MATERIA = @p_materia_id
		and ISNULL(CUATRIMESTRE, 0) in (
			select ISNULL(CUATRIMESTRE, 0)
			from TB_INSCRIPCIONES
			where GETDATE() between FECHA_APERTURA and FECHA_CIERRE
		)
		and A�O = YEAR(GETDATE())

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_USUARIOS_BY_DNI]    Script Date: 28/7/2019 17:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GET_USUARIOS_BY_DNI]
(
	@p_DNI varchar(20)
)
AS
BEGIN

	SELECT U.*
	FROM TB_USUARIOS U
	inner join TB_USUARIOS_ALUMNOS UA on UA.CD_USUARIO = U.CD_USUARIO
	inner join TB_ALUMNOS A on UA.CD_ALUMNO = A.CD_ALUMNO
	WHERE A.DNI = @p_DNI AND U.DESHABILITADO = 0 AND A.DESHABILITADO = 0
	Union
	SELECT U.*
	FROM TB_USUARIOS U
	inner join TB_USUARIOS_PROFESORES UP on UP.CD_USUARIO = U.CD_USUARIO
	inner join TB_PROFESORES P on UP.CD_PROFESOR = P.CD_PROFESOR
	WHERE P.DNI = @p_DNI AND U.DESHABILITADO = 0 AND P.DESHABILITADO = 0

END
GO

SET DATEFORMAT 'DMY'
GO
INSERT INTO TB_ALUMNOS([DNI],[APELLIDO],[NOMBRE],[FECHA_NAC]) 
VALUES('21038082','Cort�s','Barbara','28/10/2002'),('27359796','D�az','Valery','26/10/1986'),('26652880','Campos','Byron','20/11/2002'),('31716175','Aravena','Carola','18/05/1976'),('46801494','Campos','Lisandro','22/08/1986'),('19500090','Z��iga','Valentino','02/10/1999'),('9956302','P�rez','Jeremias','02/09/1987'),('28881980','Ortiz','Apolo','12/02/1986'),('34256892','Godoy','Tiare','10/01/1984'),('14450247','Guti�rrez','Johao','14/03/1982');
GO
INSERT INTO TB_PROFESORES([DNI],[APELLIDO],[NOMBRE],[FECHA_NAC],[FECHA_INGRESO]) 
VALUES('33356640','Reyes','Leslie','06/10/1978','08/02/2010'),('36781528','Araya','Jos�','09/03/2002','18/12/2016'),('13589075','Vergara','Eileen','04/04/1981','03/06/2019'),('19994302','Herrera','Nathalia','17/06/2002','18/05/2017'),('49159926','Venegas','Luis','25/11/1983','26/12/2000'),('23103885','Venegas','Leyla','26/02/1990','31/03/2005'),('32317618','Maldonado','Nabih','16/01/2000','23/04/2002'),('20361392','Garc�a','Johann','14/03/1990','29/02/2004'),('18061646','Salazar','Adri�n','17/01/1986','04/06/2009'),('36637574','Bravo','Monserrath','01/07/1971','27/05/2018');
GO

INSERT INTO TB_CARRERAS (NOMBRE, NOMBRE_CORTO, DURACION)
VALUES ('Tecnicatura Universitaria en Programaci�n', 'TUP', 2), 
	   ('Tecnicatura Universitaria en Sistemas Inform�ticos', 'TUSI', 1)
GO

INSERT INTO TB_MATERIAS (NOMBRE, CD_CARRERA, A�O, CUATRIMESTRE)
VALUES ('Sistemas de Procesamiento de Datos', 1, 1, 1), ('Programaci�n I', 1, 1, 1), ('Matem�tica', 1, 1, 1), ('Ingl�s I', 1, 1, 1), ('Laboratorio de Computaci�n I', 1, 1, 1), 
	   ('Programaci�n II', 1, 1, 2), ('Estad�stica', 1, 1, 2), ('Arquitectura y Sistemas Operativos', 1, 1, 2), ('Laboratorio de Computaci�n II', 1, 1, 2), ('Ingl�s II', 1, 1, 2), ('Metodolog�a de la Investigaci�n', 1, 1, 2),
	   ('Laboratorio de Computaci�n III', 1, 2, 1), ('Organizaci�n Empresarial', 1, 2, 1), ('Organizaci�n Contable de la Empresa', 1, 2, 1), ('Elementos de Investigaci�n Operativa', 1, 2, 1), ('Programaci�n III', 1, 2, 1), ('Pr�ctica Profesional', 1, 2, 1),
	   ('Legislaci�n', 1, 2, 2), ('Dise�o y Administraci�n de Bases de Datos', 1, 2, 2), ('Metodolog�a de Sistemas I', 1, 2, 2), ('Laboratorio de Computaci�n IV', 1, 2, 2)
GO
INSERT INTO TB_MATERIAS (NOMBRE, CD_CARRERA, A�O, CUATRIMESTRE)
VALUES ('Matem�tica II', 2, 1, 1), ('Ingl�s Avanzado I', 2, 1, 1), ('Base de Datos II', 2, 1, 1), ('Programaci�n Avanzada I', 2, 1, 1), ('Laboratorio V', 2, 1, 1), ('Metodolog�a de Sistemas II', 2, 1, 1), ('Redes', 2, 1, 1), ('Pr�ctica Profesional', 2, 1, 1),
	   ('Matem�tica III', 2, 1, 2), ('Ingl�s Avanzado II', 2, 1, 2), ('Investigaci�n Operativa II', 2, 1, 2), ('Programaci�n Avanzada II', 2, 1, 2), ('Metodolog�a de Sistemas III', 2, 1, 2), ('Administraci�n y Direcci�n de Proyectos', 2, 1, 2), ('Seminario', 2, 1, 2)
GO

INSERT INTO TB_ESTADOS_MATERIA (DESCRIPCION)
VALUES ('Aprobada'), ('Regularizada'), ('Cursando'), ('Recursada'), ('Abandonada')
GO
INSERT INTO TB_MODALIDADES (DESCRIPCION)
values ('Presencial'), ('Semi presencial'), ('A distancia')


INSERT INTO TB_TIPOS_USUARIO
VALUES ('Estudiante'), ('Docente'), ('Administrador')
GO
INSERT INTO TB_USUARIOS
VALUES ('admin', 'admin', 3, 0)
GO

INSERT INTO TB_TURNOS	
VALUES ('Ma�ana'), ('Tarde'), ('Noche')
GO

INSERT INTO TB_TIPO_INSTANCIAS
VALUES('1 a 10'), ('Aprobado/Desaprobado')
GO