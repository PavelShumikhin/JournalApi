using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DeleteModel(JournalApi.Data.JournalDbContext context)
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

            var studygroup = await _context.StudyGroups.FirstOrDefaultAsync(m => m.Id == id);

            if (studygroup == null)
            {
                return NotFound();
            }
            else 
            {
                StudyGroup = studygroup;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudyGroups == null)
            {
                return NotFound();
            }
            var studygroup = await _context.StudyGroups.FindAsync(id);

            if (studygroup != null)
            {
                StudyGroup = studygroup;
                _context.StudyGroups.Remove(StudyGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
