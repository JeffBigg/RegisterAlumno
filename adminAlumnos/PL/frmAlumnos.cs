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
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
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
            MessageBox.Show("Conectado..");
            oAlumnoDAL.Agregar(RecolectarDatos());

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
    }
}

