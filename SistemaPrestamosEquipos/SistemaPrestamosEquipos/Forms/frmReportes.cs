using SistemaPrestamosEquipos.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPrestamosEquipos.Forms
{
    public partial class frmReportes : Form
    {
        private ReporteDAL reporteDAL = new ReporteDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public frmReportes()
        {
            InitializeComponent();
            CargarUsuariosParaReporte(); // Para el reporte de historial por usuario
        }

        private void CargarUsuariosParaReporte()
        {
            // Asumiendo que tienes un ComboBox llamado cboUsuariosReporte en tu formulario
            // para seleccionar el usuario para el reporte de historial.
            cboUsuariosReporte.DataSource = usuarioDAL.ObtenerTodosUsuarios();
            cboUsuariosReporte.DisplayMember = "Nombre"; // O Nombre + Apellido
            cboUsuariosReporte.ValueMember = "UsuarioID";
            cboUsuariosReporte.SelectedIndex = -1;
        }

        private void btnReporteEquiposEnPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = reporteDAL.GetReporteEquiposEnPrestamo();
                dgvReporte.DataSource = dt;
                lblTituloReporte.Text = "Reporte de Equipos Actualmente en Préstamo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de equipos en préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteHistorialUsuario_Click(object sender, EventArgs e)
        {
            if (cboUsuariosReporte.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un usuario para generar el historial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int usuarioID = Convert.ToInt32(cboUsuariosReporte.SelectedValue);
                DataTable dt = reporteDAL.GetHistorialPrestamosPorUsuario(usuarioID);
                dgvReporte.DataSource = dt;
                lblTituloReporte.Text = $"Historial de Préstamos para: {cboUsuariosReporte.Text}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar historial de préstamos por usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

        }

        private void btnReportePrestamosVencidos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = reporteDAL.GetReportePrestamosVencidos();
                dgvReporte.DataSource = dt;
                lblTituloReporte.Text = "Reporte de Préstamos Vencidos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de préstamos vencidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
