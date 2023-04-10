using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensador
{
    public class Dispensadora
    {
        public List<Producto> Productos { get; set; }
        public string Pago { get; set; }

        public Dispensadora()
        {
            this.Productos = new List<Producto>();
            Producto agua = new Producto();
            agua.Codigo = "01";
            agua.Nombre = "Botella de agua";
            agua.Categoria = "B";
            agua.Cantidad = 5;
            agua.Valor = 1000;

            Producto mani = new Producto();
            mani.Codigo = "02";
            mani.Nombre = "Mani";
            mani.Categoria = "M";
            mani.Cantidad = 2;
            mani.Valor = 500;

            this.Productos.Add(agua);
            this.Productos.Add(mani);

        }

        public int validaProducto(string codigo)
        {
            int encontro = -1;


            for (int i = 0; i < this.Productos.Count; i++)
            {
                if (this.Productos[i].Codigo == codigo)
                {
                    encontro = i;
                }

            }

            return encontro;

        }

        public void modificarProducto(string nombre, string categoria, int cantidad, double valor) 
        { 
            foreach ( Producto item in this.Productos) 
            {
                if(item.Nombre == nombre) 
                {
                    
                    item.Categoria = categoria;
                    item.Cantidad = cantidad;
                    item.Valor = valor;

                }
            
            }
                     
        
        }

        public bool agregarProducto(Producto producto)
        {
            int enc = (this.validaProducto(producto.Codigo));
            if (enc >= 0)
            {
                this.Productos[enc].sumarCantidad(producto.Cantidad);

            }
            else
            {
                this.Productos.Add(producto);

            }
            return true;


        }

        public bool eliminarProducto(string codigo)
        {
            int enc = (this.validaProducto(codigo));

            if (enc >= 0)
            {
                this.Productos.RemoveAt(enc);
                return true;

            }

            return false;
        }

        public double validarMonedas(string[] monedas)
        {
            double total = 0;
            foreach (string item in monedas)
            {
                try
                {
                    total += float.Parse(item);

                }
                catch (Exception ) 
                { 
                
                
                }





            }
            return total;


        }

        // 1000-500-200-100

        public Producto vender(string codigo)
        {
            int enc = (this.validaProducto(codigo));

            if (enc >= 0)
            {
                if (this.Productos[enc].validarCantidad())
                {
                    string[] monedas = this.Pago.Split('-');

                    double total = this.validarMonedas(monedas);

                    if (this.Productos[enc].validarValor(total))
                    {
                        this.Productos[enc].restarProducto();

                        return this.Productos[enc];

                    }

                }
            }

            return null;

        }

        public string listarProducto() 
        { string lista = "";
            foreach (Producto item in this.Productos) 
            {
                lista += item.Codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";
                        
            }

            return lista;
                
        }

    }
}
