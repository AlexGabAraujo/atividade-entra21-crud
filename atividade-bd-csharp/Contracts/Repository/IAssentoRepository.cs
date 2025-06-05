using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    internal interface IAssentoRepository
    {
        Task<IEnumerable<AssentoEntity>> GetAll();

        Task<AssentoEntity> GetById(int id);

        Task Insert(AssentoInsertDTO assento);

        Task Delete(int id);

        Task Update(AssentoEntity aviao);
    }
}
