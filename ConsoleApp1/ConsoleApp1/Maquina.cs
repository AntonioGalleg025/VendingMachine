using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Maquina
    {
        public List<Producto> ListaProductos = new List<Producto>();
        public List<Producto> CarritoCompra = new List<Producto>();
        public int Salir {  get; set; }
        public Maquina() { }
        public double[] Precios { get; set; }

        public void ComprarProducto()
        {
            Precios = new double[100];
            int i = 0;
            do
            { 
                Console.WriteLine("Escribe el ID del producto:");
                int Id = int.Parse(Console.ReadLine());

                foreach (Producto c in ListaProductos)
                {
                    if (c.Id == Id)
                    {
                        CarritoCompra.Add(c);
                        break;
                    }
                }

                Console.WriteLine("Quieres agregar otro producto?: ");
                Salir = int.Parse(Console.ReadLine());

            } while (Salir != 1);

            if(CarritoCompra.Count > 0)
            {
                Console.WriteLine($"Tienes {CarritoCompra.Count} en tu cesta, quiere proceder con el pago?(1 = si || 2 = no): ");
                int opcion = int.Parse(Console.ReadLine());
                if(opcion == 1)
                {
                    foreach(Producto c in CarritoCompra)
                    {
                        foreach(Producto l in ListaProductos)
                        {
                            if(c.Id == l.Id)
                            {
                                if(l.Unidades_producto > 1)
                                {
                                    l.Unidades_producto = l.Unidades_producto - 1;
                                    Precios[i] = l.Precio_unidad_producto;
                                    i++;
                                    break;
                                }
                                else if(l.Unidades_producto == 1) {
                                    
                                    Precios[i] = l.Precio_unidad_producto;
                                    i++;
                                    ListaProductos.Remove(l);
                                    break;
                                }
                            }
                        }
                    }
                    Pagar();
                }
                else if(opcion == 2)
                {
                    CarritoCompra.Clear();
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                }
            }
        }
        public void Pagar()
        {
            Console.WriteLine("Cual es el metodo de pago deseado: 1.Efectivo  2.Tarjeta ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PagoEfectivo NuevoPagoConEfectivo = new PagoEfectivo();
                    NuevoPagoConEfectivo.PagarConEfectivo(Precios);
                    break;

                case 2:
                    PagoTarjeta NuevoPagoConTarjeta = new PagoTarjeta();
                    NuevoPagoConTarjeta.PagoConTarjeta(Precios);
                    break;

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
                    if(ListaProductos.Count >= 12){

                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else{
                        ProductoPrecioso productoPrecioso = new ProductoPrecioso();
                        productoPrecioso.NuevoProducto(ListaProductos);
                        ListaProductos.Add(productoPrecioso);
                    }
                    break;

                case 2:
                    if (ListaProductos.Count >= 12)
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else {
                        ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio();
                        productoAlimenticio.NuevoProducto(ListaProductos);
                        ListaProductos.Add(productoAlimenticio);
                    }
                    break;

                case 3:

                    if (ListaProductos.Count >= 12)
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else
                    {
                        ProductoElectronico productoElectronico = new ProductoElectronico();
                        productoElectronico.NuevoProducto(ListaProductos);
                        ListaProductos.Add(productoElectronico);
                    }
                break;
                    

                default:
                    Console.WriteLine("Opcion incorrecta, pulse una tecla para continuar");
                    break;
            }
        }

        public void ListarTodos()
        {
            
            Console.WriteLine();
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoPrecioso)
                {
                    Console.WriteLine("---------------------Productos preciosos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());

                }else if (p is ProductoElectronico)
                {
                    Console.WriteLine("---------------------Productos electrónicos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());

                }else if (p is ProductoAlimenticio)
                {
                    Console.WriteLine("---------------------Productos alimenticios--------------------");
                    Console.WriteLine(p.MostrarUnElemento());
                }
            }
        }

        public void BuscarProducto()
        {
            ListarTodos();
            /*Pedimos el id del producto que queremos ver detalladamente*/
            Console.WriteLine("\nIntroduce el ID del producto que desea ver: ");
            int id_producto = int.Parse(Console.ReadLine());
            foreach(Producto p in ListaProductos)
            {
                if(id_producto == p.Id)
                {
                    if(p is ProductoPrecioso)
                    {
                        Console.WriteLine(p.MostrarDetalles());
                        
                        break;

                    }else if(p is ProductoElectronico) {
                    
                        Console.WriteLine(p.MostrarDetalles());
                        break;

                    }else if( p is ProductoAlimenticio)
                    {
                        Console.WriteLine(p.MostrarDetalles());
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
