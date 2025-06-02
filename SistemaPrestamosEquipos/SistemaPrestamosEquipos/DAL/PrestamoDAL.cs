using SistemaPrestamosEquipos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class PrestamoDAL : DbConnection
    {
        public List<Prestamo> ObtenerTodosPrestamos()
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            using (SqlConnection connection = GetConnection())
            {
                string query = @"SELECT p.PrestamoID, p.EquipoID, p.UsuarioID, p.FechaPrestamo,
                                 p.FechaDevolucionEsperada, p.FechaDevolucionReal, p.EstadoPrestamo,
                                 e.Nombre AS NombreEquipo, u.Nombre + ' ' + u.Apellido AS NombreUsuario
                                 FROM Prestamos p
                                 INNER JOIN Equipos e ON p.EquipoID = e.EquipoID
                                 INNER JOIN Usuarios u ON p.UsuarioID = u.UsuarioID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prestamos.Add(new Prestamo
                            {
                                PrestamoID = Convert.ToInt32(reader["PrestamoID"]),
                                EquipoID = Convert.ToInt32(reader["EquipoID"]),
                                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                                FechaPrestamo = Convert.ToDateTime(reader["FechaPrestamo"]),
                                FechaDevolucionEsperada = Convert.ToDateTime(reader["FechaDevolucionEsperada"]),
                                FechaDevolucionReal = reader["FechaDevolucionReal"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaDevolucionReal"]),
                                EstadoPrestamo = reader["EstadoPrestamo"].ToString(),
                                NombreEquipo = reader["NombreEquipo"].ToString(),
                                NombreUsuario = reader["NombreUsuario"].ToString()
                            });
                        }
                    }
                }
            }
            return prestamos;
        }

        public void RealizarPrestamo(Prestamo prestamo)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    //Insertar el nuevo préstamo
                    string insertPrestamoQuery = "INSERT INTO Prestamos (EquipoID, UsuarioID, FechaPrestamo, FechaDevolucionEsperada, EstadoPrestamo) VALUES (@EquipoID, @UsuarioID, @FechaPrestamo, @FechaDevolucionEsperada, @EstadoPrestamo)";
                    using (SqlCommand command = new SqlCommand(insertPrestamoQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EquipoID", prestamo.EquipoID);
                        command.Parameters.AddWithValue("@UsuarioID", prestamo.UsuarioID);
                        command.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                        command.Parameters.AddWithValue("@FechaDevolucionEsperada", prestamo.FechaDevolucionEsperada);
                        command.Parameters.AddWithValue("@EstadoPrestamo", "Activo");
                        command.ExecuteNonQuery();
                    }

                    // 2. Actualizar el estado del equipo a 'En Préstamo'
                    string updateEquipoQuery = "UPDATE Equipos SET Estado = 'En Préstamo' WHERE EquipoID = @EquipoID";
                    using (SqlCommand command = new SqlCommand(updateEquipoQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EquipoID", prestamo.EquipoID);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al realizar préstamo: " + ex.Message);
                }
            }
        }

        public void RegistrarDevolucion(int prestamoID, int equipoID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Actualizar el préstamo a 'Devuelto' y registrar FechaDevolucionReal
                    string updatePrestamoQuery = "UPDATE Prestamos SET FechaDevolucionReal = GETDATE(), EstadoPrestamo = 'Devuelto' WHERE PrestamoID = @PrestamoID";
                    using (SqlCommand command = new SqlCommand(updatePrestamoQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@PrestamoID", prestamoID);
                        command.ExecuteNonQuery();
                    }

                    // Actualizar el estado del equipo a 'Disponible'
                    string updateEquipoQuery = "UPDATE Equipos SET Estado = 'Disponible' WHERE EquipoID = @EquipoID";
                    using (SqlCommand command = new SqlCommand(updateEquipoQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EquipoID", equipoID);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al registrar devolución: " + ex.Message);
                }
            }
        }

        // Para eliminar un préstamo 
        public void EliminarPrestamo(int prestamoID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Opcional: Si el préstamo se elimina, considerar qué pasa con el estado del equipo
                    // Por simplicidad, aquí solo se elimina el registro del préstamo.
                    // En un sistema real, se debería verificar el estado del equipo antes de eliminar.
                    string query = "DELETE FROM Prestamos WHERE PrestamoID = @PrestamoID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@PrestamoID", prestamoID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar préstamo: " + ex.Message);
                }
            }
        }
    }

}
