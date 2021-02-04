using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dapr.gql.product.Model {
    public class Product {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public Decimal UnitPrice {get;set;}
    }
}