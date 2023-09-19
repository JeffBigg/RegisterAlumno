using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using adminAlumnos.BLL;

namespace adminAlumnos.DAL
{
    internal class DepartamentosDAL
    {
        ConexionDAL conexion;

        public DepartamentosDAL()
        {
            conexion = new ConexionDAL();
        }

        public bool Agregar(DepartamentoBLL oDepartamentoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Departamento VALUES(@Departamente)");
            SQLComando.Parameters.Add("@Departamente",SqlDbType.VarChar).Value=oDepartamentoBLL.Departamento;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

        }

        public bool Eliminar(DepartamentoBLL oDepartamentoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Departamento WHERE ID=@ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentoBLL.ID;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

            //conexion.EjecutarComandoSinRetornoDatos("DELETE FROM Departamento WHERE ID ="+oDepartamentoBLL.ID);    
        }

        public bool Modificar(DepartamentoBLL oDepartamentoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Departamento SET departamento=@Departamento WHERE ID=@ID");
            SQLComando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentoBLL.Departamento;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentoBLL.ID;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

            /*conexion.EjecutarComandoSinRetornoDatos("UPDATE Departamento " +
                " SET departamento='"+oDepartamentoBLL.Departamento+ "'" +
                " WHERE ID =" + oDepartamentoBLL.ID);*/


        }

        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamento");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
