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
            /*Pedimos el númeor de la tarjeta*/
            Console.WriteLine("Introduce el número de tu tarjeta: ");
            string num_Targeta = Console.ReadLine();
            /*Pedimos el saldo que hay en la tarjeta*/
            Console.WriteLine("Introduce tu saldo:");
            double saldo = double.Parse(Console.ReadLine());
            /*Pedimos la fecha de caducidad*/
            Console.WriteLine("Introduce la fecha de caducidad (DD/MM/AAAA)");
            string fech_Caducidad = Console.ReadLine();
            /*Pedimos el código de seguridad*/
            Console.WriteLine("Introduce el código de seguridad (****)");
            int cod_Seguridad = int.Parse(Console.ReadLine());

            /*Si el dinero de la lista que desea comprar es menor o igual que el saldo*/
            if (TotalDinero <= saldo)
            {
                saldo = saldo - TotalDinero;/*Al saldo que le restamos el precio por comprar los productos*/
                Console.WriteLine($"Tu saldo actual es: {saldo}");/*Le mostramos el saldo que hay en la tarjeta tras la compra*/
                Console.WriteLine("Se han comprado los productos con exito");
                Console.ReadKey();
            }
            /*En caso de que la lista que desea comprar sea mayo que el sald9*/
            else
            {
                Console.WriteLine("Su saldo es insuficiente, no se puede comprar el articulo");/*Le decimos que el saldo no es suficiente para pagar la lista de productos*/
                Console.ReadKey();
            }
        }
    }
}
