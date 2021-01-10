using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    
    public class CategoryService:Category.CategoryBase
    {
        private readonly Ilogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly List<CategoryInfo> students = new List<CategoryInfo>
        {
            new CategoryInfo{User=new ProductInfo{id=1,name="Coco-cola",parentCategoryId=1},description="good product",price=200 },
            new CategoryInfo{User=new ProductInfo{id=2,name="Fanta",parentCategoryId=2},description="good product",price=230 },
            new CategoryInfo{User=new ProductInfo{id=3,name="Sprite",parentCategoryId=3},description="good product",price=280 },
            new CategoryInfo{User=new ProductInfo{id=4,name="cola",parentCategoryId=4},description="good product",price=260 },
            new CategoryInfo{User=new ProductInfo{id=5,name="Juice",parentCategoryId=5},description="good product",price=250 },
            new CategoryInfo{User=new ProductInfo{id=6,name="Tea",parentCategoryId=6},description="good product",price=300 },


        };
        


        public CategoryService(Ilogger<CategoryService> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        public override Task<CategorInfo> AddCategory(CategoryCreate request,ServiceCallContext context)
        {
            return base.GetCategoryById(request, context);

        }
        public override Task<CategoryInfo>GetCategory(CategoryLookUp request,ServerCallContext context)
        {
            return base.GetCategoryById(request, context);
        }
        public override Task<ProductInfo> AddProduct(CategoryLookUp request, ServerCallContext context)
        {
            return base.AddProduct(request, context);
        }
        public override Task<ProductInfo> GetProductById(CategoryLookUp request, ServerCallContext context)
        {
            return base.GetCategoryById(request, context);
        }
        public override Task GetProductsByCategoryId(CategoryLookUp request, IServiceStreamWriter<ProductInfo> responseStream, ServerCallContext context)
        {
            return base.GetProductsByCategoryId(request, responseStream, context);
        }
        public override async Task GetAllProducts(CategoryAllLookUp request,
            IServerStreamWriter<CategoryInfo> responseStream, ServerCallContext context)
        {
            foreach (var Category in Categorys)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(Category);



            }
        }
    }
}
