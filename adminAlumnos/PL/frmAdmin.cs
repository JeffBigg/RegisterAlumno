using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adminAlumnos.DAL;
using adminAlumnos.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace adminAlumnos.PL
{
    public partial class frmAdmin : Form
    {
        AdminDAL oAlumnoDAL;
        byte[] imagenByte;
        public frmAdmin()
        {
            oAlumnoDAL = new AdminDAL();    
            InitializeComponent();
            LlenarGrid();
            LimpiarEntradas();
        }
        private void frmAlumnos_Load(object sender, EventArgs e)
        {

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oAlumnoDAL.Agregar(RecolectarDatos());
            LlenarGrid();
            LimpiarEntradas();

        }

        private AdminBLL RecolectarDatos()
        {
            AdminBLL oAlumnosBLL  = new AdminBLL();

            int codigoEmpleado = 1;
            int edad;

            int.TryParse( txtID.Text,out codigoEmpleado);
            int.TryParse(txtEdad.Text, out edad);

            oAlumnosBLL.ID = codigoEmpleado;
            oAlumnosBLL.Nombre = txtNombre.Text;
            oAlumnosBLL.PrimerApellido = txtPrimerApellido.Text;
            oAlumnosBLL.SegundoApellido = txtSegundoApellido.Text;
            oAlumnosBLL.Correo = txtCorreo.Text;
            oAlumnosBLL.Edad = edad;
            oAlumnosBLL.Nivel = cbxNivel.Text;

            return oAlumnosBLL;

        }
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvAlumnos.ClearSelection();

            if (indice >= 0)
            {


                txtID.Text = dgvAlumnos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvAlumnos.Rows[indice].Cells[1].Value.ToString();
                txtPrimerApellido.Text = dgvAlumnos.Rows[indice].Cells[2].Value.ToString();
                txtSegundoApellido.Text = dgvAlumnos.Rows[indice].Cells[3].Value.ToString();
                txtCorreo.Text = dgvAlumnos.Rows[indice].Cells[4].Value.ToString();
                txtEdad.Text = dgvAlumnos.Rows[indice].Cells[5].Value.ToString();
                cbxNivel.Text = dgvAlumnos.Rows[indice].Cells[6].Value.ToString();


                btnAgregar.Enabled = false;
                btnBorrar.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oAlumnoDAL.Eliminar(RecolectarDatos());
            LlenarGrid();
            LimpiarEntradas();
        }
        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtCorreo.Text = "";
            txtEdad.Text = "";
            cbxNivel.Text = "";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;



        }

        public void LlenarGrid()
        {

            dgvAlumnos.DataSource = oAlumnoDAL.MostrarAlumnos().Tables[0];

            dgvAlumnos.Columns[0].HeaderText = "ID";
            dgvAlumnos.Columns[1].HeaderText = "NOMBRE";
            dgvAlumnos.Columns[2].HeaderText = "APELLIDO P";
            dgvAlumnos.Columns[3].HeaderText = "APELLIDO M";
            dgvAlumnos.Columns[4].HeaderText = "CORREO";
            dgvAlumnos.Columns[5].HeaderText = "EDAD";
            dgvAlumnos.Columns[6].HeaderText = "NIVEL";



        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oAlumnoDAL.Modificar(RecolectarDatos());
            LlenarGrid();
            LimpiarEntradas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos(txtBuscar.Text);
        }
        private void FiltrarDatos(string textoBusqueda)
        {
            DataTable dtOriginal = oAlumnoDAL.MostrarAlumnos().Tables[0];

            DataView dv = new DataView(dtOriginal);

            string filtro = string.Empty;

            foreach (DataColumn column in dtOriginal.Columns)
            {
                if (column.DataType == typeof(string))
                {
                    if (!string.IsNullOrEmpty(filtro))
                        filtro += " OR ";

                    filtro += $"{column.ColumnName} LIKE '%{textoBusqueda}%'";
                }
            }
            dv.RowFilter = filtro;
            dgvAlumnos.DataSource = dv;
        }
    }
}

