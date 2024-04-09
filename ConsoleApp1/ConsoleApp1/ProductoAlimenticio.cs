using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoAlimenticio: Producto
    {
        public string InfoNutricional {  get; set; }
        public ProductoAlimenticio() { }

        public ProductoAlimenticio(string infoNutricional, int id, string nombre, int unidades, double precio, string descripcion)
        : base(id, nombre, unidades, precio, descripcion)
        {
            InfoNutricional = infoNutricional;
        }


        public override void NuevoProducto(List<Producto> L)
        {
            base.NuevoProducto(L);
            TipoProducto = "Producto Alimenticio";
            Console.WriteLine("Introduce una descripcion a cerca de la informacion nutricional de su producto");
            InfoNutricional = Console.ReadLine();
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\tDescripción nutricional: {InfoNutricional}";
        }

        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento();
        }

        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{InfoNutricional}";
        }
    }
}
