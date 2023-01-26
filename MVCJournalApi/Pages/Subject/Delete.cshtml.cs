using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Subject
{
    public class DeleteModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DeleteModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StudySubject StudySubject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudySubjects == null)
            {
                return NotFound();
            }

            var studysubject = await _context.StudySubjects.FirstOrDefaultAsync(m => m.Id == id);

            if (studysubject == null)
            {
                return NotFound();
            }
            else 
            {
                StudySubject = studysubject;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudySubjects == null)
            {
                return NotFound();
            }
            var studysubject = await _context.StudySubjects.FindAsync(id);

            if (studysubject != null)
            {
                StudySubject = studysubject;
                _context.StudySubjects.Remove(StudySubject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
