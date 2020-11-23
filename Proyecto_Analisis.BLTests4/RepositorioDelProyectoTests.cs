using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Proyecto_Analisis.BL;
using Proyecto_Analisis.DA;
using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Analisis.BL.Tests
{
    [TestClass()]
    public class RepositorioDelProyectoTests
    {
        Persona persona;
        Producto producto;
        Factura factura;
        DetalleFactura detalleFactura;
        

        public void inicializarPersona()
        {
            persona = new Persona();
            persona.ID = 1;
            persona.PrimerNombre = "Juan";
            persona.SegundoNombre = "Carlos";
            persona.PrimerApellido = "Rodríguez";
            persona.SegundoNombre = "Roríguez";
            persona.CorreoElectronico = "jcarlos@gmail.com";
            persona.Pais = "Costa Rica";
            persona.Provincia = "Guanacaste";
            persona.Canton = "Carillo";
            persona.Distrito = "Bélen";
        }

        public void inicializarProducto()
        {
            producto = new Producto();
            producto.ID_Producto = 1;
            producto.Nombre = "Tomates";
            producto.Detalle = "Sabemas";
            producto.PrecioUnitario = 1000;
            producto.Cantidad = 10;
        }

        public void inicializarFactura()
        {
            factura = new Factura();
            factura.CodigoFactura = 1;
            factura.FechaEmision = DateTime.Now;
            factura.MontoTotal = 1000;
            factura.NombreComercial = "Pali";
        }

        public void inicializarDetalleFactura()
        {
            inicializarPersona();
            inicializarProducto();
            inicializarFactura();
            detalleFactura = new DetalleFactura();
            detalleFactura.ID_DetalleFactura = 1;
            detalleFactura.ID_Persona = persona.ID;
            detalleFactura.ID_Producto = producto.ID_Producto;
            detalleFactura.CodigoFactura = factura.CodigoFactura;
        }

        [TestMethod()]
        public void AgregarClienteTest()
        {
            inicializarPersona();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();
            mockRepositorioDelProyecto.Setup(x => x.AgregarCliente(persona));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosClientes()).Returns(new List<Persona>() { new Persona() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosClientes();
            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void FinalizarFacturaTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void actualizarClienteTest()
        {
            inicializarPersona();
            Persona personaAcomparar = persona;
            personaAcomparar.PrimerApellido = "L.";
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarCliente(persona));
            mockRepositorioDelProyecto.Setup(y => y.actualizarCliente(personaAcomparar));
            mockRepositorioDelProyecto.Setup(w => w.ObtenerPorId(persona.ID)).Returns(new Persona());
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);

            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerPorId(persona.ID);

            Assert.AreNotEqual(resultadoDelTest.PrimerApellido, "Rodríguez", false);
        }

        [TestMethod()]
        public void ObtenerPorIdTest()
        {
            inicializarPersona();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarCliente(persona));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerPorId(persona.ID)).Returns(new Persona());
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);

            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerPorId(persona.ID);

            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerProductosDeFacturaTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void EliminarClienteTest()
        {
            inicializarPersona();
            Persona personaSegunda = persona;
            personaSegunda.ID = 2;
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarCliente(persona));
            mockRepositorioDelProyecto.Setup(z => z.AgregarCliente(personaSegunda));
            mockRepositorioDelProyecto.Setup(x => x.EliminarCliente(persona));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosClientes()).Returns(new List<Persona>() { new Persona() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosClientes();
            Assert.IsTrue(resultadoDelTest.Count() == 1);
            //Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void AgregarProductoTest()
        {
            inicializarProducto();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();
            mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosArticulos()).Returns(new List<Producto>() { new Producto() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosArticulos();
            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void AgregarFacturaTest()
        {
            inicializarFactura();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();
            mockRepositorioDelProyecto.Setup(x => x.AgregarFactura(factura));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodasLasFacturas()).Returns(new List<Factura>() { new Factura() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodasLasFacturas();
            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerFacturaPorIDTest()
        {
            inicializarFactura();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarFactura(factura));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerFacturaPorID(factura.CodigoFactura)).Returns(new Factura());
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);

            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerFacturaPorID(factura.CodigoFactura);

            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerClienteDeFacturaTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ObtenerFacturasVaciasTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ObtenerFacturasFinalizadasTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AgregarDetalleDeFacturaTest()
        {
        }

        [TestMethod()]
        public void EditarProductoTest()
        {
            inicializarProducto();
            Producto productoAcomparar = producto;
            productoAcomparar.Nombre = "Papas";
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            mockRepositorioDelProyecto.Setup(y => y.EditarProducto(productoAcomparar));
            mockRepositorioDelProyecto.Setup(w => w.ObtenerProductoPorId(producto.ID_Producto)).Returns(new Producto());
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);

            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerProductoPorId(producto.ID_Producto);

            Assert.AreNotEqual(resultadoDelTest.Nombre, "Tomate", false);
        }

        [TestMethod()]
        public void DecrementarCantidadDeProductoTest()
        {
            //inicializarProducto();
            //var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            //var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            //mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            //mockRepositorioDelProyecto.Setup(y => y.DecrementarCantidadDeProducto(producto.ID_Producto));
            //mockRepositorioDelProyecto.Setup(w => w.ObtenerProductoPorId(producto.ID_Producto)).Returns(new Producto());
            //RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockRepositorioDelProyecto.Object);

            //var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerProductoPorId(producto.ID_Producto);

            //Assert.IsTrue(producto.Cantidad == 10);
        }

        [TestMethod()]
        public void ObtenerProductoPorIdTest()
        {
            inicializarProducto();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerProductoPorId(producto.ID_Producto)).Returns(new Producto());
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);

            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerProductoPorId(producto.ID_Producto);

            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerTodasLasFacturasTest()
        {
            inicializarFactura();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();
            mockRepositorioDelProyecto.Setup(x => x.AgregarFactura(factura));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodasLasFacturas()).Returns(new List<Factura>() { new Factura() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodasLasFacturas();
            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerTodosLosArticulosTest()
        {
            inicializarProducto();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosArticulos()).Returns(new List<Producto>() { new Producto() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosArticulos();

            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void ObtenerArticulosDisponiblesTest()
        {
            inicializarProducto();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();
        }

        [TestMethod()]
        public void ObtenerTodosLosClientesTest()
        {
            inicializarPersona();
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarCliente(persona));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosClientes()).Returns(new List<Persona>() { new Persona() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosClientes();

            Assert.IsNotNull(resultadoDelTest);
        }

        [TestMethod()]
        public void EliminarProductoTest()
        {
            inicializarProducto();
            Producto productoSegundo = producto;
            productoSegundo.ID_Producto = 2;
            var mockContextoDeLaBaseDeDatos = new Mock<ContextoDeBaseDeDatos>();
            var mockRepositorioDelProyecto = new Mock<IRepositorioDelProyecto>();

            mockRepositorioDelProyecto.Setup(x => x.AgregarProducto(producto));
            mockRepositorioDelProyecto.Setup(z => z.AgregarProducto(productoSegundo));
            mockRepositorioDelProyecto.Setup(x => x.EditarProducto(producto));
            mockRepositorioDelProyecto.Setup(y => y.ObtenerTodosLosArticulos()).Returns(new List<Producto>() { new Producto() });
            RepositorioDelProyecto repositorioDelProyecto = new RepositorioDelProyecto(mockContextoDeLaBaseDeDatos.Object);
            var resultadoDelTest = mockRepositorioDelProyecto.Object.ObtenerTodosLosArticulos();
            Assert.IsTrue(resultadoDelTest.Count() == 1);

        }
    }
}