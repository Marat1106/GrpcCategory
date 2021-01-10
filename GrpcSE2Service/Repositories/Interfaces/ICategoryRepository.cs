using GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCotegroy(CategoryCreate category);

    }
}
