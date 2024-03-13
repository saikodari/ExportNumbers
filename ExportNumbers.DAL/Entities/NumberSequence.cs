using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportNumbers.DAL.Entities
{

    public class NumberSequence
    {
        public int Id { get; set; }
        public string? Sequence { get; set; }
        public string? SortingDirection { get; set; }
        public DateTime SortTime { get; set; }
    }
}
