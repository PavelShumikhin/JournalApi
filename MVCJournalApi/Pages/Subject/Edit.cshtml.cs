using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Subject
{
    public class EditModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public EditModel(JournalApi.Data.JournalDbContext context)
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

            var studysubject =  await _context.StudySubjects.FirstOrDefaultAsync(m => m.Id == id);
            if (studysubject == null)
            {
                return NotFound();
            }
            StudySubject = studysubject;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudySubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudySubjectExists(StudySubject.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudySubjectExists(int id)
        {
          return (_context.StudySubjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
