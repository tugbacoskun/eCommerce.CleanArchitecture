using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace eCommerce.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    { 
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var client = new MongoClient("mongodb://root:Password1!@146.103.26.76:27017");
        BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
        {
            cm.AutoMap();
            cm.MapMember(c => c.Id).SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
        });
        _database = client.GetDatabase("eCommerce");
    }

    public IMongoCollection<Catalog> Catalogs => _database.GetCollection<Catalog>("Catalogs");
    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    public IMongoCollection<CatalogProduct> CatalogProducts => _database.GetCollection<CatalogProduct>("CatalogProducts");
}