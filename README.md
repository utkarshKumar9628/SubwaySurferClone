# Subway Surfer Clone

## Introduction

Embark on an endless journey filled with excitement, challenges, and endless possibilities. Get this game now and experience the next level of endless runner gaming.

The game utilizes various scripts to control both the game and the player. These scripts contribute to generating various trains endlessly, making the game both infinite and entertaining. Players can collect coins to increase their score and must navigate through obstacles and trains to achieve the highest score.

## Working

### The Player

The player is controlled by a script called `playerController`, resulting in continuous running. Additionally, there are three animations that can be triggered when the player performs swipe movements through finger gestures while playing the game.

### The Tile

The tile encompasses various trains and hurdles attached to it. These elements are spawned when the player reaches a certain point and continue to generate infinitely until the player collides with any of them, ending the game.

### The Coins

The coin has an update method with a function that makes it rotate on its y-axis. It also includes `OnTriggerColliders`. When the player collides with a coin, the score is increased, and the coin is destroyed.

## Screenshots
![Screenshot 1](Screenshot/1.png)
![Screenshot 2](Screenshot/2.png)
![Screenshot 3](Screenshot/3.png)
![Screenshot 4](Screenshot/4.png)
![Screenshot 5](Screenshot/5.png)
![Screenshot MainMenu](Screenshot/MainMenu.png)