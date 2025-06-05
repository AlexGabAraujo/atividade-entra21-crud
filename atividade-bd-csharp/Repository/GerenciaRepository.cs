using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstCRUD.Repository
{
    public class GerenciaRepository : IGerenciaRepository
    {
        private readonly Connection _connection = new Connection();

        public async Task<IEnumerable<GerenciaEntity>> GetAllGerencia()
        {
            using var con = _connection.GetConnection();
            string sql = "SELECT * FROM GERENCIA";
            return await con.QueryAsync<GerenciaEntity>(sql);
        }

        public async Task<GerenciaEntity> GetGerenciaById(int id)
        {
            using var con = _connection.GetConnection();
            string sql = "SELECT * FROM GERENCIA WHERE ID = @id";
            return await con.QueryFirstOrDefaultAsync<GerenciaEntity>(sql, new { id });
        }

        public async Task InsertGerencia(GerenciaInsertDTO gerencia)
        {
            string sql = @"
                INSERT INTO GERENCIA (ATIVO, DATAINICIO, DATAFIM, PESSOA_ID, HOTEL_ID)
                VALUES (@Ativo, @DataInicio, @DataFim, @Pessoa_Id, @Hotel_Id)";
            await _connection.Execute(sql, gerencia);
        }

        public async Task UpdateGerencia(GerenciaEntity gerencia)
        {
            string sql = @"
                UPDATE GERENCIA SET 
                    ATIVO = @Ativo,
                    DATAINICIO = @DataInicio,
                    DATAFIM = @DataFim,
                    PESSOA_ID = @Pessoa_Id,
                    HOTEL_ID = @Hotel_Id
                WHERE ID = @Id";
            await _connection.Execute(sql, gerencia);
        }

        public async Task DeleteGerenciaS(int id)
        {
            string sql = "DELETE FROM GERENCIA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
    }
}
