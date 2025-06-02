using SistemaPrestamosEquipos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class UsuarioRolDAL : DbConnection
    {
        public List<UsuarioRol> ObtenerTodosUsuarioRoles()
        {
            List<UsuarioRol> usuarioRoles = new List<UsuarioRol>();
            using (SqlConnection connection = GetConnection())
            {
                string query = @"SELECT ur.UsuarioRolID, ur.UsuarioID, ur.RolID,
                                 u.Nombre + ' ' + u.Apellido AS NombreUsuario, r.NombreRol
                                 FROM UsuarioRoles ur
                                 INNER JOIN Usuarios u ON ur.UsuarioID = u.UsuarioID
                                 INNER JOIN Roles r ON ur.RolID = r.RolID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarioRoles.Add(new UsuarioRol
                            {
                                UsuarioRolID = Convert.ToInt32(reader["UsuarioRolID"]),
                                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                                RolID = Convert.ToInt32(reader["RolID"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                NombreRol = reader["NombreRol"].ToString()
                            });
                        }
                    }
                }
            }
            return usuarioRoles;
        }

        public void InsertarUsuarioRol(UsuarioRol usuarioRol)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO UsuarioRoles (UsuarioID, RolID) VALUES (@UsuarioID, @RolID)";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioRol.UsuarioID);
                        command.Parameters.AddWithValue("@RolID", usuarioRol.RolID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al asignar rol a usuario: " + ex.Message);
                }
            }
        }

        public void EliminarUsuarioRol(int usuarioRolID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "DELETE FROM UsuarioRoles WHERE UsuarioRolID = @UsuarioRolID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UsuarioRolID", usuarioRolID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar asignación de rol: " + ex.Message);
                }
            }
        }
    }
}
