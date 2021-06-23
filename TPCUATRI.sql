create database TPC_Rasjido_Menendez_DB
go

use TPC_Rasjido_Menendez_DB
go

create table Cargo(
ID  int not null primary key identity(1,1),
Nombre varchar(8) not null check(Nombre='Empleado' or Nombre='Gerente')
)
go

create table Persona(
ID  int not null primary key identity(1,1),
IDCargo int not null foreign key references Cargo(ID),
DNI varchar(8) not null unique,
Nombre varchar(30) not null,
Apellido varchar(30) not null
)
go

create table Usuario(
ID  int not null primary key identity(1,1),
DNI varchar(8) not null foreign key references Persona(DNI),
Contraseña varchar(15) not null check (len([Contraseña])>=(8)),
)
go

create table Categorias(
ID int not null primary key identity(1,1),
Nombre varchar(25) not null, 
)
go

create table Insumo(
ID  int not null primary key identity(1,1),
Nombre varchar(30) not null,
IDcategoria int not null foreign key references Categorias(ID),
tipo varchar(9) not null check(tipo='agua' or tipo='gaseosa' or tipo='jugo' or tipo='alcohol' or tipo='entrada' or tipo='principal' or tipo='ensalada' or tipo='postre'),
tiempo varchar(8) not null check(tiempo='desayuno' or tiempo='almuerzo' or tiempo='merienda' or tiempo='cena'),
Precio money not null check(Precio >0)
)
go

create table Stock(
ID  int not null primary key identity(1,1),
IDInsumo int not null foreign key references Insumo(ID),
cantidad int not null check(cantidad >=0)
)
go

create table Mesa(
ID  int not null primary key identity(1,1),
IDMesero int not null foreign key references Persona(ID)
)
go

create table Pedido(
ID  int not null primary key identity(1,1),
IDInsumo int not null foreign key references Insumo(ID),
IDMesa int not null foreign key references Mesa(ID),
Precio money not null check(Precio >0),
Cantidad smallint not null check(Cantidad>0),
Estado bit not null default 0
)
go