
# E-Ticaret Projesi - Onion Architecture

Bu proje, **Onion Architecture** mimarisine dayalı bir E-Ticaret API uygulamasıdır. Projede **CQRS** ve **MediatR** gibi tasarım desenleri kullanılarak modüler, ölçeklenebilir ve test edilebilir bir yapı hedeflenmiştir.

## Proje Yapısı

Projede katmanlar şu şekilde yapılandırılmıştır:

1. **Core**: Uygulamanın temel iş kurallarını ve soyutlamalarını içerir.
2. **Application**: İş mantığı ve veri erişim operasyonlarını içerir.
3. **Infrastructure**: Dış dünya ile olan iletişim ve veri saklama katmanı. Veri tabanı bağlantıları, repository yapısı burada bulunur.
4. **Presentation**: API katmanıdır. Kullanıcıların (client) sistemi kullanacağı endpointler burada tanımlanır.

## Kullanılan Teknolojiler

- **ASP.NET Core 7**: Web API geliştirme
- **Entity Framework Core**: Veritabanı işlemleri
- **MediatR**: SORUMLULUKLARIN AYRIMI (CQRS) yapısı
- **MySQL**: Veritabanı yönetimi
- **Redis**: Cache işlemleri
- **RabbitMQ**: Mesaj kuyruğu yönetimi
- **Docker**: Konteyner tabanlı uygulama dağıtımı

## Kurulum

Projeyi yerel ortamda çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

### 1. Gereksinimler

- .NET 7 SDK
- MySQL Server
- Docker (isteğe bağlı olarak RabbitMQ ve Redis için)

### 2. Bağımlılıkları Yükleyin

```bash
dotnet restore
```

### 3. Veritabanını Hazırlayın

MySQL üzerinde bir veritabanı oluşturun ve `appsettings.json` dosyasındaki bağlantı dizgisini (connection string) buna göre güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=eticaret;User=root;Password=yourpassword;"
}
```

### 4. Veritabanı Migration'larını Uygulayın

```bash
dotnet ef database update
```

### 5. Uygulamayı Çalıştırın

```bash
dotnet run
```

## Özellikler

- **Ürün Yönetimi**: Ürün ekleme, güncelleme, silme, listeleme
- **Kategori Yönetimi**: Kategoriler arasında ilişkisel veri yönetimi
- **Kullanıcı Yönetimi**: Kimlik doğrulama ve yetkilendirme işlemleri
- **Cacheleme**: Redis ile cache yönetimi
- **Mesaj Kuyruğu**: RabbitMQ ile mesaj yönetimi

## Katkıda Bulunma

Katkıda bulunmak isterseniz, pull request göndererek projeyi geliştirebilirsiniz.
