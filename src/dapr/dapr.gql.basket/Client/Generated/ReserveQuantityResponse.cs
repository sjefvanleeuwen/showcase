using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReserveQuantityResponse
        : IReserveQuantityResponse
    {
        public ReserveQuantityResponse(
            int productId, 
            int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; }

        public int Quantity { get; }
    }
}
