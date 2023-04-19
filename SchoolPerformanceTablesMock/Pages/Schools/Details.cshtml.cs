using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class DetailsModel : PageModel
    {
        private readonly ISchoolRepository _schoolRepository;

        public DetailsModel(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

      public School School { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var school = await _schoolRepository.GetById(id);
            
            if (school == null)
            {
                return NotFound();
            }
            School = school;
            return Page();
        }
    }
}
