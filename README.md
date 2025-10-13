# Retinotopy
Modelling of axonal retinotopy during fly brain development

## Overview

This Unity project simulates two main lamina model scenarios: **half** and **equator**. For this purpose a 2D simulation of arriving axons is created, where the axonal bodies are represented with soft-bodied circle sprite and the involved adhesion proteins with `SpringJoint2D`

## Features

- Three simulation scenes:
  - **half** – a scenario where one half of lamina is simulated.
  - **half no space** – a scenario where one half of lamina is simulated, but minimizing empty space.
  - **equator** – a scenario where both mirrored halves are simulated.
- Automated test script that:
  - Runs the simulation 100 times.
  - Tracks and stores the positions of axonal heels from the simulation.
  - Outputs data for post-processing and visualization in R. Each test iteration produces output file named `name_test_number.txt`

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

![Simulation Demo](https://raw.githubusercontent.com/KleistLab/Retinotopy/main/sim_demo.gif)

### Simulation Parameters

Each scene holds a spawner object. In the inspector, it is possible to set simulation parameters.

- **Free to set:** 
  - `rows` - amount of differential rows 
  - `amount` - number of bundles per differential row, when running an equator simulation best set to a number divisible by 4 (suggestion - 12)
  - `fmi` - if set, runs a simulation of Fmi- mutant 
  - `sdk` - if set, runs a simulation of Sdk- mutant
  --> setting both runs a double-mutant simulation

- **optimized during development, suggested to leave at default values:** 
  - `spawnplace_34` / `spawnplace_16`- controls spawning location of R3/R4 and spawning location of R1/R6 where the number refers to the location relative to the surface of the spawning heel. 
  - `decay_time` is the sequence of numbers which signify timepoints of early Fmi degradation depending on the state of the simulation. Initially could be set differently for each type of heel (each number is for R2,R5 and R8), later determined that it needs to be set to the same number (timepoint) for each heel object. 
  - `fmi_time` is the equivalent of decay_time but signifies the time point of activation for Late Fmi. 
  - `equator` is a parameter which controls whether to simulate one half or full lamina with the equator. Each scene already sets the corresponding equator value.

## Analysis - R

Depending on the simulation type, change data folder names in the beginning. Once run through, gives 4 plots:
-  all 100 simulations plotted with an Euclidian ellipse
-  only R2/R5 plotted
-  2 different viusaulizations of standart distance deviation with a trend line
