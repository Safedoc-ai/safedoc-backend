📌 Sobre o Projeto

O SafeDoc AI é um sistema desenvolvido para gerenciamento e controle de documentos, com foco em organização, validação e análise automatizada.

A proposta do projeto é centralizar documentos de diferentes unidades, permitindo acompanhar o status de cada item, garantir conformidade e facilitar a tomada de decisão.

Além disso, o sistema simula a integração com inteligência artificial para análise de documentos, agregando valor ao processo de verificação.

🎯 Conceito do Projeto

O projeto segue o conceito de um sistema de gestão documental inteligente, onde:

Cada unidade possui seus próprios documentos
Os documentos passam por um processo de validação
O sistema define automaticamente o status (válido, pendente, inválido)
Existe uma simulação de análise por IA (mock), representando automação futura

A ideia central é reduzir processos manuais, melhorar a organização e dar mais visibilidade sobre a situação dos documentos.

⚙️ Como o Projeto Funciona

O sistema é dividido em duas partes principais:

🔹 Back-end (API)

Responsável por toda a lógica do sistema:

Gerenciamento de unidades e documentos
Regras de negócio (cálculo de status)
Upload de arquivos
Simulação de análise com IA
Comunicação com banco de dados

🧠 Arquitetura e Organização
Controller → Service → Repository → Banco de Dados

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


🔄 Organização do Desenvolvimento

O projeto foi desenvolvido de forma progressiva, seguindo etapas bem definidas:

Estruturação inicial do projeto e entidades
Configuração do banco de dados
Criação da API REST (CRUD)
Implementação das regras de negócio
Integração com front-end e upload
Refatoração e validações
Estabilização e testes
Finalização e entrega

🚀 Diferenciais do Projeto
Arquitetura organizada em camadas
Uso de boas práticas com DTOs e Services
Separação clara de responsabilidades
Simulação de integração com IA
API REST estruturada
Preparado para evolução futura (IA real, autenticação, etc.)




