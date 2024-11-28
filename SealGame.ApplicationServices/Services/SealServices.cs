using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SealGame.Core.Domain;
using SealGame.Core.Dto;
using SealGame.Core.ServiceInterface;
using SealGame.Data;

namespace SealGame.ApplicationServices.Services
{
    public class SealServices : ISealService
    {
        private readonly DatabaseTaskDbContext _context;
        private readonly IFileServices _fileServices;

        public SealServices(DatabaseTaskDbContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<List<Seal>> GetAllSealsAsync()
        {
            return await _context.Seals
                .Include(s => s.Species)
                .ToListAsync();
        }

        public async Task<Seal> GetSealByIdAsync(int id)
        {
            return await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Seal> CreateSealAsync(string name, int speciesId)
        {
            var species = await _context.SealSpecies.FindAsync(speciesId);
            if (species == null)
                throw new ArgumentException("Invalid species ID");

            var seal = new Seal(name, species);

            await _context.Seals.AddAsync(seal);
            await _context.SaveChangesAsync();

            return seal;
        }

        public async Task<bool> DeleteSealAsync(int id)
        {
            var seal = await _context.Seals.FindAsync(id);
            if (seal == null)
                return false;

            _context.Seals.Remove(seal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Seal?> UpdateSealStatsAsync(int id, int happiness, int hunger, int enrichment, int cleanliness)
        {
            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seal == null)
                return null;

            seal.Happiness = Math.Clamp(happiness, 0, seal.Species.MaxHappiness);
            seal.Hunger = Math.Clamp(hunger, 0, 100);
            seal.Enrichment = Math.Clamp(enrichment, 0, 100);
            seal.Cleanliness = Math.Clamp(cleanliness, 0, 100);

            await _context.SaveChangesAsync();
            return seal;
        }

        public async Task<Seal?> FeedSealAsync(int id)
        {
            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seal == null)
                return null;

            seal.Hunger = Math.Max(0, seal.Hunger - 30);
            seal.Happiness = Math.Min(seal.Species.MaxHappiness, seal.Happiness + 10);

            await _context.SaveChangesAsync();
            return seal;
        }

        public async Task<Seal> PlayWithSealAsync(int id)
        {
            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seal == null)
                return null;

            seal.Enrichment = Math.Min(100, seal.Enrichment + 25);
            seal.Happiness = Math.Min(seal.Species.MaxHappiness, seal.Happiness + 15);
            seal.Hunger = Math.Min(100, seal.Hunger + 10);

            await _context.SaveChangesAsync();
            return seal;
        }

        public async Task<Seal?> CleanSealAsync(int id)
        {
            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seal == null)
                return null;

            seal.Cleanliness = 100;
            seal.Happiness = Math.Min(seal.Species.MaxHappiness, seal.Happiness + 5);

            await _context.SaveChangesAsync();
            return seal;
        }

        public Task<Seal> CreateSeal(SealDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Seal> GetSealById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSeal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Seal> Update(SealDto id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Seal>> ISealService.GetAllSealsAsync()
        {
            throw new NotImplementedException();
        }

        Task ISealService.CreateSealAsync(string name, int speciesId)
        {
            throw new NotImplementedException();
        }

        Task ISealService.UpdateSealStatsAsync(int id, int happiness, int hunger, int enrichment, int cleanliness)
        {
            throw new NotImplementedException();
        }

        Task ISealService.DeleteSealAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
       
