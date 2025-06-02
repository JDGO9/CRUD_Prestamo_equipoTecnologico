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
    public partial class frmUsuarioRoles : Form
    {
        private UsuarioRolDAL usuarioRolDAL = new UsuarioRolDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();
        private RolDAL rolDAL = new RolDAL();

        public frmUsuarioRoles()
        {
            InitializeComponent();
            CargarUsuarioRoles();
            CargarCombos();
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void CargarUsuarioRoles()
        {
            try
            {
                dgvUsuarioRoles.DataSource = usuarioRolDAL.ObtenerTodosUsuarioRoles();
                dgvUsuarioRoles.Columns["UsuarioRolID"].Visible = false;
                dgvUsuarioRoles.Columns["UsuarioID"].Visible = false;
                dgvUsuarioRoles.Columns["RolID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaciones de roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            cboUsuario.DataSource = usuarioDAL.ObtenerTodosUsuarios();
            cboUsuario.DisplayMember = "Nombre"; // O "NombreCompleto" si creas una propiedad combinada
            cboUsuario.ValueMember = "UsuarioID";
            cboUsuario.SelectedIndex = -1;

            cboRol.DataSource = rolDAL.ObtenerTodosRoles();
            cboRol.DisplayMember = "NombreRol";
            cboRol.ValueMember = "RolID";
            cboRol.SelectedIndex = -1;
        }

        private void LimpiarCampos()
        {
            txtUsuarioRolID.Text = "";
            cboUsuario.SelectedIndex = -1;
            cboRol.SelectedIndex = -1;
        }

        private void HabilitarControles(bool enable)
        {
            cboUsuario.Enabled = enable;
            cboRol.Enabled = enable;
            btnAsignarRol.Enabled = enable;
            btnCancelar.Enabled = enable;
            btnNuevo.Enabled = !enable;
            btnEliminar.Enabled = !enable && dgvUsuarioRoles.SelectedRows.Count > 0;
        }

        private void dgvUsuarioRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarioRoles.Rows[e.RowIndex];
                txtUsuarioRolID.Text = row.Cells["UsuarioRolID"].Value.ToString();
                cboUsuario.SelectedValue = Convert.ToInt32(row.Cells["UsuarioID"].Value);
                cboRol.SelectedValue = Convert.ToInt32(row.Cells["RolID"].Value);

                HabilitarControles(false);
                btnEliminar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(true);
        }

        private void btnAsignarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboUsuario.SelectedValue == null || cboRol.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un usuario y un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UsuarioRol usuarioRol = new UsuarioRol
                {
                    UsuarioID = Convert.ToInt32(cboUsuario.SelectedValue),
                    RolID = Convert.ToInt32(cboRol.SelectedValue)
                };

                usuarioRolDAL.InsertarUsuarioRol(usuarioRol);
                MessageBox.Show("Rol asignado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarioRoles();
                LimpiarCampos();
                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarioRoles.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar esta asignación de rol?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int usuarioRolID = Convert.ToInt32(txtUsuarioRolID.Text);
                        usuarioRolDAL.EliminarUsuarioRol(usuarioRolID);
                        MessageBox.Show("Asignación de rol eliminada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarioRoles();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar asignación de rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una asignación de rol para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(false);
        }
    }
}
