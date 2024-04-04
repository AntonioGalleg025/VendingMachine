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

        /*tipo_producto: Indica la categoría del producto, con 1 para materiales preciosos, 2 para
        productos alimenticios y 3 para productos electrónicos. Esta clasificación ayuda a la correcta
        asignación de productos dentro de la máquina expendedora. */

        //donde esta esto ??

        public int Nombre_producto { get; set; }

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
            Nombre_producto = id;
        }

        public virtual void NuevoProducto(List<Producto> ListaProductos) {
            
            Console.WriteLine("---------------------Vamos a agregar un producto--------------------");
            Nombre_producto = ListaProductos.Count() + 1;
            Console.WriteLine("\nIntroduce el nombre de su producto: ");
            Nombre = Console.ReadLine();
            Console.WriteLine("\nIntroduce el numero de unidades del producto: ");
            Unidades_producto = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCual es el precio por unidad del producto?: ");
            Precio_unidad_producto = double.Parse(Console.ReadLine());
            Console.WriteLine("\nIntroduce una breve descripcion del producto: ");
            descripción_del_producto = Console.ReadLine();
        }

        public virtual string MostrarDetalles()
        {
            return $"({Nombre_producto}) Nombre: {Nombre} \n\tUnidades disponibles: {Unidades_producto} \n\tPrecio: {Precio_unidad_producto} euros " +
                $"\n\tDescripción: {descripción_del_producto}";
        }

        public virtual string MostrarUnElemento()
        {
            return $"({Id}) Nombre: {Nombre}\n\tUnidades disponibles: {Unidades}\n\tPrecio: {Precio} euros";
        }
    }
}
