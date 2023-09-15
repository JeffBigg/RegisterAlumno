using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminAlumnos.BLL;
using adminAlumnos.DAL;
using System.Windows.Forms;



namespace adminAlumnos.PL
{
    public partial class frmDepartamentos : Form
    {
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecuperarInformacion();
            ConexionDAL conexion = new ConexionDAL();

            MessageBox.Show("Conectado.." + conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Departamento(departamento) VALUES('diseno')"));
        }

        private void RecuperarInformacion()
        {
            DepartamentoBLL oDepartamento = new DepartamentoBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oDepartamento.ID = ID;
            oDepartamento.Departamento = txtNombreDepartamento.Text;

            MessageBox.Show(oDepartamento.ID.ToString());
            MessageBox.Show(oDepartamento.Departamento);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
