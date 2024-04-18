﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Maquina
    {
        //Creamos las listas
        public List<Producto> ListaProductos = new List<Producto>();
        public List<Producto> CarritoCompra = new List<Producto>();
        public List<Producto> ListaTemp = new List<Producto>();
        public int Salir { get; set; }
        
        public Maquina() { }  //Constructor vacio 

        public Maquina()
        {
            throw new System.NotImplementedException();
        }

        public void ComprarProducto()  //Metodo para comprar los productos 
        {
       
            foreach (Producto producto in ListaProductos)  // Hacemos un bucle en el que recorremos ListaProductos
            {
                
                ListaTemp.Add(producto);  //Añadimos todo lo que conenga ListaProductos a ListaTemp
            }
            
            do
            {
                //Pedimos el id del producto y lo almacenamos en una variable 
                Console.WriteLine("Escribe el ID del producto:");
                int Id = int.Parse(Console.ReadLine());

                    foreach (Producto c in ListaProductos)   //Recorremos la lista ListaProductos en la variable local c.
                    {
                        foreach (Producto l in ListaTemp)   //Recorremos la lista ListaTemp en la variable local l.
                        {
                            if (c.Id == Id && l.Unidades_producto > 0) //Compara el Id de la lista de productos con el introducido por el cliente y comprueba hay existencias del producto.
                            { 
                                if (Id == l.Id)  //Comprueba que Id pedido por pantalla y el Id del la variable local l coinciden. Sino pasara al else.
                                {
                                    if (l.Unidades_producto > 1)  //Enta en el if cuando haya mas de un producto, sino pasara al else.
                                    {
                                       
                                        CarritoCompra.Add(c);    //Añadimos el producto a la lista.
                                        l.Unidades_producto = l.Unidades_producto - 1;  //Le restamos las unidades compradas a la lista temporal.

                                    }
                                    else if (l.Unidades_producto == 1)  //Comprueba que las unidades de la lista temporal es igual a uno.
                                    {
                                        CarritoCompra.Add(c);  //Añadimos el producto a la lista.
                                        ListaTemp.Remove(l);  //Borra la lista temporal.
                                    
                                    }
                                }
                                else   // Se advierte por pantalla de ue no hay unidades 
                                {
                                    Console.WriteLine("No existen unidades de ese producto o ha indicado mal el producto");
                                    break;
                                }

                                break;
                            }
                        }
                    }

                Console.WriteLine("Quieres agregar otro producto?(1 = no || 2 = si): ");
                Salir = int.Parse(Console.ReadLine());

            } while (Salir != 1);

            if (CarritoCompra.Count > 0)
            {
                Console.WriteLine($"Tienes {CarritoCompra.Count} en tu cesta, quiere proceder con el pago?(1 = si || 2 = no): ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    foreach (Producto c in CarritoCompra)
                    {
                        foreach (Producto l in ListaProductos)
                        {
                            if (c.Id == l.Id)
                            {
                                if (l.Unidades_producto > 1)
                                {
                                    l.Unidades_producto = l.Unidades_producto - 1;
                                    break;
                                }
                                else if (l.Unidades_producto == 1)
                                {
                                    ListaProductos.Remove(l);
                                    break;
                                }
                            }
                        }
                    }
                    Pagar();
                }
                else if (opcion == 2)
                {
                    CarritoCompra.Clear();
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta");
                }
            }
        }
        public void Pagar()
        {
            Console.WriteLine("Cual es el metodo de pago deseado(1.Efectivo  2.Tarjeta):  ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PagoEfectivo NuevoPagoConEfectivo = new PagoEfectivo();
                    NuevoPagoConEfectivo.PagarConEfectivo(CarritoCompra);
                    break;

                case 2:
                    PagoTarjeta NuevoPagoConTarjeta = new PagoTarjeta();
                    NuevoPagoConTarjeta.PagoConTarjeta(CarritoCompra);
                    break;

            }
        }


        public void AniadirProducto()
        {
            int Comprobacion = ComprobarCantidadProductos();
            Console.WriteLine("1-Nuevo producto precioso");
            Console.WriteLine("2-Nuevo producto alimenticio");
            Console.WriteLine("3-Nuevo producto electronico");
            Console.WriteLine("Introduce el producto que quieres agregar: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    if (Comprobacion >= 12)
                    {

                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else
                    {

                        ProductoPrecioso productoPrecioso = new ProductoPrecioso();
                        productoPrecioso.NuevoProducto(ListaProductos, Comprobacion);
                        ListaProductos.Add(productoPrecioso);
                    }
                    break;

                case 2:
                    if (Comprobacion >= 12)
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else
                    {

                        ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio();
                        productoAlimenticio.NuevoProducto(ListaProductos, Comprobacion);
                        ListaProductos.Add(productoAlimenticio);
                    }
                    break;

                case 3:

                    if (Comprobacion >= 12)
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");
                        Console.ReadKey();
                    }
                    else
                    {

                        ProductoElectronico productoElectronico = new ProductoElectronico();
                        productoElectronico.NuevoProducto(ListaProductos, Comprobacion);
                        ListaProductos.Add(productoElectronico);
                    }
                    break;


                default:
                    Console.WriteLine("Opcion incorrecta, pulse una tecla para continuar");
                    break;
            }
        }

        public void ListarTodos()
        {

            Console.WriteLine();
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoPrecioso)
                {
                    Console.WriteLine("---------------------Productos preciosos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());

                }
                else if (p is ProductoElectronico)
                {
                    Console.WriteLine("---------------------Productos electrónicos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());

                }
                else if (p is ProductoAlimenticio)
                {
                    Console.WriteLine("---------------------Productos alimenticios--------------------");
                    Console.WriteLine(p.MostrarUnElemento());
                }
            }
        }

        public void BuscarProducto()
        {
            ListarTodos();
            /*Pedimos el id del producto que queremos ver detalladamente*/
            Console.WriteLine("\nIntroduce el ID del producto que desea ver: ");
            int id_producto = int.Parse(Console.ReadLine());
            foreach (Producto p in ListaProductos)
            {
                if (id_producto == p.Id)
                {
                    if (p is ProductoPrecioso)
                    {
                        Console.WriteLine(p.MostrarDetalles());

                        break;

                    }
                    else if (p is ProductoElectronico)
                    {

                        Console.WriteLine(p.MostrarDetalles());
                        break;

                    }
                    else if (p is ProductoAlimenticio)
                    {
                        Console.WriteLine(p.MostrarDetalles());
                        break;
                    }
                }
            }
            Console.ReadLine();
        }

        private int ComprobarCantidadProductos()
        {
            int Contador = 0;
            int Sumatorio = 0;
            int[] CantidadUnidades = new int[100];

            foreach (Producto p in ListaProductos)
            {
                CantidadUnidades[Contador] = p.Unidades_producto;
                Contador++;
            }
            for (int i = 0; i < CantidadUnidades.Count(); i++)
            {
                Sumatorio += CantidadUnidades[i];
            }

            return Sumatorio;
        }

        public void CargarContenidoArchivo()
        {

            FileStream fs = new FileStream($"Productos.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string linea = sr.ReadLine();
                string[] datos = linea.Split(';');

                if (datos[2] == "Producto Precioso")
                {
                    ProductoPrecioso productoPrecioso = new ProductoPrecioso(int.Parse(datos[0]), datos[1], datos[2],
                        int.Parse(datos[3]), double.Parse(datos[4]), datos[5],
                        datos[6], double.Parse(datos[7]));
                    ListaProductos.Add(productoPrecioso);
                }
                else if (datos[2] == "Producto Alimenticio")
                {
                    ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio(int.Parse(datos[0]),
                        datos[1], datos[2], int.Parse(datos[3]),
                        double.Parse(datos[4]), datos[5], datos[6]);
                    ListaProductos.Add(productoAlimenticio);
                }
                else if (datos[2] == "Producto Electronico")
                {

                    ProductoElectronico productoElectronico = new ProductoElectronico(int.Parse(datos[0]), datos[1], datos[2],
                        int.Parse(datos[3]), double.Parse(datos[4]), datos[5], bool.Parse(datos[6]), bool.Parse(datos[7]), datos[8]);
                    ListaProductos.Add(productoElectronico);
                }
            }
            sr.Close();
            //File.Delete("Productos.txt");
        }

        public void GuardarContenidoArchivo()
        {
            FileStream fs = new FileStream($"Productos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Producto p in ListaProductos)
            {
                if (p is ProductoPrecioso)
                {
                    sw.WriteLine(p.GuardarDatosFichero());


                }
                else if (p is ProductoElectronico)
                {

                    sw.WriteLine(p.GuardarDatosFichero());


                }
                else if (p is ProductoAlimenticio)
                {

                    sw.WriteLine(p.GuardarDatosFichero());

                }
            }
            sw.Close();
        }
    }
}
