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
    public class IndexModel : PageModel
    {
        private readonly JournalApi.Data.JournalDbContext _context;

        public IndexModel(JournalApi.Data.JournalDbContext context)
        {
            _context = context;
        }

        public IList<StudySubject> StudySubject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudySubjects != null)
            {
                StudySubject = await _context.StudySubjects.ToListAsync();
            }
        }
    }
}
