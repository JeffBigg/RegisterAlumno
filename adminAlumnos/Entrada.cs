using adminAlumnos.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminAlumnos
{
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            LoginAdmin registerForm = new LoginAdmin();
            registerForm.Show();
            this.Hide();
        }

        private void btnLoginAlumno_Click(object sender, EventArgs e)
        {
           LoginAlumnos registerForm = new LoginAlumnos();
            registerForm.Show();
            this.Hide();
        }
    }
}
