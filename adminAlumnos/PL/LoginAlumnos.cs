﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminAlumnos.PL
{
    public partial class LoginAlumnos : Form
    {
        private string cadenaConexion = "Data Source=localhost;Initial Catalog=dbSistema;Integrated Security=True";

        public LoginAlumnos()
        {
            InitializeComponent();
        }

        private void btnInicioSecion_Click(object sender, EventArgs e)
        {          
                string Usuario = txtNombreUsuario.Text;
                string contraseña = txtContraseña.Text;

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contraseña = @Contraseña";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    int resultado = (int)comando.ExecuteScalar();

                    if (resultado > 0)
                    {
                        frmAdmin registerForm = new frmAdmin();
                        registerForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("INCORRECTO");
                    }
                }           
        }
    }
}
