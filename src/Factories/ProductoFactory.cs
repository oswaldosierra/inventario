namespace Inventario.Factories;

using Inventario.Models;

public static class ProductoFactory
{
  private static int _nextId = 1;

  public static Producto Create(string nombre, decimal precio, int cantidad, CategoriaProducto categoria = CategoriaProducto.Otros)
  {

    if (string.IsNullOrWhiteSpace(nombre))
    {
      throw new ArgumentException("El nombre del producto no puede estar vacío.");
    }

    if (precio < 0)
    {
      throw new ArgumentException("El precio del producto no puede ser negativo.");
    }

    if (cantidad < 0)
    {
      throw new ArgumentException("La cantidad del producto no puede ser negativa.");
    }

    var producto = new Producto
    {
      Id = _nextId++,
      Nombre = nombre,
      Precio = precio,
      Cantidad = cantidad,
      Categoria = categoria
    };
    return producto;
  }

  public static Producto CrearConStock(string nombre, decimal precio, int cantidad)
  {
    if (cantidad <= 0)
    {
      throw new ArgumentException("La cantidad del producto no puede ser cero o negativa.");
    }
    return Create(nombre, precio, cantidad);
  }
}