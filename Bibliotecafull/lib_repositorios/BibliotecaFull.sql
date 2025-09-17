
IF DB_ID('BibliotecaFull') IS NULL
    CREATE DATABASE BibliotecaFull;
GO
USE BibliotecaFull;
GO


IF OBJECT_ID('Paises', 'U') IS NOT NULL DROP TABLE Paises;
CREATE TABLE Paises (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL
);
INSERT INTO Paises (Nombre) VALUES
('Colombia'),('Argentina'),('Chile'),('Perú'),('México');

IF OBJECT_ID('Idiomas', 'U') IS NOT NULL DROP TABLE Idiomas;
CREATE TABLE Idiomas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL
);
INSERT INTO Idiomas (Nombre) VALUES
('Español'),('Inglés'),('Francés'),('Alemán'),('Portugués');



IF OBJECT_ID('Cargos', 'U') IS NOT NULL DROP TABLE Cargos;
CREATE TABLE Cargos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL
);
INSERT INTO Cargos (Nombre) VALUES
('Bibliotecario'),('Auxiliar'),('Administrador'),
('Director'),('Recepcionista');



IF OBJECT_ID('Autores', 'U') IS NOT NULL DROP TABLE Autores;
CREATE TABLE Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Apellido VARCHAR(200),
    FechaNacimiento DATE,
    Nacionalidad VARCHAR(200),
    Biografia VARCHAR(500)
);
INSERT INTO Autores (Nombre,Apellido,FechaNacimiento,Nacionalidad,Biografia) VALUES
('Gabriel','García Márquez','1927-03-06','Colombiana','Escritor'),
('Isabel','Allende','1942-08-02','Chilena','Escritora'),
('Jorge Luis','Borges','1899-08-24','Argentina','Escritor'),
('Mario','Vargas Llosa','1936-03-28','Peruana','Escritor'),
('Octavio','Paz','1914-03-31','Mexicana','Poeta');




IF OBJECT_ID('Categorias', 'U') IS NOT NULL DROP TABLE Categorias;
CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Descripcion VARCHAR(500)
);
INSERT INTO Categorias (Nombre,Descripcion) VALUES
('Novela','Novelas literarias'),
('Historia','Libros históricos'),
('Ciencia','Libros científicos'),
('Infantil','Libros para niños'),
('Tecnología','Libros técnicos');




IF OBJECT_ID('Editoriales', 'U') IS NOT NULL DROP TABLE Editoriales;
CREATE TABLE Editoriales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    Pais INT FOREIGN KEY REFERENCES Paises(Id)
);
INSERT INTO Editoriales (Nombre,Direccion,Telefono,Email,Pais) VALUES
('Editorial A','Calle 1','111111','a@editorial.com',1),
('Editorial B','Calle 2','222222','b@editorial.com',2),
('Editorial C','Calle 3','333333','c@editorial.com',3),
('Editorial D','Calle 4','444444','d@editorial.com',4),
('Editorial E','Calle 5','555555','e@editorial.com',5);





IF OBJECT_ID('Ciudades', 'U') IS NOT NULL DROP TABLE Ciudades;
CREATE TABLE Ciudades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Pais INT FOREIGN KEY REFERENCES Paises(Id)
);
INSERT INTO Ciudades (Nombre,Pais) VALUES
('Bogotá',1),('Medellín',1),('Buenos Aires',2),
('Santiago',3),('Lima',4);




IF OBJECT_ID('Sucursales', 'U') IS NOT NULL DROP TABLE Sucursales;
CREATE TABLE Sucursales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Direccion VARCHAR(200),
    Ciudad INT FOREIGN KEY REFERENCES Ciudades(Id),
    Telefono VARCHAR(50)
);
INSERT INTO Sucursales (Nombre,Direccion,Ciudad,Telefono) VALUES
('Central','Av 1',1,'601-111111'),
('Norte','Av 2',2,'601-222222'),
('Sur','Av 3',3,'601-333333'),
('Este','Av 4',4,'601-444444'),
('Oeste','Av 5',5,'601-555555');




IF OBJECT_ID('Miembros', 'U') IS NOT NULL DROP TABLE Miembros;
CREATE TABLE Miembros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Identificacion VARCHAR(50),
    Direccion VARCHAR(200),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    FechaRegistro DATE
);
INSERT INTO Miembros (Nombre,Identificacion,Direccion,Telefono,Email,FechaRegistro) VALUES
('Juan','1001','Calle 1','3001','juan@ex.com','2024-01-01'),
('Ana','1002','Calle 2','3002','ana@ex.com','2024-02-01'),
('Luis','1003','Calle 3','3003','luis@ex.com','2024-03-01'),
('Carla','1004','Calle 4','3004','carla@ex.com','2024-04-01'),
('Pablo','1005','Calle 5','3005','pablo@ex.com','2024-05-01');




IF OBJECT_ID('Libros', 'U') IS NOT NULL DROP TABLE Libros;
CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200),
    ISBN VARCHAR(50),
    Autor INT FOREIGN KEY REFERENCES Autores(Id),
    Categoria INT FOREIGN KEY REFERENCES Categorias(Id),
    Editorial INT FOREIGN KEY REFERENCES Editoriales(Id),
    Idioma INT FOREIGN KEY REFERENCES Idiomas(Id),
    AnoPublicacion INT,
    CopiasDisponibles INT,
    Paginas INT
);
INSERT INTO Libros (Titulo,ISBN,Autor,Categoria,Editorial,Idioma,AnoPublicacion,CopiasDisponibles,Paginas) VALUES
('Cien Años de Soledad','ISBN-1001',1,1,1,1,1967,5,417),
('La Casa de los Espíritus','ISBN-1002',2,1,2,1,1982,3,400),
('Ficciones','ISBN-1003',3,1,3,2,1944,4,256),
('Conversación en la Catedral','ISBN-1004',4,1,4,1,1969,2,500),
('Poemas','ISBN-1005',5,4,5,2,1970,6,200);




IF OBJECT_ID('Empleados', 'U') IS NOT NULL DROP TABLE Empleados;
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(200),
    Identificacion VARCHAR(50),
    Telefono VARCHAR(50),
    Email VARCHAR(100),
    Cargo INT FOREIGN KEY REFERENCES Cargos(Id),
    Sucursal INT FOREIGN KEY REFERENCES Sucursales(Id)
);
INSERT INTO Empleados (Nombre,Identificacion,Telefono,Email,Cargo,Sucursal) VALUES
('Carlos','2001','3111','carlos@ex.com',1,1),
('María','2002','3222','maria@ex.com',2,2),
('Andrés','2003','3333','andres@ex.com',1,3),
('Sofía','2004','3444','sofia@ex.com',3,4),
('Diego','2005','3555','diego@ex.com',4,5);




IF OBJECT_ID('Prestamos', 'U') IS NOT NULL DROP TABLE Prestamos;
CREATE TABLE Prestamos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Libro INT FOREIGN KEY REFERENCES Libros(Id),
    Miembro INT FOREIGN KEY REFERENCES Miembros(Id),
    FechaPrestamo DATE,
    FechaDevolucion DATE,
    Estado VARCHAR(50)
);
INSERT INTO Prestamos (Libro,Miembro,FechaPrestamo,FechaDevolucion,Estado) VALUES
(1,1,'2024-01-10',NULL,'Prestado'),
(2,2,'2024-01-15','2024-01-25','Devuelto'),
(3,3,'2024-02-01',NULL,'Prestado'),
(4,4,'2024-02-10','2024-02-20','Devuelto'),
(5,5,'2024-03-01',NULL,'Prestado');




IF OBJECT_ID('Reservas', 'U') IS NOT NULL DROP TABLE Reservas;
CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Libro INT FOREIGN KEY REFERENCES Libros(Id),
    Miembro INT FOREIGN KEY REFERENCES Miembros(Id),
    FechaReserva DATE,
    Estado VARCHAR(50)
);
INSERT INTO Reservas (Libro,Miembro,FechaReserva,Estado) VALUES
(1,2,'2024-04-01','Activa'),
(2,3,'2024-04-05','Activa'),
(3,4,'2024-04-10','Cancelada'),
(4,5,'2024-04-15','Activa'),
(5,1,'2024-04-20','Activa');




IF OBJECT_ID('Multas', 'U') IS NOT NULL DROP TABLE Multas;
CREATE TABLE Multas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Miembro INT FOREIGN KEY REFERENCES Miembros(Id),
    Prestamo INT FOREIGN KEY REFERENCES Prestamos(Id),
    Monto DECIMAL(10,2),
    FechaImpuesta DATE,
    Pagada BIT
);
INSERT INTO Multas (Miembro,Prestamo,Monto,FechaImpuesta,Pagada) VALUES
(1,2,10.50,'2024-02-01',0),
(2,4,5.00,'2024-03-01',1),
(3,1,20.00,'2024-03-15',0),
(4,3,7.25,'2024-04-01',1),
(5,5,12.00,'2024-04-10',0);




IF OBJECT_ID('Pagos', 'U') IS NOT NULL DROP TABLE Pagos;
CREATE TABLE Pagos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Multa INT FOREIGN KEY REFERENCES Multas(Id),
    FechaPago DATE,
    Monto DECIMAL(10,2),
    MetodoPago VARCHAR(100)
);
INSERT INTO Pagos (Multa,FechaPago,Monto,MetodoPago) VALUES
(1,'2024-02-05',10.50,'Efectivo'),
(2,'2024-03-05',5.00,'Tarjeta'),
(3,'2024-03-20',20.00,'Efectivo'),
(4,'2024-04-05',7.25,'Transferencia'),
(5,'2024-04-15',12.00,'Efectivo');


