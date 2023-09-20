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
    internal class AlumnosDAL
    {
        ConexionDAL conexion;
        public AlumnosDAL()
        {
            conexion = new ConexionDAL();
        }
        public bool Agregar(AlumnosBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Empleado (nombre, primerapellido, segundoapellido, correo, foto)" +
                "VALUES (@Nombre,@Apellido1,@Apellido2,@Correo,@Foto)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlumnoBLL.Nombre;
            SQLComando.Parameters.Add("@Apellido1", SqlDbType.VarChar).Value = oAlumnoBLL.PrimerApellido;
            SQLComando.Parameters.Add("@Apellido2", SqlDbType.VarChar).Value = oAlumnoBLL.SegundoApellido;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oAlumnoBLL.Correo;

            SqlParameter fotoParam = new SqlParameter("@Foto", SqlDbType.VarBinary);
            fotoParam.Value = oAlumnoBLL.Foto;
            SQLComando.Parameters.Add(fotoParam);

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }
        public bool Eliminar(AlumnosBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Empleado WHERE ID=@ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oAlumnoBLL.ID;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

        }

        public bool Modificar(AlumnosBLL oAlumnoBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Empleado SET nombre=@Nombre, primerapellido=@Apellido1, segundoapellido=@Apellido2, correo=@Correo, foto=@Foto WHERE ID=@ID");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlumnoBLL.Nombre;
            SQLComando.Parameters.Add("@Apellido1", SqlDbType.VarChar).Value = oAlumnoBLL.PrimerApellido;
            SQLComando.Parameters.Add("@Apellido2", SqlDbType.VarChar).Value = oAlumnoBLL.SegundoApellido;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = oAlumnoBLL.Correo;
            SQLComando.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = oAlumnoBLL.Foto;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oAlumnoBLL.ID;


            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }


        public DataSet MostrarAlumnos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT E.ID, E.nombre, E.primerapellido, E.segundoapellido, E.correo, E.foto, D.departamento FROM Empleado E LEFT JOIN Departamento D ON E.ID = D.ID");
            return conexion.EjecutarSentencia(sentencia);
        }

    }
}
