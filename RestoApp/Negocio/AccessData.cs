using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Negocio
{
    public class AccessData
    {   
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Inicia la conexion
        public AccessData(string HOST,string BD)
        {
            string connection = "data source = " + HOST + "; initial catalog = " + BD + "; integrated security = true; ";
            conexion = new SqlConnection(connection);
            comando = new SqlCommand();
        }

        //Setea la consulta
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Ejecuta la lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        //Cierra la conexion
        public void cerrarConexion()
        {
            if (lector != null) lector.Close(); conexion.Close();
        }

        //Retorna el lector
        public SqlDataReader Lector{ get { return lector; }}

        //Ejecuta la accion
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open(); 
            comando.ExecuteNonQuery();
        }

        public void agregarParametro(string nombre, Object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void LimpiarParametros()
        {
            comando.Parameters.Clear();
        }
    }
}

