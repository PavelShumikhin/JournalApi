using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Subject
{
    public class DetailsModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public DetailsModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

      public StudySubject StudySubject { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudySubjects == null)
            {
                return NotFound();
            }

            var studysubject = await _context.StudySubjects.FirstOrDefaultAsync(m => m.Id == id);
            if (studysubject == null)
            {
                return NotFound();
            }
            else 
            {
                StudySubject = studysubject;
            }
            return Page();
        }
    }
}
