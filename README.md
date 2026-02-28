Sistema de Gerenciamento de Concessionária - ConcessionariaOBJ 

Aplicação Console desenvolvida em C# utilizando .NET com integração ao MySQL. O projeto foi estruturado com Arquitetura em Camadas, aplicando princípios de Programação Orientada a Objetos (POO) e SOLID. 

Objetivo do Projeto 
• Praticar Arquitetura em Camadas. 
• Implementar operações completas de CRUD. 
• Realizar integração com banco de dados MySQL utilizando Dapper. 
• Aplicar princípios SOLID e boas práticas de desenvolvimento. 
• Separar responsabilidades entre camadas do sistema. 

Tecnologias Utilizadas 
• C# 
• .NET 
• MySQL 
• Dapper 
• Git e GitHub 

Arquitetura do Projeto 
O sistema foi estruturado seguindo o padrão de Arquitetura em Camadas, organizado da seguinte forma: 
• Entity: Representação das entidades do domínio. 
• Repository: Comunicação com o banco de dados. 
• Services: Regras de negócio. 
• Interfaces: Contratos de implementação. 
• ConsoleHelper: Interação com o usuário.

Funcionalidades 
• Cadastro de automóveis. 
• Listagem de registros. 
• Atualização de dados. 
• Remoção de registros. 
• Integração com banco MySQL. 

Estrutura do Banco de Dados 
Tabela principal utilizada pelo sistema: automovel (Id, Marca, Modelo, Powertrain, Versao, Cor, Ano, AnoModelo, Quilometragem, Preco, Blindado e QuantidadeDonos). 

Como Executar o Projeto 
• Clonar o repositório para a máquina local. 
• Criar o banco de dados MySQL. 
• Configurar a string de conexão no arquivo App.config. 
• Executar a aplicação pelo Visual Studio. 

Conceitos Aplicados 
• Programação Orientada a Objetos. 
• Princípio da Responsabilidade Única. 
• Inversão de Dependência. 
• Repository Pattern. 
• Separação entre camada de apresentação e dados. 

Autor
Gustavo Luís Pandini Pereira
