using GrpcService.Models;
using GrpcService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Models.Category> AddCotegroy(CategoryCreate category)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
