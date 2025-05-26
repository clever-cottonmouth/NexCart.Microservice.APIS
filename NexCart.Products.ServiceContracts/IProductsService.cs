using NexCart.Products.DTO;
using NexCart.Products.Entities;
using System.Linq.Expressions;


namespace NexCart.Products.ServiceContracts
{
    public interface IProductsService
    {
        Task<List<ProductResponse?>> GetProducts();
        Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionexpression);
        Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionexpression);
        Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        Task<bool> DeleteProduct(Guid productID);

    }
}
