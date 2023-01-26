using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Students
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
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login");
            return Page();
        }

        [BindProperty]
        public StudyStudent StudyStudent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudyStudents == null || StudyStudent == null)
            {
                return Page();
            }

            _context.StudyStudents.Add(StudyStudent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
