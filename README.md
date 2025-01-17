# Teste BitZen
Teste backend .Net da BitZen

# Framework
.Net Core 3.1

# Bibliotecas
Flunt -> Andre Baltieri
 Utilizada para realizar validações dos parametros e retornar as notificações

# Execução
Utilizando pelo comando dotnet run ou debug no Visual Studio a Api vai iniciar na porta 3000, a mesma está documentada com OpenAPI (antigo Swagger).

# Estrutura de Pastas
 
**Projeto Api**
 A Api está versionada ex: V1, V2
 ```folder
 Api 
  -> bin
  -> v1
      -> Controllers
          -> UsuarioController.cs
  -> v2
      -> Controllers
          -> UsuarioController.cs
```
**Projeto Domain**
 - **Dtos**     - Pasta onde ficam as classes de são utilizadas como parâmetro de entrada na api e Interfaces, para cada entidade foi criado uma pasta de mesmo nome
 - **Entities** - Pasta onde ficam as entitades utilizadas no DataContext.
 - **Services** - Todo o processo negocial está concentrado aqui no Service
 ```folder
 Domain
  -> Dtos
    Interfaces
      -> IBaseDTO.cs
    Medico
      -> UsuarioDTO.cs
  -> Entities
      -> Usuario.cs    
  -> Interfaces
      -> IRepository.cs
  -> Services
      -> UsuarioService.cs  
```

**Projeto Infra**
 - **Data**         - Configuração do Data Context como mapeamento das Entidades para a criação das migration
 - **Migrations**   - Migrations geradas
 - **Repositories** - Todos os metodos que manipulam as informações da base de dados
 ```folder
 Infra
  -> Data
    DataMapping
      -> UsuarioMapping.cs
    DataContext.cs
  -> Migrations
  -> Repositories
    -> UsuarioRepository.cs
```

**Projeto Tests**
  - **Fakes**    - Fakes de repositories
  - **Services** - Classes para tests dos services
```folder
  Tests
    -> Fakes
      -> FakeUsuarioRepository.cs
    -> Services
      -> UsuarioServicesTests.cs
```
