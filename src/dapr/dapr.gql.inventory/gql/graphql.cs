using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace dapr.gql.inventory.gqlgen {
  public class Types {
    
    #region Query
    public class Query {
      #region members
      [JsonProperty("product")]
      public ProductQuantity product { get; set; }
      #endregion
    }
    #endregion
    
    public interface Node {
      [JsonProperty("id")]
      public string id { get; set; }
    }
    
    #region ProductQuantity
    public class ProductQuantity : Node {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("quantity")]
      public float? quantity { get; set; }
      #endregion
    }
    #endregion
  }
  
}

namespace dapr.gql.inventory.gqlgen {

    public class FindProductGQL {
      /// <summary>
      /// FindProductGQL.Request 
      /// <para>Required variables:<br/> { Id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = FindProductDocument,
          OperationName = "findProduct",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getFindProductGQL() {
        return Request();
      }
      
      public static string FindProductDocument = @"
        query findProduct($Id: ID!) {
          product(id: $Id) {
            ...ProductFields
          }
        }
        fragment ProductFields on ProductQuantity {
          id
          quantity
        }";
    }
    
}