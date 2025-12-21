# Dialogue JSON Standard (v1.1)

The **WASD Dialogue Editor** serialises dialogue trees into JSON via `DialogueTreeManager.export()` (see `Assets/Scripts/Data/Components/DialogueTreeManager.cs`).

This document is the canonical reference for that JSON structure. It reflects the current C# data classes found in `Assets/Scripts/Data/DialogueData.cs` and related files.

> **File extensions**
>
> * `.wasde` – Default extension used by the editor. Content is identical to `.json`.
> * `.json` – Alternative raw JSON export with no proprietary extension.

---

## Top-level schema
```text
DialogueTree {
    variables: { <string>: <number>, … },
    chars: Character[],
    dialogues: DialogueData[]
}
```

| Property   | Type                        | Required | Description |
|------------|-----------------------------|----------|-------------|
| `variables`| object `<string, number>`   | No       | Global numeric variables available to the dialogue system (e.g., flags, scores). |
| `chars`    | Character[]                 | Yes¹     | All characters referenced by any dialogue node. Entry **0** is reserved for *"No Character"*. |
| `dialogues`| DialogueData[]              | Yes      | Ordered list of dialogue nodes. Array index equals the node's runtime `id`. |

¹ The editor always exports at least the *Null Character*.

---

## Character
```jsonc
{
  "id": 3,
  "Name": "Merchant"
}
```

| Field | Type | Description |
|-------|------|-------------|
| `id`  | int  | Unique identifier referenced by dialogue nodes. Must be **≥ 0**. |
| `Name`| string | Display name. |

---

## DialogueData (Node)
```jsonc
{
  "id": 7,
  "title": "Greeting",
  "line": "Hello, traveller!",
  "options": [ OptionData, … ],
  "charIDs": [ 3 ],
  "charCurrentlySpeaking": 3
}
```

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `id`  | int  | Yes | **Must match this element's index** in the `dialogues` array. Used as jump target by `OptionData.id`. |
| `title` | string | No | Editor-only label. |
| `line`  | string | No | Dialogue text shown to the player. |
| `options` | OptionData[] | Yes | Player choices. May be empty, indicating a leaf node. |
| `charIDs` | int[] | Yes | All characters present in the scene for this node. Values reference `chars[*].id`. |
| `charCurrentlySpeaking` | int | Yes | The character actively speaking this line. `-1` means narrator/no speaker. |

---

## OptionData (Player Choice)
```jsonc
{
  "title": "Ask for rumours",
  "id": 8
}
```

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `title` | string | Yes | Text shown on the choice button. |
| `id`    | int    | Yes | Destination dialogue `id`. Must correspond to another node or `-1` for an immediate exit. |

---

## Example minimal file
```jsonc
{
  "variables": {},
  "chars": [
    { "id": 0, "Name": "No Character" },
    { "id": 1, "Name": "Hero" }
  ],
  "dialogues": [
    {
      "id": 0,
      "title": "Intro",
      "line": "Where am I?",
      "options": [
        { "title": "Continue", "id": 1 }
      ],
      "charIDs": [1],
      "charCurrentlySpeaking": 1
    },
    {
      "id": 1,
      "title": "Second Node",
      "line": "Time to start my adventure.",
      "options": [],
      "charIDs": [1],
      "charCurrentlySpeaking": 1
    }
  ]
}
```

---

## Versioning considerations
The schema may evolve over time. To future-proof your importer:
1. Ignore unknown properties.
2. Accept additional members in arrays/objects.
3. Treat missing optional fields as the defaults described above.

---
