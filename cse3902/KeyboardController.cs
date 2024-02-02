using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class KeyboardController : IController
{
    private Player player;


    public KeyboardController(Player player)
    {
        this.player = player;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        // Player controls
        if (keyboardState.IsKeyDown(Keys.W))
            player.MoveUp();

        if (keyboardState.IsKeyDown(Keys.S))
            player.MoveDown();

        if (keyboardState.IsKeyDown(Keys.A))
            player.MoveLeft();

        if (keyboardState.IsKeyDown(Keys.D))
            player.MoveRight();

        if (keyboardState.IsKeyDown(Keys.Z) || keyboardState.IsKeyDown(Keys.N))
            player.Attack();

        // Other controls
        if (keyboardState.IsKeyDown(Keys.E))
            player.UseItem();

        if (keyboardState.IsKeyDown(Keys.T) || keyboardState.IsKeyDown(Keys.Y))
            player.BlockCycle();

        if (keyboardState.IsKeyDown(Keys.U) || keyboardState.IsKeyDown(Keys.I))
            player.ItemCycle();

        if (keyboardState.IsKeyDown(Keys.O) || keyboardState.IsKeyDown(Keys.P))
            player.CharacterCycle();

        if (keyboardState.IsKeyDown(Keys.Q))
            QuitGame();

        if (keyboardState.IsKeyDown(Keys.R))
            ResetGame();
    }

    private void QuitGame()
    {
        // Implement logic to quit the game
    }

    private void ResetGame()
    {
        // Implement logic to reset the game
    }

}
