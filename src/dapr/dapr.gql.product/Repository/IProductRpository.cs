using System.Threading.Tasks;
using static dapr.gql.product.gqlgen.Types;

namespace dapr.gql.product.Repository
{
    public interface IProductRepository {
        Task<Product[]> GetProducts();
        Task<Product> GetProductById(string id);
    }
}