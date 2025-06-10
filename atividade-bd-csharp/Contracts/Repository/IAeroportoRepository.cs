using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    interface IAeroportoRepository
    {
        Task<IEnumerable<AeroportoEntity>> GetAll();

        Task<AeroportoEntity> GetById(int id);

        Task Insert(AeroportoInsertDTO aeroporto);

        Task Delete(int id);

        Task Update(AeroportoEntity aeroporto);
    }
}
