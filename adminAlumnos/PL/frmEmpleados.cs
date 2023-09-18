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

 
    }
}
