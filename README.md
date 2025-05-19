# ApiMDGLoja

## Sobre o Projeto

ApiMDGLoja é uma API RESTful desenvolvida em **.NET 8** para gerenciar os dados de uma loja simples. Com ela, é possível cadastrar e gerenciar clientes, endereços, produtos, pedidos, itens de pedidos e entregas.

A API foi criada para servir de backend para aplicações que precisam manipular essas informações, permitindo operações básicas de CRUD (Create, Read, Update, Delete) em cada entidade.

---

## Funcionalidades

- Gerenciamento completo de clientes  
- Cadastro e atualização de endereços vinculados aos clientes  
- Controle dos produtos disponíveis na loja  
- Gerenciamento de pedidos, incluindo detalhes dos itens  
- Controle das entregas relacionadas aos pedidos  

---

## Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)  
- Entity Framework Core para acesso e manipulação do banco de dados  
- SQL Server como banco de dados relacional  
- Swagger para documentação e testes interativos da API  

---

## Estrutura do Projeto

O projeto é dividido em controllers para cada entidade, responsáveis por lidar com as requisições HTTP:

- **ClienteController** – Gerencia clientes  
- **EnderecoController** – Gerencia endereços dos clientes  
- **ProdutoController** – Gerencia produtos da loja  
- **PedidoController** – Gerencia pedidos realizados  
- **ItensPedidoController** – Gerencia os itens dentro dos pedidos  
- **EntregaController** – Gerencia entregas dos pedidos  

Cada controller implementa as operações CRUD utilizando rotas RESTful seguindo as melhores práticas.

---

## Como Rodar Localmente

1. Instale o [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) e o [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) em sua máquina.  
2. Clone o repositório:
   ```bash
   git clone https://github.com/Lucassss9/ApiMDGLoja.git

   Navegue até a pasta do projeto:

bash
Copy
Edit
cd ApiMDGLoja
Configure a string de conexão do banco de dados no arquivo appsettings.json para apontar para o seu SQL Server local.

Execute as migrações para criar as tabelas no banco (se usar EF Core migrations):

bash
Copy
Edit
dotnet ef database update
Rode o projeto:

bash
Copy
Edit
dotnet run
Acesse a documentação da API via Swagger em:

bash
Copy
Edit
https://localhost:{porta}/swagger/index.html
(A porta será mostrada no terminal ao iniciar a aplicação.)

Testando a API
Use o Swagger para testar todos os endpoints diretamente pelo navegador. Você pode enviar requisições GET, POST, PUT e DELETE para as rotas definidas nos controllers.

Comandos Git Úteis para Subir o Projeto
Se ainda não fez o upload do projeto para o GitHub, aqui está um passo a passo básico:

bash
Copy
Edit
git init
git add .
git commit -m "Primeiro commit da ApiMDGLoja"
git branch -M master
git remote add origin https://github.com/Lucassss9/ApiMDGLoja.git
git push -u origin master
Se ocorrer conflito (porque já existe algo no repositório remoto), faça um pull antes:

bash
Copy
Edit
git pull origin master --allow-unrelated-histories
git add .
git commit -m "Resolve conflitos do pull"
git push -u origin master
Contribuição
Contribuições são bem-vindas! Para contribuir:

Faça um fork do projeto

Crie uma branch para sua feature ou correção (git checkout -b minha-feature)

Faça commit das suas alterações (git commit -m "Minha nova feature")

Envie para o seu repositório (git push origin minha-feature)

Abra um pull request explicando suas mudanças

Contato
Se tiver dúvidas ou quiser sugerir algo, abra uma issue no repositório ou me envie uma mensagem.

Desenvolvido por Lucas Gabriel dos Santos
Curso de Análise e Desenvolvimento de Sistemas
2025
