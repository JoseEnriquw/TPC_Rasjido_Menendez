create database TPC_Rasjido_Menendez_DB
go

use TPC_Rasjido_Menendez_DB
go

create table Cargos(
ID  int not null primary key identity(1,1),
Descripcion varchar(10) not null check(Descripcion='Empleado' or Descripcion='Gerente')
)
go

create table Personas(
ID  int not null primary key identity(1,1),
IDCargo int not null foreign key references Cargos(ID),
DNI varchar(8) not null unique,
Nombre varchar(30) not null,
Apellido varchar(30) not null
)
go

create table Usuarios(
ID  int not null primary key identity(1,1),
DNI varchar(8) not null foreign key references Personas(DNI),
Contrase�a varchar(15) not null check (len([Contrase�a])>=(8)),
)
go

create table Categorias(
ID int not null primary key identity(1,1),
Descripcion varchar(25) not null, 
)
go

create table TipoInsumos(
ID int not null primary key identity(1,1),
Descripcion varchar(25) not null, 
)
go

create table Insumos(
ID  int not null primary key identity(1,1),
Nombre varchar(30) not null,
IDCategoria int not null foreign key references Categorias(ID),
IDTipo int not null foreign key references TipoInsumos(ID),
Precio money not null check(Precio >0),
Stock smallint not null check(Stock >0),
UrlImg varchar(200) not null
)
go



create table Mesas(
ID  int not null primary key identity(1,1),
IDMesero int not null foreign key references Personas(ID),

)
go


create table Pedidos(
ID  int not null primary key identity(1,1),
IDMesa int not null foreign key references Mesas(ID),
PrecioTotal money not null check(PrecioTotal >0),
FechaHora Datetime not null

)
go

create table ItemsPedido(
ID  int not null primary key identity(1,1),
Pedido int not null foreign key references Pedidos(ID),
IDInsumo int not null foreign key references Insumos(ID),
PrecioSubTotal money not null check(PrecioSubTotal >0),
Cantidad smallint not null check(Cantidad >0)

)
go

Create View VW_Insumos as
select I.ID,Nombre,IDCategoria,C.Descripcion as Categoria,IDTipo,T.Descripcion as Tipo,Precio,Stock,UrlImg from Insumos I
inner join TipoInsumos T on T.ID=I.IDTipo
inner join Categorias C on C.ID=I.IDCategoria
go
Create View VW_Personas as
select P.ID,P.IDCargo,C.Descripcion as Cargo,P.DNI,P.Nombre,P.Apellido from Personas P inner join Cargos C on C.ID=P.IDCargo
go

create table historial(
ID int not null primary key identity(1,1),
IdMesero int not null foreign key references Personas(ID),
total money not null check(total >0),
fechaHora datetime not null
)
go

create Trigger TR_Verificar_Mesero on Mesas
After insert
as
begin 
 
 declare @ID int
 declare @Cargo varchar(20)

 select @ID=IDMesero from inserted
 select @Cargo=Cargo from VW_Personas where ID=@ID

 if @Cargo!='Empleado' begin
 rollback transaction
 raiserror('Error!El ID que se ingres� no pertenece a un Mesero',16,1)
 end

end
go


select *from VW_Personas
select * from VW_Insumos order by Precio asc
select * from TipoInsumos
SELECT * from Categorias



insert into Cargos values ('Gerente'),('Empleado')
insert into Personas values (1,'11222333','Adriel','Rasjido'),(2,'11222444','Jose','Menendez'),(1,'11222555','Elian','Rasjido'),(2,'11222666','Enrique','Menendez')
insert into Mesas values (2),(2),(2),(2),(2),(2),(2),(2),(2)
insert into Usuarios values ('11222333','11222333'),('11222444','11222444'),('11222555','11222555'),('11222666','11222666')
insert into Categorias values ('Plato'),('Bebida')
insert into TipoInsumos values ('Entrada'),('Ensalada'),('Principal'),('Postre'),('Jugo'),('Alcohol'),('Gaseosa'),('Agua')
insert into Insumos values 
('Chorizo criollo'	,  1,   1,  1600,  20,'https://decarolis.com.ar/wp-content/uploads/2020/07/12-chorizo-de-cerdo.jpg'),
('Provoleta'		    ,  1,   1,  490,   30,'http://thebrandsoup.com/wp-content/uploads/2018/07/provoleta2.jpg'),
('Ensalada Cesar'	    ,  1,   2,  450,   50,'https://cdn.kiwilimon.com/recetaimagen/36391/45060.jpg'),
('Ensalada caprese'	,  1,   2,  450,   60,'https://okdiario.com/img/2016/11/26/receta-de-ensalada-caprese.jpg'),
('Papas fritas'		,  1,   2,  110,   50,'https://www.bbva.com/wp-content/uploads/2019/08/Dia_internacional_de_la_papa_frita_BBVA_opt-1024x559.png'),
('Fussilli'		    ,  1,   3,  1400,  100,'http://www.superama.com.mx/views/micrositio/recetas/images/verano/fusilli/Web_fotoreceta.jpg'),
('Ravioles'		    ,  1,   3,  1400,  50,'https://www.cocinavital.mx/wp-content/uploads/2017/10/ravioles-en-salsa-de-pimienta-1-e1549472181921.jpg'),
('Asado'		        ,  1,   3,  1800,  50,'https://www.recetaspanama.com/base/stock/Recipe/119-image/119-image_web.jpg'),
('Entra�a'		    ,  1,   3,  1200,  100,'https://canalcocina.es/medias/_cache/zoom-27a5946fbd2cacb92cf8f791f8149489-920-518.jpg'),
('Churrasco'		    ,  1,   3,	1400,  70,'https://cdn2.cocinadelirante.com/sites/default/files/styles/gallerie/public/el-churrasco-que-es-corte.jpg'),

('Matambre'		    ,  1,   3,	1200,  80,'https://media.minutouno.com/p/756403023543082f7f63deba6587acac/adjuntos/150/imagenes/038/377/0038377613/540x405/smart/como-hacer-un-matambre-relleno.jpg'),
('Licuado'		    ,  2,   4,	320,   20,'https://cdn.kiwilimon.com/recetaimagen/20093/23942.jpg'),
('Panqueque'		    ,  1,   4,  460,   20,'https://cocina.guru/wp-content/uploads/2019/10/receta-de-panqueques.jpg'),
('Helado'		        ,  1,   4,  620,   50,'https://i.blogs.es/098b7c/helados1/1366_2000.jpg'),
('Creme brulee'		,  1,   4,  720,   20,'https://i.blogs.es/2d3efb/creme-brulee-kitchen-aid-como-preparar/840_560.jpg'),
('Vaso de agua'		,  2,   8,  55,    20,'https://cdn2.cocinadelirante.com/sites/default/files/styles/gallerie/public/images/2017/06/istock-471488514.jpg'),
('Gaseosa'		    ,  2,   7,  120,   50,'https://www.somoselagua.com.ar/blog/img/novedades/106.jpg'),
('Jugo de naranja'	,  2,   6,  85,    20,'https://easyrecetas.com/wp-content/uploads/2020/04/Receta-de-Jugo-de-Naranja.jpg'),
('Cerveza'		    ,  2,   5,  270,   70,'https://thefoodtech.com/wp-content/uploads/2020/05/cerveza-1.jpg'),
('Vino'			    ,  2,   5,  720,   50,'https://www.65ymas.com/uploads/s1/21/56/6/bigstock-wine-glass-wine-bottle-and-gr-239880082.jpeg'),
('Coca-Cola'		,  2,   7,  150,   50,'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/15-09-26-RalfR-WLC-0098.jpg/158px-15-09-26-RalfR-WLC-0098.jpg')
