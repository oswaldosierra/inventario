namespace Inventario.Models;

public class Producto
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public decimal Precio { get; set; }
  public int Cantidad { get; set; }
  public CategoriaProducto Categoria { get; set; }
  public EstadoProducto Estado { get; set; }
  public DateTime FechaRegistro { get; set; }
  public decimal Total => Precio * Cantidad;
  public override string ToString()
  {
    return $"Id: {Id}, Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}, Categoria: {Categoria}, Estado: {Estado}, FechaRegistro: {FechaRegistro}, Total: {Total}";
  }
}
