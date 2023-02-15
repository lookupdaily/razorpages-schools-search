using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<School> _repository;

        public IndexModel(IRepository<School> repository)
        {
            _repository = repository;
        }

        public IList<School> School { get;set; } = default!;

        public async Task OnGetAsync()
        {
            School = await _repository.GetAll();
        }
    }
}
