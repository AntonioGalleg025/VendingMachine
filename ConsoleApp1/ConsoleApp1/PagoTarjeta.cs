using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PagoTarjeta
    {
        public double TotalDinero { get; set; }


        // Método para realizar un pago con tarjeta
        public void PagoConTarjeta(double[] Precios)
        {
            // Sumamos el precio de cada producto al total
            for (int i = 0; i < Precios.Length; i++)
            {
                TotalDinero += Precios[i];
            }
            // Pedimos al usuario los datos de la tarjeta
            Console.WriteLine("Introduce el numerode tu tarjeta: ");
            string num_Targeta = Console.ReadLine();
            Console.WriteLine("Introduce tu saldo:");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la fecha de caducidad (DD/MM/AAAA)");
            string fech_Caducidad = Console.ReadLine();
            Console.WriteLine("Introduce el codigo de seguridad (****)");
            int cod_Seguridad = int.Parse(Console.ReadLine());

            // Comprobamos si el saldo es suficiente para realizar el pago
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
