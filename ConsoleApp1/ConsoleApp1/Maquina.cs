using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Maquina
    {
        public List<Producto> ListaProductos = new List<Producto>();

        public Maquina() { }

        public void AniadirProducto() {

            Console.WriteLine("1-Nuevo producto precioso");
            Console.WriteLine("2-Nuevo producto alimenticio");
            Console.WriteLine("3-Nuevo producto electronico");
            Console.WriteLine("Introduce el producto que quieres agregar: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    ProductoPrecioso productoPrecioso = new ProductoPrecioso();
                    productoPrecioso.NuevoProducto();
                    ListaProductos.Add(productoPrecioso);
                    break;

                case 2:
                    ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio();
                    productoAlimenticio.NuevoProducto();
                    ListaProductos.Add(productoAlimenticio);
                    break;

                case 3:
                    ProductoElectronico productoElectronico = new ProductoElectronico();
                    productoElectronico.NuevoProducto();
                    ListaProductos.Add(productoElectronico);
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta, pulse una tecla para continuar");
                    break;
            }
        }
    }
}
