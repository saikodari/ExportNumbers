using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNumbers.BAL.DTO
{
    public class SortedSequenceDTO
    {
        public string? Sequence { get; set; }
        public string? SortingDirection { get; set; }
        public DateTime SortTime { get; set; }
    }
}
