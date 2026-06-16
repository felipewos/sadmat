# Notas do Projeto

## Visão geral

SIGEV - Sistema Inteligente de Gestão da Evasão é um aplicativo WinUI 3 focado em análise, aprovação e priorização de causas de evasão estudantil. A interface usa termos como participantes, aprovação, peso dos grupos e ranking final; os métodos AHP e TOPSIS permanecem como base técnica interna.

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

Comando de desenvolvimento:

```powershell
dotnet build PrimeiraTelaWinUI.csproj -c Debug
```

Comando de distribuição:

```powershell
dotnet publish PrimeiraTelaWinUI.csproj -c Release -r win-x64 --self-contained true -o dist\SIGEV-Distribuicao
```

Executável de distribuição:

```text
dist\SIGEV-Distribuicao\PrimeiraTelaWinUI.exe
```

Entrega final:

```text
dist\SIGEV-Instalador.exe
dist\SIGEV-Distribuicao\
dist\SIGEV-Distribuicao.zip
```

Use `dist\SIGEV-Instalador.exe` como arquivo final para instalação pelos usuários. O `PrimeiraTelaWinUI.exe` em `dist\SIGEV-Distribuicao\` é o executável interno do aplicativo publicado.

## Próximos ajustes possíveis

- reduzir avisos de nulidade no build
- consolidar recursos locais do app
- ampliar a documentação de operação e manutenção
