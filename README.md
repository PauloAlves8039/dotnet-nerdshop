<h1 align="center">NerdShop</h1>

## :computer: Projeto

Repositório com uma aplicação web para simular uma loja virtual fictícia, onde é possível visualizar uma lista de produtos e utilizar um carrinho de compras para a venda ser efetivada.

## Decisões Técnicas

Foi decidida a utilização de uma arquitetura [MVC](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-7.0) no projeto visando uma melhor produtividade através da linguagem [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/getting-started/) e o [ASP.NET MVC](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-7.0&tabs=visual-studio), a partir de uma estrutura base foi possível realizar a implementação projeto de uma forma mais objetiva.

O Nerdshop possui dois modelos de domínios `Categoria` e `Produto`, assim foi criado um relacionamento de Um-Para-Muitos onde uma Categoria pode ter um ou mais Produtos aplicando um CRUD.   

## :wrench: Recursos Utilizados

- [Visual Studio v17.6.4](https://visualstudio.microsoft.com/pt-br/downloads/)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/getting-started/)
- [ASP.NET MVC](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-7.0&tabs=visual-studio)
- [Entity Framework Core v6.0.19](https://learn.microsoft.com/en-us/ef/core/)
- [Code First Migrations](https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/)
- [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Identity Framework Core v6.0.19](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore?view=aspnetcore-7.0)
- [ReflectionIT Mvc Paging](https://github.com/sonnemaf/ReflectionIT.Mvc.Paging)
- [Bootstrap  v5.1.0](https://getbootstrap.com/)
- [Imagem dos Produtos - NerdStore](https://nerdstore.com.br/?gclid=EAIaIQobChMIkubCy6f4_wIVMeVcCh3wBQZPEAAYASAAEgJurfD_BwE)

Foi utilizado o SGBD [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) por ser uma tecnologia da Microsoft e ter recursos que facilitam o gerenciamento das bases de dados, em sequência
foi usado a ferramenta ORM [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) para realizar a criação e conexão com o banco de dados com a abordagem  [Code First Migrations](https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/), a decisão de uso desta ferramenta foi com o propósito de ganho de tempo em comparação ao uso do [ADO.NET](https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/ado-net-overview).

O [Identity Framework Core](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore?view=aspnetcore-7.0) foi acrescentado para gerenciar os acessos a loja virtual, inicialmente foram criados dois usuários, o `admin@localhost` que tem acesso a área adminsitrativa e toda aplição, e o comum `usuario@localhost` que possui acesso a loja virtual exceto a área administrativa, com isso é necessário que todos os usuários realizem o procedimento de `Logon` de acordo com seu perfil. 

O [ReflectionIT Mvc Paging](https://github.com/sonnemaf/ReflectionIT.Mvc.Paging) foi adicionado para a geração de relatórios de acordo com um período de datas, o objetivo é para facilitar o gerencimanto dos pediddos da loja, esse recurso só está disponível apenas para usuários com perfis administrativos. 

o [Bootstrap](https://getbootstrap.com/) foi usado para melhorar a parte de estilos nas Views, esse recurso já vem adicionando na criação do projeto.

Os recursos de imagens dos produtos foram inspirados na loja [NerdStore](https://nerdstore.com.br/?gclid=EAIaIQobChMIkubCy6f4_wIVMeVcCh3wBQZPEAAYASAAEgJurfD_BwE).

## Instruções para downlaod

### :floppy_disk: Clonar Repositório

`git clone https://github.com/PauloAlves8039/dotnet-nerdshop.git`

`Observação`: é necessário ter o [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalado e configurado com alguma ferramenta de acesso as bases de dados.

Este projeto foi desenvolvido com o [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/), após clonar o repositório abra o mesmo com essa IDE vá no menu `Tools/NuGet Package Manager/Package Manager Console` para abrir um terminal e em seguida execute o comando `Update-Database` esse procedimento vai gerar o banco de dados com a inserção de alguns registros para as categorias, produtos e usuários.

### Credencias de acesso

- usuário comum: usuário `usuario@localhost` senha `UserKey#2023`
- usuário administrativo: usuário `admin@localhost` senha `UserKey#2023`

## :camera: Screenshots

### Diagrama do Banco de Dados

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/diagrama-banco-de-dados.png"/></p>

### Tela de Login

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/tela-de-login.png"/></p>

### Home Page

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/home-page.png"/></p>

### Lista de Produtos

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/todos-os-produtos.png"/></p>

### Carrinho de Compras

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/tela-do-carrinho.png"/></p>

### Completando Pedido

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/complemento-do-pedido.png"/></p>

### Resumo do Carrinho

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/resumo-do-carrinho.png"/></p>

### Área Administrativa dos Produtos

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/area-administrativa-produtos.png"/></p>

### Área Administrativa de Relatórios

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-nerdshop/blob/master/src/NerdShop.WebApp/wwwroot/images/relatorio-dos-pedidos.png"/></p>

## Author

:boy: [Paulo Alves](https://github.com/PauloAlves8039)
