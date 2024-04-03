using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PagoTarjeta
    {

        public void PagoConTarjeta(List<Producto> ListaProductos, Producto c)
        {
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
                if (c.Unidades >= 1)
                {
                    ListaProductos.Remove(c);
                    Console.WriteLine("Se han agotado las existencias del producto!!");
                    Console.ReadKey();
                }
                else
                {
                    c.Unidades = c.Unidades - 1;
                    Console.WriteLine($"Queda una unidad menos del Producto {c.Nombre}");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Su saldo es insuficiente, no se puede comprar el articulo");
                Console.ReadKey();
            }
        }
    }
}
