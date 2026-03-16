# Fluxo de Uso

## Tela inicial

A tela inicial lista os projetos cadastrados e permite:

1. Criar projeto.
2. Abrir projeto.
3. Renomear projeto.
4. Excluir projeto.

Ao criar um projeto, o app pede instituição e curso e cria automaticamente uma pasta local para armazenar os dados.

## Fluxo recomendado dentro do projeto

1. Cadastre os grupos na seção `Grupos`.
2. Cadastre ou importe as causas na seção `Causas`.
3. Exporte `q1.txt` para gerar o formulário de pré-teste no Google Forms.
4. Colete as respostas e exporte `q1.csv`.
5. Importe `q1.csv` na seção `Validação Q1`.
6. Revise as causas aprovadas com base na média mínima e na proporção mínima configuradas.
7. Verifique os pesos AHP e o `CR` global na seção `AHP`.
8. Exporte `q2.txt` para gerar o formulário final.
9. Colete as respostas e exporte `q2.csv`.
10. Importe `q2.csv` na seção `Relatórios e TOPSIS`.
11. Atualize os relatórios e exporte o resumo final em CSV, se necessário.

## Seções da página de detalhes

### Relatórios e TOPSIS

- Mostra o status das últimas importações.
- Exibe o topo do ranking TOPSIS.
- Permite importar `q2.csv`, limpar Q2, atualizar relatórios, exportar CSV e copiar resumo.

### AHP

- Exibe os pesos dos grupos.
- Calcula a razão de consistência global.
- Permite ajustar o limite de `CR (%)`.
- Permite exportar `q2.txt`.

### Validação Q1

- Importa `q1.csv`.
- Filtra visualmente a escala Likert.
- Aplica corte por média mínima e proporção mínima.
- Marca cada causa como aprovada ou não.

### Causas

- Lista as causas do projeto.
- Permite adicionar, renomear, excluir e limpar causas.
- Permite importar `causas.csv`.
- Permite exportar `q1.txt`.

### Grupos

- Lista os grupos do projeto.
- Permite adicionar, renomear, excluir e limpar grupos.
- Os grupos cadastrados são usados no AHP e no TOPSIS.

## Armazenamento local

Os dados do app ficam em `%LocalAppData%\\SADMAT`, com um `projects.json` na raiz e uma pasta para cada projeto em `%LocalAppData%\\SADMAT\\Projects`.
