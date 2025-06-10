using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using Dapper;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;

namespace MyFirstCRUD.Repository
{
    class AeroportoRepository : IAeroportoRepository
    {
        public async Task<IEnumerable<AeroportoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                     SELECT ID AS {nameof(AeroportoEntity.id)},
                            NOME AS {nameof(AeroportoEntity.Nome)},
                            CODIGOIATA AS {nameof(AeroportoEntity.CodigoIata)},
                           CIDADE_ID {nameof(AeroportoEntity.Cidade_id)}
                       FROM AEROPORTO
                ";
                IEnumerable<AeroportoEntity> aeroportoList = await con.QueryAsync<AeroportoEntity>(sql);
                return aeroportoList;
            }
        }
        public async Task Insert(AeroportoInsertDTO aeroporto)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO AEROPORTO (NOME,CODIGOIATA,CIDADE_ID)
                                VALUES (@Nome,@CodigoIata, @Cidade_ID)                                                         
            ";
            await _connection.Execute(sql, aeroporto);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM AEROPORTO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<AeroportoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                            SELECT ID AS {nameof(AeroportoEntity.id)},
                            NOME AS {nameof(AeroportoEntity.Nome)},
                            CODIGOIATA AS {nameof(AeroportoEntity.CodigoIata)},
                           CIDADE_ID {nameof(AeroportoEntity.Cidade_id)}
                       FROM AEROPORTO
                         WHERE ID = @Id
                              
                            ";
                AeroportoEntity aeroporto = await con.QueryFirstAsync<AeroportoEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(AeroportoEntity aeroporto)
        {
            Connection _connection = new Connection();
            string sql = @$"
                      UPDATE AEROPORTO
                               SET NOME = @Nome,
                               CODIGOIATA = @CodigoIata,
                               CIDADE_ID = @Cidade_id
                               WHERE ID = @Id;
                          ";
            await _connection.Execute(sql, aeroporto);
        }
    }
}
