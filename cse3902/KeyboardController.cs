using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class KeyboardController : IController
{
    //private Enermy enermy;
    //private Block block;
    //private IItem item;
    private KeyboardState keyboardState;

    public bool isPlayerMoveUpPress()
    {
     

        if (keyboardState.IsKeyDown(Keys.W)){
            return true;
        }
        return false;
    }
    public bool isPlayerMoveDownPress()
    {
        if (keyboardState.IsKeyDown(Keys.S))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerMoveLeftPress()
    {
        if (keyboardState.IsKeyDown(Keys.A))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerMoveRightPress()
    {
        if (keyboardState.IsKeyDown(Keys.D))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerAttackPress()
    {
        if (keyboardState.IsKeyDown(Keys.Z) || keyboardState.IsKeyDown(Keys.N))
        {
            return true;
        }
        return false;
    }
    public bool isItem1Press()
    {
        if (keyboardState.IsKeyDown(Keys.NumPad1))
        {
            return true;
        }
        return false;
    }

    public bool isItem2Press()
    {
        if (keyboardState.IsKeyDown(Keys.NumPad2))
        {
            return true;
        }
        return false;
    }

    public bool isItem3Press()
    {
        if (keyboardState.IsKeyDown(Keys.NumPad3))
        {
            return true;
        }
        return false;
    }

    /* TODO: make functions to check inputs for:
     * - cycling the block
     * - cycling the item
     * - cycling the enemy
     * - quitting the game
     * - resetting the game
     */

public void Update(GameTime gameTime)
    {
        keyboardState = Keyboard.GetState();

        /*
        if (keyboardState.IsKeyDown(Keys.T) || keyboardState.IsKeyDown(Keys.Y))
            block.BlockCycle();

        if (keyboardState.IsKeyDown(Keys.U) || keyboardState.IsKeyDown(Keys.I))
            item.ItemCycle();

        if (keyboardState.IsKeyDown(Keys.O) || keyboardState.IsKeyDown(Keys.P))
            enermy.CharacterCycle();
        */
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
   
