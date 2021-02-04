using System.Threading.Tasks;
using static dapr.gql.product.gqlgen.Types;
using System.Linq;
using GraphQL.Types;
using GraphQL;
using System;
using GraphQL.Utilities;
using System.Collections.Generic;
using System.Security.Claims;

namespace dapr.gql.product.Repository
{
    /// <summary>
    /// Product repo
    /// </summary>
    public class ProductRepository :IProductRepository {
        public async Task<Product[]> GetProducts(){
            return await Task.FromResult( new Product[]{
                new Product(){id="1", name="milk", description="some milk.", code="milk-abc"},
                new Product(){id="2", name="cheese", description="some cheese.", code="cheese-abc"},
                new Product(){id="3", name="yoghurt", description="some yoghurt.", code="yoghurt-abc"},
            });
        }
        public async Task<Product> GetProductById(string id){
             return await Task.FromResult(GetProducts().Result.SingleOrDefault(p=>p.id==id));
        }
    }

    /// <summary>
    /// Graph for Product
    /// </summary>
    public class ProductType : ObjectGraphType<Product> 
    {
        public ProductType(IProductRepository repository){
            Field(x=>x.id).Description("Product id");
            Field(x=>x.code).Description("Product code");
            Field(x=>x.name).Description("Product name");
            Field(x=>x.description).Description("Product description");
        }
    }

    /// <summary>
    /// GraphQl graph for Product Search
    /// </summary>
    public class ProductQuery : ObjectGraphType<object>{
        public ProductQuery(IProductRepository repository){
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name= "id", Description = "id of the product to find."}
                    ),
                resolve: context => repository.GetProductById(context.GetArgument<string>("id"))
            );
        }
    }

    /// <summary>
    /// Graphql schema
    /// </summary>
    public class ProductSchema : Schema {
        public ProductSchema(IServiceProvider provider) : base(provider){
            Query = provider.GetRequiredService<ProductQuery>();
        }
    }

    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}