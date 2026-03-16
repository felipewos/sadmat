# SADMAT

SADMAT é um aplicativo desktop WinUI 3 para apoio à decisão multicritério sobre evasão estudantil, combinando validação de causas, cálculo de pesos AHP e ranking TOPSIS.

O projeto atual é uma reconstrução de um aplicativo já instalado. O código-fonte foi recuperado a partir do assembly e de artefatos binários, por isso ainda depende de arquivos em `RecoveredArtifacts/`. Mais detalhes estão em `RECOVERY_NOTES.md`.

## O que o app faz

1. Gerencia projetos por instituição/curso.
2. Mantém grupos de atores e causas de evasão por projeto.
3. Exporta `q1.txt` e `q2.txt` em formato Google Apps Script para gerar formulários.
4. Importa `causas.csv`, `q1.csv` e `q2.csv`.
5. Valida causas com base em respostas Likert do `q1.csv`.
6. Calcula pesos AHP e exibe a razão de consistência global.
7. Calcula o ranking TOPSIS a partir do `q2.csv`.
8. Exporta um resumo em CSV e copia um resumo textual para a área de transferência.

## Build e execução

Build validado localmente:

```powershell
dotnet build PrimeiraTelaWinUI.csproj -c Debug
```

Executável gerado:

```text
bin\Debug\net8.0-windows10.0.19041.0\PrimeiraTelaWinUI.exe
```

Observação: o build passa, mas ainda emite avisos de nulidade herdados da recuperação do projeto.

## Estrutura principal

- `PrimeiraTelaWinUI/`: código C# principal do app.
- `Views/`: XAML reconstruído das telas.
- `RecoveredArtifacts/`: binários, `.xbf`, `.pri` e assets recuperados.
- `Samples/`: amostras de `causas.csv`, `q1.csv`, `q2.csv` e scripts `q1.txt`/`q2.txt`.
- `RECOVERY_NOTES.md`: histórico e limitações da recuperação.

## Documentação adicional

- `docs/FLUXO_DE_USO.md`
- `docs/ARQUITETURA.md`
- `docs/ARQUIVOS_DE_DADOS.md`
