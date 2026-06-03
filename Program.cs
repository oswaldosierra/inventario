// ==================================================
// SISTEMA DE INVENTARIO
// Estado: Estructura profesional configurada
// ==================================================


using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

Console.WriteLine("==============================================");
Console.WriteLine("SISTEMA DE INVENTARIO");
Console.WriteLine("==============================================");
Console.WriteLine($"Plataforma: {Environment.OSVersion}");
Console.WriteLine($"Versión: {version}");
Console.WriteLine($".NET Versión: {Environment.Version}");
Console.WriteLine("");
