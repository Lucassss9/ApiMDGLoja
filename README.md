# API MDGLoja

API RESTful construída com ASP.NET Core 8 para gerenciamento de clientes, endereços, produtos, pedidos e entregas.

---

## 1. Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (local ou remoto)
- Git (para versionamento)
- Navegador para acessar Swagger UI

---

## 2. Configuração da conexão com o banco de dados

No arquivo `appsettings.json`, configure a string de conexão com seu banco SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=MDG;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
