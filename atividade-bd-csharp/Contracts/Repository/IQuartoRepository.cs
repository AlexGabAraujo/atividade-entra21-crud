using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    public interface IQuartoRepository
    {
        Task<IEnumerable<QuartoEntity>> GetAll();
        Task<QuartoEntity> GetById(int id);  
        Task Insert(QuartoInsertDTO quarto);
        Task Update(QuartoEntity quarto);
        Task Delete(int id);
    }
}
