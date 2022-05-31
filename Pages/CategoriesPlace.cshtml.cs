using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Model.Repositories;
using System.Security.Claims;

namespace NotesApp.Pages
{

    [Authorize]
    public class CategoriesPlaceModel : PageModel
    {

        [BindProperty]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; }

        public List<NotesCategories> notesCategories { get; set; } = new List<NotesCategories>();


        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesPlaceModel(CategoriesRepository categoriesRepository)
        {

            _categoriesRepository = categoriesRepository;

        }

        public void OnGet()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            notesCategories = _categoriesRepository.GetCategoriesOfUser(userId);

            if (!string.IsNullOrEmpty(SearchInputTitle))
            {

                notesCategories = _categoriesRepository.GetByTitle(SearchInputTitle, userId);


            }

        }

        public RedirectToPageResult OnPost()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);
            _categoriesRepository.Create(Title, userId);
            return RedirectToPage("/CategoriesPlace");
        }

        public RedirectToPageResult OnPostDeleteCategory(Guid id)
        {

            _categoriesRepository.RemoveCategory(id);

            return RedirectToPage("/CategoriesPlace");
        }
    }

}
