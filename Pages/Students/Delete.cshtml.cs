using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInfoApp.Data;
using StudentInfoApp.Models;
using System.Threading.Tasks;

namespace StudentInfoApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
