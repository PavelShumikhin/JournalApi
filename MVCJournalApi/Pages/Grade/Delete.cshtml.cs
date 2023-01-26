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
    public class DeleteModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DeleteModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudyGrades == null)
            {
                return NotFound();
            }
            var studygrade = await _context.StudyGrades.FindAsync(id);

            if (studygrade != null)
            {
                StudyGrade = studygrade;
                _context.StudyGrades.Remove(StudyGrade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
