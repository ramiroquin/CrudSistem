using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        // Encapsular
        private CD_Productos objetoCD = new CD_Productos();

        // Metodo para mostrar Productos
        public DataTable MostrarProd()
        {
            // Para guardar los datos
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();

            return tabla;
        }

        // Metodo para insertar Productos
        public void InsertarProd (string nombre, string desc, string marca, string precio, string stock) 
        { 
            // Convierte y valida los datos
            objetoCD.Insertar(nombre,desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        // Metodo para editar Productos
        public void EditarProd(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock),Convert.ToInt32(id));
        }

        // Metodo para eliminar productos
        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id)); 
        }
    }
}
