# Notas do Projeto

## Visão geral

SADMAT é um aplicativo WinUI 3 focado em apoio à decisão multicritério para análise de evasão estudantil com AHP e TOPSIS.

## Estrutura relevante

- `PrimeiraTelaWinUI/`: código principal da aplicação.
- `Views/`: definição das telas.
- `AppAssets/`: recursos, dependências e arquivos empacotados usados pela aplicação.
- `Samples/`: exemplos de `causas.csv`, `q1.csv`, `q2.csv`, `q1.txt` e `q2.txt`.

## Pontos de entrada

- `PrimeiraTelaWinUI/App.cs`
- `PrimeiraTelaWinUI/Program.cs`
- `PrimeiraTelaWinUI/Views/MainPage.cs`
- `PrimeiraTelaWinUI/Views/ProjectDetailsPage.cs`

## Build

Comando validado:

```powershell
dotnet build PrimeiraTelaWinUI.csproj -c Debug
```

Executável gerado:

```text
bin\Debug\net8.0-windows10.0.19041.0\PrimeiraTelaWinUI.exe
```

## Próximos ajustes possíveis

- reduzir avisos de nulidade no build
- consolidar recursos locais do app
- ampliar a documentação de operação e manutenção
