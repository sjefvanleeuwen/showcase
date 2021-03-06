using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate.AspNetCore.Voyager;

namespace gql.gateway
{
    public class Startup
    {
        public const string Basket = "basket";
        public const string Customer = "customer";
        public const string Inventory = "inventory";
        public const string Payment = "payment";
        public const string Product = "product";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddDapr();
            // Gateway Endpoints via ocelot (obsolete, replaced by graphql)
            /*
            services.AddHttpClient(Basket, x=>x.BaseAddress = new Uri($"http://localhost:10000/{Basket}/graphql"));
            services.AddHttpClient(Customer, x=>x.BaseAddress = new Uri($"http://localhost:10000/{Customer}/graphql"));
            services.AddHttpClient(Inventory, x=>x.BaseAddress = new Uri($"http://localhost:10000/{Inventory}/graphql"));
            services.AddHttpClient(Payment, x=>x.BaseAddress = new Uri($"http://localhost:10000/{Payment}/graphql"));
            services.AddHttpClient(Product, x=>x.BaseAddress = new Uri($"http://localhost:10000/{Product}/graphql"));
            */

            // Direct Endpoints
            /*
            services.AddHttpClient(Basket, x=>x.BaseAddress = new Uri($"http://localhost:10001/graphql"));
            services.AddHttpClient(Customer, x=>x.BaseAddress = new Uri("http://localhost:10002/graphql"));
            services.AddHttpClient(Inventory, x=>x.BaseAddress = new Uri($"http://localhost:10003/graphql"));
            services.AddHttpClient(Payment, x=>x.BaseAddress = new Uri($"http://localhost:10004/graphql"));
            services.AddHttpClient(Product, x=>x.BaseAddress = new Uri($"http://localhost:10005/graphql"));
            */

            // Darp endpoints
            services.AddHttpClient(Basket, x=>x.BaseAddress = new Uri($"http://localhost:20001/v1.0/invoke/dapr-gql-basket/method/graphql"));
            services.AddHttpClient(Customer, x=>x.BaseAddress = new Uri("http://localhost:20002/v1.0/invoke/dapr-gql-customer/method/graphql"));
            services.AddHttpClient(Inventory, x=>x.BaseAddress = new Uri($"http://localhost:20003/v1.0/invoke/dapr-gql-inventory/method/graphql"));
            services.AddHttpClient(Payment, x=>x.BaseAddress = new Uri($"http://localhost:20004/v1.0/invoke/dapr-gql-payment/method/graphql"));
            services.AddHttpClient(Product, x=>x.BaseAddress = new Uri($"http://localhost:20005/v1.0/invoke/dapr-gql-product/method/graphql"));



            http://localhost:20005/v1.0/invoke/dapr-gql-product/method/graphql

            services.AddGraphQLServer()
            //.AddQueryType(d => d.Name("Query")) <-- used when stitching query and overriding source root schemas
            .AddRemoteSchema(Basket, ignoreRootTypes: false)
            .AddTypeExtensionsFromFile("basket.stitches.graphql")
            .AddRemoteSchema(Customer)
            .AddRemoteSchema(Inventory)
            .AddRemoteSchema(Payment)
            .AddRemoteSchema(Product);
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseVoyager("/graphql","/voyager");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapSubscribeHandler();
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
