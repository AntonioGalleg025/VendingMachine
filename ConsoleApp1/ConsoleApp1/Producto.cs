using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Producto
    {

        public Producto() { }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Unidades { get; set; }

        public double Precio { get; set; }

        public string Descripcion { get; set; }

        public Producto(int id, string nombre, int unidades, double precio, string descripcion)
        {
            Nombre = nombre;
            Unidades = unidades;
            Precio = precio;
            Descripcion = descripcion;
            Id = id;
        }

        public virtual void NuevoProducto(List<Producto> ListaProductos) {
            
            Console.WriteLine("---------------------Vamos a agregar un producto--------------------");
            Id = ListaProductos.Count() + 1;
            Console.WriteLine("\nIntroduce el nombre de su producto: ");
            Nombre = Console.ReadLine();
            Console.WriteLine("\nIntroduce el numero de unidades del producto: ");
            Unidades = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCual es el precio por unidad del producto?: ");
            Precio = double.Parse(Console.ReadLine());
            Console.WriteLine("\nIntroduce una breve descripcion del producto: ");
            Descripcion = Console.ReadLine();
        }

        public virtual string MostrarDetalles()
        {
            return $"({Id}) Nombre: {Nombre}\n\tUNidades disponibles: {Unidades}\n\tPrecio: {Precio} euros" +
                $"\n\tDescripción: {Descripcion}";
        }

        public virtual string MostrarUnElemento()
        {
            return $"({Id} Nombre: {Nombre})\n\t Unidades disponibles :{Unidades}\n\tPrecio: {Precio} euros";
        }
    }
}
