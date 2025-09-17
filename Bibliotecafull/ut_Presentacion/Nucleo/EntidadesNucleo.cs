using BibliotecaFull.Dominio.Entidades;

namespace BibliotecaFull.Test.Nucleo
{
    public static class EntidadesNucleo
    {
        public static Autores CrearAutor() => new Autores
        {
            Nombre = "Autor Test",
            Apellido = "Apellido",
            FechaNacimiento = DateTime.Now.AddYears(-40),
            Nacionalidad = "Colombiana",
            Biografia = "Bio de prueba"
        };

        public static Categorias CrearCategoria() => new Categorias
        {
            Nombre = "Categoría Test",
            Descripcion = "Descripción de prueba"
        };

        public static Editoriales CrearEditorial() => new Editoriales
        {
            Nombre = "Editorial Test",
            Direccion = "Calle 123",
            Telefono = "300000000",
            Email = "editorial@test.com",
            Pais = 1
        };

        public static Idiomas CrearIdioma() => new Idiomas
        {
            Nombre = "Español Test"
        };

        public static Paises CrearPais() => new Paises
        {
            Nombre = "País Test"
        };

        public static Ciudades CrearCiudad() => new Ciudades
        {
            Nombre = "Ciudad Test",
            Pais = 1
        };

        public static Sucursales CrearSucursal() => new Sucursales
        {
            Nombre = "Sucursal Test",
            Direccion = "Av Test",
            Ciudad = 1,
            Telefono = "311111111"
        };

        public static Cargos CrearCargo() => new Cargos
        {
            Nombre = "Cargo Test"
        };

        public static Empleados CrearEmpleado() => new Empleados
        {
            Nombre = "Empleado Test",
            Identificacion = "EMP123",
            Telefono = "322222222",
            Email = "empleado@test.com",
            Cargo = 1,
            Sucursal = 1
        };

        public static Miembros CrearMiembro() => new Miembros
        {
            Nombre = "Miembro Test",
            Identificacion = "MI123",
            Direccion = "Calle Test",
            Telefono = "333333333",
            Email = "miembro@test.com",
            FechaRegistro = DateTime.Now
        };

        public static Libros CrearLibro() => new Libros
        {
            Titulo = "Libro Test",
            ISBN = "ISBN-TEST",
            Autor = 1,
            Categoria = 1,
            Editorial = 1,
            Idioma = 1,
            AnoPublicacion = 2024,
            CopiasDisponibles = 5,
            Paginas = 250
        };

        public static Prestamos CrearPrestamo() => new Prestamos
        {
            Libro = 1,
            Miembro = 1,
            FechaPrestamo = DateTime.Now,
            Estado = "Prestado"
        };

        public static Reservas CrearReserva() => new Reservas
        {
            Libro = 1,
            Miembro = 1,
            FechaReserva = DateTime.Now,
            Estado = "Activa"
        };

        public static Multas CrearMulta() => new Multas
        {
            Miembro = 1,
            Prestamo = 1,
            Monto = 10.50m,
            FechaImpuesta = DateTime.Now,
            Pagada = false
        };

        public static Pagos CrearPago() => new Pagos
        {
            Multa = 1,
            FechaPago = DateTime.Now,
            Monto = 10.50m,
            MetodoPago = "Efectivo"
        };
    }
}
