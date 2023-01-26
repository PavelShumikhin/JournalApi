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
    public class DetailsModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DetailsModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

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
    }
}
