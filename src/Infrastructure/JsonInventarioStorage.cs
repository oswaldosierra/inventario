using System.Text.Json;
using System.Text.Json.Serialization;
using Inventario.Models;

namespace Inventario.Infrastructure;

public class JsonInventarioStorage
{
  private readonly Filemanager _filemanager;
  private readonly JsonSerializerOptions _options;

  public JsonInventarioStorage()
  {
    _filemanager = new Filemanager();
    _options = new JsonSerializerOptions
    { 
      WriteIndented=true,
      PropertyNamingPolicy=JsonNamingPolicy.CamelCase,
      Converters={new JsonStringEnumConverter()}
    };
  }

  public void Guardar(List<Producto> productos, string ruta)
  {
    string json = JsonSerializer.Serialize(productos, _options);
    _filemanager.Escribir(ruta, json);
  }

  public List<Producto> Cargar(string ruta)
  {
    string json = _filemanager.Leer(ruta);
    return JsonSerializer.Deserialize<List<Producto>>(json, _options) ?? new List<Producto>();
  }

  public string? CrearBackup(string ruta)
  {
    if (!_filemanager.Existe(ruta))
    {
      return null;
    }

    string directorio = Path.GetDirectoryName(ruta);
    string nombreSinExtension = Path.GetFileNameWithoutExtension(ruta);
    string extencion = Path.GetExtension(ruta);
    string timestamp = DateTime.Now.ToString("yyyy-MM-DD_HH-mm-ss");

    string rutaBackup = Path.Combine(
      directorio ?? ".",
      $"{nombreSinExtension}_backup_{timestamp}{extencion}"
    );

    File.Copy(ruta,rutaBackup);
    return rutaBackup;
  }
}