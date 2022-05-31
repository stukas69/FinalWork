using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model.Repositories;

namespace NotesApp.Pages
{
    public class EditNotesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Text { get; set; }


        private readonly NotesRepository _notesRepository;



        public EditNotesModel(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void OnGet()
        {
            var noteForEditing = _notesRepository.GetNote(Id);
            Title = noteForEditing.Title;
            Text = noteForEditing.Text;
        }

        public RedirectToPageResult OnPost()
        {
            _notesRepository.EditNote(Id, Title, Text);

            return RedirectToPage("/NotesPlace");
        }


    }

}
