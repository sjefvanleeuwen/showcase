using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Reserve1
        : IReserve
    {
        public Reserve1(
            global::dapr.gql.basket.IReserveQuantityResponse reserve)
        {
            Reserve = reserve;
        }

        public global::dapr.gql.basket.IReserveQuantityResponse Reserve { get; }
    }
}
