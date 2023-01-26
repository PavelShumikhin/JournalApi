using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace MVCJournalApi.Pages.Lesson
{
    public class IndexModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public IndexModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        public IList<StudyOccupation> StudyOccupation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudyOccupations != null)
            {
                StudyOccupation = await _context.StudyOccupations
                .Include(s => s.StudyGroup)
                .Include(s => s.StudySubject).ToListAsync();
            }
        }
    }
}
