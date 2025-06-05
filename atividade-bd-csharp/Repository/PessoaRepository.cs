using atividade_bd_csharp.Entity;
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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly Connection _connection = new Connection();

        public async Task<IEnumerable<PessoaEntity>> GetAllPessoa()
        {
            using var con = _connection.GetConnection();
            string sql = "SELECT * FROM PESSOA";
            return await con.QueryAsync<PessoaEntity>(sql);
        }

        public async Task<PessoaEntity> GetPessoaById(int id)
        {
            using var con = _connection.GetConnection();
            string sql = "SELECT * FROM PESSOA WHERE ID = @id";
            return await con.QueryFirstOrDefaultAsync<PessoaEntity>(sql, new { id });
        }

        public async Task InsertPessoa(PessoaInsertDTO pessoa)
        {
            string sql = @"
                INSERT INTO PESSOA (NOME, DATANASCIMENTO, CPF, TELEFONE, EMAIL, SENHA, ENDERECOFOTO, CAOGUIA, CEP, BAIRRO, RUA, NUMEROENDERECO, CIDADE_ID)
                VALUES (@Nome, @DataNascimento, @CPF, @Telefone, @Email, @Senha, @EnderecoFoto, @CaoGuia, @CEP, @Bairro, @Rua, @NumeroEndereco, @Cidade_Id)";
            await _connection.Execute(sql, pessoa);
        }

        public async Task UpdatePessoa(PessoaEntity pessoa)
        {
            string sql = @"
                UPDATE PESSOA SET 
                    NOME = @Nome,
                    DATANASCIMENTO = @DataNascimento,
                    CPF = @CPF,
                    TELEFONE = @Telefone,
                    EMAIL = @Email,
                    SENHA = @Senha,
                    ENDERECOFOTO = @EnderecoFoto,
                    CAOGUIA = @CaoGuia,
                    CEP = @CEP,
                    BAIRRO = @Bairro,
                    RUA = @Rua,
                    NUMEROENDERECO = @NumeroEndereco,
                    CIDADE_ID = @Cidade_Id
                WHERE ID = @Id";
            await _connection.Execute(sql, pessoa);
        }

        public async Task DeletePessoa(int id)
        {
            string sql = "DELETE FROM PESSOA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
    }
}
