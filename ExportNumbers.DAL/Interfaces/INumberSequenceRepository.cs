using ExportNumbers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNumbers.DAL.Interfaces
{
    public interface INumberSequenceRepository
    {
        Task InsertSortedSequenceAsync(NumberSequence sortedSequence);
        Task<IEnumerable<NumberSequence>> GetAllSortedSequencesAsync();
    }
}
