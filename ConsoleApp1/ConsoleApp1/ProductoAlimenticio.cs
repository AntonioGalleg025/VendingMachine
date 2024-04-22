using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoAlimenticio : Producto
    {
        public string InfoNutricional { get; set; }
        public ProductoAlimenticio() { }

        public ProductoAlimenticio(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, string infonutricional)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion)
        {
            TipoProducto = tipoproducto;
            InfoNutricional = infonutricional;
            Id = id;
            Nombre_producto = nombre;
            Unidades_producto = unidades;
            Precio_unidad_producto = precio;
            descripción_del_producto = descripcion;
        }

        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            /*Llamamos a la del padre y completamos con los de productos alimenticios*/
            base.NuevoProducto(L, Comprobacion);
            TipoProducto = "Producto Alimenticio";
            Console.WriteLine("Introduce una descripcion a cerca de la informacion nutricional de su producto");
            InfoNutricional = Console.ReadLine();
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        public override string MostrarDetalles()
        {
            /*Llamamos a la del padre y complementamos*/
            return $"{base.MostrarDetalles()}\n\tDescripción nutricional: {InfoNutricional}"; 
        }

        public override string MostrarUnElemento()
        {
            /*Llamamos a la del padre*/
            return base.MostrarUnElemento();
        }

        public override string GuardarDatosFichero()
        {
            /*Llamamos a la del padre, completamos y lo guardamos en el fichero*/
            return base.GuardarDatosFichero() + $"{InfoNutricional}"; 
        }
    }
}
