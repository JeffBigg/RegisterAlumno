using adminAlumnos.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adminAlumnos.BLL;
using System.Data.SqlClient;

namespace adminAlumnos.PL
{
    public partial class frmAlumno : Form
    {
        private string cadenaConexion = "Data Source=localhost;Initial Catalog=dbSistema;Integrated Security=True";
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Empleado"; // Reemplaza "TuTabla" con el nombre de tu tabla

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Asigna la tabla de datos al DataGridView en tu formulario
                dgvid.DataSource = dataTable;
            }

        }

    }
}
