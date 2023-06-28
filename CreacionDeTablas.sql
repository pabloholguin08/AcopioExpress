CREATE DATABASE AcopioExpressDB

Use AcopioExpressDB

Create TABLE Login(
	idLogin INT IDENTITY(1,1) NOT NULL,
	usuario VARCHAR(50) NOT NULL,
	password varchar(50) NOT NULL,
	id_Acopio INT NOT NULL,
	id_Rol INT not null,
	FOREIGN KEY (id_Rol) REFERENCES Rol_User(idRol),
	FOREIGN KEY (id_Acopio) REFERENCES Acopio(idAcopio),
	PRIMARY KEY(idLogin)

);


CREATE TABLE Rol_User(
	idRol INT IDENTITY(1,1) not null,
	nombreRol VARCHAR(20) not null CHECK(nombreRol IN('ADMINISTRADOR','EMPLEADO','PRODUCTOR')),
	PRIMARY KEY (idRol)
);


CREATE TABLE Acopio(
	idAcopio INT IDENTITY(1,1) not null,
	nombreAcopi VARCHAR(50) not null,
	ubicacion VARCHAR(50) not null,
	cantidadEmpleados INT not null,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idAcopio)
);

CREATE TABLE TipoProducto(
	idTipoProducto INT IDENTITY(1,1) not null,
	tipoProducto VARCHAR(50) not null,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idTipoProducto)
);


CREATE TABLE Persona(
	idPersona INT IDENTITY(1,1) not null,
	cedula VARCHAR(12) not null,
	nombres VARCHAR(50) not null,
	apellidos VARCHAR(50) not null,
	telefono VARCHAR(25) not null,
	direccion VARCHAR(50) not null,
	id_Acopio INT not null,
	id_TipoProducto INT not null,
	id_Rol INT not null,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idPersona),
	FOREIGN KEY (id_Rol) REFERENCES Rol_User(idRol),
	FOREIGN KEY (id_Acopio) REFERENCES Acopio(idAcopio),
	FOREIGN KEY (id_TipoProducto) REFERENCES TipoProducto(idTipoProducto)
);



CREATE TABLE Produccion(
	idProduccion INT IDENTITY (1,1) not null,
	diaIngresoProducto DATE DEFAULT GETDATE() not null,
	cantidad INT not null,
	precioProducto INT not null,
	observaciones VARCHAR(150) not null,
	valorProducto as (cantidad * precioProducto ),
	id_Persona INT not null,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idProduccion),
	FOREIGN KEY (id_Persona) REFERENCES Persona(idPersona)
);




CREATE TABLE Insumo(
	idInsumo INT IDENTITY (1,1) not null,
	nombreInsumo VARCHAR(50) not null,
	descripcion TEXT not null,
	valorUnitarioVenta INT not null,
	stock INT not null,
	valorTotalInsumosV as (valorUnitarioVenta * stock),
	valorUnitarioCompra INT NOT NULL,
	valorTotalUCompra  as (valorUnitarioCompra * stock),
	gananciaUnitaria INT,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idInsumo)
);


CREATE TABLE TipoPago(
 idTipoPago INT IDENTITY(1,1) NOT NULL,
 nombreTipoProducto VARCHAR(50) NOT NULL,
 PRIMARY KEY(idTipoPago)
)


CREATE TABLE VentaInsumo(
	idVentaInsumo INT IDENTITY (1000,1) not null,
	id_Persona INT not null,
	id_tipoPago INT,
	observacion VARCHAR(150) not null,
	fechaRegistro datetime default getdate(),
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idVentaInsumo),
	FOREIGN KEY (id_Persona) REFERENCES Persona(idPersona),
	FOREIGN KEY (id_tipoPago) REFERENCES TipoPago(idTipoPago)
);

CREATE TABLE DetalleVentaInsumo(
	idDetalleVentaInsumo INT IDENTITY (1,1) not null,
	id_Insumo INT not null,
	id_VentaInsumo INT not null,
	cantidad INT not null,
	precio INT NOT NULL,
	totalVentaInsumo BIGINT,
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idDetalleVentaInsumo),
	FOREIGN KEY (id_Insumo) REFERENCES Insumo(idInsumo)	,
	FOREIGN KEY (id_VentaInsumo) REFERENCES VentaInsumo(idVentaInsumo)
	
);



CREATE TABLE VentaProduccion(
	idVentaProduccion INT IDENTITY(1000,1) not null,
	id_Acopio INT not null,
	fechaVenta DATE DEFAULT GETDATE() not null,
	cantidad INT not null,
	precio decimal(10,2),
	totalVentaProduccion as (cantidad * precio),
	observaciones VARCHAR(250),
	estado INT NOT NULL DEFAULT 1,
	PRIMARY KEY (idVentaProduccion),
	FOREIGN KEY (id_Acopio) REFERENCES Acopio(idAcopio),
);


CREATE TABLE Bodega(
	idBodega INT IDENTITY(1,1) NOT NULL,
	cantidadAlmacenada INT NOT NULL,
	estado INT NOT NULL DEFAULT 1
)


CREATE TABLE Nomina(
	idNomina INT IDENTITY(1,1) not null,
	id_Persona  INT not null,
	salario DECIMAL not null,
	fechaPago DATE DEFAULT GETDATE() not null,
	PRIMARY KEY (idNomina),
	FOREIGN KEY (id_Persona) REFERENCES Persona(idPersona)
);

CREATE TABLE LiquidacionProductor(
	idLiquidacion INT IDENTITY(1,1) NOT NULL,
	fechaLiquidacion DATE DEFAULT GETDATE() not null,
	totalProduccion BIGINT NOT NULL,
	totalInsumos INT NOT NULL,
	TotalPagar AS(totalProduccion - totalInsumos),
	id_persona INT NOT NULL,
	PRIMARY KEY(idLiquidacion),
	FOREIGN KEY (id_Persona) REFERENCES Persona(idPersona)

);

CREATE TABLE EgresosAcopio(
	idEgresosAcopio INT IDENTITY(1,1) NOT NULL,
	id_acopio INT NOT NULL,
	arriendo BIGINT NOT NULL,
	sumatoriaNominas INT NOT NULL,
	servicios INT NOT NULL,
	sumatoriaLiquidacion INT NOT NULL, 
	gastosExtras INT NOT NULL,
	TotalEgresos BIGINT NOT NULL,
	fechaInicailEgresos DATE not null,
	fechaFinalIngresosEgresos DATE  not null,
	PRIMARY KEY (idEgresosAcopio),
	FOREIGN KEY (id_acopio) REFERENCES Acopio(idAcopio)
)

CREATE TABLE IngresosAcopio(
	idIngresosAcopio INT IDENTITY(1,1) NOT NULL,
	id_acopio INT NOT NULL,
	totalGananciaInsumos INT NOT NULL,
	TotalGananciaProduccion INT NOT NULL,
	fechaInicailIngresos DATE not null,
	fechaFinalIngresosLiquidacion DATE  not null,
	TotalIngresos BIGINT NOT NULL,
	PRIMARY KEY(idIngresosAcopio),
	FOREIGN KEY (id_acopio) REFERENCES Acopio(idAcopio)
)



insert into Rol_User(nombreRol) VALUES('ADMINISTRADOR');
insert into Rol_User(nombreRol) VALUES('EMPLEADO');
insert into Rol_User(nombreRol) VALUES('PRODUCTOR');

insert into TipoPago(nombreTipoProducto) VALUES('CONTADO');
insert into TipoPago(nombreTipoProducto) VALUES('FIADO');

insert into TipoProducto(tipoProducto) VALUES('LECHE');



insert into Login(usuario,password,id_Acopio,id_Rol) VALUES('admin','admin',1,2);
insert into Login(usuario,password,id_Acopio,id_Rol) VALUES('emple','emple',1,2);

insert into Acopio(nombreAcopi,ubicacion,cantidadEmpleados,estado) VALUES('AcopiMilk','Valdivia',1,1);



select * from DetalleVentaInsumo

select * from insumo

select * from VentaInsumo