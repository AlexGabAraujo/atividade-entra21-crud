using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using Dapper;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;

namespace atividade_bd_csharp.Repository
{
    internal class AssentoRepository : IAssentoRepository
    {
        public async Task<IEnumerable<AssentoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                       SELECT ID AS {nameof(AssentoEntity.Id)},
                        NUMERO AS {nameof(AssentoEntity.Numero)},
                        TIPO AS {nameof(AssentoEntity.Tipo)},
                        AVIAO_ID AS {nameof(AssentoEntity.Aviao_Id)}
                        FROM ASSENTO
                ";

                IEnumerable<AssentoEntity> assentoList = await con.QueryAsync<AssentoEntity>(sql);
                return assentoList;
            }
        }

        public async Task<AssentoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT ID AS {nameof(AssentoEntity.Id)},
                        NUMERO AS {nameof(AssentoEntity.Numero)},
                        TIPO AS {nameof(AssentoEntity.Tipo)},
                        AVIAO_ID AS {nameof(AssentoEntity.Aviao_Id)}
                        FROM ASSENTO
                        WHERE ID = @id
                ";

                AssentoEntity assento = await con.QueryFirstAsync<AssentoEntity>(sql, new { id });
                return assento;
            }
        }

        public async Task Insert(AssentoInsertDTO assento)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO ASSENTO (NUMERO, TIPO, AVIAO_ID)
                    VALUES (@Numero, @Tipo, @Aviao_Id)
            ";

            await _connection.Execute(sql, assento);
        }

        public async Task Update(AssentoEntity assento)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE ASSENTO
                    SET NUMERO = @Numero,
                    TIPO = @Tipo,
                    AVIAO_ID = @Aviao_Id
                    WHERE ID = @Id
            ";

            await _connection.Execute(sql, assento);
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM ASSENTO WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

    }
}
