# Project Save Format (`.was` files)

The **WASD Dialogue Editor** lets you save an *editing session* (File ➜ Save) so you can later reopen the node graph exactly as you left it.  These files use the `.was` extension and contain JSON describing both the content and layout of the editor.

While the **Dialogue export** (`json` / `wasde`) is intended for game-runtime consumption, the **project save** retains extra data needed only by the editor UI (e.g., window positions).  If you only want the dialogue data for your game, prefer the export function described in `json_standard.md`.

---

## Top-level schema
```text
DialogueTreeSave {
    variables: { <string>: <number>, … },
    chars: Character[],
    dialogues: DialogueObjSave[]
}
```

| Property   | Type                          | Required | Description |
|------------|-------------------------------|----------|-------------|
| `variables`| object `<string, number>`     | No       | Same as export – project-wide numeric variables. |
| `chars`    | Character[]                   | Yes¹     | Character roster. Identical structure to the export format. |
| `dialogues`| DialogueObjSave[]             | Yes      | Dialogue nodes **plus** UI-position metadata. |

---

## DialogueObjSave
```jsonc
{
  "data": DialogueData,
  "pos": [ x, y, z ]
}
```

| Field | Type | Description |
|-------|------|-------------|
| `data` | `DialogueData` | The dialogue node itself, exactly as defined in `json_standard.md`. |
| `pos`  | float[3] | Node position in the editor canvas (local space). |

---

## Character & DialogueData
The internal structure of `Character` and `DialogueData` is **identical** to the export format; see `json_standard.md` for field breakdowns.

---

## Example `.was` file
```jsonc
{
  "variables": {
    "karma": 5
  },
  "chars": [
    { "id": 0, "Name": "No Character" },
    { "id": 1, "Name": "Guide" }
  ],
  "dialogues": [
    {
      "data": {
        "id": 0,
        "title": "Intro",
        "line": "Welcome!",
        "options": [{ "title": "Begin", "id": 1 }],
        "charIDs": [1],
        "charCurrentlySpeaking": 1
      },
      "pos": [ -120.0, 80.5, 0.0 ]
    },
    {
      "data": {
        "id": 1,
        "title": "Branch",
        "line": "Where to next?",
        "options": [],
        "charIDs": [1],
        "charCurrentlySpeaking": 1
      },
      "pos": [ 220.0, 80.5, 0.0 ]
    }
  ]
}
```

---

## Versioning tips
Because `.was` files include UI metadata, they are **not** intended for version-control merging.  Treat them as binary artifacts:
* Commit only when necessary (e.g., shared workflows).  
* Consider adding them to `.gitignore` if each contributor maintains personal layouts.

---
