# 🏦 Sistema Multibanco - Configuração da Base de Dados

Este projeto utiliza o **SQL Server Express LocalDB**, uma versão leve do SQL Server que já vem instalada com o Visual Studio. **Não é necessário instalar a versão completa e pesada do SQL Server.**

Para que o projeto funcione no teu computador, precisas de criar a base de dados localmente. Segue este passo a passo (demora menos de 5 minutos):

## 🛠️ Pré-requisitos
1. Ter o **Visual Studio** instalado (com a carga de trabalho "Armazenamento e processamento de dados" ativa no Visual Studio Installer).
2. Ter o **SQL Server Management Studio (SSMS)** instalado. Se não tens, [descarrega gratuitamente aqui](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms).

---

## 🚀 Passo a Passo para criar a Base de Dados

### Passo 1: Ligar ao Servidor Local
1. Abre o **SQL Server Management Studio (SSMS)**.
2. Vai aparecer a janela **"Connect to Server"**. Preenche exatamente assim:
   * **Server type:** `Database Engine`
   * **Server name:** `(localdb)\MSSQLLocalDB` *(Atenção à barra invertida!)*
   * **Authentication:** `Windows Authentication`
3. Clica no botão **Connect**.

### Passo 2: Criar a Base de Dados e as Tabelas
1. Já dentro do SSMS, clica no botão **New Query** (Nova Consulta) no menu superior.
2. Copia e cola o script SQL abaixo na janela em branco que se abriu:

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

-- 5. Inserir dados de teste para podermos fazer Login!
INSERT INTO Contas (IdCliente, AccountNumber, PIN, Balance, HolderName, IsDefault)
VALUES 
(1, '123456789', '1234', 5000.00, 'João Silva', 1),
(2, '987654321', '5678', 2500.00, 'Maria Santos', 1),
(3, '555666777', '0000', 10000.00, 'Pedro Oliveira', 1);
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
