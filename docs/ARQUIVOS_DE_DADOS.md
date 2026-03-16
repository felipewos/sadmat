# Arquivos de Dados

## Arquivos por projeto

Cada projeto usa uma pasta própria em `%LocalAppData%\\SADMAT\\Projects\\<NomeDoProjeto>`.

Nessa pasta, os arquivos mais relevantes são:

- `groups.json`: grupos cadastrados no projeto.
- `causas.json`: causas persistidas internamente.
- `causas.csv`: arquivo de importação/exportação de causas.
- `q1.csv`: respostas do pré-teste com validação e comparações AHP.
- `q2.csv`: respostas finais usadas no TOPSIS.
- `relatorio.csv`: resumo exportado pelo app.

## Regras práticas de importação

- O nome do arquivo precisa bater com o esperado pelo app: `causas.csv`, `q1.csv` e `q2.csv`.
- O parser do app procura a coluna de vínculo e as colunas cujo cabeçalho contém `Causa da evasão`.
- No caso do `q1.csv`, o app também procura as colunas de comparação pareada para calcular o AHP.

## q1

`q1` representa o pré-teste de validação.

Conteúdo esperado:

1. Perfil do respondente.
2. Escala Likert para as causas de evasão.
3. Comparações pareadas entre grupos para o AHP.

Amostra atual em `Samples/q1.csv`:

- `10` respostas no total.
- `5` respostas de `(Ex)coordenação`.
- `5` respostas de `Docentes`.

O script base do formulário está em `Samples/q1.txt`.

## q2

`q2` representa a etapa final de intensidade das causas.

Conteúdo esperado:

1. Perfil do respondente.
2. Escala Likert das causas aprovadas.

Amostra atual em `Samples/q2.csv`:

- `100` respostas no total.
- `10` respostas de `(Ex-)coordenação`.
- `30` respostas de `Docentes`.
- `60` respostas de `Discentes`.

O script base do formulário está em `Samples/q2.txt`.

## causas.csv

`causas.csv` é o arquivo mais simples do fluxo.

Formato mínimo:

```csv
Causa
Exemplo de causa
```

A amostra atual em `Samples/causas.csv` lista 17 causas ligadas à evasão, cobrindo temas como desempenho acadêmico, trabalho e estudo, motivação, saúde mental, infraestrutura e currículo.
