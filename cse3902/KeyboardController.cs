using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using cse3902.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class KeyboardController : IController
{

    public KeyboardState keyboardState;

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
    public bool isDamaged() {
        if (keyboardState.IsKeyDown(Keys.E)) {
            return true;
        }
        return false;
    }

    /*
     * for block control: "t" switches to the previous item and "y" switches to the next
     */
    public bool isCycleBlockPress()
    {
        if (keyboardState.IsKeyDown(Keys.T))
        {
            return true;
        }
        else if (keyboardState.IsKeyDown(Keys.Y))
        {
            return true;
        }
        return false;
    }

    /*
    * for Item control: "u" switches to the previous item and "i" switches to the next
    */

    public bool isCycleItemPress()
    {
        if (keyboardState.IsKeyDown(Keys.U))
        {
            return true;
        }
        else if (keyboardState.IsKeyDown(Keys.I))
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
        if (keyboardState.IsKeyDown(Keys.O))
        {
            return true;
        }
        return false;
    }

    public bool isEnemyPressP()
    {
        if (keyboardState.IsKeyDown(Keys.P))
        {
            return true;
        }
        return false;
    }



    public void Update(GameTime gameTime)
    {
        keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.Q))
        {
            QuitGame();
        }

        if (keyboardState.IsKeyDown(Keys.R))
        {
            ResetGame();
        }
    }
    /*
     * quit the game
     */
    private void QuitGame()
    {

        Environment.Exit(0);
   
    }
    /*
     *  reset the program back to its initial state
     */
    private void ResetGame()
    {
        
    }

}
   
