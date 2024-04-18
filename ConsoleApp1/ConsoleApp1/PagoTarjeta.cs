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
            throw new System.NotImplementedException();
        }

        public double TotalDinero { get; set; }

        public void PagoConTarjeta(List<Producto> CarritoCompra)
        {
            foreach (Producto p in CarritoCompra)/*Recorremos la lista de productos que deseamos comprar*/
            {
                TotalDinero = TotalDinero + p.Precio_unidad_producto;/*Sumamos el total del precio de la lista de la compra*/
            }
            Console.WriteLine("Introduce el numerode tu tarjeta: ");
            string num_Targeta = Console.ReadLine();
            Console.WriteLine("Introduce tu saldo:");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la fecha de caducidad (DD/MM/AAAA)");
            string fech_Caducidad = Console.ReadLine();
            Console.WriteLine("Introduce el codigo de seguridad (****)");
            int cod_Seguridad = int.Parse(Console.ReadLine());

            if (TotalDinero <= saldo)
            {
                saldo = saldo - TotalDinero;
                Console.WriteLine($"Tu saldo actual es: {saldo}");
                Console.WriteLine("Se han comprado los productos con exito");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Su saldo es insuficiente, no se puede comprar el articulo");
                Console.ReadLine();
            }
        }
    }
}
