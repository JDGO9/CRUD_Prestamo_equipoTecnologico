using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.DAL
{
    public class ReporteDAL : DbConnection
    {
        
        public DataTable GetReporteEquiposEnPrestamo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_ReporteEquiposEnPrestamo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                   
                    connection.Open(); 
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt); 
                    }
                }
            }
            return dt;
        }
        public DataTable GetHistorialPrestamosPorUsuario(int usuarioID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_HistorialPrestamosPorUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable GetReportePrestamosVencidos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_ReportePrestamosVencidos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
