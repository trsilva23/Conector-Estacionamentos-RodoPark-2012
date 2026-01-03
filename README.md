# Projeto Legado (2012) - Conexão RodoPark e Gestão Predial

Este projeto consiste no desenvolvimento de uma Integração para conectar o sistema de controle de acesso da rede de estacionamentos RodoPark (Desktop/C#) à plataforma de gestão de condomínios do cliente (Ambiente Web PHP/Linux).

O objetivo principal da solução é permitir que a liberação das cancelas ocorra de forma automática e inteligente, validando em tempo real se os condôminos estão devidamente cadastrados ou se possuem pendências financeiras (inadimplência) no sistema do síndico.

## Tecnologias Utilizadas
- **Linguagem Principal:** C# 
- **Framework:** .NET Framework 4.5 e ASP.NET Web API 1
- **Linguagem do Sistema Cliente:** PHP 5.4 (Sistema do Condomínio)
- **Banco de Dados:** Microsoft SQL Server 2008 R2
- **Protocolo de Comunicação:** REST / JSON via HTTP

## Padrões de Projeto Aplicados (Design Patterns)
- **DTO (Data Transfer Object):** Utilizado para o tráfego de informações entre o sistema PHP e a API C#, garantindo a integridade dos dados e performance na comunicação.
- **MVC (Model-View-Controller):** Estrutura base da API para separação clara entre a lógica de rotas, processamento de dados e os modelos de entidade.
- **Facade/Adapter:** A integração atua como uma fachada para o sistema de banco de dados legado, expondo apenas os métodos estritamente necessários para a integração, protegendo a regra de negócio interna.

## Funcionamento
1. **Sincronização Ativa:** Sempre que um condômino é cadastrado ou altera seu status financeiro no sistema PHP, um gatilho envia um objeto JSON para o conector desenvolvido em C#.
2. **Base Espelhada (Fallback):** O sistema de estacionamento mantém uma tabela local sincronizada (`Condominos_Integracao`). Isso garante que o controle de acesso continue operando em modo offline.
3. **Validação de Cancela:** O software de portaria (Desktop) consulta esta API local para validar se a placa identificada pelos sensores possui permissão imediata de entrada.

## Estrutura do Repositório
- `/ParkConnect.Models`: Entidades de dados e DTOs compartilhados entre as camadas.
- `/ParkConnect.Api`: Projeto ASP.NET Web API responsável por receber e processar as requisições externas.
- `/Sindrome_System_Integration/cliente_php`: Exemplo técnico da implementação do lado do cliente (PHP) que realiza o consumo da API C#.
