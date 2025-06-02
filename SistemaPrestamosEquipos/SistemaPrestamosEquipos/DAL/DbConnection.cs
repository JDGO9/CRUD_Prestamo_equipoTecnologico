using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; // Necesario para ConfigurationManager
using System.Collections.Generic;
using SistemaPrestamosEquipos.Models;


namespace SistemaPrestamosEquipos.DAL
{
    public class DbConnection
    {
        protected string connectionString;

        public DbConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SistemaPrestamosDB"].ConnectionString;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

