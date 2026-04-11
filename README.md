# Dungeon Crawler

## Genre
Roguelike Action Dungeon Crawler

## Core Idea
A fast-paced dungeon crawler where the player character automatically shoots in the facing direction while navigating through waves of enemies. The goal is to survive enemy waves, defeat enemies for drops, and progress through levels.

## Mechanics
- **Automatic Shooting**: Player character continuously shoots projectiles in the direction they're facing
- **Player Movement**: WASD or Arrow keys to move the character around the arena
- **Enemy Spawning**: Enemies spawn in waves and move towards the player
- **Collision Detection**: Player takes damage when hit by enemies
- **Basic Projectiles**: Arrows that travel in a straight line and damage enemies on impact
- **Simple Enemy AI**: Enemies move towards the player's position or shoot projectiles at that spot.

## Win/Lose Conditions

### Win Conditions
- Defeat all enemies in the current wave to progress to the next level
- Complete all levels without being defeated

### Lose Conditions
- Player health reaches zero
- Player collides with too many enemies

## UI Plan
- **Main Menu**: Start Game, Quit buttons
- **Gameplay HUD**: Player health bar, current wave/level counter, enemy count
- **Pause Menu**: Resume, Restart, Quit to Main Menu
- **Game Over Screen**: Final score, Restart, Quit to Main Menu
- **Settings**: Minimal settings (audio toggle, basic graphics options)
