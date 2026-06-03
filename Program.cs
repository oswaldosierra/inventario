// ==================================================
// SISTEMA DE INVENTARIO
// Estado: Estructura profesional configurada
// ==================================================


using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

if (args.Length > 0)
{
  switch (args[0].ToLower())
  {
    case "--help":
    case "-h":
      MostrarAyuda();
      Environment.Exit(0);
      break;
    case "--version":
    case "-v":
      Console.WriteLine($"Versión: {version}");
      Environment.Exit(0);
      break;
    default:
      Console.WriteLine("Comando no reconocido. Use --help para obtener ayuda.");
      Environment.Exit(1);
      break;
  }
}

int cantidadProductos = 0;
decimal valorTotalInventario = 0.0m;
bool sistemaActivo = true;
string nombreSistema = "Sistema de gestión de inventario";

MostrarBanner();

EstadoSistema();

Console.WriteLine("Ingrese una cantidad: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int cantidad))
{
  Console.WriteLine($"Cantidad ingresada: {cantidad}");
  cantidadProductos += cantidad;
}
else
{
  Console.WriteLine("Entrada no válida para cantidad.");
}


Console.WriteLine("Ingrese un precio: ");
string? inputPrecio = Console.ReadLine();

if (decimal.TryParse(inputPrecio, out decimal precioIngresado))
{
  Console.WriteLine($"Precio ingresado: {precioIngresado:C}");
  valorTotalInventario += precioIngresado * cantidadProductos;

  Console.WriteLine($"Valor total actualizado del inventario: {valorTotalInventario:N2}");
}
else
{
  Console.WriteLine("Entrada no válida para precio.");
}

while (sistemaActivo)
{
  Console.Write("Ingrese un comando (o 'salir' para terminar): ");

  string? entrada = Console.ReadLine();

  string comando = entrada?.ToLower() ?? "salir";

  switch (comando)
  {
    case "salir":
      Console.WriteLine("Saliendo del programa...");
      sistemaActivo = false;
      break;

    case "listar":
      Console.WriteLine($"Productos registrados: {cantidadProductos}");
      break;

    default:
      Console.WriteLine("Comando no reconocido. Use 'listar' para ver el estado o 'salir' para terminar.");
      break;
  }
}

void MostrarBanner()
{
  Console.WriteLine("==============================================");
  Console.WriteLine("=============SISTEMA DE INVENTARIO============");
  Console.WriteLine("==============================================");
  Console.WriteLine($"Plataforma:   {Environment.OSVersion}");
  Console.WriteLine($"Versión:      {version}");
  Console.WriteLine($".NET Versión: {Environment.Version}");
  Console.WriteLine("");
}


void MostrarAyuda()
{
  Console.WriteLine("USO: InventarioApp [comando] [opciones]");
  Console.WriteLine();
  Console.WriteLine("COMANDOS:");
  Console.WriteLine("  --help, -h      Muestra esta ayuda");
  Console.WriteLine("  --version, -v   Muestra la version del programa");
  Console.WriteLine();
  Console.WriteLine("EJEMPLOS:");
  Console.WriteLine(" dotnet run -- --help");
  Console.WriteLine(" dotnet run -- --version");
}

void EstadoSistema()
{
  Console.WriteLine("==============================================");
  Console.WriteLine("=============ESTADO DEL SISTEMA===============");
  Console.WriteLine("==============================================");
  Console.WriteLine($"Nombre:                     {nombreSistema}");
  Console.WriteLine($"Productos registrados:      {cantidadProductos}");
  Console.WriteLine($"Valor total del inventario: {valorTotalInventario:N2}");
  Console.WriteLine($"Sistema activo:             {(sistemaActivo ? "Sí" : "No")}");
  Console.WriteLine("");
}