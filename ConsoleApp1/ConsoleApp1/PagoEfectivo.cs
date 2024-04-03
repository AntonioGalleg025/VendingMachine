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


        public void PagarConEfectivo(List<Producto> ListaProductos, Producto c)
        {
            
            do
            {
                MostrarTiposDeMonedas();
                Console.WriteLine("Selecciona que moneda o billete quieres introducir: ");
                int opcion = int.Parse(Console.ReadLine());
                c.Precio = c.Precio - Monedas[opcion];

                if(c.Precio > 0)
                {
                    Console.WriteLine($"Le quedan por pagar {c.Precio}");
                    Console.ReadKey();

                }else if(c.Precio < 0)
                {

                    Console.WriteLine($"Le han sobrado {-c.Precio}");
                    Console.ReadKey();
                    if(c.Unidades > 1)
                    {
                        c.Unidades = c.Unidades - 1;
                    }
                    else
                    {
                        ListaProductos.Remove(c);
                    }
                }
                else
                {
                    Console.WriteLine("No hay cambio, disfrute de su producto!");
                    Console.ReadKey();
                    if (c.Unidades > 1)
                    {
                        c.Unidades = c.Unidades - 1;
                    }
                    else
                    {
                        ListaProductos.Remove(c);
                    }
                }
            } while (c.Precio >= 0);
        }

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
