using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Lesson
{
    public class CreateModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public CreateModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, "Id", "Name");
        ViewData["StudySubjectId"] = new SelectList(_context.StudySubjects, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StudyOccupation StudyOccupation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudyOccupations == null || StudyOccupation == null)
            {
                return Page();
            }

            _context.StudyOccupations.Add(StudyOccupation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
