using SistemaPrestamosEquipos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class UsuarioDAL : DbConnection
    {
        public List<Usuario> ObtenerTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT UsuarioID, Nombre, Apellido, DNI, CorreoElectronico, Departamento FROM Usuarios";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = reader["DNI"].ToString(),
                                CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                Departamento = reader["Departamento"].ToString()
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO Usuarios (Nombre, Apellido, DNI, CorreoElectronico, Departamento) VALUES (@Nombre, @Apellido, @DNI, @CorreoElectronico, @Departamento)";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@DNI", usuario.DNI);
                        command.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                        command.Parameters.AddWithValue("@Departamento", usuario.Departamento);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al insertar usuario: " + ex.Message);
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, CorreoElectronico = @CorreoElectronico, Departamento = @Departamento WHERE UsuarioID = @UsuarioID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@DNI", usuario.DNI);
                        command.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                        command.Parameters.AddWithValue("@Departamento", usuario.Departamento);
                        command.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al actualizar usuario: " + ex.Message);
                }
            }
        }

        public void EliminarUsuario(int usuarioID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar usuario: " + ex.Message);
                }
            }
        }
    }
}
