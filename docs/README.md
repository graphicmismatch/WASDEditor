# WASD Dialogue Editor Documentation

Welcome to the **WASD Dialogue Editor** project. This Unity-based tool allows writers and designers to craft complex, branching dialogue trees and export them as JSON files that can be consumed by games or other tools.

## Table of contents
1. [Project overview](#project-overview)
2. [Getting started](#getting-started)
3. [Directory layout](#directory-layout)
4. [Scripts of interest](#scripts-of-interest)
5. [Dialogue export format](#dialogue-export-format)
6. [Project save format](#project-save-format)
7. [Contributing](#contributing)

---

## Project overview
This editor provides a node-based interface for creating dialogue trees. Each dialogue node can contain:
* A line of dialogue
* A set of options that point to other nodes
* A speaker (character) reference

When you are ready to ship your content, the editor serialises the dialogue tree into a **JSON** document through `DialogueTreeManager.export(…)`. The exact format is described in detail in [`json_standard.md`](json_standard.md).

## Getting started
1. Clone the repository and open the project with **Unity 2022.3 LTS** (or newer).
2. Open the scene `Scenes/WorkScene.unity`.
3. Press **Play** to launch the editor interface.
4. Use the **File** panel in the UI to **Export** the dialogue tree. Two options are available:
   * **.wasde** – Same as JSON but with a custom file extension for easy association.
   * **.json** – Raw JSON file.

## Directory layout
```
Assets/
  Scripts/           C# runtime and editor scripts
  Prefab/            Prefabs used by the editor UI
  Scenes/            Unity scenes
Docs/                Project documentation (this directory)
```

## Scripts of interest
* **`DialogueData.cs`** – Data class for a single dialogue node. *This is the core of the JSON schema*.
* **`DialogueTreeManager.cs`** – Manages the in-memory tree and handles serialisation/deserialisation.
* **`CharCreatorManager.cs`** – Handles character creation and stores character metadata.

## Dialogue export format
A complete specification of the exported JSON can be found in [`json_standard.md`](json_standard.md).

## Project save format
The in-editor **save** feature (file extension `.was`) includes workspace metadata such as node positions so you can resume editing later.  The binary is still JSON and its schema is documented in [`project_save_format.md`](project_save_format.md).

## Contributing
Pull-requests are welcome! Please read `contributing.md` at the project root for code style and PR guidelines. 