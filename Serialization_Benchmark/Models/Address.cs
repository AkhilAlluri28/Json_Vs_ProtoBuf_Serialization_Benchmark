using ProtoBuf;

namespace Serialization_Benchmark.Models
{
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string Street { get; set; } = null!;
        [ProtoMember(2)]
        public string City { get; set; } = null!;
        [ProtoMember(3)]
        public string State { get; set; } = null!;
        [ProtoMember(4)]
        public int Zipcode { get; set; }
    }
}
