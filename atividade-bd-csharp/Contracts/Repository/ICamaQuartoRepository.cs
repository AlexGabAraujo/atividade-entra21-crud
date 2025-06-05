using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;

namespace atividade_bd_csharp.Contracts.Repository
{
    interface ICamaQuartoRepository
    {
        public IEnumerable<Entity.CamaQuartoEntity> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {

            }
        }

    }
}