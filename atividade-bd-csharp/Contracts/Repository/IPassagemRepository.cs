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
    interface IPassagemRepository
    {
        Task<IEnumerable<PassagemEntity>> GetAll();

        Task<PassagemEntity> GetById(int id);

        Task Insert(PassagemInsertDTO passagem);

        Task Delete(int id);

        Task Update(PassagemEntity passagem);
    }
}
