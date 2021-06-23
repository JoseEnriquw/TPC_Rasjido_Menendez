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
Precio money not null check(Precio >0),
UrlImg varchar(200) not null
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

insert into Cargo values ('Gerente'),('Gerente'),('Empleado'),('Empleado')
insert into Persona values (1,'11222333','Adriel','Rasjido'),(2,'11222444','Jose','Menendez'),(3,'11222555','Elian','Rasjido'),(4,'11222666','Enrique','Menendez')
insert into Usuario values ('11222333','11222333'),('11222444','11222444'),('11222555','11222555'),('11222666','11222666')
insert into Categorias values ('Plato'),('Bebida')
insert into Insumo values 
('Chorizo criollo'	,1,'entrada','almuerzo'		,1600,'https://decarolis.com.ar/wp-content/uploads/2020/07/12-chorizo-de-cerdo.jpg'),
('Provoleta'		,1,'entrada','cena'			,490,'http://thebrandsoup.com/wp-content/uploads/2018/07/provoleta2.jpg'),
('Ensalada Cesar'	,1,'ensalada','almuerzo'	,450,'https://cdn.kiwilimon.com/recetaimagen/36391/45060.jpg'),
('Ensalada caprese'	,1,'ensalada','cena'		,450,'https://okdiario.com/img/2016/11/26/receta-de-ensalada-caprese.jpg'),
('Papas fritas'		,1,'entrada','almuerzo'		,110,'https://www.bbva.com/wp-content/uploads/2019/08/Dia_internacional_de_la_papa_frita_BBVA_opt-1024x559.png'),
('Fussilli'		,1,'principal','almuerzo'	,1400,'http://www.superama.com.mx/views/micrositio/recetas/images/verano/fusilli/Web_fotoreceta.jpg'),
('Ravioles'		,1,'principal','cena'		,1400,'https://www.cocinavital.mx/wp-content/uploads/2017/10/ravioles-en-salsa-de-pimienta-1-e1549472181921.jpg'),
('Asado'		,1,'principal','almuerzo'	,1800,'https://www.recetaspanama.com/base/stock/Recipe/119-image/119-image_web.jpg'),
('Entraña'		,1,'principal','cena'		,1200,'https://canalcocina.es/medias/_cache/zoom-27a5946fbd2cacb92cf8f791f8149489-920-518.jpg'),
('Churrasco'		,1,'principal','almuerzo'	,1400,'https://cdn2.cocinadelirante.com/sites/default/files/styles/gallerie/public/el-churrasco-que-es-corte.jpg'),

('Matambre'		,1,'principal','cena'		,1200,'https://media.minutouno.com/p/756403023543082f7f63deba6587acac/adjuntos/150/imagenes/038/377/0038377613/540x405/smart/como-hacer-un-matambre-relleno.jpg'),
('Licuado'		,2,'postre','merienda'		,320,'https://cdn.kiwilimon.com/recetaimagen/20093/23942.jpg'),
('Panqueque'		,1,'postre','desayuno'		,460,'https://cocina.guru/wp-content/uploads/2019/10/receta-de-panqueques.jpg'),
('Helado'		,1,'postre','almuerzo'		,620,'https://i.blogs.es/098b7c/helados1/1366_2000.jpg'),
('Creme brulee'		,1,'postre','cena'		,720,'https://i.blogs.es/2d3efb/creme-brulee-kitchen-aid-como-preparar/840_560.jpg'),
('Vaso de agua'		,2,'agua','almuerzo'		,55,'https://cdn2.cocinadelirante.com/sites/default/files/styles/gallerie/public/images/2017/06/istock-471488514.jpg'),
('Gaseosa'		,2,'gaseosa','almuerzo'		,120,'https://www.somoselagua.com.ar/blog/img/novedades/106.jpg'),
('Jugo de naranja'	,2,'Jugo','desayuno'		,85,'https://easyrecetas.com/wp-content/uploads/2020/04/Receta-de-Jugo-de-Naranja.jpg'),
('Cerveza'		,2,'alcohol','cena'		,270,'https://thefoodtech.com/wp-content/uploads/2020/05/cerveza-1.jpg'),
('Vino'			,2,'alcohol','cena'		,720,'https://www.65ymas.com/uploads/s1/21/56/6/bigstock-wine-glass-wine-bottle-and-gr-239880082.jpeg')
insert into Stock values
(1,20),(2,30),(3,50),(4,60),(5,50),(6,100),(7,50),(8,50),(9,100),(10,70),
(11,80),(12,20),(13,20),(14,50),(15,20),(16,20),(17,50),(18,20),(19,70),(20,50)