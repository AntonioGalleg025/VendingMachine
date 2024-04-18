using System;
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
                                else   // Se advierte por pantalla de que no hay unidades 
                                {
                                    Console.WriteLine("No existen unidades de ese producto o ha indicado mal el producto");
                                    break;
                                }

                                break;
                            }
                        }
                    }
                /*Le preguntamos si quiere agregar otro producto*/
                Console.WriteLine("Quieres agregar otro producto?(1 = no || 2 = si): ");
                Salir = int.Parse(Console.ReadLine());

            } while (Salir != 1); /*Si no quiere agregar otro producto a la cesta salimos del bucle*/

            if (CarritoCompra.Count > 0)/*Si hemos añadido algún producto*/
            {
                Console.WriteLine($"Tienes {CarritoCompra.Count} en tu cesta, quiere proceder con el pago?(1 = si || 2 = no): ");/*Le preguntamos si quiere pagar*/
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)/*En caso de que quiera pagar*/
                {
                    /*Comprobamos los productos que están en la ListaProductos y CarritoCompra*/
                    foreach (Producto c in CarritoCompra)
                    {
                        foreach (Producto l in ListaProductos)
                        {
                            if (c.Id == l.Id) /*En caso de que los id del producto coincida en las dos listas*/
                            {
                                if (l.Unidades_producto > 1) /*Si deseamos comprar más de un producto*/
                                {
                                    l.Unidades_producto = l.Unidades_producto - 1; /*Eliminamos 1 Unidades_producto*/
                                    break;
                                }
                                else if (l.Unidades_producto == 1)/*En caso de que solo sea 1*/
                                {
                                    ListaProductos.Remove(l); /*Lo eliminamos de la ListaProductos*/
                                    break;
                                }
                            }
                        }
                    }
                    /*Llamamos al método pagar*/
                    Pagar();
                }
                /*En caso de que no desee pagar*/
                else if (opcion == 2)
                {
                    CarritoCompra.Clear();/*Limpiamos la lista CarritoCompra*/
                }
                /*Si no pulsa el 1 o el 2*/
                else
                {
                    Console.WriteLine("Opcion incorrecta");/*Le indicamos que no es la opción correcta*/
                }
            }
        }

        public void Pagar()/*Método para pagar*/
        {
            /*Le preguntamos que método quiere usar para pagar*/
            Console.WriteLine("Cual es el metodo de pago deseado(1.Efectivo  2.Tarjeta):  ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                /*Paago en efectivo*/
                case 1:
                    PagoEfectivo NuevoPagoConEfectivo = new PagoEfectivo();
                    NuevoPagoConEfectivo.PagarConEfectivo(CarritoCompra);/*Llamamos al método y pasamos la lista por valor donde se encuentran los productos que quiera pagar*/
                    break;

                /*Pago con tarjeta*/
                case 2:
                    PagoTarjeta NuevoPagoConTarjeta = new PagoTarjeta();
                    NuevoPagoConTarjeta.PagoConTarjeta(CarritoCompra);/*Llamamos al método y pasamos la lista por valor donde se encuentran los productos que quiera pagar*/
                    break;

            }
        }


        public void AniadirProducto()/*Método para añadir productos*/
        {
            int Comprobacion = ComprobarCantidadProductos();
            /*Indicamos los tipos de producto que hay*/
            Console.WriteLine("1-Nuevo producto precioso");
            Console.WriteLine("2-Nuevo producto alimenticio");
            Console.WriteLine("3-Nuevo producto electronico");
            Console.WriteLine("Introduce el producto que quieres agregar: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                /*Productos preciosos*/
                case 1:
                    if (Comprobacion >= 12)/*Cuando haya más de 12 productos*/
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");/*Le indicamos que la máquina está llena*/
                        Console.ReadKey();
                    }
                    else
                    {
                        ProductoPrecioso productoPrecioso = new ProductoPrecioso();
                        productoPrecioso.NuevoProducto(ListaProductos, Comprobacion);/*Llamamos al método que pide los detalles de productos preciosos*/
                        ListaProductos.Add(productoPrecioso);/*Lo añadimos a la lista*/
                    }
                    break;
                
                /*Productos alimenticios*/
                case 2:
                    if (Comprobacion >= 12)/*Cuando haya más de doce productos*/
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");/*Le indicamos que la máquina está llena*/
                        Console.ReadKey();
                    }
                    else
                    {
                        ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio();
                        productoAlimenticio.NuevoProducto(ListaProductos, Comprobacion);/*Llamamos al método que pide los detalles de productos alimenticios*/
                        ListaProductos.Add(productoAlimenticio);/*Lo añadimos a la lista*/
                    }
                    break;

                /*Productos electrónicos*/
                case 3:
                    if (Comprobacion >= 12)/*Cuando haya más de 12 productos*/
                    {
                        Console.WriteLine("Lo siento, la maquina esta llena");/*Le indicamos que la máquina está llena*/
                        Console.ReadKey();
                    }
                    else
                    {
                        ProductoElectronico productoElectronico = new ProductoElectronico();
                        productoElectronico.NuevoProducto(ListaProductos, Comprobacion);/*Llamamos al método que pide los detalles de productos electrónicos*/
                        ListaProductos.Add(productoElectronico);/*Lo añadimos a la lista*/
                    }
                    break;

                /*En caso de que pulse una opción incorrecta*/
                default:
                    Console.WriteLine("Opcion incorrecta, pulse una tecla para continuar");
                    break;
            }
        }

        public void ListarTodos()/*Método para lisatar todo los productos*/
        {

            Console.WriteLine();
            foreach (Producto p in ListaProductos)/*Recorremos la ListaProductos*/
            {
                if (p is ProductoPrecioso)/*Si hay productos preciosos*/
                {
                    Console.WriteLine("---------------------Productos preciosos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());/*Mostramos los detalles de forma reducida*/

                }
                else if (p is ProductoElectronico)/*Si hay productos electrónicos*/
                {
                    Console.WriteLine("---------------------Productos electrónicos--------------------");
                    Console.WriteLine(p.MostrarUnElemento());/*Mostramos los detalles de forma reducida*/

                }
                else if (p is ProductoAlimenticio)/*Si hay productos alimenticios*/
                {
                    Console.WriteLine("---------------------Productos alimenticios--------------------");
                    Console.WriteLine(p.MostrarUnElemento());/*Mostramos los detalles de forma reducida*/
                }
            }
        }

        public void BuscarProducto()/*Método para buscar los productos y mostrarlos de forma detallada*/
        {
            ListarTodos();
            /*Pedimos el id del producto*/
            Console.WriteLine("\nIntroduce el ID del producto que desea ver: ");
            int id_producto = int.Parse(Console.ReadLine());
            foreach (Producto p in ListaProductos)/*Recorremos la lista de productos*/
            {
                if (id_producto == p.Id)/*En caso de que coincida la id pedida con la que hay en la lista*/
                {
                    if (p is ProductoPrecioso)/*Si es un producto precioso*/
                    {
                        Console.WriteLine(p.MostrarDetalles());/*Mostramos el producto de forma detallada*/
                        break;

                    }
                    else if (p is ProductoElectronico)/*Si es un producto electrónico*/
                    {
                        Console.WriteLine(p.MostrarDetalles());/*Mostramos el producto de forma detallada*/
                        break;
                    }
                    else if (p is ProductoAlimenticio)/*Si es un producto alimenticio*/
                    {
                        Console.WriteLine(p.MostrarDetalles());/*Mostramos el producto de forma detallada*/
                        break;
                    }
                }
            }
            Console.ReadKey();
        }

        private int ComprobarCantidadProductos()/*Método para comprobar la cantidad de productos que hay*/
        {
            int Contador = 0;
            int Sumatorio = 0;
            int[] CantidadUnidades = new int[100];

            foreach (Producto p in ListaProductos)/*Recorremos la lista de productos*/
            {
                CantidadUnidades[Contador] = p.Unidades_producto;/*Por cada producto que haya la añadimos al array*/
                Contador++;/*Sumamos uno en el contador*/
            }
            for (int i = 0; i < CantidadUnidades.Count(); i++)/*Hacemos un for para recorrer todo el array*/
            {
                Sumatorio += CantidadUnidades[i]; /*Por cada producto que hay en el array se lo sumamos al número de productos quehabí anteriormente*/
            }
            return Sumatorio;/*Devolvemos el sumatorio*/
        }

        public void CargarContenidoArchivo() /*Método para cargar los contenidos del archivo*/
        {
            FileStream fs = new FileStream($"Productos.txt", FileMode.OpenOrCreate, FileAccess.Read); /*Abrimos o creamos el archivo Productos.txt y lo ponemos para podamos leer su contenido*/
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string linea = sr.ReadLine();
                string[] datos = linea.Split(';');/*Separador entre cada elemento del archivo*/

                /*Si hay productos preciosos*/
                if (datos[2] == "Producto Precioso")
                {
                    /*Identificamos cada elemento del archivo de los productos preciosos*/
                    ProductoPrecioso productoPrecioso = new ProductoPrecioso(int.Parse(datos[0]), datos[1], datos[2],
                        int.Parse(datos[3]), double.Parse(datos[4]), datos[5],
                        datos[6], double.Parse(datos[7]));
                    ListaProductos.Add(productoPrecioso);/*Y lo añadimos a la lista de productos*/
                }
                /*Si hay productos alimenticios*/
                else if (datos[2] == "Producto Alimenticio")
                {
                    /*Identificamos cada elemento del archivo de los productos alimenticios*/
                    ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio(int.Parse(datos[0]),
                        datos[1], datos[2], int.Parse(datos[3]),
                        double.Parse(datos[4]), datos[5], datos[6]);
                    ListaProductos.Add(productoAlimenticio);/*Y lo añadimos a la lista de productos*/
                }
                /*Si hay productos electrónicos*/
                else if (datos[2] == "Producto Electronico")
                {
                    /*Identificamos cada elemento del archivo de los productos electrónicos*/
                    ProductoElectronico productoElectronico = new ProductoElectronico(int.Parse(datos[0]), datos[1], datos[2],
                        int.Parse(datos[3]), double.Parse(datos[4]), datos[5], bool.Parse(datos[6]), bool.Parse(datos[7]), datos[8]);
                    ListaProductos.Add(productoElectronico);/*Y los añadimos a la lista de productos*/
                }
            }
            sr.Close();/*Cerramos el archivo*/
            //File.Delete("Productos.txt");
        }

        public void GuardarContenidoArchivo() /*Método para guardar el contenido en el archivo*/
        {
            FileStream fs = new FileStream($"Productos.txt", FileMode.OpenOrCreate, FileAccess.Write);/*Abrimos o creamos el archivo Productos.txt y lo ponemos para que podamos escribir en el*/
            StreamWriter sw = new StreamWriter(fs);
            foreach (Producto p in ListaProductos)/*Recorremos la lista de productos*/
            {
                /*Si es un producto precioso*/
                if (p is ProductoPrecioso)
                {
                    sw.WriteLine(p.GuardarDatosFichero());/*Llamamos a la función que guarda los datos en el fichero*/
                }
                /*Si es un producto electrónico*/
                else if (p is ProductoElectronico)
                {
                    sw.WriteLine(p.GuardarDatosFichero());/*Llamamos a la función que guarda los datos en el fichero*/
                }
                /*Si es un producto alimenticio*/
                else if (p is ProductoAlimenticio)
                {
                    sw.WriteLine(p.GuardarDatosFichero());/*Llamamos a la función que guarda los datos en el fichero*/
                }
            }
            sw.Close();
        }
    }
}
