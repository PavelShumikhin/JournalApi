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

namespace MVCJournalApi.Pages.Grade
{
    public class EditModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public EditModel(JournalApi.Data.JournalDbContext context)
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

            var studygrade =  await _context.StudyGrades.FirstOrDefaultAsync(m => m.Id == id);
            if (studygrade == null)
            {
                return NotFound();
            }
            StudyGrade = studygrade;
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

            _context.Attach(StudyGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyGradeExists(StudyGrade.Id))
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

        private bool StudyGradeExists(int id)
        {
          return (_context.StudyGrades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
