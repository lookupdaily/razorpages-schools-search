using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolPerformanceTablesMock.Data;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Pages.Schools
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<School> _repository;

        public DetailsModel(IRepository<School> repository)
        {
            _repository = repository;
        }

      public School School { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var school = await _repository.GetById(id);
            
            if (school == null)
            {
                return NotFound();
            }
            School = school;
            return Page();
        }
    }
}
