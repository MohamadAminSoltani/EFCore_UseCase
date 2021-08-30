﻿using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using System.Collections.Generic;

namespace EFCore.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;
        public void Create(CreateProduct command)
        {
            if (productRepository.Exists(command.Name, command.CategoryId))
                return;

            var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
        }

        public void Edit(EditProduct command)
        {
            var product = productRepository.Get(command.Id);
            if (product == null)
                return;

            product.Edit(command.Name, command.UnitPrice, command.CategoryId);
            productRepository.SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            return productRepository.GetDetails(id);
        }

        public void Remove(int id)
        {
            var product = productRepository.Get(id);
            if (product == null)
                return;

            product.Remove();
            productRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = productRepository.Get(id);
            if (product == null)
                return;

            product.Restore();
            productRepository.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
