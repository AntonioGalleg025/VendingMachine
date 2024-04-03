using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoPrecioso: Producto
    {
        public string TipoMaterial {  get; set; }
        public double Peso {  get; set; }

        public ProductoPrecioso() { }

        public ProductoPrecioso(string tipoMaterial, double peso, int id, string nombre, int unidades, double precio, string descripcion) 
        :base(id, nombre, unidades, precio, descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }

        public override void NuevoProducto(List<Producto> L)
        {
            base.NuevoProducto(L);
            Console.WriteLine("\nIntroduce el tipo de material del producto precioso: ");
            TipoMaterial = Console.ReadLine();
            Console.WriteLine("\nIntroduce el Peso (en gramos) de su producto precioso: ");
            Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }
    }
}
