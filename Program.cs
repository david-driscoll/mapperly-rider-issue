// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using Riok.Mapperly.Abstractions;

Console.WriteLine("Hello, World!");

var thing = new Thing
{
    Id = Guid.NewGuid(),
    Name = "John Doe",
    Address = "123 Main St",
    City = "Anytown",
    State = "NY",
    Zip = "12345",
    Phone = "555-555-5555",
    Email = "test@example.com",
};
var model2 = MapperNoErrors.Map(thing);
var model = MapperErrors.Map(thing);

Console.WriteLine(JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true }));
Console.WriteLine(JsonSerializer.Serialize(model2, new JsonSerializerOptions { WriteIndented = true }));
public record ThingModel
{
    public string? Name { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? State { get; init; }
    public string? ZipCode { get; init; }
    public string? PhoneNumber { get; init; }
    public string? EmailAddress { get; init; }
}

public record Thing
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? State { get; init; }
    public string? Zip { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
static partial class MapperNoErrors
{
    [MapProperty(nameof(@Thing.Zip), nameof(@ThingModel.ZipCode))]
    [MapProperty(nameof(@Thing.Phone), nameof(@ThingModel.PhoneNumber))]
    [MapProperty(nameof(@Thing.Email), nameof(@ThingModel.EmailAddress))]
    public static partial ThingModel Map(Thing thing);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
static partial class MapperErrors
{
    public static partial ThingModel Map(Thing thing);
}

