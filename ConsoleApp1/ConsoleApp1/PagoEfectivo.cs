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
        public PagoEfectivo()
        {
            
        }

        public double TotalDinero { get; set; }
        /*Array de monedas y billetes*/
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

        public void PagarConEfectivo(List<Producto> CarritoCompra)
        {
            /*Sumamos el precio de los productos de la lista*/
            foreach(Producto p in CarritoCompra)
            {
                TotalDinero = TotalDinero + p.Precio_unidad_producto;
            }
            do
            {
                /*Mostramos el tipo de monedas y billetes*/
                MostrarTiposDeMonedas();
                /*Pedimos que moneda o billete quiere utilizar y se lo restamos al precio hasta que sea 0 o menor que 0*/
                Console.WriteLine("Selecciona que moneda o billete quieres introducir: ");
                int opcion = int.Parse(Console.ReadLine());
                TotalDinero = TotalDinero - Monedas[opcion];
                if (TotalDinero > 0)
                {
                    Console.WriteLine($"Le quedan por pagar {TotalDinero}");
                    Console.ReadKey();
                }

                else if (TotalDinero < 0)
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

        private void MostrarTiposDeMonedas()
        {
            /*Hacemos un for recorriendo el array mostrando las monedas y los billetes*/
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
