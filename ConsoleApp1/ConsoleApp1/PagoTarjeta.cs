using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PagoTarjeta
    {
        public PagoTarjeta()
        {
            
        }

        public double TotalDinero { get; set; }

        public void PagoConTarjeta(List<Producto> CarritoCompra)
        {
            /*Sumamos el precio total de la lista*/
            foreach (Producto p in CarritoCompra)
            {
                TotalDinero = TotalDinero + p.Precio_unidad_producto;
            }

            /*Pedimos los datos bancarios*/
            Console.WriteLine("Introduce el número de tu tarjeta: ");
            string num_Targeta = Console.ReadLine();

            Console.WriteLine("Introduce tu saldo:");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduce la fecha de caducidad (DD/MM/AAAA)");
            string fech_Caducidad = Console.ReadLine();

            Console.WriteLine("Introduce el código de seguridad (****)");
            int cod_Seguridad = int.Parse(Console.ReadLine());

            /*Restamos el dinero de la cuenta al precio de la lista y si no es suficiente le mostramos un mensaje*/
            if (TotalDinero <= saldo)
            {
                saldo = saldo - TotalDinero;
                Console.WriteLine($"Tu saldo actual es: {saldo}");
                Console.WriteLine("Se han comprado los productos con exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Su saldo es insuficiente, no se puede comprar el artículo");
                Console.ReadKey();
            }
        }
    }
}
