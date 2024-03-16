using ExportNumbers.DAL.Entities;
using ExportNumbers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExportNumbers.DAL.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext _context;

        public DataRepository(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<IEnumerable<NumberSequence>> GetAllSortedSequencesAsync()
        {
            return await _context.NumberSequences.ToListAsync();
        }

        public async Task InsertSortedSequenceAsync(NumberSequence numSequence)
        {
            _context.NumberSequences.Add(numSequence);
            await _context.SaveChangesAsync();
        }
    }
}
