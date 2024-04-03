using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoElectronico: Producto
    {
        public bool Pilas {  get; set; }

        public string[] Materiales { get; set; }

        public bool Precargado { get; set; }


        public override void NuevoProducto()
        {
            base.NuevoProducto();
            Console.WriteLine("Para indicar los tipos de materiales de su producto electronico," +
            " primero indique de cuantos materiales esta conformado: ");
            int CantidadMateriales = int.Parse(Console.ReadLine());

            
            for(int i = 0; i < CantidadMateriales; i++)
            {
                Console.WriteLine($"Indique el material {i}: ");
                Materiales[i] = Console.ReadLine();
            }
            Console.WriteLine("Materiales añadidos con exito, pulse una tecla para continuar");
            Console.ReadKey();

            Console.WriteLine("El producto electronico incluye pilas?(1 = si || 2 = no): ");
            int opcion = int.Parse(Console.ReadLine());
            if(opcion == 1)
            {
                Pilas = true;
            }else if(opcion == 2)
            {
                Pilas = false;
            }
            else
            {
                Console.WriteLine("Opcion incorrecta");
            }

            Console.WriteLine("Su producto viene precargado?(1 = si || 2 = no): ");
            int opcion2 = int.Parse(Console.ReadLine());
            if (opcion2 == 1)
            {
                Precargado = true;
            }
            else if (opcion2 == 2)
            {
                Precargado = false;
            }
            else
            {
                Console.WriteLine("Opcion incorrecta");
            }


            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }
    }
}
