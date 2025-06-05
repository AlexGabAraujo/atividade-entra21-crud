using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    interface IVooRepository
    {
        Task<IEnumerable<VooEntity>> GetAll();

        Task<VooEntity> GetById(int id);

        Task Insert(VooInsertDTO voo);

        Task Delete(int id);

        Task Update(VooEntity voo);
    }
}
