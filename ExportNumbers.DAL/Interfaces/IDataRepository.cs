using ExportNumbers.DAL.Entities;

namespace ExportNumbers.DAL.Interfaces
{
    public interface IDataRepository
    {
        Task InsertSortedSequenceAsync(NumberSequence sortedSequence);
        Task<IEnumerable<NumberSequence>> GetAllSortedSequencesAsync();
    }
}
