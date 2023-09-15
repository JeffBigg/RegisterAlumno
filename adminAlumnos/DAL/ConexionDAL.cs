using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Common;

namespace adminAlumnos.DAL
{
    class ConexionDAL
    {

        private string CadenaConexion = "Data Source=JEFFBIGG22;Initial Catalog=dbSistema;Integrated Security=True";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {

            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;

        }
        public bool EjecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {

                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true; 

            }
            catch 
            {

                return false;

            }

        }
    }
}
