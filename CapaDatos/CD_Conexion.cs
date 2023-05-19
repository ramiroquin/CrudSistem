using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
        // Establecer conexion a la base de datos

        private SqlConnection Conexion = new SqlConnection("Server=QUINTEROS\\SQLEXPRESS;DataBase=CRUD;Integrated Security=True");

        // Abrir la conexion
        public SqlConnection AbrirConexion() 
        {
            if (Conexion.State == ConnectionState.Closed) 
            
                Conexion.Open();
            
                

            return Conexion;
            
        }

        // Cerrar la conexion
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                
                Conexion.Close();

            
            return Conexion;
        }
    }
}
