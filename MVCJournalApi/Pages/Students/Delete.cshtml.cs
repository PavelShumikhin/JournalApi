using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DeleteModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StudyStudent StudyStudent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudyStudents == null)
            {
                return NotFound();
            }

            var studystudent = await _context.StudyStudents.FirstOrDefaultAsync(m => m.Id == id);

            if (studystudent == null)
            {
                return NotFound();
            }
            else 
            {
                StudyStudent = studystudent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudyStudents == null)
            {
                return NotFound();
            }
            var studystudent = await _context.StudyStudents.FindAsync(id);

            if (studystudent != null)
            {
                StudyStudent = studystudent;
                _context.StudyStudents.Remove(StudyStudent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
