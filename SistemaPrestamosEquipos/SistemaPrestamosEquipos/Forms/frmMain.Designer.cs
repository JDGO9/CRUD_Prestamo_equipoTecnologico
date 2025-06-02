namespace SistemaPrestamosEquipos
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGestionEquipos = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnGestionUsuarioRoles = new System.Windows.Forms.Button();
            this.btnVerReportes = new System.Windows.Forms.Button();
            this.btnGestionPrestamos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionEquipos
            // 
            this.btnGestionEquipos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGestionEquipos.Font = new System.Drawing.Font("Javanese Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionEquipos.Location = new System.Drawing.Point(242, 55);
            this.btnGestionEquipos.Name = "btnGestionEquipos";
            this.btnGestionEquipos.Size = new System.Drawing.Size(313, 123);
            this.btnGestionEquipos.TabIndex = 0;
            this.btnGestionEquipos.Text = "Gestión de equipos";
            this.btnGestionEquipos.UseVisualStyleBackColor = false;
            this.btnGestionEquipos.Click += new System.EventHandler(this.btnGestionEquipos_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Javanese Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuarios.Location = new System.Drawing.Point(732, 55);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(313, 123);
            this.btnGestionUsuarios.TabIndex = 1;
            this.btnGestionUsuarios.Text = "Gestión de Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = false;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionUsuarioRoles
            // 
            this.btnGestionUsuarioRoles.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGestionUsuarioRoles.Font = new System.Drawing.Font("Javanese Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuarioRoles.Location = new System.Drawing.Point(732, 250);
            this.btnGestionUsuarioRoles.Name = "btnGestionUsuarioRoles";
            this.btnGestionUsuarioRoles.Size = new System.Drawing.Size(313, 123);
            this.btnGestionUsuarioRoles.TabIndex = 3;
            this.btnGestionUsuarioRoles.Text = "Gestión de roles de usuarios";
            this.btnGestionUsuarioRoles.UseVisualStyleBackColor = false;
            this.btnGestionUsuarioRoles.Click += new System.EventHandler(this.btnGestionUsuarioRoles_Click);
            // 
            // btnVerReportes
            // 
            this.btnVerReportes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnVerReportes.Font = new System.Drawing.Font("Javanese Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerReportes.Location = new System.Drawing.Point(491, 440);
            this.btnVerReportes.Name = "btnVerReportes";
            this.btnVerReportes.Size = new System.Drawing.Size(313, 123);
            this.btnVerReportes.TabIndex = 4;
            this.btnVerReportes.Text = "Ver Reportes";
            this.btnVerReportes.UseVisualStyleBackColor = false;
            this.btnVerReportes.Click += new System.EventHandler(this.btnVerReportes_Click);
            // 
            // btnGestionPrestamos
            // 
            this.btnGestionPrestamos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGestionPrestamos.Font = new System.Drawing.Font("Javanese Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionPrestamos.Location = new System.Drawing.Point(242, 250);
            this.btnGestionPrestamos.Name = "btnGestionPrestamos";
            this.btnGestionPrestamos.Size = new System.Drawing.Size(313, 123);
            this.btnGestionPrestamos.TabIndex = 5;
            this.btnGestionPrestamos.Text = "Prestamos";
            this.btnGestionPrestamos.UseVisualStyleBackColor = false;
            this.btnGestionPrestamos.Click += new System.EventHandler(this.btnGestionPrestamos_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1352, 616);
            this.Controls.Add(this.btnGestionPrestamos);
            this.Controls.Add(this.btnVerReportes);
            this.Controls.Add(this.btnGestionUsuarioRoles);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnGestionEquipos);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionEquipos;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnGestionUsuarioRoles;
        private System.Windows.Forms.Button btnVerReportes;
        private System.Windows.Forms.Button btnGestionPrestamos;
    }
}

