using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Producto
    {
        // Constructor
        public Producto() { }
        // Propiedades
        public int Id { get; set; }
        public string TipoProducto { get; set; }
        public string Nombre_producto { get; set; }
        public int Unidades_producto { get; set; }

        public double Precio_unidad_producto { get; set; }

        public string descripción_del_producto { get; set; }

        public Producto(int id, string nombre, int unidades, double precio, string descripcion)
        {
            Nombre_producto = nombre;
            Unidades_producto = unidades;
            Precio_unidad_producto = precio;
            descripción_del_producto = descripcion;
            Id = id;
        }

        public virtual void NuevoProducto(List<Producto> ListaProductos) 
        {            
            Console.WriteLine("---------------------Vamos a agregar un producto--------------------");
            Id = ListaProductos.Count() + 1;
            Console.WriteLine("\nIntroduce el nombre de su producto: ");
            Nombre_producto = Console.ReadLine();
            Console.WriteLine("\nIntroduce el numero de unidades del producto: ");
            Unidades_producto = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCual es el precio por unidad del producto?: ");
            Precio_unidad_producto = double.Parse(Console.ReadLine());
            Console.WriteLine("\nIntroduce una breve descripcion del producto: ");
            descripción_del_producto = Console.ReadLine();
        }

        public virtual string MostrarDetalles()
        {
            return $"({Nombre_producto}) Nombre: {Nombre_producto} \n\tUnidades disponibles: {Unidades_producto} \n\tPrecio: {Precio_unidad_producto} euros " +
                $"\n\tDescripción: {descripción_del_producto}";
        }

        public virtual string MostrarUnElemento()
        {
            return $"({Id}) Nombre: {Nombre_producto}\n\tUnidades disponibles: {Unidades_producto}\n\tPrecio: {Precio_unidad_producto} euros";
        }
    }
}
