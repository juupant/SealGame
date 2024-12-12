using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SealGame.Core.Domain;
using SealGame.Core.Dto;

namespace SealGame.Core.ServiceInterface
{
    public interface ISealService
    {
        Task<Seal> CreateSeal(SealDto dto);
        Task<Seal> GetSealById(int id);
        Task DeleteSeal(int id);
        Task<Seal> Update(SealDto id);
    }
}
