using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace dapr.gql.basket
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReserveMutation
        : global::StrawberryShake.IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            97,
            52,
            51,
            101,
            50,
            98,
            57,
            54,
            49,
            48,
            98,
            48,
            51,
            102,
            55,
            99,
            98,
            54,
            102,
            50,
            99,
            100,
            98,
            99,
            55,
            99,
            100,
            99,
            102,
            55,
            51,
            56
        };
        private readonly byte[] _content = new byte[]
        {
            109,
            117,
            116,
            97,
            116,
            105,
            111,
            110,
            32,
            82,
            101,
            115,
            101,
            114,
            118,
            101,
            32,
            123,
            32,
            114,
            101,
            115,
            101,
            114,
            118,
            101,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            112,
            114,
            111,
            100,
            117,
            99,
            116,
            73,
            100,
            32,
            113,
            117,
            97,
            110,
            116,
            105,
            116,
            121,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static ReserveMutation Default { get; } = new ReserveMutation();

        public override string ToString() => 
            @"mutation Reserve {
              reserve {
                productId
                quantity
              }
            }";
    }
}
