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

namespace adminAlumnos.PL
{
    public partial class frmAlumnos : Form
    {
        AlumnosDAL oAlumnoDAL;
        byte[] imagenByte;
        public frmAlumnos()
        {
            oAlumnoDAL = new AlumnosDAL();    
            InitializeComponent();
            LlenarGrid();
            LimpiarEntradas();
        }
        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            DepartamentosDAL objDepartamentos = new DepartamentosDAL();
            cbxDepartamento.DataSource = objDepartamentos.MostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "ID";
        }


        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectorImagen = new OpenFileDialog();
            SelectorImagen.Title = "Seleccionar Imagen";
            if (SelectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(SelectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria,System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oAlumnoDAL.Agregar(RecolectarDatos());
            LlenarGrid();
            LimpiarEntradas();

        }

        private AlumnosBLL RecolectarDatos()
        {
            AlumnosBLL oAlumnosBLL  = new AlumnosBLL();

            int codigoEmpleado = 1;

            int.TryParse( txtID.Text,out codigoEmpleado);

            oAlumnosBLL.ID = codigoEmpleado;
            oAlumnosBLL.Nombre = txtNombre.Text;
            oAlumnosBLL.PrimerApellido = txtPrimerApellido.Text;
            oAlumnosBLL.SegundoApellido = txtSegundoApellido.Text;
            oAlumnosBLL.Correo = txtCorreo.Text;

            int IDDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(),out IDDepartamento);

            oAlumnosBLL.Departamento = IDDepartamento;
            oAlumnosBLL.Foto = imagenByte;

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
                cbxDepartamento.Text = dgvAlumnos.Rows[indice].Cells[5].Value.ToString();
                byte[] imagenBytes = (byte[])dgvAlumnos.Rows[indice].Cells[6].Value;

                if (imagenBytes != null && imagenBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        picFoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picFoto.Image = null; 
                }


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
            picFoto.Image = null;


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
            dgvAlumnos.Columns[5].HeaderText = "ESTADO";
            dgvAlumnos.Columns[6].HeaderText = "FOTO";


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
    }
}

