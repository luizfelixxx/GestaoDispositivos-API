# API de Gestão de Dispositivos e Eventos

API RESTful desenvolvida em .NET 9 para um desafio técnico, seguindo os princípios de Arquitetura Limpa (Clean Architecture) e Domain-Driven Design (DDD).

A solução é totalmente containerizada com Docker para garantir um ambiente de desenvolvimento e execução consistente e de fácil configuração.

## Tecnologias e Padrões

* **.NET 9**
* **ASP.NET Core**
* **Entity Framework Core**
* **SQL Server**
* **Clean Architecture/DDD**
* **Padrão de Repositório** (Repository Pattern)
* **Abordagem de Casos de Uso** (Use Cases)
* **Docker**

## Pré-requisitos

* [Docker](https://www.docker.com/products/docker-desktop/)  `docker-compose`.
* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (Apenas para execução local).

---

## Como Executar a Aplicação 

Este método irá construir a imagem da API, iniciar um contêiner para a aplicação e outro para o banco de dados SQL Server, conectando ambos.

**1. Clone o Repositório**
```bash
    git clone <url-do-seu-repositorio>
    cd <nome-do-repositorio>
```

**2. Execute com Docker Compose**

Na pasta raiz do projeto (onde o arquivo `docker-compose.yml` está localizado), execute o seguinte comando:

```bash
    docker-compose up --build
```




-   O comando `--build` garante que a imagem da API seja construída com o código mais recente.
    
-   Na primeira execução, pode levar alguns minutos para baixar a imagem do SQL Server.
    
-   A aplicação irá iniciar e aplicar as migrações do banco de dados automaticamente. Você verá logs de ambos os contêineres no seu terminal.
    

**3. Acesse a API**

-   **URL da API:**  `http://localhost:8080`
    
-   **Documentação Interativa (Swagger):**  `http://localhost:8080/swagger`
    

