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
    public partial class frmUsuarios : Form
    {
       

        private UsuarioDAL usuarioDAL = new UsuarioDAL();
        private bool isEditing = false;

        public frmUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = usuarioDAL.ObtenerTodosUsuarios();
                dgvUsuarios.Columns["UsuarioID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtUsuarioID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtCorreoElectronico.Text = "";
            txtDepartamento.Text = "";
        }

        private void HabilitarControles(bool enable)
        {
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtDNI.Enabled = enable;
            txtCorreoElectronico.Enabled = enable;
            txtDepartamento.Enabled = enable;
            btnGuardar.Enabled = enable;
            btnCancelar.Enabled = enable;
            btnNuevo.Enabled = !enable;
            btnEditar.Enabled = !enable && dgvUsuarios.SelectedRows.Count > 0;
            btnEliminar.Enabled = !enable && dgvUsuarios.SelectedRows.Count > 0;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                txtUsuarioID.Text = row.Cells["UsuarioID"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtDNI.Text = row.Cells["DNI"].Value.ToString();
                txtCorreoElectronico.Text = row.Cells["CorreoElectronico"].Value.ToString();
                txtDepartamento.Text = row.Cells["Departamento"].Value.ToString();

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
                Usuario usuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    DNI = txtDNI.Text,
                    CorreoElectronico = txtCorreoElectronico.Text,
                    Departamento = txtDepartamento.Text
                };

                if (isEditing)
                {
                    usuario.UsuarioID = Convert.ToInt32(txtUsuarioID.Text);
                    usuarioDAL.ActualizarUsuario(usuario);
                    MessageBox.Show("Usuario actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuarioDAL.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarUsuarios();
                LimpiarCampos();
                HabilitarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                HabilitarControles(true);
                isEditing = true;
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int usuarioID = Convert.ToInt32(txtUsuarioID.Text);
                        usuarioDAL.EliminarUsuario(usuarioID);
                        MessageBox.Show("Usuario eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                        HabilitarControles(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarControles(false);
            isEditing = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}

