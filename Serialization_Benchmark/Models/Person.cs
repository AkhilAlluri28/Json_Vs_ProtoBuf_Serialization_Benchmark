using ProtoBuf;
namespace Serialization_Benchmark.Models
{
    /// <summary>
    /// Person record.
    /// </summary>
    [ProtoContract]
    public class Person
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
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
