using SistemaPrestamosEquipos.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPrestamosEquipos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnGestionEquipos_Click(object sender, EventArgs e)
        {
            frmEquipos formEquipos = new frmEquipos();
            formEquipos.ShowDialog();
        }

        // Ejemplo de método para abrir frmUsuarios (asumiendo un botón btnGestionUsuarios)
        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios formUsuarios = new frmUsuarios();
            formUsuarios.ShowDialog();
        }

        // Ejemplo de método para abrir frmPrestamos (asumiendo un botón btnGestionPrestamos)
        private void btnGestionPrestamos_Click(object sender, EventArgs e)
        {
            frmPrestamos formPrestamos = new frmPrestamos();
            formPrestamos.ShowDialog();
        }

        // Ejemplo de método para abrir frmRoles (asumiendo un botón btnGestionRoles)
        private void btnGestionRoles_Click(object sender, EventArgs e)
        {
            frmRoles formRoles = new frmRoles();
            formRoles.ShowDialog();
        }

        // Ejemplo de método para abrir frmUsuarioRoles (asumiendo un botón btnGestionUsuarioRoles)
        private void btnGestionUsuarioRoles_Click(object sender, EventArgs e)
        {
            frmUsuarioRoles formUsuarioRoles = new frmUsuarioRoles();
            formUsuarioRoles.ShowDialog();
        }

        // Ejemplo de método para abrir frmReportes (asumiendo un botón btnVerReportes)
        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            frmReportes formReportes = new frmReportes();
            formReportes.ShowDialog();
        }

    }
}

