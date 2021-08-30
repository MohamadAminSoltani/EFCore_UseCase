
using EFCore.Application.Contracts.Product;
using System.Collections.Generic;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        void Create(Product product);
        void SaveChanges();
        EditProduct GetDetails(int id);
        bool Exists(string name, int categoryId);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
