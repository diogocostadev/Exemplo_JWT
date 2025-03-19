# JWT Authentication em ASP.NET Core

Este projeto demonstra a implementação de autenticação e autorização usando JSON Web Tokens (JWT) em uma API ASP.NET Core. Ideal para fins educacionais e como ponto de partida para projetos que necessitam de controle de acesso.

## Características

- Autenticação baseada em JWT
- Autorização baseada em roles (Admin e User)
- Configuração de expiração de tokens
- Proteção de rotas por políticas de autorização
- Implementação de boas práticas de segurança

## Requisitos

- .NET 7.0 ou superior
- Visual Studio 2022 ou VS Code

## Como executar

1. Clone o repositório:
   ```
   git clone https://github.com/diogocostadev/Exemplo_JWT
   cd Exemplo_JWT
   ```

2. Restaure os pacotes:
   ```
   dotnet restore
   ```

3. Execute o projeto:
   ```
   dotnet run
   ```

4. A API estará disponível em:
   - https://localhost:7xxx (HTTPS)
   - http://localhost:5xxx (HTTP)

## Estrutura do Projeto

- **Controllers/AuthController.cs**: Endpoints para autenticação e rotas protegidas
- **Models/**: Modelos de dados
- **Services/**: Serviços para gerenciamento de usuários e tokens JWT
- **Program.cs**: Configuração da aplicação, middleware de autenticação

## Endpoints da API

### Autenticação

- **POST /api/auth/login**: Obtém um token JWT
  ```json
  {
    "username": "admin",
    "password": "admin123"
  }
  ```

### Rotas Protegidas

- **GET /api/auth/profile**: Acessível para usuários autenticados (Admin e User)
- **GET /api/auth/admin**: Acessível apenas para usuários com role Admin

## Testando com Arquivo HTTP

Incluímos um arquivo `.http` para testar facilmente a API usando a extensão REST Client no VS Code ou usando o HTTP Client no Visual Studio:

1. Abra o arquivo `requests.http`
2. Clique em "Send Request" acima de cada requisição para testar
3. Os tokens são automaticamente capturados das respostas de login

## Usuários para Teste

| Usuário  | Senha    | Role  | Acesso                   |
|----------|----------|-------|--------------------------|
| admin    | admin123 | Admin | /profile, /admin         |
| usuario  | senha123 | User  | /profile                 |

## Considerações de Segurança

- Em ambiente de produção, use variáveis de ambiente ou gerenciamento seguro de segredos para armazenar a chave JWT
- Considere implementar refresh tokens para melhor experiência do usuário
- Sempre use HTTPS em produção
- Considere implementar um sistema de revogação de tokens quando necessário

## Próximos Passos

- Implementar refresh tokens
- Adicionar persistência de usuários em banco de dados
- Implementar validação de senhas mais robusta
- Adicionar log de eventos de autenticação
- Implementar expiração configurável de tokens

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo LICENSE para detalhes.