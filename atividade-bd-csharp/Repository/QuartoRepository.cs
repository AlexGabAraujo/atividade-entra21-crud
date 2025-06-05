using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.Entity;
using Dapper;
using MyFirstCRUD.infrastructure;

namespace atividade_bd_csharp.Repository
{
    public class QuartoRepository : ICamaQuartoRepository
    {
        private readonly Connection _connection;

        public QuartoRepository(Connection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<QuartoEntity>> GetAll()
        {
            using (var con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT
                        HOTEL ID AS 
                        HOTEL CNPJ AS
                        HOTEL NOME AS 
                        HOTEL TIPO AS
                        HOTEL EMAIL AS
                        HOTEL TELEFONE AS
                        HOTEL ENDERECOFOTO AS
                        HOTEL SITE AS
                        HOTEL ACESSIBILIDADE AS
                        HOTEL CEP AS
                        HOTEL BAIRRO AS
                        HOTEL RUA AS
                        HOTEL NUMEROENDERECO AS
                        HOTEL CIDADE_ID AS
                        HOTEL NOME AS
                        FROM Hotel
                        LEFT JOIN CIDADE ON CIDADE_ID
                        ORDER BY HOTEL.NOME";

                IEnumerable<HotelEntity> hotellist = await con.QueryAsync< HotelEntity > (sql);
                return hotellist;
            }
            

        }
    }
}
