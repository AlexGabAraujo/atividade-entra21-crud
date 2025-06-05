using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Contracts.Repository;

namespace MyFirstCRUD.Repository
{
    public class LembreteRepository : ILembreteRepository
    {
        private readonly Connection _connection = new Connection();

        public async Task<IEnumerable<LembreteEntity>> GetAllLembrete()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @"
                    SELECT ID, TITULO, DESCRICAO, DATAINICIO, DATAFIM, FREQUENCIA, PESSOA_ID 
                    FROM LEMBRETE";
                return await con.QueryAsync<LembreteEntity>(sql);
            }
        }

        public async Task<LembreteEntity> GetLembreteById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = "SELECT * FROM LEMBRETE WHERE ID = @id";
                return await con.QueryFirstOrDefaultAsync<LembreteEntity>(sql, new { id });
            }
        }

        public async Task InsertLembrete(LembreteInsertDTO lembrete)
        {
            string sql = @"
                INSERT INTO LEMBRETE (TITULO, DESCRICAO, DATAINICIO, DATAFIM, FREQUENCIA, PESSOA_ID)
                VALUES (@Titulo, @Descricao, @DataInicio, @DataFim, @Frequencia, @Pessoa_Id)";
            await _connection.Execute(sql, lembrete);
        }

        public async Task UpdateLembrete(LembreteEntity lembrete)
        {
            string sql = @"
                UPDATE LEMBRETE SET 
                    TITULO = @Titulo,
                    DESCRICAO = @Descricao,
                    DATAINICIO = @DataInicio,
                    DATAFIM = @DataFim,
                    FREQUENCIA = @Frequencia,
                    PESSOA_ID = @Pessoa_Id
                WHERE ID = @Id";
            await _connection.Execute(sql, lembrete);
        }

        public async Task DeleteLembrete(int id)
        {
            string sql = "DELETE FROM LEMBRETE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
    }
}
