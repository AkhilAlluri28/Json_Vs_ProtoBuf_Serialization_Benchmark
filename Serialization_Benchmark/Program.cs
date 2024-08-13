using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using ProtoBuf;
using Serialization_Benchmark.Models;
using System.Reflection;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);

[MemoryDiagnoser]
[MediumRunJob]
public class SerializationBenchmark
{
    private Person _person;
    private byte[] _jsonData;
    private byte[] _protobufData;


    // Test-change
    [GlobalSetup]
    public void Setup()
    {
        _person = new Person
        {
            Id = 1,
            Name = "Test",
            Age = 99,
            Address = new Address
            {
                Street = "street-name",
                City = "city-name",
                State = "state-name",
                Zipcode = 12345
            }
        };

        _jsonData = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_person));

        using var memoryStream = new MemoryStream();
        Serializer.Serialize(memoryStream, _person);
         
        _protobufData = memoryStream.ToArray();
    }

    [Benchmark]
    public byte[] JsonSerializer()
    {
        return System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_person));
    }

    [Benchmark]
    public Person JsonDeserializer()
    {
        string json = System.Text.Encoding.UTF8.GetString(_jsonData);
        return JsonConvert.DeserializeObject<Person>(json);
    }

    [Benchmark]
    public byte[] ProtobuffSerializer()
    {
        using var memoryStream = new MemoryStream();
        Serializer.Serialize(memoryStream, _person);
        return memoryStream.ToArray();
    }

    [Benchmark]
    public Person ProtobuffDeserializer()
    {
        using var memoryStream = new MemoryStream(_protobufData);
        return Serializer.Deserialize<Person>(memoryStream);
    }
}