using ExportNumbers.DAL.Entities;
using ExportNumbers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNumbers.DAL.Repositories
{
    public class NumberSequenceRepository : INumberSequenceRepository
    {
        private readonly AppDbContext _context;

        public NumberSequenceRepository(AppDbContext Context)
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
