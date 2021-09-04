using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public class ProductoModel
    {
        private Producto[] productos;

        public void agregar(Producto pe)
        {
            if(pe == null)
            {
                throw new ArgumentException("Error, el producto no puede ser null.");
            }

            if(productos == null)
            {
                productos = new Producto[1];
                productos[productos.Length - 1] = pe;
                return;
            }

            Producto[] tmp = new Producto[productos.Length + 1];
            Array.Copy(productos, tmp, productos.Length);
            tmp[tmp.Length - 1] = pe;
            productos = tmp;
        }

        public bool aactualizar (Producto pe)
        {
            bool success = false;
            int index = GetIndex(pe);
            if(index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {pe.Codigo} no existe.");
            }

            productos[index] = pe;
            return !success;
        }

        public bool Delete(Producto p)
        {
            bool flag = false;
            int index = GetIndex(p);
            if(index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Codigo} no existe.");
            }
            Producto[] tmp = new Producto[productos.Length - 1];
            productos[index] = productos[productos.Length - 1]; 
            Array.Copy(productos, tmp, productos.Length - 1);
            productos = tmp;
            
            return !flag;
        }
        public Producto[] GetProductos()
        {
            return productos;
        }

        public Producto FindById(int id)
        {
            int index = -1;
            for(int i = 0; i < productos.Length; i++)
            {
                if(productos[i].Codigo == id)
                {
                    index = i;
                    break;
                }
            }
            
            return index < 0 ? null : productos[index];
        }

        public int GetIndex(Producto p)
        {
            int index = -1, i = 0;
            foreach(Producto prod in productos)
            {
                if(prod.Codigo == p.Codigo)
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }
    }
}
