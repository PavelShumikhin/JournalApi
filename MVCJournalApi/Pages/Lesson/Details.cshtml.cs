using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Lesson
{
    public class DetailsModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DetailsModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

      public StudyOccupation StudyOccupation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudyOccupations == null)
            {
                return NotFound();
            }

            var studyoccupation = await _context.StudyOccupations.FirstOrDefaultAsync(m => m.Id == id);
            if (studyoccupation == null)
            {
                return NotFound();
            }
            else 
            {
                StudyOccupation = studyoccupation;
            }
            return Page();
        }
    }
}
