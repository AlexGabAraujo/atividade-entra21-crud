using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using Dapper;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;

namespace atividade_bd_csharp.Repository
{
    class AviaoRepository : IAviaoRepository
    {
        public async Task<IEnumerable<AviaoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT ID AS {nameof(AviaoEntity.Id)},
                           QUANTIDADEVAGA AS {nameof(AviaoEntity.QuantidadeVaga)}
                           CODIGOREGISTRO AS {nameof(AviaoEntity.CodigoRegistro)}
                           COMPANHIA AS {nameof(AviaoEntity.Companhia)}
                           MODELO AS {nameof(AviaoEntity.Modelo)}
                           FABRICANTE AS {nameof(AviaoEntity.Fabricante)}
                      FROM AVIAO
                ";

                IEnumerable<AviaoEntity> aviaoList = await con.QueryAsync<AviaoEntity>(sql);

                return aviaoList;
            }
        }
        public async Task Insert(AviaoInsertDTO aviao)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO AVIAO (QUANTIDADEVAGA, CODIGOREGISTRO, COMPANHIA, MODELO, FABRICANTE)
                                VALUES (@QuantidadeVaga, @CodigoRegistro, @Companhia, @Modelo, @Fabricante)
                ";

            await _connection.Execute(sql, aviao);
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM AVIAO WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<AviaoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT ID AS {nameof(AviaoEntity.Id)},
                           QUANTIDADEVAGA AS {nameof(AviaoEntity.QuantidadeVaga)}
                           CODIGOREGISTRO AS {nameof(AviaoEntity.CodigoRegistro)}
                           COMPANHIA AS {nameof(AviaoEntity.Companhia)}
                           MODELO AS {nameof(AviaoEntity.Modelo)}
                           FABRICANTE AS {nameof(AviaoEntity.Fabricante)}
                      FROM AVIAO WHERE ID = @Id
                ";

                AviaoEntity aviao = await con.QueryFirstAsync<AviaoEntity>(sql, new { id });
                return aviao;
            }
        }

        public async Task Update(AviaoEntity aviao)
        {
            Connection _connection = new Connection();
            string sql = $@"UPDATE AVIAO
                                SET QUANTIDADEVAGA = @QuantidadeVaga,
                                CodigoRegistro = @CodigoRegistro,
                                COMPANHIA = @Companhia, 
                                MODELO = @Modelo,
                                FABRICANTE = @Fabricante
                                WHERE ID = @Id
            ";

            await _connection.Execute(sql, aviao);
        }
    }
}