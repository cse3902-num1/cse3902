using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using cse3902.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using cse3902.Interfaces;

namespace cse3902;

public class KeyboardController : IController
{
    /*
    *  initialize the lists of game entities (blocks, items, enemies) 
    *  that KeyboardController will interact with
    */
    /*
    public KeyboardController(List<IEnemy> enemies,List<Item> items,List<Block> blocks) {

    }
    */

    private KeyboardState currentKeyboardState;
    private KeyboardState previousKeyboardState;
    public KeyboardController()
    {
        currentKeyboardState = Keyboard.GetState();
        previousKeyboardState = currentKeyboardState; // Initialize both to the same state
    }
    public bool isPlayerMoveUpPress()
    {

        if (currentKeyboardState.IsKeyDown(Keys.W)){
            return true;
        }
        return false;
    }
    public bool isPlayerMoveDownPress()
    {
        if (currentKeyboardState.IsKeyDown(Keys.S))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerMoveLeftPress()
    {
        if (currentKeyboardState.IsKeyDown(Keys.A))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerMoveRightPress()
    {
        if (currentKeyboardState.IsKeyDown(Keys.D))
        {
            return true;
        }
        return false;
    }
    public bool isPlayerAttackPress()
    {
        if (currentKeyboardState.IsKeyDown(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.N))
        {
            return true;
        }
        return false;
    }
    public bool isItem1Press()
    {
        if (currentKeyboardState.IsKeyDown(Keys.NumPad1))
        {
            return true;
        }
        return false;
    }

    public bool isItem2Press()
    {
        if (currentKeyboardState.IsKeyDown(Keys.NumPad2))
        {
            return true;
        }
        return false;
    }

    public bool isItem3Press()
    {
        if (currentKeyboardState.IsKeyDown(Keys.NumPad3))
        {
            return true;
        }
        return false;
    }

    public bool isDamaged() {
        return previousKeyboardState.IsKeyUp(Keys.E) && currentKeyboardState.IsKeyDown(Keys.E);
    }

    /*
     * for block control: "t" switches to the previous item and "y" switches to the next
     */
    public bool isCycleBlockPress()
    {
        if (currentKeyboardState.IsKeyDown(Keys.T))
        {
            return true;
        }
        else if (currentKeyboardState.IsKeyDown(Keys.Y))
        {
            return true;
        }
        return false;
    }

    /*
    * for Enemy control: "o" switches to the previous item and "p" switches to the next
    */
    public bool isEnemyPressO()
    {
        if (currentKeyboardState.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
        {
            return true;
        }
        return false;
    }

    public bool isEnemyPressP()
    {
        if (currentKeyboardState.IsKeyDown(Keys.P) && !previousKeyboardState.IsKeyDown(Keys.P))
        {
            return true;
        }
        return false;
    }

    public bool isResetPressed()
    {
        return currentKeyboardState.IsKeyDown(Keys.R);
    }

    public bool isQuitPressed()
    {
        return currentKeyboardState.IsKeyDown(Keys.Q);
    }

    public void Update(GameTime gameTime)
    {
        previousKeyboardState = currentKeyboardState;
        currentKeyboardState = Keyboard.GetState();
    }

    public bool isNextBlockPressed()
    {
        return !previousKeyboardState.IsKeyDown(Keys.I) && currentKeyboardState.IsKeyDown(Keys.I);
    }

    public bool isPreviousBlockPressed()
    {
        return !previousKeyboardState.IsKeyDown(Keys.U) && currentKeyboardState.IsKeyDown(Keys.U);
    }
}
