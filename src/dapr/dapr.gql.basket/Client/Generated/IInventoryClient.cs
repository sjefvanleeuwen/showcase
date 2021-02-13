using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IInventoryClient
    {
        Task<IOperationResult<global::dapr.gql.basket.IReserve>> ReserveAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::dapr.gql.basket.IReserve>> ReserveAsync(
            ReserveOperation operation,
            CancellationToken cancellationToken = default);
    }
}
