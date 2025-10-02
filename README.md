<p align="center">
<a href="https://dscvit.com">
	<img width="400" src="https://user-images.githubusercontent.com/56252312/159312411-58410727-3933-4224-b43e-4e9b627838a3.png#gh-light-mode-only" alt="GDSC VIT"/>
</a>
	<h2 align="center"> WASDEditor </h2>
	<h4 align="center"> A simple open-source dialogue system and editor <h4>
</p>
<p align="center">
	<a href="https://gdscvit.itch.io/wasdeditor">
		<img width="400" src="https://github.com/GDGVIT/nonlinear-info-editor/blob/dev/Assets/UI%20Art/WASDEditor_logo_darkmode.png" alt="WASDEditor"/>
	</a>
</p>

---
[![Join Us](https://img.shields.io/badge/Join%20Us-Developer%20Student%20Clubs-red)](https://dsc.community.dev/vellore-institute-of-technology/)
[![Discord Chat](https://img.shields.io/discord/760928671698649098.svg)](https://discord.gg/498KVdSKWR)

[![DOCS](https://img.shields.io/badge/Documentation-see%20docs-green?style=flat-square&logo=appveyor)](INSERT_LINK_FOR_DOCS_HERE) 
  [![UI ](https://img.shields.io/badge/User%20Interface-Link%20to%20UI-orange?style=flat-square&logo=appveyor)](INSERT_UI_LINK_HERE)


## Features
- [X]  Character Creation
- [X]  Branching Dialogue Trees
- [X]  Designer Friendly

<br>

## Dependencies
This project requires the following tools and libraries to be edited:

- Unity Engine (2023+)
- Newtonsoft JSON (com.unity.nuget.newtonsoft-json)

Newtonsoft JSON is also required to use the sample interpreter.
No dependencies are required to run the editor application.


## Running
download the binaries from itch.io

## Technical Details

### Data Format

The following class is used to generate the json output of the program. It uses the newtonsoft.json library to Serialize and Deserialize data.

```csharp
//Unused
public struct VarConstOperation
{
    public string varName;
    public VarOperators op; // VarOperators is an enum that remains unused for this version

    public float num;
}

//Unused
public struct VarVarOperation
{
    public string varName;
    public VarOperators op; // VarOperators is an enum that remains unused for this version

    public string var2Name;
}

// Following struct defines a Connection
public struct OptionData
{
    public VarConstOperation[] constCheck; //Unused
    public VarVarOperation[] varCheck; //Unused
    public string title; // Used to store the content of the option
    public int id; // id of the Option, also the index of self in the DialogueData.options array
}

// Following struct defines a Character
public struct Character
{
    public int id; // unique id of the Character, also the index of self in the DialogueTree.chars array
    public string Name; // name of the character
}

// Following class contains all data for the dialogue node
public class DialogueData
{
    public int id; // unique id of the node, also the index of self in the DialogueTree.dialogues array
    public string title; // title of the node
    public string line; // actual content of the node
    public OptionData[] options; // list of connections made from this node
    public VarConstOperation[] variableConstantOperations; //Unused
    public VarVarOperation[] variableVariableOperations; //Unused
    public int[] charIDs; // refers to index in the DialogueTree.chars array
    public int charCurrentlySpeaking; // refers to index in the charID array
}

// Following class contains all data for the dialogue tree
public class DialogueTree
{
    public Dictionary<string, float> variables; //Unused
    public Character[] chars; //Characters
    public DialogueData[] dialogues; //List of dialogue nodes
}
```


## External Libraries/Packages Used

- [UnityUILineRenderer](https://github.com/graphicmismatch/UnityUILineRenderer)

## Contributors

<table>
	<tr align="center">
		<td>
		graphicmismatch (Rayan Madan)
		<p align="center">
			<img src = "https://avatars.githubusercontent.com/u/48159187" width="150" height="150" alt="graphicmismatch(Rayan Madan)">
		</p>
			<p align="center">
				<a href = "https://github.com/graphicmismatch">
					<img src = "http://www.iconninja.com/files/241/825/211/round-collaboration-social-github-code-circle-network-icon.svg" width="36" height = "36" alt="GitHub"/>
				</a>
				<a href = "https://www.linkedin.com/in/rayan-madan/">
					<img src = "http://www.iconninja.com/files/863/607/751/network-linkedin-social-connection-circular-circle-media-icon.svg" width="36" height="36" alt="LinkedIn"/>
				</a>
			</p>
		</td>
	</tr>
</table>

<p align="center">
	Made with ❤ by <a href="https://dscvit.com">GDSC-VIT</a>
</p>
