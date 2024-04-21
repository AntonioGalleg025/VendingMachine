using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoPrecioso : Producto
    {

        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

        public ProductoPrecioso() { }

        public ProductoPrecioso(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, string tipoMaterial, double peso)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion) 
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

        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            base.NuevoProducto(L, Comprobacion);

            TipoProducto = "Producto Precioso";
            Console.WriteLine("\nIntroduce el tipo de material del producto precioso: ");
            TipoMaterial = Console.ReadLine();
            Console.WriteLine("\nIntroduce el Peso (en gramos) de su producto precioso: ");
            Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\tTipo de material: {TipoMaterial}\n\tPeso: {Peso} gramos"; 
        }

        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento();
        }

        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{TipoMaterial};{Peso}";
        }
    }
}
