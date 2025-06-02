namespace SistemaPrestamosEquipos.Forms
{
    partial class frmReportes
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
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.cboUsuariosReporte = new System.Windows.Forms.ComboBox();
            this.btnReporteEquiposEnPrestamo = new System.Windows.Forms.Button();
            this.btnReporteHistorialUsuario = new System.Windows.Forms.Button();
            this.btnReportePrestamosVencidos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(70, 305);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 24;
            this.dgvReporte.Size = new System.Drawing.Size(843, 229);
            this.dgvReporte.TabIndex = 0;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Javanese Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.Location = new System.Drawing.Point(302, 27);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(0, 69);
            this.lblTituloReporte.TabIndex = 1;
            // 
            // cboUsuariosReporte
            // 
            this.cboUsuariosReporte.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuariosReporte.FormattingEnabled = true;
            this.cboUsuariosReporte.Location = new System.Drawing.Point(344, 119);
            this.cboUsuariosReporte.Name = "cboUsuariosReporte";
            this.cboUsuariosReporte.Size = new System.Drawing.Size(278, 53);
            this.cboUsuariosReporte.TabIndex = 2;
            // 
            // btnReporteEquiposEnPrestamo
            // 
            this.btnReporteEquiposEnPrestamo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReporteEquiposEnPrestamo.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEquiposEnPrestamo.Location = new System.Drawing.Point(84, 213);
            this.btnReporteEquiposEnPrestamo.Name = "btnReporteEquiposEnPrestamo";
            this.btnReporteEquiposEnPrestamo.Size = new System.Drawing.Size(234, 66);
            this.btnReporteEquiposEnPrestamo.TabIndex = 3;
            this.btnReporteEquiposEnPrestamo.Text = "Equipos en prestamo";
            this.btnReporteEquiposEnPrestamo.UseVisualStyleBackColor = false;
            this.btnReporteEquiposEnPrestamo.Click += new System.EventHandler(this.btnReporteEquiposEnPrestamo_Click);
            // 
            // btnReporteHistorialUsuario
            // 
            this.btnReporteHistorialUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReporteHistorialUsuario.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteHistorialUsuario.Location = new System.Drawing.Point(388, 213);
            this.btnReporteHistorialUsuario.Name = "btnReporteHistorialUsuario";
            this.btnReporteHistorialUsuario.Size = new System.Drawing.Size(204, 66);
            this.btnReporteHistorialUsuario.TabIndex = 4;
            this.btnReporteHistorialUsuario.Text = "Historial";
            this.btnReporteHistorialUsuario.UseVisualStyleBackColor = false;
            this.btnReporteHistorialUsuario.Click += new System.EventHandler(this.btnReporteHistorialUsuario_Click);
            // 
            // btnReportePrestamosVencidos
            // 
            this.btnReportePrestamosVencidos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReportePrestamosVencidos.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePrestamosVencidos.Location = new System.Drawing.Point(664, 213);
            this.btnReportePrestamosVencidos.Name = "btnReportePrestamosVencidos";
            this.btnReportePrestamosVencidos.Size = new System.Drawing.Size(226, 66);
            this.btnReportePrestamosVencidos.TabIndex = 5;
            this.btnReportePrestamosVencidos.Text = "Prestamos vencidos";
            this.btnReportePrestamosVencidos.UseVisualStyleBackColor = false;
            this.btnReportePrestamosVencidos.Click += new System.EventHandler(this.btnReportePrestamosVencidos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Javanese Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 69);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reportes";
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1001, 563);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReportePrestamosVencidos);
            this.Controls.Add(this.btnReporteHistorialUsuario);
            this.Controls.Add(this.btnReporteEquiposEnPrestamo);
            this.Controls.Add(this.cboUsuariosReporte);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.dgvReporte);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.ComboBox cboUsuariosReporte;
        private System.Windows.Forms.Button btnReporteEquiposEnPrestamo;
        private System.Windows.Forms.Button btnReporteHistorialUsuario;
        private System.Windows.Forms.Button btnReportePrestamosVencidos;
        private System.Windows.Forms.Label label2;
    }
}