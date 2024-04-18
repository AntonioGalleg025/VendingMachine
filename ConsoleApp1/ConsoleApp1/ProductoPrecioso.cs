using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoPrecioso : Producto /*Herencia con la clase producto*/
    {
        /*Atríbutos adicionales de los productos preciosos*/
        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

        /*Constructor vacío*/
        public ProductoPrecioso() { }

        /*Constructor*/
        public ProductoPrecioso(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, string tipoMaterial, double peso)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion) /*Más la herencia de la clase Producto*/
        {
            TipoProducto = tipoproducto;
            TipoMaterial = tipoMaterial;
            Peso = peso;
            Id = id;
            Nombre_producto = nombre;
            Unidades_producto = unidades;
            Precio_unidad_producto = precio;
            descripción_del_producto = descripcion;
        }

        public ProductoPrecioso()
        {
            throw new System.NotImplementedException();
        }

        /*Método para establecer los atributos de un nuevo producto precioso*/
        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            base.NuevoProducto(L, Comprobacion);/*LLamamos a la clase padre*/
            /*Añadimos los atributos que son solo de productos preciosos*/
            TipoProducto = "Producto Precioso";
            Console.WriteLine("\nIntroduce el tipo de material del producto precioso: ");
            TipoMaterial = Console.ReadLine();
            Console.WriteLine("\nIntroduce el Peso (en gramos) de su producto precioso: ");
            Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        /*Método para mostrar los detalles de los productos preciosos*/
        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\tTipo de material: {TipoMaterial}\n\tPeso: {Peso} gramos"; /*Llamamos a la clase padre y añadimos los atributos de productos preciosos*/
        }

        /*Método para mostrar los elementos de forma reducida*/
        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento(); /*LLamando a la clase padre*/
        }

        /*Método para guardar los elementos en un fichero*/
        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{TipoMaterial};{Peso}"; /*Llamamos a la clase padre y añadimos los atributos de productos preciosos*/
        }
    }
}
