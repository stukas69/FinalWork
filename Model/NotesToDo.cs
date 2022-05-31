
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Areas.Identity.Data;
using NotesApp.Model.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace NotesApp.Model
{
    public class Notes
    {

        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Text { get; set; }

        public NotesCategories Category { get; set; }




    }

}
