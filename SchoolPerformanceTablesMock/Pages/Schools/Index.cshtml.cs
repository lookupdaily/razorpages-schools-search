using System.Collections;
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

        public IEnumerable<School> School { get;set; } = default!;

        [BindProperty(SupportsGet = true)] public string SchoolNameOrUrn { get; set; } = "";

        public async Task OnGetAsync()
        {
            IEnumerable<School> schools;
            if (SchoolNameOrUrn != "")
            {
                schools = await _schoolRepository.GetByNameOrUrn(SchoolNameOrUrn);
            }
            else
            {
                schools = _schoolRepository.GetAll();
            }

            School = schools;
        }
    }
}
