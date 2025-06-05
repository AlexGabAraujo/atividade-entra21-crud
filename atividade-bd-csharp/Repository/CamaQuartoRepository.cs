using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.Entity;
using MyFirstCRUD.infrastructure;

namespace atividade_bd_csharp.Repository
{
    public class CamaQuartoRepository : ICamaQuartoRepository
    {
            private readonly Connection _connection;

            public CamaQuartoRepository(Connection connection)
            {
                _connection = connection;
            }

        public async Task<IEnumerable<CamaQuartoEntity>> GetAll()
        {
            using var con = _connection.GetConnection();    


        }


    }
}
