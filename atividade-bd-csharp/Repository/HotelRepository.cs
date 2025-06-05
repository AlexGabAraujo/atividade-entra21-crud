using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Contracts.Repository;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using Dapper;
using MyFirstCRUD.infrastructure;

namespace atividade_bd_csharp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Connection _connection;

        public HotelRepository(Connection connection)
        {
            _connection = connection;
        }
        

        public async Task<IEnumerable<HotelEntity>> GetAll()
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
                        FROM HOTEL
                        LEFT JOIN CIDADE ON CIDADE_ID
                        ORDER BY HOTEL.NOME";

                IEnumerable<HotelEntity> hotellist = await con.QueryAsync<HotelEntity>(sql);
                return hotellist;
            }

           
        }
        //CREATE
        public async Task Insert(HotelInsertDTO hotel)
        {
            using (var con = _connection.GetConnection())
            {
                string sql = @"
                    INSERT INTO HOTEL (
                        CNPJ, NOME, TIPO,EMAIL,
                        TELEFONE, ENDERECOFOTO, SITE,
                        ACESSIBILIDADE, CEP, BAIRRO,
                        RUA, NUMEROENDERECO, CIDADE_ID,
                        HOTEL_ID;
                    ) VALUES (
                        @Cnpj, @Nome, @Tipo, @Email,
                        @Telefone, @EnderecoFoto, @site,
                        @Acessbilidade, @Cep, @Bairro,
                        @Rua, @NumeroEndereco, @Cidade_Id,
                        @Hotel|_Id;)
                        ";

                await con.ExecuteAsync(sql, hotel);
            }

        }

        public async Task Update(HotelEntity hotel)
        {
            using (var con = _connection.GetConnection())
            {
                string sql = @"
                    UPDATE HOTEL SET
                    CNPJ= @CNPJ
                    NOME= @Nome
                    TIPO= @Tipo
                    EMAIL= @Email
                    TELEFONE= @Telefone
                    ENDERECOFOTO= @EnderecoFoto
                    SITE= @Site
                    ACESSIBILIDADE= @Acessibilidade
                    CEP= @CEP
                    BAIRRO= @Bairro
                    RUA= @Rua
                    NUMEROENDERECO= @NumeroEndereco
                    CIDADE_ID= @Cidade_Id
                    WHERE ID = @Id
                    ";
                await con.ExecuteAsync(sql, hotel);
            }
        }
    }
}
