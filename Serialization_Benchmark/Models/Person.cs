﻿using ProtoBuf;

namespace Serialization_Benchmark.Models
{
    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; } = null!;
        [ProtoMember(3)]
        public int Age { get; set; }
        [ProtoMember(4)]
        public Address? Address { get; set; }
    }
}
