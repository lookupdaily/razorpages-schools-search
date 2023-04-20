using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private const string SearchLabel = "Search by name or URN (Unique Reference Number). Entering more characters will give quicker results. You should write URNs in full.";

        private readonly ISchoolRepository _schoolRepository;

        public IndexModel(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public IEnumerable<School> School { get;set; } = default!;
        
        public AutoCompleteSearchModel AutoCompleteSearchModel { get; set; }

        [BindProperty(SupportsGet = true)] public string Id { get; set; } = "";

        public async Task OnGetAsync()
        {
            AutoCompleteSearchModel = new AutoCompleteSearchModel(SearchLabel, Id);
            IEnumerable<School> schools;
            if (Id != "")
            {
                schools = _schoolRepository.GetByNameOrUrn(Id);
            }
            else
            {
                schools = _schoolRepository.GetAll();
            }
            School = schools;
            
        }

        public IActionResult OnGetSchool(string query)
        {
            var result = _schoolRepository.GetByNameOrUrn(query);
            return new JsonResult(result.Select(s => new { hint = $"{s.Name}, {s.LocalAuthority}", value = $"{s.Name}", id = $"{s.Id}"}));
        }
        
        
    }
}
