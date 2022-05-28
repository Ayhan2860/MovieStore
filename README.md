# MovieStore
Bu proje [.Net Core](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) 5.0 sürümü ile oluşturulmuştur.

<!-- ### Geliştirme Sunucusu
Bir geliştirme sunucusu için `dotnet watch run` komutunu çalıştırın. `https://localhost:5001/swagger/index.html` adresine gidin. Kaynak dosyalardan herhangi birini değiştirirseniz uyugulama otomatik olarak yeniden yüklenir. -->

### Uygulamada kullanılan kütüphane ve frameworkler
[![EF CORE](https://img.shields.io/badge/.NET_CORE_5-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![AutoMapper](https://img.shields.io/badge/Auto_Mapper-d90429?style=for-the-badge&logo=nuget&logoColor=white)](https://automapper.org/)
[![FluentValidation](https://img.shields.io/badge/FLUENT_VALIDATION-40babd?style=for-the-badge&logo=nuget&logoColor=white)](https://fluentvalidation.net/) 
[![EF CORE](https://img.shields.io/badge/ENTITY_FRAMEWORK_CORE-512bd4?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![EF CORE IN-MEMORY](https://img.shields.io/badge/EF_CORE_IN_MEMORY-512bd4?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)


## Özellikler 
  <details>
    <summary> İçeriği Göster</summary>

 ### Film
#### Operasyonlar
- Yeni Film Ekleme
- Film Güncelleme
- Film Silme
- Film Listeleme
- Id'ye Göre Bir Film Getirme

### Aktör
#### Operasyonlar
- Yeni Aktör Ekleme
- Aktör Güncelleme
- Aktör Silme
- Aktör Listeleme
- Id'ye Göre Bir Aktör Getirme       

### Yönetmen
#### Operasyonlar
- Yeni Yönetmen Ekleme
- Yönetmen Güncelleme
- Yönetmen Silme
- Yönetmen Listeleme
- Id'ye Göre Bir Yönetmen Getirme

### Tür
#### Operasyonlar
- Yeni Tür Ekleme
- Tür Güncelleme
- Tür Silme
- Tür Listeleme
- Id'ye Göre Bir Tür Getirme

### Film&Aktör
#### Operasyonlar
- Yeni Film&Aktör Ekleme
- Film&Aktör Güncelleme
- Film&Aktör Silme
- Film&Aktör Listeleme
- Id'ye Göre Bir Film&Aktör Getirme
</details><hr>

## Model
<details>
<summary>İçeriği Göster</summary>

### Movie
| Name          | Data Type     | Allow Nulls | Default |
| :------------ | :------------ | :---------- | :------ |
| Id            | int           | False       |         |
| Title         | nvarchar(25)  | False       |         |
| ReleaseDate   | datetime      | False       |         |
| Price         | decimal       | False       |         |
| DirectorId    | int           | False       |         |
| GenreId       | int           | False       |         |

### Actor
| Name        | Data Type         | Allow Nulls  | Default |
| :---------- | :---------------- | :----------- | :------ |
| Id          | int               | False        |         |
| FirstName   | nvarchar(50)      | False        |         |
| LastName    | nvarchar(50)      | False        |         |

### Director
| Name        | Data Type         | Allow Nulls  | Default |
| :---------- | :---------------- | :----------- | :------ |
| Id          | int               | False        |         |
| FirstName   | nvarchar(50)      | False        |         |
| LastName    | nvarchar(50)      | False        |         |

### Genre
| Name        | Data Type         | Allow Nulls  | Default |
| :---------- | :---------------- | :----------- | :------ |
| Id          | int               | False        |         |
| Name        | nvarchar(25)      | False        |         |

### MovieActor
| Name        | Data Type  | Allow Nulls  | Default |
| :---------- | :--------- | :----------- | :------ |
| Id          | int        | False        |         |
| MovieId     | int        | False        |         |
| ActorId     | int        | False        |         |

### Customer
| Name        | Data Type     | Allow Nulls  | Default |
| :---------- | :------------ | :----------- | :------ |
| Id          | int           | False        |         |
| FirstName   | nvarchar(50)  | False        |         |
| LastName    | nvarchar(50)  | False        |         |
| Email       | nvarchar(50)  | False        |         |
| Password    | nvarchar(100) | False        |         |

### CustomerFavoritGenre
| Name        | Data Type         | Allow Nulls  | Default |
| :---------- | :---------------- | :----------- | :------ |
| Id          | int               | False        |         |
| GenreId     | int               | False        |         |
| CustomerId  | int               | False        |         |


### Order
| Name         | Data Type     | Allow Nulls  | Default |
| :----------- | :------------ | :----------- | :------ |
| Id           | int           | False        |         |
| OrderPrice   | float         | False        |         |
| OrderDate    | dateTime      | False        |         |
| MovieId      | int           | False        |         |
| CustomerId   | int           | False        |         |


</details><hr>


## Teşekkürler
- [Zikriye Ürkmez](https://www.linkedin.com/in/zikriye-urkmez-cengiz)
- [Patika.dev](https://www.patika.dev/tr)