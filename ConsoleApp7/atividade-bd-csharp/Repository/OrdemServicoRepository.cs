using ConsoleApp5.atividade_bd_csharp.Contracts.Repository;
using ConsoleApp5.atividade_bd_csharp.DTO;
using ConsoleApp5.atividade_bd_csharp.Entity;
using Dapper;
using MyFirstCRUD.Infrastructure;

namespace ConsoleApp5.atividade_bd_csharp.Repository
{
    class OrdemServicoRepository : IOrdemServicoRepository
    {
        public async Task Delete(int id)
        {
            var _connection = new Connection();
            string sql = "DELETE FROM ORDEMSERVICO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<OrdemServicoEntity>> GetAll()
        {
            var _connection = new Connection();
            using var con = _connection.GetConnection();
            string sql = "SELECT Id, DataCriacao, StatusOs, Pessoa_Id FROM ORDEMSERVICO";
            return await con.QueryAsync<OrdemServicoEntity>(sql);

        }

        public async Task<OrdemServicoEntity> GetById(int id)
        {
            var _connection = new Connection();
            using var con = _connection.GetConnection();
            string sql = "SELECT Id, DataCriacao, StatusOs, Pessoa_Id FROM ORDEMSERVICO WHERE Id = @id";
            return await con.QueryFirstAsync<OrdemServicoEntity>(sql, new { id });
        }

        public async Task Insert(OrdemServicoEntityDTO dto)
        {
            var _connection = new Connection();
            string sql = "INSERT INTO ORDEMSERVICO (DataCriacao, StatusOs, Pessoa_Id) VALUES (@DataCriacao, @StatusOs, @PessoaId)";
            await _connection.Execute(sql, dto);
        }

        public async Task Update(OrdemServicoEntity ordemServico)
        {
            var _connection = new Connection();
            string sql = "UPDATE ORDEMSERVICO SET DataCriacao = @DataCriacao, StatusOs = @StatusOs, Pessoa_Id = @PessoaId WHERE Id = @Id";
            await _connection.Execute(sql, ordemServico);
        }
    }
}

