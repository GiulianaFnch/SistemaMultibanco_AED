# 🏦 Sistema Multibanco Simulado

Projeto final desenvolvido para a disciplina de Algoritmia e Estruturas de Dados (AED). Trata-se de uma aplicação desktop que simula o funcionamento de uma caixa Multibanco (ATM) e a gestão de contas bancárias de clientes.

## 🏗️ Arquitetura do Projeto
O projeto foi rigorosamente desenvolvido seguindo a **Arquitetura em Três Camadas (3-Tier Architecture)**, garantindo a separação de responsabilidades, segurança e facilidade de manutenção:

1. **🖥️ Presentation Layer (Camada de Apresentação):** Desenvolvida em Windows Forms. Contém apenas a interface gráfica (ecrãs, botões). Não realiza cálculos nem comunica com a base de dados.
2. **🧠 Business Logic Layer (Camada de Lógica de Negócio):** O "cérebro" da aplicação (`AccountService`, `MBWayService`). Valida regras de negócio (ex: verificar se há saldo suficiente, calcular taxas de juros para empréstimos).
3. **🗄️ Data Access Layer (Camada de Dados):** A única camada com permissão para interagir com o SQL Server (`AccountRepository`). Responsável por executar comandos de leitura e escrita (SELECT, INSERT, UPDATE).

## ✨ Funcionalidades Principais

**Administração (User: `sibs`)**
* Gestão completa (CRUD) de Clientes e Contas.
* Listagem de todas as contas ativas no sistema.

**Operações de Cliente**
* Autenticação segura por Número de Conta e PIN.
* Consulta de Saldo e visualização de Extrato de Movimentos (com filtros de datas).
* Levantamentos e Depósitos.
* Transferências Nacionais entre contas.

**🌟 Funcionalidades Extra (Criatividade)**
* **MBWay:** Associação de número de telemóvel à conta e envio de dinheiro via telemóvel.
* **Pagamento de Serviços:** Pagamentos com Entidade, Referência e Valor.
* **Empréstimos:** Simulação e contração de empréstimos com cálculo automático de juros mediante o prazo (meses) e cálculo da prestação mensal.

---

## 🛠️ Tecnologias Utilizadas
* **Linguagem:** C# (.NET 8.0)
* **Interface Gráfica:** Windows Forms
* **Base de Dados:** SQL Server Express LocalDB (`Microsoft.Data.SqlClient`)
* **Testes Automáticos:** xUnit (Testes de Integração e Testes Unitários)

---

## 🚀 Como Executar o Projeto Localmente

Como a aplicação utiliza o **SQL Server Express LocalDB**, não é necessário instalar a versão completa do SQL Server. Segue os passos abaixo para configurar o ambiente em menos de 5 minutos:

### Pré-requisitos
1. **Visual Studio** (com a framework de desenvolvimento .NET desktop instalada).
2. **SQL Server Management Studio (SSMS)**.

### Passo 1: Ligar ao Servidor Local
1. Abre o **SSMS**.
2. Na janela "Connect to Server", preenche:
   * **Server type:** `Database Engine`
   * **Server name:** `(localdb)\MSSQLLocalDB`
   * **Authentication:** `Windows Authentication`
3. Clica em **Connect**.

### Passo 2: Criar a Base de Dados
1. No SSMS, clica em **New Query**.
2. Copia e executa (`F5`) o seguinte script SQL para criar a estrutura e inserir dados de teste:

```sql
-- 1. Criar a Base de Dados
CREATE DATABASE SistemaMultibancoDB;
GO

-- 2. Usar a base de dados criada
USE SistemaMultibancoDB;
GO

-- 3. Criar a Tabela de Contas
CREATE TABLE Contas (
    IdConta INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    AccountNumber NVARCHAR(20) UNIQUE NOT NULL,
    PIN NVARCHAR(4) NOT NULL,
    Balance DECIMAL(18,2) NOT NULL,
    HolderName NVARCHAR(100) NOT NULL,
    IsDefault BIT NOT NULL DEFAULT 0
);
GO

-- 4. Criar a Tabela de Movimentos
CREATE TABLE Movimentos (
    IdMovimento INT IDENTITY(1,1) PRIMARY KEY,
    IdConta INT NOT NULL FOREIGN KEY REFERENCES Contas(IdConta),
    Data DATETIME NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL,
    Descricao NVARCHAR(255) NOT NULL
);
GO

-- 5. Criar a Tabela de Clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY, -- Usamos IDs manuais para bater certo com as contas já criadas (1, 2, 3)
    Nome NVARCHAR(100) NOT NULL,
    NIF NVARCHAR(9) UNIQUE NOT NULL
);
GO

-- 6. Inserir dados de teste para podermos fazer Login!
INSERT INTO Contas (IdCliente, AccountNumber, PIN, Balance, HolderName, IsDefault)
VALUES 
(1, '123456789', '1234', 5000.00, 'João Silva', 1),
(2, '987654321', '5678', 2500.00, 'Maria Santos', 1),
(3, '555666777', '0000', 10000.00, 'Pedro Oliveira', 1);
GO

-- 7. Inserir os dados de teste na tabela clientes
INSERT INTO Clientes (IdCliente, Nome, NIF)
VALUES 
(1, 'João Silva', '123456789'),
(2, 'Maria Santos', '987654321'),
(3, 'Pedro Oliveira', '555666777');

GO
```

3. Clica em Execute (ou carrega em F5).
4. Na parte de baixo, deve aparecer a mensagem "Commands completed successfully".

### Passo 3: Confirmar e Testar!
1. Do teu lado esquerdo, no painel *Object Explorer*, clica com o botão direito na pasta **Databases** e escolhe **Refresh** (Atualizar). 
2. Já deves ver lá a base de dados `SistemaMultibancoDB`.
3. **Está pronto!** Agora é só abrir o projeto no Visual Studio, clicar no "Play" (ou em Iniciar) e testar o login com a conta de demonstração:
   * **Conta:** `123456789`
   * **PIN:** `1234`
   * **Titular:** João Silva

> **Nota para a equipa:** Sempre que houver alterações na estrutura da base de dados (novas tabelas ou colunas), avisem no grupo para podermos atualizar este ficheiro e todos corrermos o novo código SQL nas nossas máquinas locais!
