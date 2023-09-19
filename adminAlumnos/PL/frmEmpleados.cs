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
    public partial class frmEmpleados : Form
    {
        byte[] imagenByte;
        public frmEmpleados()
        {
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
            RecolectarDatos();
        }

        private void RecolectarDatos()
        {
            EmpleadosBLL objEmpleados  = new EmpleadosBLL();

            int codigoEmpleado = 1;

            int.TryParse( txtID.Text,out codigoEmpleado);

            objEmpleados.ID = codigoEmpleado;
            objEmpleados.NombreEmpleado = txtNombre.Text;
            objEmpleados.PrimerApellido = txtPrimerApellido.Text;
            objEmpleados.SegundoApellido = txtSegundoApellido.Text;
            objEmpleados.Correo = txtCorreo.Text;

            int IDDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(),out IDDepartamento);

            objEmpleados.Departamento = IDDepartamento;
            objEmpleados.FotoEmpleado = imagenByte;
        }
    }
}
