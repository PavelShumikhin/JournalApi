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

namespace MVCJournalApi.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public EditModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudyGroup StudyGroup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudyGroups == null)
            {
                return NotFound();
            }

            var studygroup =  await _context.StudyGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (studygroup == null)
            {
                return NotFound();
            }
            StudyGroup = studygroup;
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

            _context.Attach(StudyGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyGroupExists(StudyGroup.Id))
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

        private bool StudyGroupExists(int id)
        {
          return (_context.StudyGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
