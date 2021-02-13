using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReserveResultParser
        : JsonResultParserBase<IReserve>
    {
        private readonly IValueSerializer _intSerializer;

        public ReserveResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IReserve ParserData(JsonElement data)
        {
            return new Reserve1
            (
                ParseReserveReserve(data, "reserve")
            );

        }

        private global::dapr.gql.basket.IReserveQuantityResponse ParseReserveReserve(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new ReserveQuantityResponse
            (
                DeserializeInt(obj, "productId"),
                DeserializeInt(obj, "quantity")
            );
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
    }
}
