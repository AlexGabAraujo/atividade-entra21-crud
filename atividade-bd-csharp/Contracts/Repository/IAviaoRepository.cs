using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.Entity;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    interface IAviaoRepository
    {
        Task<IEnumerable<AviaoEntity>> GetAll();

        Task<AviaoEntity> GetById(int id);

        Task Insert(AviaoEntity aviao);

        Task Delete(int id);

        Task Update(AviaoEntity aviao);
    }
}
