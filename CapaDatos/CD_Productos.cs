using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        // encapsular la variable
        private CD_Conexion conexion = new CD_Conexion();

        // Leer filas te la tabla PRODUCTOS
        SqlDataReader leer;

        // Almacenar las filas que consulte el SqlDataReader
        DataTable tabla = new DataTable();

        // Ejecutar instrucciones desde SQL
        SqlCommand comando = new SqlCommand();

        // Metodo para mostrar registros de la tabla
        public DataTable Mostrar() 
        {
         //TRANSACT SQL
            
            // Abrir la conexion
            comando.Connection = conexion.AbrirConexion();
            // Ejecutarla
            comando.CommandText = "MOSTRARPRODUCTOS";
            //Especificar que es de tipo procedimiento
            comando.CommandType = CommandType.StoredProcedure;
            // Se lee y devuelve filas
            leer = comando.ExecuteReader();
            // Rellenar la tabla con lo consultado
            tabla.Load(leer);
            // Cerrrar la conexion
            conexion.CerrarConexion();

            return tabla;
            
        }

        // Metodo para insertar regitros
        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            // Abrir la conexion
            comando.Connection = conexion.AbrirConexion();
            // Insertar datos a la base
            comando.CommandText = "INSERT INTO PRODUCTOS VALUES ('"+nombre+"','"+desc+"','"+marca+"',"+precio+","+stock+")";
            comando.CommandType = CommandType.Text;
            // Ejecutar instrucciones
            comando.ExecuteNonQuery();
        }

        // Metodo para editar registros
        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            // Abrir la conexion
            comando.Connection = conexion.AbrirConexion();
            // Editar datos de la base
            comando.CommandText = "EDITARPRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            
            comando.ExecuteNonQuery();
            
            comando.Parameters.Clear();
        }

        // Metodo para eliminar registros
        public void Eliminar (int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ELIMINARPRODUCTO";
            comando.CommandType= CommandType.StoredProcedure;
            comando.Parameters.AddWithValue ("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }   
    }
}
