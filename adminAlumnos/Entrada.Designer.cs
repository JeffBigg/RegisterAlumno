namespace adminAlumnos
{
    partial class Entrada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoginAlumno = new System.Windows.Forms.Button();
            this.btnLoginAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al Sistema de Registro";
            // 
            // btnLoginAlumno
            // 
            this.btnLoginAlumno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAlumno.Location = new System.Drawing.Point(12, 121);
            this.btnLoginAlumno.Name = "btnLoginAlumno";
            this.btnLoginAlumno.Size = new System.Drawing.Size(313, 80);
            this.btnLoginAlumno.TabIndex = 1;
            this.btnLoginAlumno.Text = "INICIO SESION ALUMNO";
            this.btnLoginAlumno.UseVisualStyleBackColor = true;
            this.btnLoginAlumno.Click += new System.EventHandler(this.btnLoginAlumno_Click);
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAdmin.Location = new System.Drawing.Point(366, 121);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.Size = new System.Drawing.Size(313, 80);
            this.btnLoginAdmin.TabIndex = 2;
            this.btnLoginAdmin.Text = "INICIO SESION ADMINISTRADOR";
            this.btnLoginAdmin.UseVisualStyleBackColor = true;
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 253);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.btnLoginAlumno);
            this.Controls.Add(this.label1);
            this.Name = "Entrada";
            this.Text = "Entrada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoginAlumno;
        private System.Windows.Forms.Button btnLoginAdmin;
    }
}