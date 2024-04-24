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
        
        public Maquina() { }

        //Comienzo de metodos para el cliente
        public void ComprarProducto()
        {
            ListarTodos();
            foreach (Producto producto in ListaProductos)
            {
                
                ListaTemp.Add(producto);
            }
            
            do
            {
                /*Pedimos el id del producto*/
                Console.WriteLine("Escribe el ID del producto:");
                int Id = int.Parse(Console.ReadLine());

                    /*Recorremos las listas cuando el id coinciden quitamos una unidad de producto de la lista temporal*/
                    foreach (Producto c in ListaProductos)
                    {
                        foreach (Producto l in ListaTemp)
                        {
                            if (c.Id == Id && l.Unidades_producto > 0) 
                            { 
                                if (Id == l.Id)
                                {
                                    if (l.Unidades_producto > 1) 
                                    {
                                       
                                        CarritoCompra.Add(c);
                                        l.Unidades_producto = l.Unidades_producto - 1;

                                    }
                                    else if (l.Unidades_producto == 1)
                                    {
                                        CarritoCompra.Add(c);
                                        ListaTemp.Remove(l);
                                    
                                    }
                                }
                                else
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

            /*Si quieres pagar los eliminas de la lista de productos, sino quieres pagar limpias la lista*/
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
            /*Opciones para pagar con tarjeta o en efectivo*/
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
        //Final de metodos para el cliente

        //Comienzo de metodos para el administrador
        public void MenuProductosAdmin()
        {
            /*Menú con opciones*/
            int opcion;
            Console.Clear();
            Console.WriteLine("1-Añadir un nuevo producto a la maquina");
            Console.WriteLine("2-Eliminar un tipo de producto que esta dentro de la maquina");
            Console.WriteLine("3-Eliminar una unidad de un producto que esta en la maquina");
            Console.WriteLine("4-Agregar unidades de un producto");
            Console.WriteLine("Selecciona la opcion que quiere realizar: ");
            opcion = int.Parse(Console.ReadLine());
            switch(opcion)
            {
                /*Función para añadir productos*/
                case 1:
                    AniadirProducto();
                    break;
                /*Función para eliminar productos*/
                case 2:
                    EliminarProducto();
                    break;
                /*Función para eliminar una unidad*/
                case 3:
                    EliminarUnaUnidad();
                    break;

                case 4:
                    AgregarUnidades();
                    break;

                default:
                    Console.WriteLine("Opcion no valida");
                    Console.ReadKey();
                    break;
            }
        }

        public void AgregarUnidades()
        {
            int UdsAgrego;
            int UdsMaquina = ComprobarCantidadProductos();
            ListarTodos();
            if(UdsMaquina < 12)
            {
                Console.WriteLine("Introduce el Id del producto del que quieres agregar unidades: ");
                int IdElimino = int.Parse(Console.ReadLine());
                foreach (Producto p in ListaProductos)
                {
                    if (IdElimino == p.Id)
                    {
                        do
                        {
                            Console.WriteLine("Cuantas unidades quieres agregar?: ");
                            UdsAgrego = int.Parse(Console.ReadLine());
                        } while (UdsAgrego + UdsMaquina > 12);
                        p.Unidades_producto += UdsAgrego;
                        Console.WriteLine("Unidades añadidas con exito");
                        break;
                    }
                }
            }
        }

        public void AniadirProducto()
        {
            int Comprobacion = ComprobarCantidadProductos();
            /*Menú con opciones*/
            Console.WriteLine("1-Nuevo producto precioso");
            Console.WriteLine("2-Nuevo producto alimenticio");
            Console.WriteLine("3-Nuevo producto electronico");
            Console.WriteLine("Introduce el producto que quieres agregar: ");
            int opcion = int.Parse(Console.ReadLine());
            /*Comprobamos el número de productos y en caso de no estar llena añadimos lso productos preciosos, alimenticios o electrónicos*/
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

        public void EliminarProducto()
        {
            /*Listamos los productos, pedimos el id y lo eliminamos*/
            ListarTodos();
            Console.WriteLine("Introduce el Id del producto que quieres eliminar: ");
            int IdElimino = int.Parse(Console.ReadLine());
            foreach(Producto p in ListaProductos)
            {
                if(IdElimino == p.Id)
                {
                    ListaProductos.Remove(p);
                    Console.WriteLine("Producto eliminado con exito");
                    break;
                }
            }
            Console.WriteLine("Pulsa una tecla para continuar");
            Console.ReadKey();
        }

        public void EliminarUnaUnidad()
        {
            /*En vez de eliminar el producto quitamos solo una unidad*/
            /*Si solo queda una un producto lo elimina de la lista*/
            ListarTodos();
            Console.WriteLine("Introduce el Id del producto del cual quieres eliminar una unidad: ");
            int IdElimino = int.Parse(Console.ReadLine());
            foreach (Producto p in ListaProductos)
            {
                if (IdElimino == p.Id)
                {
                    if(p.Unidades_producto > 1)
                    {
                        p.Unidades_producto -= 1;

                    }else if(p.Unidades_producto == 1)
                    {
                        ListaProductos.Remove(p);
                    }
                }
            }
        }

        private int ComprobarCantidadProductos()
        {
            /*Recorremos la lista y contamos el numero de productos que hay en la lista*/
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
            /*Indentificamos los items que hay en el archivo y los añadimos a la lista*/
            try
            {
                FileStream fs = new FileStream($"Productos.csv", FileMode.OpenOrCreate, FileAccess.Read);
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
            }catch(FileNotFoundException ex) { 
            
                Console.WriteLine("No se encuentra el fichero: "+ ex.Message);
            }catch(IOException ex)
            {
                Console.WriteLine("ERROR !!!: " + ex.Message);
            }

        }

        public void GuardarContenidoArchivo()
        {
            /*Recorremos la lista y guardamos los datos en el fichero*/
            FileStream fs = new FileStream($"Productos.csv", FileMode.OpenOrCreate, FileAccess.Write);
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
        //Final metodos del administrador

        //Metodos comunes para los dos tipos de actores(cliente y administrador)
        public void ListarTodos()
        {
            /*Recorremos la lista y en caso de que haya productos muestra los detalles de forma reducida*/
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
            /*Pedimos el id y mostramos el producto de forma detallada*/
            ListarTodos();
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
            Console.ReadKey();
        }
        //Final metodos comunes para ambos actores(cliente y administrador)
    }
}
