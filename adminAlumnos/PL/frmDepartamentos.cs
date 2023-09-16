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
        DepartamentosDAL oDepartamentosDAL;
        public frmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            dvgDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conectado..");
            //clase DAL departamentos.. objetos que tiene la informacion de la GUI
            oDepartamentosDAL.Agregar(RecuperarInformacion());
            dvgDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

        }

        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oDepartamentoBLL.ID = ID;
            oDepartamentoBLL.Departamento = txtNombreDepartamento.Text;

            return oDepartamentoBLL;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            txtID.Text = dvgDepartamentos.Rows[indice].Cells[0].Value.ToString();
            txtNombreDepartamento.Text = dvgDepartamentos.Rows[indice].Cells[1].Value.ToString();   

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            dvgDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

        }
    }
}
