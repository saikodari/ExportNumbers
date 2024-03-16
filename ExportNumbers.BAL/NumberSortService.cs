using ExportNumbers.BAL.Contracts;
using ExportNumbers.DAL.Entities;
using ExportNumbers.DAL.Interfaces;

namespace ExportNumbers.BAL
{
    public class NumberSortService : INumberSortService
    {
        private readonly IDataRepository _dataRepository;

        public NumberSortService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public Task<IEnumerable<NumberSequence>> GetAllSortedSequencesAsync()
        {
            return _dataRepository.GetAllSortedSequencesAsync();
        }

        public Task InsertSortedSequenceAsync(NumberSequence sortedSequence)
        {
            return _dataRepository.InsertSortedSequenceAsync(sortedSequence);
        }
    }
}
