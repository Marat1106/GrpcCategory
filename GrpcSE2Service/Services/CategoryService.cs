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
    }
}
