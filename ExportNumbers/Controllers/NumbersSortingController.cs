using ExportNumbers.BAL.DTO;
using ExportNumbers.DAL.Interfaces;
using ExportNumbers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExportNumbers.Controllers
{
    public class NumbersSortingController : Controller
    {
        private readonly INumberSequenceRepository _numSequenceRepository;

        public NumbersSortingController(INumberSequenceRepository numSequenceRepository)
        {
            _numSequenceRepository = numSequenceRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Sort(NumberViewModel vmNumbers)
        {
            if (vmNumbers == null || string.IsNullOrWhiteSpace(vmNumbers.Numbers))
            {
                ModelState.AddModelError("Numbers", "Please enter numbers to sort.");
                return View("Index");
            }

            // Split numbers input by comma and convert to integers
            var numbers = vmNumbers.Numbers.Split(',').Select(n => int.Parse(n.Trim()));

            // Sort numbers based on sorting direction
            var sortedNumbers = vmNumbers.SortingDirection == "asc" ? numbers.OrderBy(n => n) : numbers.OrderByDescending(n => n);

            // Join sorted numbers into a string
            var sortedSequence = string.Join(",", sortedNumbers);

            // Save sorted sequence to database
            var numberSequenceDTO = new SortedSequenceDTO
            {
                Sequence = sortedSequence,
                SortingDirection = vmNumbers.SortingDirection,
                SortTime = DateTime.Now
            };

            await _numSequenceRepository.InsertSortedSequenceAsync(numberSequenceDTO);

            return RedirectToAction("DisplaySortedSequences");
        }
        public async Task<IActionResult> DisplaySortedSequences()
        {
            var sortedSequences = await _numSequenceRepository.GetAllSortedSequencesAsync();
            return View(sortedSequences);
        }

        public async Task<IActionResult> ExportSortedSequences()
        {
            var sortedSequences = await _numSequenceRepository.GetAllSortedSequencesAsync();
            return Json(sortedSequences);
        }
    }


}

