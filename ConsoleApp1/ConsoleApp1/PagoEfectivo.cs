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
            
            foreach(Producto p in CarritoCompra)/*Recorremos la lista de productos que deseamos comprar*/
            {
                TotalDinero = TotalDinero + p.Precio_unidad_producto;/*Sumamos el total del precio de la lista de la compra*/
            }
            do
            {
                MostrarTiposDeMonedas();/*Mostramos el tipo de monedas y billetes*/
                /*Pedimos que tipo de moneda o billete quiere usar*/
                Console.WriteLine("Selecciona que moneda o billete quieres introducir: ");
                int opcion = int.Parse(Console.ReadLine());
                TotalDinero = TotalDinero - Monedas[opcion];/*Le restamos la cantidad pedida al precio total*/

                /*Si el precio total es mayor que 0*/
                if (TotalDinero > 0)
                {
                    Console.WriteLine($"Le quedan por pagar {TotalDinero}");/*Mostramos el precio que falta por pagar*/
                    Console.ReadKey();
                }
                /*Si el precio total es menor que 0*/
                else if (TotalDinero < 0)
                {
                    Console.WriteLine($"Le han sobrado {-TotalDinero}");/*Mostramos el dinero que recibe por pagar demás*/
                    Console.ReadKey();
                }
                /*En caso de que haya pagado el precio justo*/
                else
                {
                    Console.WriteLine("No hay cambio, disfrute de su producto!");
                    Console.ReadKey();
                }
            } while (TotalDinero > 0);/*No sale del bucle a menos que el PrecioTotal sea menor que 0*/
        }

        private void MostrarTiposDeMonedas()/*Método para mostrar el tipo de billettes y monedas*/
        {
            for (int i = 0; i < Monedas.Length; i++)/*For para recorrer el array*/
            {
                /*Si son céntimos*/
                if (i < 6)
                {
                    Console.WriteLine($"{i}-Moneda de {Monedas[i]} centimos");

                }
                /*Si son euros en monedas*/
                else if (i < 8)
                {
                    Console.WriteLine($"{i}-Moneda de {Monedas[i]} euros");
                }
                /*Si son billetes*/
                else
                {
                    Console.WriteLine($"{i}-Billete de {Monedas[i]} euros");
                }
            }
        }
    }
}
