using NotesApp.Areas.Identity.Data;

namespace NotesApp.Model
{
    public class NotesCategories
    {


        public Guid Id { get; set; }
        public string CategoryTitle { get; set; }

        public List<Notes> NotesInCategory { get; set; }


        public NoteAppUser Notebook_User { get; set; }
    }




}
