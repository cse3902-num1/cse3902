# The Legend of Zelda

## Overview

Welcome to "The Legend of Zelda", a 2D game built with MonoGame. This project is a homage to the classic Legend of Zelda series.

## Table of Contents

- [Installation](#installation)
- [Controls](#controls)
- [Gameplay](#gameplay)
- [Collision Detection](#collision-detection)
- [Technical Details](#technical-details)
- [Contributing](#contributing)
- [License](#license)

## Installation

[Provide step-by-step instructions on how to install and run your game. Include any dependencies or system requirements.]

```bash
git clone https://github.com/yourusername/gamerepo.git
cd gamerepo
dotnet restore
dotnet build
dotnet run
```
## Player controls
* W - move Link up, make Link face up
* A - move Link left, make Link face left
* S - move Link down, make Link face down
* D - move Link right, make Link face right
* Z - make Link use his primary attack
* N - make Link use his primary attack

* 1 - use bomb, bombs can break the block
* 2 - use magical boomerang
* 3 - use blue arrow
* 4 - use fireball
* 5 - use fire (not implemented yet)
* 6 - use green boomerang
* 7 - use green arrow

## Hud controls
* Hud displays:
* minimap radar on the top left corner to display relative position
  * green dot represents where the player is
  * lavender dots represents where the triforces are
  * red dots represents where the dragons are
  * indigo dots represents where the wizards are

* Life container represents the health of the player
* Ruby picked up quantity
* Triforce picked up quantity
* Bombs picked up quantity
* slot A contains only swords
* slot B contains all the other weapons
* B - switch weapon in slot B 
* V - switch weapon in slot A

## Player Inventory controls
* C - display the full player inventory
* B - switch weapon in slot B 
* V - switch weapon in slot A
* Map - show the map that player just picked
* Compass - show the compass that player just picked

## Win Check
* Player will pick up 3 triforces to win
* Beat dragon or the boss to get a new triforce
* Press "boggus" to trigger the final round and beat Mr.Boggus to win the game
## Other control
* Q - quit the game
* M - Mute the game
* R - Reset the game
