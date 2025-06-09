using ConsoleApp5.atividade_bd_csharp.DTO;
using ConsoleApp5.atividade_bd_csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.atividade_bd_csharp.Contracts.Repository
{
    interface IOrdemServicoRepository
    {
        Task<IEnumerable<OrdemServicoEntity>> GetAll();
        Task<OrdemServicoEntity> GetById(int id);
        Task Insert(OrdemServicoEntityDTO ordemServico);
        Task Delete(int id);
        Task Update(OrdemServicoEntity ordemServico);
    }
}