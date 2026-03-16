# Recuperacao do App

Origem da recuperacao:
- Assembly decompilado: `C:\Program Files\SADMAT\PrimeiraTelaWinUI.dll`
- Simbolos usados: `C:\Program Files\SADMAT\PrimeiraTelaWinUI.pdb`
- Ferramenta: `ilspycmd 9.1`

O que foi recuperado:
- Projeto C# decompilado em `PrimeiraTelaWinUI.csproj`
- Codigo C# de `App`, `Program`, `Data` e `Views`
- Nomes de variaveis melhores onde o `.pdb` ajudou
- Artefatos do app instalado em `RecoveredArtifacts\`
- Primeira reconstrucao manual de `Views\MainPage.xaml` e `Views\ProjectDetailsPage.xaml`
- Projeto ajustado para recompilar localmente em `C:\dev\sadmat\recovered`
- Execucao validada a partir de `bin\Debug\net8.0-windows10.0.19041.0\PrimeiraTelaWinUI.exe`

Arquivos uteis dentro de `RecoveredArtifacts`:
- `Assets\` com icones e imagens
- `Views\` com `MainPage.xbf` e `ProjectDetailsPage.xbf`
- `App.xbf`
- `PrimeiraTelaWinUI.exe`
- `PrimeiraTelaWinUI.dll`
- `PrimeiraTelaWinUI.pri`
- `PrimeiraTelaWinUI.pdb`
- arquivos `.deps.json` e `.runtimeconfig.json`

Limitacoes:
- O XAML original nao foi recuperado como `.xaml`; so os artefatos compilados `.xbf` restaram
- Os arquivos `Views\MainPage.xaml` e `Views\ProjectDetailsPage.xaml` sao uma reconstrucao manual inicial e ainda nao substituem os `.xbf`
- Comentarios, formatacao original e parte da estrutura exata do projeto foram perdidos
- O nome do produto exibido no instalador e `SADMAT`, mas o assembly recuperado e `PrimeiraTelaWinUI`
- O `.csproj` decompilado e uma aproximacao; ele nao representa com exatidao o projeto original
- A interface atual recompilada depende dos arquivos `App.xbf`, `Views\*.xbf` e `PrimeiraTelaWinUI.pri`

Pontos de entrada principais:
- `PrimeiraTelaWinUI\App.cs`
- `PrimeiraTelaWinUI\Program.cs`
- `PrimeiraTelaWinUI\Views\MainPage.cs`
- `PrimeiraTelaWinUI\Views\ProjectDetailsPage.cs`

Proximo passo recomendado:
- Integrar `Views\MainPage.xaml` e `Views\ProjectDetailsPage.xaml` ao build WinUI, removendo gradualmente a dependencia dos `.xbf`
- Refinar a hierarquia visual e os estilos usando `PrimeiraTelaWinUI\Views\MainPage.cs` e `PrimeiraTelaWinUI\Views\ProjectDetailsPage.cs` como referencia
- Enquanto isso, o projeto atual ja compila com `dotnet build PrimeiraTelaWinUI.csproj -c Debug`
