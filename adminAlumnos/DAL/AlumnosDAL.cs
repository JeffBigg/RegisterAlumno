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
            fotoParam.Value = oAlumnoBLL.Foto; // Asumiendo que oAlumnoBLL.Foto es un arreglo de bytes
            SQLComando.Parameters.Add(fotoParam);

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

        }
    }
}
