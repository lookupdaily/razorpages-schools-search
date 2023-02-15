using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<School> _repository;

        public CreateModel(IRepository<School> repository)
        {
            _repository = repository;
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

          await _repository.CreateAsync(School);

          return RedirectToPage("./Index");
        }
    }
}
