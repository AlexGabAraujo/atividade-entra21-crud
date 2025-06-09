
using ConsoleApp7.atividade_bd_csharp.Contracts.Repositori;
using ConsoleApp7.atividade_bd_csharp.DTO;
using ConsoleApp7.atividade_bd_csharp.Entity;
using ConsoleApp7.atividade_bd_csharp.Infrastructure;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp7.atividade_bd_csharp.Repository
{
    public class PrestadorServicoRepository : IPrestadorServico
    {
        private readonly Connection _connection = new();

        public async Task<IEnumerable<PrestadorServicoEntity>> GetAll()
        {
            using var db = _connection.GetConnection();
            return await db.QueryAsync<PrestadorServicoEntity>("SELECT * FROM PrestadorServico");
        }

        public async Task<PrestadorServicoEntity> GetById(int id)
        {
            using var db = _connection.GetConnection();
            return await db.QueryFirstOrDefaultAsync<PrestadorServicoEntity>(
                "SELECT * FROM PrestadorServico WHERE Id = @Id", new { Id = id });
        }

        public async Task Insert(PrestadorServicoEntityDTO dto)
        {
            using var db = _connection.GetConnection();
            string sql = @"INSERT INTO PrestadorServico 
                           (PrecoHora, Observacao, CNPJ, Especialidade_Id, Pessoa_Id)
                           VALUES (@PrecoHora, @Observacao, @CNPJ, @EspecialidadeId, @PessoaId)";
            await db.ExecuteAsync(sql, dto);
        }

        public async Task Update(PrestadorServicoEntity entity)
        {
            using var db = _connection.GetConnection();
            string sql = @"UPDATE PrestadorServico SET 
                           PrecoHora = @PrecoHora, 
                           Observacao = @Observacao, 
                           CNPJ = @CNPJ, 
                           Especialidade_Id = @EspecialidadeId, 
                           Pessoa_Id = @PessoaId 
                           WHERE Id = @Id";
            await db.ExecuteAsync(sql, entity);
        }

        public async Task Delete(int id)
        {
            using var db = _connection.GetConnection();
            await db.ExecuteAsync("DELETE FROM PrestadorServico WHERE Id = @Id", new { Id = id });
        }
    }
}
