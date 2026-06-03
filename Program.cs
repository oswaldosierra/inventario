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


MostrarBanner();

Console.Write("Ingrese un comando (o 'salir' para terminar): ");
string? comando = Console.ReadLine()?.ToLower();

if (string.IsNullOrEmpty(comando) || comando == "salir")
{
  Console.WriteLine("Saliendo del programa...");
  Environment.Exit(0);
}

void MostrarBanner()
{
  Console.WriteLine("SISTEMA DE INVENTARIO");
  Console.WriteLine("==============================================");
  Console.WriteLine($"Plataforma: {Environment.OSVersion}");
  Console.WriteLine($"Versión: {version}");
  Console.WriteLine($".NET Versión: {Environment.Version}");
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