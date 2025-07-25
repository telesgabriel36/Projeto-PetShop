#  PetCare - Sistema de Gestão para PetShop

## Sobre o Projeto

Este sistema foi desenvolvido durante o 5º semestre do curso de Análise e Desenvolvimento de Sistemas, como parte da disciplina de Desenvolvimento Web II.

O objetivo da aplicação é auxiliar na gestão interna de um Pet Shop, permitindo o cadastro e gerenciamento de clientes, pets, serviços, agendamentos e pagamentos, bem como a criação de um histórico dos citados. 

## Tecnologias

- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap

## Funcionalidades

- Cadastro, visualização, edição e remoção de **Pets**
- Cadastro, visualização, edição e remoção de **Tutores**
- Cadastro, visualização, edição e remoção de **Serviços**
- Cadastro, visualização, edição e remoção de **Agendamentos** 
- Cadastro, visualização, edição e remoção de **Pagamentos**

## Capturas de Telas

### Tela Inicial do Sistema/ Home

Visual simples, limpo e intuitívo para o usuário.

![Tela Inicial](/Docs/Tela-Inicial-Sistema.png)

### Tela de listagem de Tutores

Nessa tela é possível visualizar, editar e remover um determinado tutor.

![Tela de listagem de Tutores](/Docs/Tela-Tutores.png)

### Tela de Cadastro de Pet

Nessa tela é possível inserir dados de um Pet e associá-lo ao seu Tutor.

![Tela de Cadastro de Pet](/Docs/Tela-Cadastrar-Pet.png)

### Tela de Agendamento

Na criação do agendamento é possível associar um Pet e um determinado serviço.

![Tela de Agendamento](/Docs/Tela-Agendamento.png)

### Tela de Deletar Pagamento

Possibilita deletar um pagamento ou cancelar a operação

![Tela de Deletar Agendamento](/Docs/Tela-Deletar-Pagamento.png)

## Como rodar

```bash
git clone https://github.com/gabrielteles/petshop.git
cd petshop
dotnet restore
dotnet run
```
