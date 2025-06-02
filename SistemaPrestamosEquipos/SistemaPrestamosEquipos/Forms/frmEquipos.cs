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
    public partial class frmEquipos : Form
    {
        private EquipoDAL equipoDAL = new EquipoDAL();
        private bool isEditing = false;

        public frmEquipos()
        {
            InitializeComponent();
            CargarEquipos();
            ConfigurarComboBoxEstado();
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void ConfigurarComboBoxEstado()
        {
            
            cboEstado.SelectedIndex = 0; // Estado por defecto
        }

        private void CargarEquipos()
        {
            try
            {
                dgvEquipos.DataSource = equipoDAL.ObtenerTodosEquipos();
                dgvEquipos.Columns["EquipoID"].Visible = false; // Ocultar ID si no es necesario mostrarlo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtEquipoID.Text = "";
            txtNombre.Text = "";
            txtNumeroSerie.Text = "";
            txtDescripcion.Text = "";
            cboEstado.SelectedIndex = 0;
        }

        private void HabilitarControles(bool enable)
        {
            txtNombre.Enabled = enable;
            txtNumeroSerie.Enabled = enable;
            txtDescripcion.Enabled = enable;
            cboEstado.Enabled = enable;
            btnGuardar.Enabled = enable;
            btnCancelar.Enabled = enable;
            btnNuevo.Enabled = !enable;
           
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEquipos.Rows[e.RowIndex];
                txtEquipoID.Text = row.Cells["EquipoID"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtNumeroSerie.Text = row.Cells["NumeroSerie"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                cboEstado.SelectedItem = row.Cells["Estado"].Value.ToString();

                HabilitarControles(false); // Deshabilitar edición al seleccionar
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(true);
            isEditing = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Equipo equipo = new Equipo
                {
                    Nombre = txtNombre.Text,
                    NumeroSerie = txtNumeroSerie.Text,
                    Descripcion = txtDescripcion.Text,
                    Estado = cboEstado.SelectedItem.ToString()
                };

                if (isEditing)
                {
                    equipo.EquipoID = Convert.ToInt32(txtEquipoID.Text);
                    equipoDAL.ActualizarEquipo(equipo);
                    MessageBox.Show("Equipo actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    equipoDAL.InsertarEquipo(equipo);
                    MessageBox.Show("Equipo guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarEquipos();
                LimpiarCampos();
                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                HabilitarControles(true);
                isEditing = true;
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este equipo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int equipoID = Convert.ToInt32(txtEquipoID.Text);
                        equipoDAL.EliminarEquipo(equipoID);
                        MessageBox.Show("Equipo eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEquipos();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(false);
            isEditing = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

