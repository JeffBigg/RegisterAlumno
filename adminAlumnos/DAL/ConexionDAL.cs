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

        //Metodo insert, delete y update
        public bool EjecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando = SQLComando;
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


        //SELECT retorno de datos
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;

            }
            catch
            {
                return (DS);
            }
        }

    }
}
