using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.Domain.Entities.Base;

public abstract class BaseEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}