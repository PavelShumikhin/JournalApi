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

namespace MVCJournalApi.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public EditModel(JournalApi.Data.JournalDbContext context)
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

            var studystudent =  await _context.StudyStudents.FirstOrDefaultAsync(m => m.Id == id);
            if (studystudent == null)
            {
                return NotFound();
            }
            StudyStudent = studystudent;
           ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, "Id", "Name");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login");
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

            _context.Attach(StudyStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyStudentExists(StudyStudent.Id))
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

        private bool StudyStudentExists(int id)
        {
          return (_context.StudyStudents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
