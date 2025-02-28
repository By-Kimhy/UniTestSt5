using Microsoft.EntityFrameworkCore;
using UniTestSt5.Data;
using UniTestSt5.Models;

namespace UniTestSt5.Services
{
    public class CatogoryService : ICategoryService, IDisposable
    {
        public readonly AppDbContext _context;
        public CatogoryService(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task<string> Delete(Guid Id)
        {
            try 
            {
                var category = await _context.Category.FindAsync(Id);
                if(category is null) return "Invalid Id";
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch(Exception ex) 
            {
                return ex.Message.ToString();
            }
        }

        public void Dispose() => _context.Dispose();

        public async Task<List<Category>> GetCategories()
            => await _context.Category.ToListAsync();

        public async Task<Category?> GetCategory(Guid Id)
        {
            return await _context.Category.FindAsync(Id);
        }

        public async Task<string> Save(Category category)
        {
            try 
            {
                if (await IsExistAsync(category.CategoryName))
                    return "Invalid Id";
                category.CategoryId = Guid.NewGuid();
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception ex) 
            {
                return ex.Message.ToString();
            }
        }
        private async Task<bool> IsExistAsync(string name)
            => await _context.Category.AnyAsync(x => x.CategoryName.Equals(name));
        public async Task<string> Update(Guid Id, Category category)
        {
            try
            {
                var cat = await _context.Category.FindAsync(Id);
                if (cat is null) return "Invalid Id";
                _context.Category.Attach(cat);
                cat.CategoryName = category.CategoryName;
                cat.Description = category.Description;
                category.CategoryId = Guid.NewGuid();
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
