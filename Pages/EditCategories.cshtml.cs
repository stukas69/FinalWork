using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model.Repositories;

namespace NotesApp.Pages
{
    public class EditCategoriesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public string Title { get; set; }
     
  

        private readonly CategoriesRepository _categoriesRepository;

        public EditCategoriesModel(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void OnGet()
        {
            var categoryForEditing = _categoriesRepository.GetCategory(Id);
            Title = categoryForEditing.CategoryTitle;
            
        }

        public RedirectToPageResult OnPost()
        {
            _categoriesRepository.EditCategory(Id, Title);

            return RedirectToPage("/CategoriesPlace");
        }
    }

    
}
