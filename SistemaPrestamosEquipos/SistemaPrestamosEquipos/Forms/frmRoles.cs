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
    public partial class frmRoles : Form
    {
        private RolDAL rolDAL = new RolDAL();
        private bool isEditing = false;

        public frmRoles()
        {
            InitializeComponent();
            CargarRoles();
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void CargarRoles()
        {
            try
            {
                dgvRoles.DataSource = rolDAL.ObtenerTodosRoles();
                dgvRoles.Columns["RolID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtRolID.Text = "";
            txtNombreRol.Text = "";
        }

        private void HabilitarControles(bool enable)
        {
            txtNombreRol.Enabled = enable;
            btnGuardar.Enabled = enable;
            btnCancelar.Enabled = enable;
            btnNuevo.Enabled = !enable;
            btnEditar.Enabled = !enable && dgvRoles.SelectedRows.Count > 0;
            btnEliminar.Enabled = !enable && dgvRoles.SelectedRows.Count > 0;
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoles.Rows[e.RowIndex];
                txtRolID.Text = row.Cells["RolID"].Value.ToString();
                txtNombreRol.Text = row.Cells["NombreRol"].Value.ToString();

                HabilitarControles(false);
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
                Rol rol = new Rol
                {
                    NombreRol = txtNombreRol.Text
                };

                if (isEditing)
                {
                    rol.RolID = Convert.ToInt32(txtRolID.Text);
                    rolDAL.ActualizarRol(rol);
                    MessageBox.Show("Rol actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rolDAL.InsertarRol(rol);
                    MessageBox.Show("Rol guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarRoles();
                LimpiarCampos();
                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                HabilitarControles(true);
                isEditing = true;
            }
            else
            {
                MessageBox.Show("Seleccione un rol para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este rol?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int rolID = Convert.ToInt32(txtRolID.Text);
                        rolDAL.EliminarRol(rolID);
                        MessageBox.Show("Rol eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRoles();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(false);
            isEditing = false;
        }
    }
}
