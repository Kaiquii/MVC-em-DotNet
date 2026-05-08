# Cadastro N1

Projeto ASP.NET Core MVC para cadastro de clientes e produtos.

O sistema permite cadastrar clientes, cadastrar produtos e vincular cada produto a um cliente e a uma categoria. A aplicação usa Entity Framework Core com banco em memória, então os dados ficam disponíveis apenas enquanto a aplicação estiver em execução.

## Funcionalidades

- Cadastro, listagem, edição, detalhes e exclusão de clientes.
- Cadastro, listagem, edição, detalhes e exclusão de produtos.
- Seleção de cliente no cadastro de produto.
- Seleção de categoria no cadastro de produto.
- Código gerado automaticamente para clientes e produtos.
- Mensagens de validação nos formulários.
- Tema claro e escuro com preferência salva no navegador.

## Tecnologias

- .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- Entity Framework Core InMemory
- AutoMapper
- Bootstrap
- jQuery

## Estrutura do projeto

```text
Controllers/        Controllers MVC da aplicação
Domain/             Entidades e interfaces de domínio
Infrastructure/     Contexto EF, repositórios, mapeamentos e injeção de dependência
Interfaces/         Interfaces dos serviços de ViewModel
Services/           Serviços usados pelas telas
ViewModels/         ViewModels das telas
Views/              Views Razor
wwwroot/            Arquivos estáticos como CSS, JavaScript e bibliotecas
```

## Como rodar

Na raiz do projeto, execute:

```bash
dotnet run --urls http://localhost:5077
```

Depois acesse no navegador:

```text
http://localhost:5077
```

## Como usar

1. Acesse a tela inicial.
2. Cadastre um cliente em `Clientes > Novo Cliente`.
3. Acesse `Produtos > Novo Produto`.
4. Preencha os dados do produto.
5. Selecione o cliente cadastrado.
6. Selecione uma categoria.
7. Salve o produto.

## Observações

Como o projeto usa banco em memória, os dados cadastrados são perdidos quando a aplicação é encerrada. Para testar o cadastro de produtos, cadastre primeiro pelo menos um cliente.

O arquivo `CadastroN1.sln` fica fora da pasta do projeto e aponta para `Cadastro/Cadastro.csproj`.
