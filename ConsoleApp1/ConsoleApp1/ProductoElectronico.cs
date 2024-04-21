using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoElectronico : Producto /*Herencia con la clase producto*/
    {
        /*Atríbutos adicionales de los productos electrónicos*/
        public bool Pilas { get; set; }
        public string Materiales { get; set; }
        public bool Precargado { get; set; }

        /*Constructor*/
        public ProductoElectronico(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, bool pilas, bool precargado, string materiales)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion) /*Más la herencia de la clase Producto*/
        {
            TipoProducto = tipoproducto;
            Pilas = pilas;
            Materiales = materiales;
            Precargado = precargado;
            Id = id;
            Nombre_producto = nombre;
            Unidades_producto = unidades;
            Precio_unidad_producto = precio;
            descripción_del_producto = descripcion;
        }
        /*Constructor vacío*/
        public ProductoElectronico() { }


        /*Método para establecer los atributos de un nuevo producto electrónico*/
        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            base.NuevoProducto(L, Comprobacion);/*LLamamos a la clase padre*/
            /*Añadimos los atributos que son solo de productos electrónicos*/
            TipoProducto = "Producto Electronico";
            Console.WriteLine("Indique los materiales separados por comas: ");
            Materiales = Console.ReadLine();
            Console.WriteLine("Materiales añadidos con exito, pulse una tecla para continuar");
            Console.ReadKey();

            /*En caso de que incluya pilas creamos un if*/
            Console.WriteLine("El producto electronico incluye pilas?(1 = si || 2 = no): ");
            int opcion = int.Parse(Console.ReadLine());
            /*En caso de que incluya pilas*/
            if (opcion == 1)
            {
                Pilas = true;
            }
            /*En case de que no incluya pilas*/
            else if (opcion == 2)
            {
                Pilas = false;
            }
            /*En caso de que ponga un número que no sea correcto*/
            else
            {
                Console.WriteLine("Opcion incorrecta");
            }

            /*En caso de que venga precargado creamos un if*/
            Console.WriteLine("Su producto viene precargado?(1 = si || 2 = no): ");
            int opcion2 = int.Parse(Console.ReadLine());
            /*En caso de que venga precargado*/
            if (opcion2 == 1)
            {
                Precargado = true;
            }
            /*En caso de que no venga precargado*/
            else if (opcion2 == 2)
            {
                Precargado = false;
            }
            /*En caso de que ponga un número que no sea correcto*/
            else
            {
                Console.WriteLine("Opcion incorrecta");
            }


            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        /*Método para mostrar los detalles de los productos electrónicos*/
        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\t¿Contiene pilas? {Pilas}\n\t¿Viene precargado? {Precargado}"; /*Llamamos a la clase padre y añadimos los atributos de productos electrónicos*/
        }

        /*Método para mostrar los elementos de forma reducida*/
        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento(); /*LLamando a la clase padre*/
        }

        /*Método para guardar los elementos en un fichero*/
        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{Pilas};{Precargado};{Materiales}"; /*Llamamos a la clase padre y añadimos los atributos de productos electrónicos*/
        }
    }
}
