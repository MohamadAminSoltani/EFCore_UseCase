
using EFCore.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        ProductCategory Get(int id);
        void Create(ProductCategory productCategory);
        List<ProductCategoryViewModel> Search(string name);
        bool Exists(string name);
        void SaveChanges();
    }
}
