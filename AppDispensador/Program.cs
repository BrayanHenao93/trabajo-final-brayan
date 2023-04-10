using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispensador;
namespace AppDispensador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispensadora dispensador = new Dispensadora();

            while (true)
            {
                Console.WriteLine("Bienvenidos a la maquina dispensadora de Brayan");
               
                Console.WriteLine(dispensador.listarProducto());

                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Modificar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Comprar producto");
                string opcion = Console.ReadLine();

                switch(opcion) 
                {
                    case "1":
                        Producto producto = new Producto();
                        Console.Write("Codigo");
                        producto.Codigo = Console.ReadLine();

                        Console.Write("Nombre");
                        producto.Nombre = Console.ReadLine();

                        Console.Write("Categoria");
                        producto.Categoria = Console.ReadLine();

                        Console.Write("Cantidad");
                        producto.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Valor");
                        producto.Valor = double.Parse(Console.ReadLine());

                        dispensador.agregarProducto(producto);

                        break;
                        case "2":
                        // Mostrar los datos del producto
                        
                        Producto producto1 = new Producto();

                        
                        Console.WriteLine("Datos del producto original:");
                        Console.WriteLine("Nombre: {0}", producto1.Nombre);
                        Console.WriteLine("Categoría: {0}", producto1.Categoria);
                        Console.WriteLine("Cantidad: {0}", producto1.Cantidad);
                        Console.WriteLine("Valor: {0}", producto1.Valor);
                        Console.WriteLine();

                        // Pedir al usuario los nuevos datos del producto
                        Console.WriteLine("Ingrese los nuevos datos del producto:");
                        Console.Write("Nombre: ");
                        string nuevoNombre = Console.ReadLine();
                        Console.Write("Categoría: "); 
                        string nuevaCategoria = Console.ReadLine();
                        Console.Write("Cantidad: ");
                        int nuevaCantidad = int.Parse(Console.ReadLine());
                        Console.Write("Valor: ");
                        double nuevoValor = double.Parse(Console.ReadLine());

                        // Actualizar el objeto Producto con los nuevos datos
                        Producto.modificarProducto(nuevoNombre, nuevaCategoria, nuevaCantidad, nuevoValor);

                        // Mostrar los datos del producto actualizado
                        Console.WriteLine("Datos del producto actualizado:");
                        Console.WriteLine("Nombre: {0}", producto1.Nombre);
                        Console.WriteLine("Categoría: {0}", producto1.Categoria);
                        Console.WriteLine("Cantidad: {0}", producto1.Cantidad);
                        Console.WriteLine("Valor: {0}", producto1.Valor);

                        break; 

                        case "3":

                        Console.Write("Codigo");
                        string codigo = Console.ReadLine();

                        dispensador.eliminarProducto(codigo);

                        break;

                        case "4":

                        Console.Write("Codigo");
                        string codigo_venta= Console.ReadLine();

                        Console.Write("Monedas solo de (1000-500-200-100)");
                        dispensador.Pago = Console.ReadLine();

                        Producto pcomprado= dispensador.vender(codigo_venta); 

                        if( pcomprado == null) 
                        {
                            Console.WriteLine("No se pudo sacar el producto");
                        
                        }
                        else 
                        {
                            Console.WriteLine("Su producto es {0} y la devuelta es {1}", pcomprado.Codigo, pcomprado.Cambio);
                                                
                        }

                        break;  

                }

                Console.WriteLine("Desea continuar si/no");

                if(Console.ReadLine() == "no") 
                {
                    break;
                
                }


            } 



            

        }
    }
}