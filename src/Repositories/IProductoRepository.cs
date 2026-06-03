using Inventario.Models;

namespace Inventario.Repositories;

public interface IProductoRepository
{
  void Agregar(Producto producto);
  Producto? ObtenerPorId(int id);
  IEnumerable<Producto> ObtenerTodos();
  bool Actualizar(Producto producto);
  bool Eliminar(int id);
  int Cantidad { get; }
}