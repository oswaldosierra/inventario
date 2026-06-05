using System.Runtime.InteropServices;
using Inventario.Factories;
using Inventario.Infrastructure;
using Inventario.Models;
using Inventario.Repositories;

namespace Inventario.Services;

public class InventarioService
{
  private readonly InMemoryProductoRepository _repository;
  private readonly JsonInventarioStorage _storage;
  private readonly string _rutaInventario;

  public InventarioService(string rutaInventario = "inventario.json")
  {
    _repository = new InMemoryProductoRepository();
    _storage = new JsonInventarioStorage();
    _rutaInventario = rutaInventario;

    CargarInventario();
  }

  public void CargarInventario()
  {
    if (File.Exists(_rutaInventario))
    {
      var productos = _storage.Cargar(_rutaInventario);
      foreach (var producto in productos)
      {
        _repository.Agregar(producto);
      }
    }
  }

  public void AgregarProducto(string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
  {
    var producto = ProductoFactory.Create(nombre, precio, cantidad, categoria);
    _repository.Agregar(producto);
    _Persistir();
  }

  public IEnumerable<Producto> ObtenerTodosLosProdustos()
  {
    return _repository.ObtenerTodos();
  }

  public Producto? ObtenerProductoPorId(int id)
  {
    return _repository.ObtenerPorId(id);
  }

  public void ActualizarProducto(int id, string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
  {
    var producto = _repository.ObtenerPorId(id);
    if (producto == null) return;

    producto.Nombre = nombre;
    producto.Precio = precio;
    producto.Cantidad = cantidad;
    producto.Categoria = categoria;
    _repository.Actualizar(producto);
    _Persistir();
  }

  public void EliminarProducto(int id)
  {
    _repository.Eliminar(id);
    _Persistir();
  }

  public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
  {
    return _repository.BuscarPorCategoria(categoria);
  }

  public IEnumerable<Producto> BuscarPorNombre(string nombre)
  {
    return _repository.BuscarPorNombre(nombre);
  }

  public IEnumerable<Producto> ObtenerProductosBajoStock()
  {
    return _repository.ObtenerStockBajo();
  }

  public decimal ObtenerValorTotalInventario()
  {
    return _repository.ObtenerValorTotalInventario();
  }

  public decimal ObtenerPrecioPromedio()
  {
    return _repository.ObtenerPrecioPromedio();
  }

  public Producto? ObtenerProductoMasCaro()
  {
    return _repository.ObtenerProductoMasCaro();
  }

  // Reportes

  public string GenerarResumen()
  {
    var productos = _repository.ObtenerTodos();
    var generador = new GeneradorReportes(productos);
    return generador.GenerarResumen();
  }

  public string GenerarReporteStockBajo(int minimo = 5)
  {
    var productos = _repository.ObtenerTodos();
    var generador = new GeneradorReportes(productos);
    return generador.GenerarReporteStockajo(minimo);
  }

  public string GenerarTopProductos(int cantidad = 5)
  {
    var productos = _repository.ObtenerTodos();
    var generador = new GeneradorReportes(productos);
    return generador.GenerarTopProductos(cantidad);
  }

  public string ExportarCsv()
  {
    var productos = _repository.ObtenerTodos();
    var generador = new GeneradorReportes(productos);
    return generador.ExportarCsv();
  }

  public void _Persistir()
  {
    _storage.CrearBackup(_rutaInventario);
    var productos = _repository.ObtenerTodos().ToList();
    _storage.Guardar(productos, _rutaInventario);
  }
}