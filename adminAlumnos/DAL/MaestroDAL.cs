using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using adminAlumnos.BLL;
using System.Windows.Forms;

namespace adminAlumnos.DAL
{
    internal class MaestroDAL
    {
        ConexionDAL conexion;
        public MaestroDAL()
        {
            conexion = new ConexionDAL();
        }
        public bool Agregar(MaestroBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Empleado (nombre, primerapellido, segundoapellido, correo, edad, nivel)" +
                "VALUES (@Nombre,@Apellido1,@Apellido2,@Correo,@Edad,@Nivel)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlumnoBLL.Nombre;
            SQLComando.Parameters.Add("@Apellido1", SqlDbType.VarChar).Value = oAlumnoBLL.PrimerApellido;
            SQLComando.Parameters.Add("@Apellido2", SqlDbType.VarChar).Value = oAlumnoBLL.SegundoApellido;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oAlumnoBLL.Correo;
            SQLComando.Parameters.Add("@Edad", SqlDbType.Int).Value = oAlumnoBLL.Edad;
            SQLComando.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = oAlumnoBLL.Nivel;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }
        public bool Eliminar(MaestroBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Empleado WHERE ID=@ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oAlumnoBLL.ID;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

        }

        public bool Modificar(MaestroBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Empleado SET nombre=@Nombre, primerapellido=@Apellido1, segundoapellido=@Apellido2, edad=@Edad, correo=@Correo,nivel=@Nivel WHERE ID=@ID");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlumnoBLL.Nombre;
            SQLComando.Parameters.Add("@Apellido1", SqlDbType.VarChar).Value = oAlumnoBLL.PrimerApellido;
            SQLComando.Parameters.Add("@Apellido2", SqlDbType.VarChar).Value = oAlumnoBLL.SegundoApellido;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oAlumnoBLL.Correo;
            SQLComando.Parameters.Add("@Edad", SqlDbType.Int).Value = oAlumnoBLL.Edad;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oAlumnoBLL.ID;
            SQLComando.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = oAlumnoBLL.Nivel;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }


        public DataSet MostrarAlumnos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Empleado");
            return conexion.EjecutarSentencia(sentencia);
        }

    }
}
