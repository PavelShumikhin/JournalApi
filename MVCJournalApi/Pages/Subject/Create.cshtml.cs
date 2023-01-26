using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Subject
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
            return Page();
        }

        [BindProperty]
        public StudySubject StudySubject { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudySubjects == null || StudySubject == null)
            {
                return Page();
            }

            _context.StudySubjects.Add(StudySubject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
