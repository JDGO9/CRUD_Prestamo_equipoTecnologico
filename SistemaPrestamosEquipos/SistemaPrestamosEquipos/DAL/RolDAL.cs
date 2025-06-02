using SistemaPrestamosEquipos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class RolDAL : DbConnection
    {
        public List<Rol> ObtenerTodosRoles()
        {
            List<Rol> roles = new List<Rol>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT RolID, NombreRol FROM Roles";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Rol
                            {
                                RolID = Convert.ToInt32(reader["RolID"]),
                                NombreRol = reader["NombreRol"].ToString()
                            });
                        }
                    }
                }
            }
            return roles;
        }

        public void InsertarRol(Rol rol)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO Roles (NombreRol) VALUES (@NombreRol)";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@NombreRol", rol.NombreRol);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al insertar rol: " + ex.Message);
                }
            }
        }

        public void ActualizarRol(Rol rol)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "UPDATE Roles SET NombreRol = @NombreRol WHERE RolID = @RolID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@NombreRol", rol.NombreRol);
                        command.Parameters.AddWithValue("@RolID", rol.RolID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al actualizar rol: " + ex.Message);
                }
            }
        }

        public void EliminarRol(int rolID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "DELETE FROM Roles WHERE RolID = @RolID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@RolID", rolID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar rol: " + ex.Message);
                }
            }
        }
    }
}
