# Imangi Contributions

* Imported a GUI for SelectionHistory, based off the [RBG Fork](https://github.com/redbluegames/com.hextantstudios.utilities)
* Removed Settings and Log Compile time, for now, as we don't have plans to use them at this time.

# Hextant - Utilities

This repository contains a collection of helpful runtime and editor classes for Unity. 

## Package Manager Installation

It can be installed from Unity's *Package Manager* using the following Git URL:

* [https://github.com/hextantstudios/com.hextantstudios.utilities.git](https://github.com/hextantstudios/com.hextantstudios.utilities.git)

## Embedded Installation

It can also be installed by cloning this repository into a Unity project's `Packages/` folder. This will allow for changes to be made to the package, but updates will need to be done manually using Git instead of Unity's *Package Manager*.

# Documentation

Documentation for these classes can be found below and in various articles on [HextantStudios.com](https://HextantStudios.com).

## Editor Singleton

A `ScriptableObject`-based singleton that can be used for GUI-less editor plug-ins. By deriving from `ScriptableObject`, non-static fields are persisted between script recompiles (domain reloads). 

* See [Singletons in Unity](https://hextantstudios.com/unity-singletons/) for additional details and several runtime implementations.

## Selection History

This editor plug-in derives from the `EditorSingleton` class allowing it to maintain a small history of recently selected objects that can be moved backward or forward through by pressing `F1` and `Shift+F1` (customize in *Edit/Shortcuts*).

* See [Selection History for Unity's Editor](https://hextantstudios.com/unity-selection-history/) for additional details.

## Log Compile Times

Removed in this fork. See [upstream](https://github.com/hextantstudios/com.hextantstudios.utilities) for details on this utility.

## Settings

Removed in this fork. See [upstream](https://github.com/hextantstudios/com.hextantstudios.utilities) for details on this utility.
