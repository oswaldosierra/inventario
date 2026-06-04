// ==================================================
// SISTEMA DE INVENTARIO
// Estado: Estructura profesional configurada
// ==================================================

using Inventario.Factories;
using Inventario.Models;
using Inventario.Repositories;

Console.WriteLine("====================== InventarioApp====================");

var repository = new InMemoryProductoRepository();

Producto laptop = ProductoFactory.Create(nombre: "Laptop Dell XPS 13", precio: 1200, cantidad: 5, CategoriaProducto.Electronica);
Producto mouse = ProductoFactory.Create(nombre: "Mouse Logitech MX Master", precio: 99, cantidad: 20, CategoriaProducto.Electronica);
Producto teclado = ProductoFactory.Create(nombre: "Teclado Mecánico", precio: 150, cantidad: 3, CategoriaProducto.Electronica);
Producto silla = ProductoFactory.Create(nombre: "Silla Ergonómica Herman Miller", precio: 500, cantidad: 8, CategoriaProducto.Muebles);
Producto escritorio = ProductoFactory.Create(nombre: "Escritorio Stand-up", precio: 300, cantidad: 2, CategoriaProducto.Muebles);

repository.Agregar(laptop);
repository.Agregar(mouse);
repository.Agregar(teclado);
repository.Agregar(silla);
repository.Agregar(escritorio);

Console.WriteLine($"Productos agregados: {repository.Cantidad}");

IEnumerable<Producto> electronicos = repository.BuscarPorCategoria(CategoriaProducto.Electronica);
Console.WriteLine($"Productos electronicos: {electronicos.Count()}");

foreach (Producto producto in electronicos)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<Producto> conMouse = repository.BuscarPorNombre("mouse");
Console.WriteLine($"\nProductos con mouse: {conMouse.Count()}");

foreach (Producto producto in conMouse)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<string> nombres = repository.ObtenerNombres();
Console.WriteLine($"\nTodos los nombres de los productos: {string.Join(", ", nombres)}");

bool hayStockBajo = repository.HayStockBajo();
Console.WriteLine($"\nHay stock bajo: {hayStockBajo}");


// ==================================================
// using System.Reflection;

// var assembly = Assembly.GetExecutingAssembly();
// var version = assembly.GetName().Version;

// if (args.Length > 0)
// {
//   switch (args[0].ToLower())
//   {
//     case "--help":
//     case "-h":
//       MostrarAyuda();
//       Environment.Exit(0);
//       break;
//     case "--version":
//     case "-v":
//       Console.WriteLine($"Versión: {version}");
//       Environment.Exit(0);
//       break;
//     default:
//       Console.WriteLine("Comando no reconocido. Use --help para obtener ayuda.");
//       Environment.Exit(1);
//       break;
//   }
// }

// int cantidadProductos = 0;
// decimal valorTotalInventario = 0.0m;
// bool sistemaActivo = true;
// string nombreSistema = "Sistema de gestión de inventario";

// MostrarBanner();

// EstadoSistema();

// while (sistemaActivo)
// {
//   MostrarMenu();

//   string? entrada = Console.ReadLine();

//   string comando = entrada?.ToLower() ?? "salir";

//   switch (comando)
//   {
//     case "salir":
//       Console.WriteLine("Saliendo del programa...");
//       sistemaActivo = false;
//       break;

//     case "agregar":
//       AgregarProducto();
//       break;

//     case "listar":
//       ListarProductos();
//       break;

//     default:
//       Console.WriteLine("Comando no reconocido. Use 'listar' para ver el estado o 'salir' para terminar.");
//       break;
//   }
// }

// // Funciones auxiliares

// void MostrarMenu()
// {
//   Console.WriteLine();
//   Console.WriteLine("Seleccione una opción:");
//   Console.WriteLine("1. Listar productos (escriba 'listar')");
//   Console.WriteLine("2. Agregar producto (escriba 'agregar')");
//   Console.WriteLine("3. Salir (escriba 'salir')");
//   Console.Write("Opción: ");
// }

// void ListarProductos()
// {
//   Console.WriteLine("Listado de productos:");
//   Console.WriteLine($"- Cantidad total: {cantidadProductos}");
//   Console.WriteLine($"- Valor total del inventario: {valorTotalInventario:N2}");
// }

// void AgregarProducto()
// {
//   Console.WriteLine("Ingrese la cantidada de productos: ");
//   string input = Console.ReadLine();

//   if (int.TryParse(input, out int cantidad))
//   {
//     Console.WriteLine($"Cantidad ingresada: {cantidad}");
//     cantidadProductos += cantidad;
//   }
//   else
//   {
//     Console.WriteLine("Entrada no válida para cantidad.");
//   }


//   Console.WriteLine("Ingrese el precio unitario: ");
//   string? inputPrecio = Console.ReadLine();

//   if (decimal.TryParse(inputPrecio, out decimal precioIngresado))
//   {
//     Console.WriteLine($"Precio ingresado: {precioIngresado:C}");
//     valorTotalInventario += precioIngresado * cantidadProductos;

//     Console.WriteLine($"Valor total actualizado del inventario: {valorTotalInventario:N2}");
//   }
//   else
//   {
//     Console.WriteLine("Entrada no válida para precio.");
//   }
// }

// void BuscarProducto(string nombre)
// {
//   Console.WriteLine($"Buscando producto: {nombre}");
//   // Aquí se implementaría la lógica de búsqueda en un sistema real
//   Console.WriteLine("Producto no encontrado (función de búsqueda no implementada).");
// }

// void MostrarBanner()
// {
//   Console.WriteLine("==============================================");
//   Console.WriteLine("=============SISTEMA DE INVENTARIO============");
//   Console.WriteLine("==============================================");
//   Console.WriteLine($"Plataforma:   {Environment.OSVersion}");
//   Console.WriteLine($"Versión:      {version}");
//   Console.WriteLine($".NET Versión: {Environment.Version}");
//   Console.WriteLine("");
// }

// void MostrarAyuda()
// {
//   Console.WriteLine("USO: InventarioApp [comando] [opciones]");
//   Console.WriteLine();
//   Console.WriteLine("COMANDOS:");
//   Console.WriteLine("  --help, -h      Muestra esta ayuda");
//   Console.WriteLine("  --version, -v   Muestra la version del programa");
//   Console.WriteLine();
//   Console.WriteLine("EJEMPLOS:");
//   Console.WriteLine(" dotnet run -- --help");
//   Console.WriteLine(" dotnet run -- --version");
// }

// void EstadoSistema()
// {
//   Console.WriteLine("==============================================");
//   Console.WriteLine("=============ESTADO DEL SISTEMA===============");
//   Console.WriteLine("==============================================");
//   Console.WriteLine($"Nombre:                     {nombreSistema}");
//   Console.WriteLine($"Productos registrados:      {cantidadProductos}");
//   Console.WriteLine($"Valor total del inventario: {valorTotalInventario:N2}");
//   Console.WriteLine($"Sistema activo:             {(sistemaActivo ? "Sí" : "No")}");
//   Console.WriteLine("");
// }