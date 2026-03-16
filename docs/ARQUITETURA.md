# Arquitetura

## Visão geral

O app é uma aplicação WinUI 3 desktop com navegação simples entre uma tela de lista de projetos e uma tela de detalhes do projeto.

## Camadas principais

### Inicialização

- `PrimeiraTelaWinUI/App.cs`: cria a janela principal, define o título do app e navega para `MainPage`.
- `PrimeiraTelaWinUI/Program.cs`: ponto de entrada e inicialização do ambiente WinUI.

### Interface

- `Views/MainPage.xaml` e `PrimeiraTelaWinUI/Views/MainPage.cs`: tela inicial com CRUD de projetos.
- `Views/ProjectDetailsPage.xaml` e `PrimeiraTelaWinUI/Views/ProjectDetailsPage.cs`: tela principal de operação do projeto, com importação, validação, AHP, TOPSIS e relatórios.

### Persistência

- `PrimeiraTelaWinUI/Data/ProjectStorage.cs`: resolve e cria as pastas locais do app.
- `PrimeiraTelaWinUI/Data/ProjectRepository.cs`: persiste metadados de projetos em `projects.json`.
- `PrimeiraTelaWinUI/Data/ProjectGroupsRepository.cs`: persiste os grupos do projeto em `groups.json`.
- `PrimeiraTelaWinUI/Data/ProjectCausesRepository.cs`: persiste causas em `causas.json` e importa/exporta `causas.csv`.

## Cálculos e importações

Grande parte da lógica de importação e cálculo está concentrada em `PrimeiraTelaWinUI/Views/ProjectDetailsPage.cs`.

Esse arquivo concentra:

1. Leitura e parsing de `q1.csv`.
2. Cálculo agregado das respostas Likert para validação das causas.
3. Leitura das comparações pareadas do AHP a partir do `q1.csv`.
4. Cálculo dos pesos AHP por média geométrica.
5. Cálculo da razão de consistência global.
6. Leitura de `q2.csv`.
7. Montagem da matriz de decisão do TOPSIS.
8. Cálculo do ranking final das causas.
9. Geração do relatório exportável em CSV.

## Artefatos recuperados

O projeto ainda depende de recursos em `RecoveredArtifacts/`, incluindo:

- `.xbf` reconstruídos da interface.
- `.pri` do app.
- DLLs necessárias para a execução.
- assets de ícone e imagens.

Isso reflete o estado atual da recuperação. O XAML em `Views/` é uma reconstrução manual e não representa integralmente o projeto original.
