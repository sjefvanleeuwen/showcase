using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReserveOperation
        : IOperation<IReserve>
    {
        public string Name => "Reserve";

        public IDocument Document => ReserveMutation.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IReserve);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
