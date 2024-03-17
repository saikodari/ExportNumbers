using ExportNumbers.BAL.Contracts;
using ExportNumbers.DAL.Entities;
using ExportNumbers.DAL.Interfaces;
using ExportNumbers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;

namespace ExportNumbers.Controllers
{
    public class NumbersSortingController : Controller
    {
        private readonly INumberSortService _numberSortService;

        public NumbersSortingController(INumberSortService numberSortService)
        {
            _numberSortService = numberSortService;
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
            var numbers = vmNumbers.Numbers.Split(',').Select(n => int.Parse(n.Trim()));
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sortedNumbers = numbers.ToList();

            if (vmNumbers.SortingDirection == "asc")
            {
                for (int i = 0; i < sortedNumbers.Count - 1; i++)
                {
                    for (int j = i + 1; j < sortedNumbers.Count; j++)
                    {
                        if (sortedNumbers[i] > sortedNumbers[j])
                        {
                            int temp = sortedNumbers[i];
                            sortedNumbers[i] = sortedNumbers[j];
                            sortedNumbers[j] = temp;
                        }
                    }
                }
            }
            else if (vmNumbers.SortingDirection == "desc")
            {
                for (int i = 0; i < sortedNumbers.Count - 1; i++)
                {
                    for (int j = i + 1; j < sortedNumbers.Count; j++)
                    {
                        if (sortedNumbers[i] < sortedNumbers[j])
                        {
                            int temp = sortedNumbers[i];
                            sortedNumbers[i] = sortedNumbers[j];
                            sortedNumbers[j] = temp;
                        }
                    }
                }
            }

            //var sortedNumbers = vmNumbers.SortingDirection == "asc" ? numbers.OrderBy(n => n) : numbers.OrderByDescending(n => n);
            stopwatch.Stop();
            long elapsedTicks = stopwatch.ElapsedTicks;
            double milliseconds = (double)elapsedTicks / Stopwatch.Frequency * 1000.0;
            int sortTime = (int)milliseconds;

            var sortedSequence = string.Join(",", sortedNumbers);
           
            var obj = new NumberSequence
            {
                Sequence = sortedSequence,
                SortingDirection = vmNumbers.SortingDirection,
                SortTime = sortTime
            };

            await _numberSortService.InsertSortedSequenceAsync(obj);
            return new JsonResult(new { success = true, message = "saved succesfully!" });
        }
        public async Task<PartialViewResult> DisplaySortedSequences()
        {
            var sortedSequences = await _numberSortService.GetAllSortedSequencesAsync();
            return PartialView("_DisplaySortedSequences", sortedSequences);
        }

        public async Task<IActionResult> ExportSortedSequences()
        {
            var sortedSequences = await _numberSortService.GetAllSortedSequencesAsync();
            return Json(sortedSequences);
        }
    }


}

