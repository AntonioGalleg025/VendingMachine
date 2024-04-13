using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoAlimenticio : Producto /*Herencia con la clase productos*/
    {
        public string InfoNutricional { get; set; } /*Atríbutos adicionales de los productos alimenticios*/
        public ProductoAlimenticio() { }/*Constructor vacío*/

        /*Constructor*/
        public ProductoAlimenticio(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, string infonutricional)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion)/*Más la herencia de la clase Producto*/
        {
            TipoProducto = tipoproducto;
            InfoNutricional = infonutricional;
            Id = id;
            Nombre_producto = nombre;
            Unidades_producto = unidades;
            Precio_unidad_producto = precio;
            descripción_del_producto = descripcion;
        }

        /*Método para establecer los atributos de un nuevo producto alimenticio*/
        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            base.NuevoProducto(L, Comprobacion);/*LLamamos a la clase padre*/
            /*Añadimos los atributos que son solo de productos alimenticios*/
            TipoProducto = "Producto Alimenticio";
            Console.WriteLine("Introduce una descripcion a cerca de la informacion nutricional de su producto");
            InfoNutricional = Console.ReadLine();
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        /*Método para mostrar los detalles de los productos alimenticios*/
        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\tDescripción nutricional: {InfoNutricional}"; /*Llamamos a la clase padre y añadimos los atributos de productos alimenticios*/
        }

        /*Método para mostrar los elementos de forma reducida*/
        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento(); /*LLamando a la clase padre*/
        }

        /*Método para guardar los elementos en un fichero*/
        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{InfoNutricional}"; /*Llamamos a la clase padre y añadimos los atributos de productos alimenticios*/
        }
    }
}
