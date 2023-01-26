using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Grade
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
        public StudyGrade StudyGrade { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudyGrades == null || StudyGrade == null)
            {
                return Page();
            }

            _context.StudyGrades.Add(StudyGrade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
