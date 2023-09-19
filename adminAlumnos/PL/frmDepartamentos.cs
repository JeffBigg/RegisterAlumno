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
            LlegarGrid();
            LimpiarEntradas();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conectado..");
            //clase DAL departamentos.. objetos que tiene la informacion de la GUI
            oDepartamentosDAL.Agregar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }

        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oDepartamentoBLL.ID = ID;
            oDepartamentoBLL.Departamento = txtNombreDepartamento.Text;

            return oDepartamentoBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dvgDepartamentos.ClearSelection();

            if (indice>=0)
            {


                txtID.Text = dvgDepartamentos.Rows[indice].Cells[0].Value.ToString();
                txtNombreDepartamento.Text = dvgDepartamentos.Rows[indice].Cells[1].Value.ToString();

                btnAgregar.Enabled = false;
                btnBorrar.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }

        public void LlegarGrid()
        {
            dvgDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

            dvgDepartamentos.Columns[0].HeaderText = "ID";
            dvgDepartamentos.Columns[1].HeaderText = "Nombre Departamento";

        }

        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombreDepartamento.Text = "";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }


    }
}
