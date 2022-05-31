using NotesApp.Areas.Identity.Data;

namespace NotesApp.Model.Repositories
{
    public class CategoriesRepository
    {

        private readonly ContextNotebook _context;

        public CategoriesRepository(ContextNotebook context)
        {
            _context = context;

        }

        public List<NotesCategories> GetCategoriesOfUser(Guid userId)
        {
            return _context.Categories.Where(z => z.Notebook_User.Id == userId).ToList();

        }

        public List<NotesCategories> GetByTitle(string title, Guid userId) // To find a note by its title
        {
            return _context.Categories.Where(n => n.CategoryTitle.Contains(title) && n.Notebook_User.Id == userId).ToList();

        }


        public NotesCategories GetCategory(Guid Id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == Id);

        }


        public void Create(string title, Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var category = new NotesCategories
            {
                Id = Guid.NewGuid(),
                CategoryTitle = title,
                Notebook_User = user
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }


        public void EditCategory(Guid Id, string title)
        {
            var category = _context.Categories.FirstOrDefault(n => n.Id == Id);
            category.CategoryTitle = title;
            _context.SaveChanges();
        }




        public void RemoveCategory(Guid Id)
        {
            var categoryToRemove = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (categoryToRemove != null)
            {
                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
        }


    }



}
