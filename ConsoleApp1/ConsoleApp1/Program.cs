﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*Ejercicio Realizado por: Antonio Gallego Ortiz, Carlos Ynclan Nieto, Adrián Zamorano Valero*/
    internal class Program
    {
        static int Opcion;
        static string CodigoSecreto;

        static void Main(string[] args)
        {
            Maquina maquina = new Maquina();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Sea bienvenido a su Maquina de Vending");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Por favor, pulse una tecla y seleccione una opcion del menu para continuar: ");
            Console.ReadKey();
            do
            {
                /*Menú con opciones*/
                Console.ForegroundColor= ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("1-Comprar un producto");
                Console.WriteLine("2-Mostrar informacion de un producto");
                Console.WriteLine("3-Acceder al menu de administracion de productos");
                Console.WriteLine("4-Carga completa de productos");
                Console.WriteLine("5-Salir del programa");
                Console.WriteLine("\n\nSeleccione una opcion");
                try
                {
                    Opcion = int.Parse(Console.ReadLine());
                    switch (Opcion)
                    {
                        /*Función para comprar un producto*/
                        case 1:
                            Console.Clear();
                            maquina.ComprarProducto();
                            break;

                        /*Función para buscar un producto*/
                        case 2:
                            Console.Clear();
                            maquina.BuscarProducto();
                            break;
                        /*Función para meter un producto*/
                        case 3:
                            Console.Clear();
                            Console.WriteLine("La opcion introducida es solo para administradores");
                            /*Pedimos el código para admins*/
                            Console.WriteLine("Introduce el codigo secreto para continuar");
                            CodigoSecreto = Console.ReadLine();
                            if (CodigoSecreto == "0000")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Contraseña correcta!");
                                maquina.MenuProductosAdmin();
                            }
                            else
                            {

                                Console.WriteLine("No ha introducido el codigo correcto");
                                Console.WriteLine("Saliendo al menu principal...");
                                System.Threading.Thread.Sleep(1000);
                            }
                            break;
                        /*Cargar productos*/
                        case 4:
                            Console.Clear();
                            Console.WriteLine("La opcion introducida es solo para administradores");

                            Console.WriteLine("Introduce el codigo secreto para continuar");
                            CodigoSecreto = Console.ReadLine();
                            if (CodigoSecreto == "0000")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Contraseña correcta!");
                                if (File.Exists("Productos.csv"))
                                {
                                    maquina.CargarContenidoArchivo();
                                }
                            }
                            else
                            {

                                Console.WriteLine("No ha introducido el codigo correcto");
                                Console.WriteLine("Saliendo al menu principal...");
                                System.Threading.Thread.Sleep(1000);
                            }
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduce una opcion valida");
                }catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            } while (Opcion != 5);
            if (Opcion == 5)
            {
                /*Guardamos el contenido del archivo*/
                maquina.GuardarContenidoArchivo();
                Console.WriteLine("Gracias por usar la maquina, esperamos verle pronto :)");
            }
        }

        
    }
}
