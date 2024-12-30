# eCommerce Clean Architecture Projesi

Bu proje, modern yazılım geliştirme pratiklerine uygun olarak Clean Architecture prensipleriyle geliştirilmiş bir e-ticaret sistemidir. .NET 9 kullanılarak oluşturulmuştur ve veri depolama çözümü olarak MongoDB tercih edilmiştir.

## Mimarinin Özellikleri
- **Clean Architecture**: Kodun farklı katmanlara ayrılması sayesinde iş mantığı, veri erişimi ve dış dünyadan tamamen soyutlanmıştır.
- **.NET 9**: En güncel .NET sürümü kullanılarak modern C# özellikleri entegre edilmiştir.
- **MongoDB**: NoSQL veritabanı olarak kullanılmıştır.
- **CQRS (Command Query Responsibility Segregation)**: Command ve Query işlemleri farklı sınıflarda tanımlanarak sorumluluklar ayrılmıştır.
- **Dependency Injection**: `IServiceCollection` kullanılarak bağımlılıklar yönetilmiştir.
- **AutoMapper**: Nesne dönüşümleri için kullanılmıştır.
- **MediatR**: Command ve Query işlemlerinin merkezi bir şekilde yönetilmesi sağlanmıştır.

## Kullanılan Teknolojiler ve Paketler
- **.NET 9**
- **MongoDB.Driver**
- **AutoMapper**
- **MediatR**
- **Microsoft.Extensions.DependencyInjection**

## Proje Katmanları
1. **eCommerce.Api**: API katmanı, istemcilerin sistemle etkileşim kurduğu giriş noktasıdır.
    - Controller sınıfları burada bulunur (`CatalogController`, `ProductController`).
    - `Program.cs` içinde tüm bağımlılıklar eklenmiştir.
2. **eCommerce.Application**:
    - İş mantığı ve uygulama kuralları bu katmanda tanımlanmıştır.
    - **Commands**: Veritabanı üzerinde değişiklik yapan işlemler (`CreateProduct`, `UpdateProduct`, `DeleteProduct`).
    - **Queries**: Veri okuma işlemleri (`GetProductById`, `GetProducts`).
    - **Dtos**: Veri transfer nesneleri.
3. **eCommerce.Domain**: Temel iş modelinin bulunduğu katmandır.
    - **Entities**: Veritabanı nesneleri (`Product`, `Catalog`, vb.).
4. **eCommerce.Infrastructure**: Veritabanı ve dış sistemlerle olan bağlantıların yönetildiği katmandır.
    - **MongoDbContext**: MongoDB bağlantı yapılandırması burada gerçekleştirilmiştir.
    - Repositories ve veri erişim kodları.

## Proje Yapılandırması
### Dependency Injection
Tüm bağımlılıklar `DependencyInjection` sınıflarında tanımlanır ve `IServiceCollection` üzerinden uygulanır:
- **MediatR**: Command ve Query işlemlerinin yönetimi için eklendi.
- **AutoMapper**: DTO ve Entity dönüşümleri için yapılandırıldı.
- **MongoDbContext**: MongoDB bağlantısı için yapılandırıldı.

### Örnek MongoDbContext
```csharp
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var client = new MongoClient("mongodb://<username>:<password>@<host>:<port>");
        _database = client.GetDatabase("eCommerce");
    }

    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    public IMongoCollection<Catalog> Catalogs => _database.GetCollection<Catalog>("Catalogs");
}
