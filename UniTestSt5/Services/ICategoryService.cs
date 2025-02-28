using UniTestSt5.Models;

namespace UniTestSt5.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategory(Guid Id);
        Task<String> Save(Category category);
        Task<String> Update(Guid Id, Category category);
        Task<String> Delete(Guid Id);
    }
}
