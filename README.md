# Backend da Aplicação de Monitoramento
Este projeto contém a API RESTful desenvolvida em .NET para o desafio de estágio. A API simula o monitoramento de máquinas pesadas, permitindo o cadastro, a consulta e a atualização de dados de telemetria.

## Tecnologias Utilizadas
.NET 8

ASP.NET Core Web API

## Como Rodar o Projeto
Certifique-se de que o .NET SDK está instalado em sua máquina.

Navegue até a pasta do projeto no terminal (Backend/MyMachineAPI).

Execute o seguinte comando para iniciar a API:

dotnet run

A API será iniciada e estará disponível em https://localhost:5075 (a porta pode variar).

## Endpoints da API
A API possui os seguintes endpoints principais para a entidade Máquina.

### GET /api/Machines

Descrição: Lista todas as máquinas cadastradas.

Parâmetros de Consulta (Opcional):

status: Filtra as máquinas por status (e.g., Operando, Manutenção, Desligada).

Exemplo de Resposta:

[
  {
    "id": "e2e9b0d3-5f8e-4a7b-8b5e-9a2c3d1f4e5a",
    "name": "Escavadeira X-2000",
    "location": "Pedreira Serra Azul",
    "status": "Operando"
  }
]

### POST /api/Machines

Descrição: Cadastra uma nova máquina.

Corpo da Requisição:

{
  "name": "Caminhão de Carga Y",
  "location": "Mina de Ferro Beta",
  "status": "Operando"
}

Resposta: Retorna a máquina criada com o ID gerado automaticamente.

### PUT /api/Machines/{id}

Descrição: Atualiza o status e/ou a localização de uma máquina específica.

Parâmetros de Rota:

{id}: O ID único da máquina a ser atualizada.

Corpo da Requisição:

{
  "id": "e2e9b0d3-5f8e-4a7b-8b5e-9a2c3d1f4e5a",
  "location": "Centro de Manutenção",
  "status": "Parada para Manutenção"
}

Resposta: Retorna um status de sucesso 204 No Content se a atualização for bem-sucedida.