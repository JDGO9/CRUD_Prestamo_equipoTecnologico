using SistemaPrestamosEquipos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class EquipoDAL : DbConnection
    {
        public List<Equipo> ObtenerTodosEquipos()
        {
            List<Equipo> equipos = new List<Equipo>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT EquipoID, Nombre, NumeroSerie, Descripcion, Estado FROM Equipos";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipos.Add(new Equipo
                            {
                                EquipoID = Convert.ToInt32(reader["EquipoID"]),
                                Nombre = reader["Nombre"].ToString(),
                                NumeroSerie = reader["NumeroSerie"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }
                }
            }
            return equipos;
        }

        public void InsertarEquipo(Equipo equipo)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO Equipos (Nombre, NumeroSerie, Descripcion, Estado) VALUES (@Nombre, @NumeroSerie, @Descripcion, @Estado)";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                        command.Parameters.AddWithValue("@NumeroSerie", equipo.NumeroSerie);
                        command.Parameters.AddWithValue("@Descripcion", equipo.Descripcion);
                        command.Parameters.AddWithValue("@Estado", equipo.Estado);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al insertar equipo: " + ex.Message);
                }
            }
        }

        public void ActualizarEquipo(Equipo equipo)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "UPDATE Equipos SET Nombre = @Nombre, NumeroSerie = @NumeroSerie, Descripcion = @Descripcion, Estado = @Estado WHERE EquipoID = @EquipoID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                        command.Parameters.AddWithValue("@NumeroSerie", equipo.NumeroSerie);
                        command.Parameters.AddWithValue("@Descripcion", equipo.Descripcion);
                        command.Parameters.AddWithValue("@Estado", equipo.Estado);
                        command.Parameters.AddWithValue("@EquipoID", equipo.EquipoID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al actualizar equipo: " + ex.Message);
                }
            }
        }

        public void EliminarEquipo(int equipoID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "DELETE FROM Equipos WHERE EquipoID = @EquipoID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EquipoID", equipoID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar equipo: " + ex.Message);
                }
            }
        }
    }
}
