using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace dapr.gql.product.gqlgen {
  public class Types {
    
    #region Query
    public class Query {
      #region members
      [JsonProperty("product")]
      public Product product { get; set; }
      #endregion
    }
    #endregion
    
    public interface Node {
      [JsonProperty("id")]
      public string id { get; set; }
    }
    
    #region Product
    public class Product : Node {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("code")]
      public string code { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("description")]
      public string description { get; set; }
      #endregion
    }
    #endregion
  }
  
}

namespace dapr.gql.product.gqlgen {

    public class GetProductGQL {
      /// <summary>
      /// GetProductGQL.Request 
      /// <para>Required variables:<br/> { Id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetProductDocument,
          OperationName = "getProduct",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetProductGQL() {
        return Request();
      }
      
      public static string GetProductDocument = @"
        query getProduct($Id: ID!) {
          product(id: $Id) {
            ...getProductFields
          }
        }
        fragment getProductFields on Product {
          id
          code
          name
          description
        }";
    }
    
}