# Retinotopy
Modelling of axonal retinotopy during fly brain development

## Overview

This Unity project simulates two lamina model scenarios: **half** and **equator**. 

## Features

- Two simulation scenes:
  - **half** – a scenario where one half of lamina is simulated.
  - **equator** – a scenario where both mirrowed halves are simulated.
- Automated test script that:
  - Runs the simulation 100 times.
  - Tracks and stores the positions of axonal heels from the simulation.
  - Outputs data for post-processing and visualization in R.

## Requirements

- Unity 2022.3.6f1 
- R

## Installation - Unity

1. Download and install [Unity Hub](https://unity.com/download).
2. Install Unity version 2022.3.6f1 through Unity Hub.
3. Open Unity Hub, click "Add project", and select the project folder.

## Running Simulations

1. Launch the project in Unity.
2. In the Project window, navigate to Assets/Scenes/.
3. Open either half.unity or equator.unity.
4. Use the Inspector for the spawner object to configure parameters such as number of rows or bundels per row.
5. Click the "Play" button in the toolbar to start the simulation.

### Simulation Parameters
TODO

## Analysis - R