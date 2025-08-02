# KubeCrafter

KubeCrafter is a web application designed for creating and editing custom Minecraft recipes using the KubeJS mod format or standard JSON. The tool aims to support both beginners and advanced modders in crafting their own in-game recipes easily.

## Features

- Create new Minecraft recipes with a user-friendly interface  
- Edit existing recipes for KubeJS or JSON format  
- Export recipes as files or code snippets ready to use in Minecraft  
- Supports both beginner and advanced modding workflows  

## Installation and Usage

Currently, KubeCrafter is available as a web application. To use it:

1. Open the web app in your browser.  
2. Create or edit recipes as needed.  
3. Export your recipe as a `.js` file (for KubeJS) or `.json` file.  
4. Place the exported file into your Minecraft modded world folder under:  
	```
	<minecraft-world-folder>/kubejs/server_scripts/
	```
	for KubeJS recipes, or 
	```
	<minecraft-world-folder>/data/<namespace>/recipes/
	```
	for standard JSON recipes.  

5. Launch Minecraft with the appropriate mods installed, and your custom recipes will be available in-game.

## Technologies

- Backend: C# with ASP.NET Core (for the web application)  
- Planned: WPF for future desktop application development  
- Uses JSON-based data formats for recipe definitions  

## Contribution

Contributions and suggestions are welcome. Please open issues or pull requests on the project's repository.

## License
[Apache License 2.0](LICENSE)




