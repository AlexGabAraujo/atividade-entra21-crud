using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atividade_bd_csharp.DTO;
using atividade_bd_csharp.Entity;

namespace atividade_bd_csharp.Contracts.Repository
{
    public interface IHotelRepository
    {
        Task Insert(HotelInsertDTO hotel);
        Task<IEnumerable<HotelEntity>> GetAll();
        Task<HotelEntity> GetById(int id);
        Task Update(HotelEntity hotel);
        Task Delete(int id);
    }
}
