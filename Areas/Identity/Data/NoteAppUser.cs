using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NotesApp.Model;
using NotesApp.Model.Repositories;

namespace NotesApp.Areas.Identity.Data;


public class NoteAppUser : IdentityUser<Guid>
{
    
    public List<NotesCategories> Categories { get; set; } = new List<NotesCategories>();
}
