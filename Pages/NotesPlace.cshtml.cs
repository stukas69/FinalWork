using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Model.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Pages
{
    [Authorize]
    public class NotesPlace : PageModel
    {
        private readonly ILogger<NotesPlace> _logger;

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public Guid CategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchCategoryTitle { get; set; }

        public List<Notes> ListOfNotes { get; set; } = new List<Notes>();
        public List<NotesCategories> NotesCategories { get; set; } = new List<NotesCategories>();

        private readonly NotesRepository _notesRepository;
        private readonly CategoriesRepository _categoriesRepository;
        public NotesPlace(ILogger<NotesPlace> logger, NotesRepository notesRepository, CategoriesRepository categoriesRepository)
        {
            _notesRepository = notesRepository;
            _logger = logger;
            _categoriesRepository = categoriesRepository;

        }



        public void OnGet()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            ListOfNotes = _notesRepository.GetNotesOfUser(userId);
            NotesCategories = _categoriesRepository.GetCategoriesOfUser(userId);
            if (!string.IsNullOrEmpty(SearchInputTitle))
            {

                ListOfNotes = _notesRepository.GetByTitle(SearchInputTitle, userId);


            }

            if (!string.IsNullOrEmpty(SearchCategoryTitle))
            {

                ListOfNotes = _notesRepository.GetByCategory(SearchCategoryTitle, userId);


            }




        }

        public RedirectToPageResult OnPost()
        {
            _notesRepository.Create(Title, Text, CategoryId);
            return RedirectToPage("/NotesPlace");
        }

        public RedirectToPageResult OnPostDelete(Guid id)
        {

            _notesRepository.RemoveNote(id);

            return RedirectToPage("/NotesPlace");
        }

        public RedirectToPageResult OnPostEdit(Guid id, string title, string text)
        {
            _notesRepository.EditNote(id, title, text);

            return RedirectToPage("/NotesPlace");
        }


    }
}


