using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class IndexModel : PageModel
    {

        private readonly ISchoolRepository _schoolRepository;

        public IndexModel(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public AutoCompleteSearchModel AutoCompleteSearchModel { get; set; }

        [BindProperty(SupportsGet = true)] public string SchoolId { get; set; } = "";

        public async Task OnGetAsync()
        {
            
        }

        public IActionResult OnGetSchool(string query)
        {
            var result = _schoolRepository.GetByNameOrUrn(query);
            return new JsonResult(result.Select(s => new { hint = $"{s.Name}, {s.LocalAuthority}", value = $"{s.Name}", schoolId = $"{s.Id}"}));
        }

    }
}
