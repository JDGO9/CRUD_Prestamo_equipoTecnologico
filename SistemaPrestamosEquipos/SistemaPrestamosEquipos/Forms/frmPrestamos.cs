using SistemaPrestamosEquipos.DAL;
using SistemaPrestamosEquipos.Models;
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
    public partial class frmPrestamos : Form
    {
        private PrestamoDAL prestamoDAL = new PrestamoDAL();
        private EquipoDAL equipoDAL = new EquipoDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public frmPrestamos()
        {
            InitializeComponent();
            CargarPrestamos();
            CargarCombos();
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void CargarPrestamos()
        {
            try
            {
                dgvPrestamos.DataSource = prestamoDAL.ObtenerTodosPrestamos();
                dgvPrestamos.Columns["PrestamoID"].Visible = false;
                dgvPrestamos.Columns["EquipoID"].Visible = false;
                dgvPrestamos.Columns["UsuarioID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            // Cargar ComboBox de Equipos
            cboEquipo.DataSource = equipoDAL.ObtenerTodosEquipos();
            cboEquipo.DisplayMember = "Nombre";
            cboEquipo.ValueMember = "EquipoID";
            cboEquipo.SelectedIndex = -1; // No seleccionar nada por defecto

            // Cargar ComboBox de Usuarios
            cboUsuario.DataSource = usuarioDAL.ObtenerTodosUsuarios();
            cboUsuario.DisplayMember = "Nombre"; // Puedes concatenar Nombre y Apellido si lo deseas
            cboUsuario.ValueMember = "UsuarioID";
            cboUsuario.SelectedIndex = -1; // No seleccionar nada por defecto
        }

        private void LimpiarCampos()
        {
            txtPrestamoID.Text = "";
            cboEquipo.SelectedIndex = -1;
            cboUsuario.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaDevolucionEsperada.Value = DateTime.Now.AddDays(7);
            txtEstadoPrestamo.Text = ""; // Se actualizará automáticamente
            btnRegistrarDevolucion.Enabled = false;
        }

        private void HabilitarControles(bool enable)
        {
            cboEquipo.Enabled = enable;
            cboUsuario.Enabled = enable;
            dtpFechaPrestamo.Enabled = enable;
            dtpFechaDevolucionEsperada.Enabled = enable;
            btnGuardar.Enabled = enable;
            btnCancelar.Enabled = enable;
            btnNuevo.Enabled = !enable;
            btnEliminar.Enabled = !enable && dgvPrestamos.SelectedRows.Count > 0;
            // El botón de devolución se habilita solo cuando se selecciona un préstamo activo
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPrestamos.Rows[e.RowIndex];
                txtPrestamoID.Text = row.Cells["PrestamoID"].Value.ToString();
                cboEquipo.SelectedValue = Convert.ToInt32(row.Cells["EquipoID"].Value);
                cboUsuario.SelectedValue = Convert.ToInt32(row.Cells["UsuarioID"].Value);
                dtpFechaPrestamo.Value = Convert.ToDateTime(row.Cells["FechaPrestamo"].Value);
                dtpFechaDevolucionEsperada.Value = Convert.ToDateTime(row.Cells["FechaDevolucionEsperada"].Value);
                txtEstadoPrestamo.Text = row.Cells["EstadoPrestamo"].Value.ToString();

                // Habilitar botón de devolución solo si el préstamo está activo
                btnRegistrarDevolucion.Enabled = (txtEstadoPrestamo.Text == "Activo");
                HabilitarControles(false);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboEquipo.SelectedValue == null || cboUsuario.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un equipo y un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Prestamo prestamo = new Prestamo
                {
                    EquipoID = Convert.ToInt32(cboEquipo.SelectedValue),
                    UsuarioID = Convert.ToInt32(cboUsuario.SelectedValue),
                    FechaPrestamo = dtpFechaPrestamo.Value,
                    FechaDevolucionEsperada = dtpFechaDevolucionEsperada.Value
                };

                // Siempre es un nuevo préstamo, la edición es para la devolución
                prestamoDAL.RealizarPrestamo(prestamo);
                MessageBox.Show("Préstamo registrado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPrestamos();
                LimpiarCampos();
                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea registrar la devolución de este equipo?", "Confirmar Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int prestamoID = Convert.ToInt32(txtPrestamoID.Text);
                        int equipoID = Convert.ToInt32(cboEquipo.SelectedValue); // Obtener el EquipoID del préstamo seleccionado

                        prestamoDAL.RegistrarDevolucion(prestamoID, equipoID);
                        MessageBox.Show("Devolución registrada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrestamos();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo activo para registrar la devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este registro de préstamo? (Esto no cambiará el estado del equipo si ya fue devuelto)", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int prestamoID = Convert.ToInt32(txtPrestamoID.Text);
                        prestamoDAL.EliminarPrestamo(prestamoID);
                        MessageBox.Show("Préstamo eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrestamos();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(false);
        }
    }

}

