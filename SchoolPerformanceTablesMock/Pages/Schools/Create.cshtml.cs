using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class CreateModel : PageModel
    {
        private readonly ISchoolRepository _schoolRepository;

        public CreateModel(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public School School { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
          {
              return Page();
          }

          await _schoolRepository.CreateAsync(School);

          return RedirectToPage("./Index");
        }
    }
}
