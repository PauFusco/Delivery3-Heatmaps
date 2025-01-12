# Delivery3-Heatmaps
 
## Instructions
### How to Generate Data
The project comes with pre-made data. To visualize this data go to [How to Visualize Data](https://github.com/PauFusco/Delivery3-Heatmaps?tab=readme-ov-file#how-to-visualize-data).

To create your own data, first go to _Assets/ExampleScene.unity_. There select the "PHPConnection" Object of the scene. In the inspector you will see an Editor Button **Truncate All**. **Pressing this button will _DELETE ALL_ the example data**, letting you generate yours. 

After playing, press the Editor Button **Create All JSONs** to download the data to use it for the visualization. **This will _OVERRIDE_ the data those files had**.

### How to Visualize Data
In order to visualize the game data, open _Assets/Heatmaps/Editor/LevelToHeatmap.unity_. Open the Tools>Heatmaps (Top-Bar Menu). This will open the Heatmaps window. In this window input the _Assets/Heatmaps/HeatmapsMAT.mat_ material in the **Heatmap Material** variable. This will give you Editor Buttons to deserialize the JSON information.

Pressing the **Deserialize X** Button ("X" being the information you want to show on the heatmap) will select that information. Then pressing the **Generate Heatmap** Button will create the Heatmap on the surface of the level.

The variables that can be shown in the map are:
- _Positions_: The positions the player was in. This values are recorded in 2-second intervals.
- _Defeats_: The positions of the enemies where they were defeated.
- _Deaths_: The position of the player when they were killed. This can be filtered with the **Damager Type** Dropdown Menu.
- _Hits_: The position of the player when they were damaged. This can be filtered with the **Damager Type** Dropdown Menu.
Pressing the **Clear Heatmap** Button will delete the heatmap projection on the level.

## Features
- Upload gameplay data to a MySQL database
- Download JSON-encoded information from a MySQL database to JSON files
- Deserialize JSON files data
- Generate Heatmaps with deserialized data to visualize gameplay data on the surface of the level it was generated in
