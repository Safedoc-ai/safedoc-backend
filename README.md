📁 Estrutura do Projeto (Back-end)

SafeDocAI.API/
│
├── Controllers/
│   ├── UnidadeController.cs
│   ├── DocumentoController.cs
│   └── UploadController.cs
│
├── Models/
│   ├── Unidade.cs
│   ├── Documento.cs
│   └── Enum/
│       └── StatusDocumento.cs
│
├── DTOs/
│   ├── UnidadeDTO.cs
│   ├── DocumentoDTO.cs
│   └── UploadDTO.cs
│
├── Data/
│   ├── AppDbContext.cs
│   └── Migrations/
│
├── Services/
│   ├── UnidadeService.cs
│   ├── DocumentoService.cs
│   └── IAServiceMock.cs
│
├── Repositories/
│   ├── IUnidadeRepository.cs
│   ├── UnidadeRepository.cs
│   ├── IDocumentoRepository.cs
│   └── DocumentoRepository.cs
│
├── Config/
│   └── AutoMapperProfile.cs
│
├── Middlewares/
│   └── ErrorHandlingMiddleware.cs
│
├── Utils/
│   └── FileHelper.cs
│
├── appsettings.json
├── Program.cs
└── Startup.cs (se estiver usando .NET antigo)


📌 Explicação da Estrutura
🔹 Controllers

Responsáveis por receber as requisições HTTP e retornar as respostas.

Ex: CRUD, upload, endpoints REST
🔹 Models

Representam as entidades do banco de dados.

Ex: Unidade, Documento
🔹 DTOs

Objetos usados para transferência de dados (entrada/saída da API).

Evita expor diretamente os models
🔹 Data
DbContext (Entity Framework)
Migrations e conexão com banco
🔹 Services

Onde fica a regra de negócio

Processamento
Cálculo de status
Integrações (ex: IA mock)
🔹 Repositories

Camada de acesso ao banco

Separação de responsabilidade (boas práticas)
🔹 Config

Configurações gerais

Ex: AutoMapper
🔹 Middlewares

Interceptação global

Tratamento de erros
Logs
🔹 Utils

Funções auxiliares

Upload de arquivos, helpers, etc
