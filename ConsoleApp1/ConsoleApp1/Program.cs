using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Opcion;
        static string CodigoSecreto;
        static void Main(string[] args)
        {
            Maquina maquina = new Maquina();
            Console.WriteLine("Sea bienvenido a su Maquina de Vending");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Por favor, pulse una tecla y seleccione una opcion del menu para continuar: ");
            Console.ReadKey();
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine("1-Comprar un producto");
                Console.WriteLine("2-Mostrar informacion de un producto");
                Console.WriteLine("3-Carga individual de un producto");
                Console.WriteLine("4-Carga completa de productos");
                Console.WriteLine("5-Salir del programa");
                Console.WriteLine("\n\nSeleccione una opcion");
                Opcion = int.Parse(Console.ReadLine());
                switch(Opcion)
                {
                    case 1:
                        maquina.ComprarProducto();
                        break;

                    case 2:
                        maquina.ListarPreciosos();
                        maquina.ListarElectronicos();
                        maquina.ListarAlimenticios();
                       
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("La opcion introducida es solo para administradores");
                        Console.WriteLine("Introduce el codigo secreto para continuar");
                        CodigoSecreto = Console.ReadLine();
                        if (CodigoSecreto == "0000")
                        {
                            Console.WriteLine("Contraseña correcta!");
                            maquina.AniadirProducto();
                        }
                        else
                        {
                            Console.WriteLine("No ha introducido el codigo correcto");
                            Console.WriteLine("Saliendo al menu principal...");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("La opcion introducida es solo para administradores");
                        Console.WriteLine("Introduce el codigo secreto para continuar");
                        CodigoSecreto = Console.ReadLine();
                        if(CodigoSecreto == "0000")
                        {
                            Console.WriteLine("Contraseña correcta!");
                            //Implementar el metodo correspondiente
                        }
                        else
                        {
                            Console.WriteLine("No ha introducido el codigo correcto");
                            Console.WriteLine("Saliendo al menu principal...");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;

                    default: 
                        Console.WriteLine("Opcion incorrecta"); 
                        break;
                }

            } while (Opcion != 5);
            if(Opcion == 5)
            {
                Console.WriteLine("Gracias por usar la maquina, esperamos verle pronto :)");
            }
        }
    }
}
