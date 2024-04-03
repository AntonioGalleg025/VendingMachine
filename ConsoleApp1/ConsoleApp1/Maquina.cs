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

        public void Comprar() 
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
                            Console.WriteLine("Introduce el efectivo:");
                            break;
                        case 2:
                            Console.WriteLine("Introduce el numerode tu tarjeta: ");
                            string num_Targeta = Console.ReadLine();
                            Console.WriteLine("Introduce tu saldo:");
                            double saldo = double.Parse(Console.ReadLine());
                            Console.WriteLine("Introduce la fecha de caducidad (DD/MM/AAAA)");
                            string fech_Caducidad = Console.ReadLine();
                            Console.WriteLine("Introduce el codigo de seguridad (****)");
                            int cod_Seguridad = int.Parse(Console.ReadLine());

                            if (c.Precio <= saldo)
                            {
                                saldo = saldo - c.Precio;
                                Console.WriteLine($"Tu saldo actual es: {saldo}");
                            
                            
                            }
                            break;
                    
                    }

                
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


        
    }
}
