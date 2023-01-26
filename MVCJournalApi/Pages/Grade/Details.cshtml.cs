using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Grade
{
    public class DetailsModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DetailsModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

      public StudyGrade StudyGrade { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudyGrades == null)
            {
                return NotFound();
            }

            var studygrade = await _context.StudyGrades.FirstOrDefaultAsync(m => m.Id == id);
            if (studygrade == null)
            {
                return NotFound();
            }
            else 
            {
                StudyGrade = studygrade;
            }
            return Page();
        }
    }
}
