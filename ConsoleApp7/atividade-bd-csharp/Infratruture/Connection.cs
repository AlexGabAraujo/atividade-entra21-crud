using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConsoleApp7.atividade_bd_csharp.Infrastructure
{
    public class Connection
    {
  
        private readonly string _connectionString = "Server=localhost;Database=SeuBanco;Trusted_Connection=True;";

        public IDbConnection GetConnection() => new MySqlConnection(_connectionString);
    }
}

