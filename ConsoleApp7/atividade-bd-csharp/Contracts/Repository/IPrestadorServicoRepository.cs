
using ConsoleApp7.atividade_bd_csharp.DTO;
using ConsoleApp7.atividade_bd_csharp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp7.atividade_bd_csharp.Contracts.Repositori
{
    public interface IPrestadorServico
    {
        Task<IEnumerable<PrestadorServicoEntity>> GetAll();
        Task<PrestadorServicoEntity> GetById(int id);
        Task Insert(PrestadorServicoEntityDTO dto);
        Task Update(PrestadorServicoEntity entity);
        Task Delete(int id);
    }
}
