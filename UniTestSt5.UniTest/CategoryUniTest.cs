using Moq;
using UniTestSt5.Controllers;
using UniTestSt5.Models;
using UniTestSt5.Services;

namespace UniTestSt5.UniTest
{
    [TestClass]
    public class CategoryUniTest
    {
        private readonly Mock<ICategoryService> mock;
        public CategoryUniTest() 
        {
            mock = new Mock<ICategoryService>();
        
        }
        [TestMethod]
        public void Category_GetAll_Success()
        {
            //Arrange
            mock.Setup(item=>item.GetCategories()).ReturnsAsync(GetCategories());
            var controller = new CategoryController(mock.Object);
            //Act
            var result = controller.Get();
            //Assertion
            Assert.IsNotNull(result);
            Assert.AreEqual(GetCategories().Count,result.Result.Count);
            Assert.AreEqual(GetCategories()[0].CategoryName, result.Result[0].CategoryName);

        }
        private List<Category> GetCategories()
        {
            var categoryList = new List<Category>()
            {
                new Category {CategoryId = Guid.NewGuid(), CategoryName = "Food"},
                new Category {CategoryId = Guid.NewGuid(), CategoryName = "Drink" }
            };
            return categoryList;

        }
    }
}