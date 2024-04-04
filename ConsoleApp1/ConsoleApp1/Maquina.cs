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

        public void ComprarProducto()
        {
            Console.WriteLine("Escribe el ID del producto:");
            int Id = int.Parse(Console.ReadLine());

            foreach (Producto c in ListaProductos)
            { 
                if (c.Id == Id)
                {
                    Console.WriteLine("Cual es el metodo de pago deseado: 1.Efectivo  2.Targeta ");
                    int option = int.Parse(Console.ReadLine());

                    switch(option) 
                    {
                        case 1:
                            PagoEfectivo NuevoPagoConEfectivo = new PagoEfectivo();
                            NuevoPagoConEfectivo.PagarConEfectivo(ListaProductos, c);
                            break;

                        case 2:
                            PagoTarjeta NuevoPagoConTarjeta = new PagoTarjeta();
                            NuevoPagoConTarjeta.PagoConTarjeta(ListaProductos, c);
                            break;
                    
                    }
                    break;
                }
            }
        }


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
                    productoPrecioso.NuevoProducto(ListaProductos);
                    ListaProductos.Add(productoPrecioso);
                    break;

                case 2:
                    ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio();
                    productoAlimenticio.NuevoProducto(ListaProductos);
                    ListaProductos.Add(productoAlimenticio);
                    break;

                case 3:
                    ProductoElectronico productoElectronico = new ProductoElectronico();
                    productoElectronico.NuevoProducto(ListaProductos);
                    ListaProductos.Add(productoElectronico);
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta, pulse una tecla para continuar");
                    break;
            }
        }

        public void ListarPreciosos()
        {
            Console.WriteLine("---------------------Productos preciosos--------------------");
            Console.WriteLine();
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoPrecioso)
                {
                    Console.WriteLine(p.MostrarUnElemento());
                }
            }
        }

        public void ListarElectronico()
        {
            Console.WriteLine("---------------------Productos electrónicos--------------------");
            Console.WriteLine();
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoElectronico)
                {
                    Console.WriteLine(p.MostrarUnElemento());
                }
            }
        }

        public void ListarAlimenticios()
        {
            Console.WriteLine("---------------------Productos alimenticios--------------------");
            Console.WriteLine();
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoAlimenticio)
                {
                    Console.WriteLine(p.MostrarUnElemento());
                }
            }
        }
    }
}
