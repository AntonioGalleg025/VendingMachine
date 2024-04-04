using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PagoEfectivo
    {
        
        public double TotalDinero { get; set; }
        // Array con las diferentes centimos, monedas y billetes disponibles
        public static double[] Monedas = new double[]
        {
            0.01,
            0.02,
            0.05,
            0.10,
            0.20,
            0.50,
            1.0,
            2.0,
            5.0,
            10.0,
            20.0,
            50.0,
            100.0,
            200.0,
            500.0
        };

        // Método para realizar un pago en efectivo
        public void PagarConEfectivo(double[] Precios)
        {
            // Sumamos el precio de cada producto al total
            for (int i = 0; i < Precios.Length; i++)
            {
                TotalDinero += Precios[i];
            }
            // Bucle para realizar el pago 
            do
            {
                MostrarTiposDeMonedas();
                Console.WriteLine("Selecciona que moneda o billete quieres introducir: ");
                int opcion = int.Parse(Console.ReadLine());
                TotalDinero = TotalDinero - Monedas[opcion];

                if(TotalDinero > 0)
                {
                    Console.WriteLine($"Le quedan por pagar {TotalDinero}");
                    Console.ReadKey();

                }else if(TotalDinero < 0)
                {

                    Console.WriteLine($"Le han sobrado {-TotalDinero}");
                    Console.ReadKey();
                    
                }
                else
                {
                    Console.WriteLine("No hay cambio, disfrute de su producto!");
                    Console.ReadKey();
                    
                }
            } while (TotalDinero > 0);
        }

        //mostramos el tipo de moneda si es centimo / euros / billetes 
        private void MostrarTiposDeMonedas()
        {
            for (int i = 0; i < Monedas.Length; i++)
            {
                if (i < 6)
                {
                    Console.WriteLine($"{i}-Moneda de {Monedas[i]} centimos");

                }
                else if (i < 8)
                {
                    Console.WriteLine($"{i}-Moneda de {Monedas[i]} euros");
                }
                else
                {
                    Console.WriteLine($"{i}-Billete de {Monedas[i]} euros");
                }
            }
        }
    }
}
