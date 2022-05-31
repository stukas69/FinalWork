using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesApp.Areas.Identity.Data;
using NotesApp.Model;
using NotesApp.Model.Repositories;

namespace NotesApp.Areas.Identity.Data;

public class ContextNotebook : IdentityDbContext<NoteAppUser, UserRole, Guid>
{
    public ContextNotebook(DbContextOptions<ContextNotebook> options)
        : base(options)
    {

    }

    public DbSet<Notes> Notes { get; set; }
    public DbSet<NotesCategories> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<NoteAppUser>().HasMany(u => u.Categories).WithOne(c => c.Notebook_User);
        builder.Entity<NotesCategories>().HasMany(u => u.NotesInCategory).WithOne(n => n.Category);
    }
}


