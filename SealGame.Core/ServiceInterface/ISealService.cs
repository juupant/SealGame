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
        Task<IEnumerable<Seal>> GetAllSealsAsync();
        Task<Seal> GetSealByIdAsync(int id);
        Task CreateSealAsync(string name, int speciesId);
        Task UpdateSealStatsAsync(int id, int happiness, int hunger, int enrichment, int cleanliness);
        Task DeleteSealAsync(int id);
        Task<Seal> FeedSealAsync(int id);
        Task<Seal> PlayWithSealAsync(int id);
        Task<Seal> CleanSealAsync(int id);
    }
}