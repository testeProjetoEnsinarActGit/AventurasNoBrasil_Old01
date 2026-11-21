# AventurasNoBrasil_Old01

## Visão geral

Projeto de jogo em **Unity** (C#) chamado "Aventuras no Brasil". Pelos documentos de planejamento em `Gerencimento/`, trata-se de um **jogo de plataforma educativo**, com desafios de lógica e matemática integrados à jogabilidade, e cenários históricos e brasileiros. Este repositório contém o projeto Unity (cenas, scripts, recursos e configurações) e a documentação de design.

O sufixo `Old01` sugere uma versão antiga do projeto. Essa leitura é **inferência**: a versão do editor é a 5.1.1f1 (`ProjectSettings/ProjectVersion.txt`) e os documentos de design têm datas de agosto de 2015.

## Objetivo

Inferido de `Gerencimento/History/` e `Gerencimento/Scenes/`:

- **Problema de interesse**: ensinar matemática e raciocínio lógico de forma lúdica, substituindo o combate físico por desafios intelectuais. Exemplo descrito em `Jogo de plataforma Educativo.docx`: o jogador pula em plataformas com contas, e só sobrevive quando escolhe o resultado correto.
- **Narrativa**: `História.docx` descreve duas possibilidades de enredo, uma na Roma/Egito antigo e outra no Brasil do período do descobrimento. `Scene01 - Description.docx` detalha uma cena com um desafio de lógica (lenhadores) proposto por um curupira.
- **Estado atual**: o `Relatório do Estado do Projeto.docx` é um modelo vazio, sem métricas. Os desafios educativos descritos nos documentos **não foram identificados** no código-fonte.

## Funcionalidades

Apenas o que é evidente no código:

- Movimento horizontal do personagem com o eixo `Horizontal` (`Assets/Script/player.cs`). O movimento vertical existe, mas está comentado.
- Câmera ou cenário que acompanha suavemente a posição X de um alvo (`Assets/Script/cenario.cs`, via `Mathf.SmoothDamp`).
- Objeto que oscila para a esquerda e para a direita por contagem de frames (`Assets/Script/ondas.cs`).
- Quatro cenas: `Mapa-Do-Brasil`, `Scene-Agua`, `Scene-Agua2` e `cenario01`.

Não identificados no código: desafios de matemática ou lógica, pontuação, vidas, menus e persistência de progresso.

## Arquitetura

### Tipo e padrão

Projeto Unity com linguagem C#. A arquitetura é **baseada em componentes**: scripts que herdam de `MonoBehaviour` são anexados a `GameObjects` dentro das cenas. Não há camadas de aplicação, serviços ou repositórios.

Padrões observados:

- Ciclo de vida da Unity (`Start()` e `Update()`).
- Referências públicas configuradas no Inspector (`action` em `cenario.cs`).
- Física 2D com `Rigidbody2D` (`player.cs`).

### Camadas e responsabilidades

| Pasta ou arquivo | Responsabilidade |
| --- | --- |
| `Assets/Script/` | Os 3 scripts do jogo: `player.cs`, `cenario.cs` e `ondas.cs`. |
| `Assets/Editor/` | Script de editor `CrossPlatformInputInitialize.cs` (`[InitializeOnLoad]`) que gerencia símbolos de compilação. |
| `Assets/Scenes/` | Cenas Unity (`.unity`). |
| `Assets/Standard Assets/` | Pacotes do Unity de terceiros (FirstPersonCharacter, ThirdPersonCharacter, RollerBall, CrossPlatformInput). Os três scripts do projeto não os referenciam. |
| `Assets/Textures/`, `Assets/Tree*`, `Assets/New Terrain*.asset` | Texturas, prefab de árvore e assets de terreno. |
| `Assets/UnityVS/Editor/` | DLLs do plugin UnityVS, que integra o Unity ao Visual Studio. |
| `ProjectSettings/` | Configurações do Unity (versão, Input, Physics2D, Tags, Qualidade, Build). |
| `Library/` | Cache gerado pelo Unity. Está versionado (ver Observações). |
| `*.sln` e `*.csproj` | Soluções e projetos gerados pelo Unity e pelo UnityVS para o Visual Studio. |
| `Gerencimento/` | Documentos de design e gestão (`.docx`, `.xmind`), imagens e áudio. |

### Fluxo principal

Fluxo inferido do código, sem execução:

1. O Unity carrega uma cena de `Assets/Scenes/`.
2. Os `GameObjects` com os scripts executam `Start()` uma vez e `Update()` a cada frame.
3. `player.cs` lê `Input.GetAxisRaw("Horizontal")` e move o `Transform` em 20 unidades por segundo.
4. `cenario.cs` faz a posição X do próprio objeto seguir a posição X do objeto `action`, com suavização.
5. `ondas.cs` move o objeto para a esquerda durante `tempo` frames e depois para a direita, reiniciando o contador em `tempo * 2 + 1`.

### Tecnologias

| Item | Versão ou detalhe | Fonte |
| --- | --- | --- |
| Unity | 5.1.1f1 | `ProjectSettings/ProjectVersion.txt` |
| Linguagem | C# | `Assets/Script/*.cs` |
| Target framework | .NET 3.5 (`v3.5`) | `Assembly-CSharp.csproj` |
| Física | 2D (`Rigidbody2D`) e 3D (Standard Assets, terreno) | código e assets |
| IDE | Visual Studio com UnityVS | `AventurasNoBrasil.sln`, `UnityVS.*` |
| Controle de versão | Git | `.gitignore`, `.graphifyignore` |
| Persistência | não identificada | - |
| Integrações externas | não identificadas | - |

### Árvore resumida

```text
AventurasNoBrasil_Old01/
├── Assets/
│   ├── Editor/CrossPlatformInput/   # script de editor
│   ├── Script/                      # player.cs, cenario.cs, ondas.cs
│   ├── Scenes/                      # cenas .unity
│   ├── Standard Assets/             # pacotes de terceiros
│   ├── Textures/, Tree_Textures/    # texturas
│   └── UnityVS/Editor/              # plugin Visual Studio
├── ProjectSettings/                 # configurações do Unity
├── Gerencimento/                    # design, cenas, história e gestão
├── Library/                         # cache gerado pelo Unity
└── AventurasNoBrasil.sln            # solução para o Visual Studio
```

## Como executar e testar

Nenhum comando foi executado ou validado nesta documentação.

1. Instalar o Unity **5.1.1f1**, a versão indicada em `ProjectSettings/ProjectVersion.txt`. *Não executado/validado.*
2. Abrir a pasta do repositório como projeto no Unity. *Não executado/validado.*
3. Abrir `AventurasNoBrasil.sln` no Visual Studio para editar os scripts em C#. *Não executado/validado.*
4. Abrir uma cena de `Assets/Scenes/` e pressionar Play no editor. *Não executado/validado.*

- **Build**: não identificado. Não há script de build, e não foi possível extrair a lista de cenas de `ProjectSettings/EditorBuildSettings.asset`.
- **Testes**: não identificados. Não há diretório de testes nem framework de teste.
- **CI**: não identificado. Não há `.github/` nem Dockerfile versionados.

## Observações

Limitações e dívidas técnicas visíveis nos arquivos:

- **Versão antiga**: Unity 5.1.1f1, de 2015. Abrir o projeto em versões mais novas do Unity exige migração, que não foi testada.
- **`Library/` versionada**: há 3.412 arquivos gerados pelo Unity no Git (2.665 em `ShaderCache`, 678 em `metadata`). Isso polui o histórico e gera conflitos. O `.gitignore` não cobre `Library/`, `Temp/`, `Logs/` nem `UserSettings/`.
- **Arquivos de IDE e de erro versionados**: `.vs/.../.suo` e `sh.exe.stackdump` estão no Git, apesar de o `.gitignore` listar `.vs/` e `*.suo`. Isso indica que foram adicionados antes da regra.
- **Arquivos binários e de sistema**: `Thumbs.db` aparece em `Assets/Scenes/`, `Gerencimento/` e em texturas. Há também `.docx`, `.xmind` e `.m4a` versionados junto com o código.
- **Terceiros sem licença identificada**: `Assets/Standard Assets/` inclui pacotes do Unity inteiros. Não há arquivo `LICENSE` no repositório.
- **Nomes com acentos e espaços**: por exemplo `Esboço1.png` e a pasta `Standard Assets`. Isso exige aspas em alguns comandos.
- **Código**:
  - `ondas.cs` chama `Debug.Log` a cada frame.
  - `ondas.cs` declara o campo `transform`, que sombreia o membro herdado de `MonoBehaviour`.
  - `player.cs` declara `rigidbody2D` como público, sombreando a propriedade, e tem o campo `playerr` sem uso.
  - `player.cs` usa `Input.GetAxisRaw` diretamente, e não o pacote CrossPlatformInput.
- **Mistura de idiomas**: nomes de scripts e documentos em português, e a API da Unity em inglês.
- **Lacuna entre design e código**: os desafios educativos descritos nos documentos não estão implementados nos três scripts.
- **Sem testes e sem CI**: nada automatiza a validação de mudanças.
- **Este README é o primeiro**: não havia README anterior a preservar.
