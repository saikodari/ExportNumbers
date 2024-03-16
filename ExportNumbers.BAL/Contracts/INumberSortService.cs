using ExportNumbers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNumbers.BAL.Contracts
{
    public interface INumberSortService
    {
        Task InsertSortedSequenceAsync(NumberSequence sortedSequence);
        Task<IEnumerable<NumberSequence>> GetAllSortedSequencesAsync();
    }
}
