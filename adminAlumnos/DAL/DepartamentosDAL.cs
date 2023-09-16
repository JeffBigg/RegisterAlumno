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
            return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Departamento(departamento) VALUES('"+oDepartamentoBLL.Departamento+"')");
        }

        public int Eliminar(DepartamentoBLL oDepartamentoBLL)
        {
            conexion.EjecutarComandoSinRetornoDatos("DELETE FROM Departamento WHERE ID ="+oDepartamentoBLL.ID);

            return 1;
        }
        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamento");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
