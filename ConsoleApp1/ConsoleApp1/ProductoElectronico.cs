using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductoElectronico : Producto
    {

        public bool Pilas { get; set; }
        public string Materiales { get; set; }
        public bool Precargado { get; set; }


        public ProductoElectronico(int id, string nombre, string tipoproducto, int unidades,
            double precio, string descripcion, bool pilas, bool precargado, string materiales)
            : base(id, nombre, tipoproducto, unidades, precio, descripcion) 
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

        public ProductoElectronico() { }

        public override void NuevoProducto(List<Producto> L, int Comprobacion)
        {
            base.NuevoProducto(L, Comprobacion);

            TipoProducto = "Producto Electronico";
            Console.WriteLine("Indique los materiales separados por comas: ");
            Materiales = Console.ReadLine();
            Console.WriteLine("Materiales añadidos con exito, pulse una tecla para continuar");
            Console.ReadKey();

            Console.WriteLine("El producto electronico incluye pilas?(1 = si || 2 = no): ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Pilas = true;
            }

            else if (opcion == 2)
            {
                Pilas = false;
            }

            else
            {
                Console.WriteLine("Opcion incorrecta");
            }

            Console.WriteLine("Su producto viene precargado?(1 = si || 2 = no): ");
            int opcion2 = int.Parse(Console.ReadLine());

            if (opcion2 == 1)
            {
                Precargado = true;
            }

            else if (opcion2 == 2)
            {
                Precargado = false;
            }
            else
            {
                Console.WriteLine("Opcion incorrecta");
            }


            Console.WriteLine("-----------Producto ha sido agregado con exito, pulse una tecla para continuar-------------");
            Console.ReadKey();
        }

        public override string MostrarDetalles()
        {
            return $"{base.MostrarDetalles()}\n\t¿Contiene pilas? {Pilas}\n\t¿Viene precargado? {Precargado}";
        }

        public override string MostrarUnElemento()
        {
            return base.MostrarUnElemento();
        }

        public override string GuardarDatosFichero()
        {
            return base.GuardarDatosFichero() + $"{Pilas};{Precargado};{Materiales}"; 
        }
    }
}
