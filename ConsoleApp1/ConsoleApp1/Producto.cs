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

        public string Nombre { get; set; }

        public int Unidades { get; set; }

        public double Precio { get; set; }

        public string Descripcion { get; set; }

        public Producto(string nombre, int unidades, double precio, string descripcion)
        {
            Nombre = nombre;
            Unidades = unidades;
            Precio = precio;
            Descripcion = descripcion;
        }

        public virtual void NuevoProducto() {

            Console.WriteLine("---------------------Vamos a agregar un producto--------------------");
            Console.WriteLine("\nIntroduce el nombre de su producto: ");
            Nombre = Console.ReadLine();
            Console.WriteLine("\nIntroduce el numero de unidades del producto: ");
            Unidades = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCual es el precio por unidad del producto?: ");
            Precio = double.Parse(Console.ReadLine());
            Console.WriteLine("\nIntroduce una breve descripcion del producto: ");
            Descripcion = Console.ReadLine();
        }
    }
}
