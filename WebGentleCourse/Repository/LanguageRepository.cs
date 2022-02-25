using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentleCourse.Data;
using WebGentleCourse.Models;

namespace WebGentleCourse.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Languages.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
        }


    }
}
