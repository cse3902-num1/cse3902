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
    private  KeyboardState previousKeyboardState;
    public KeyboardController()
    {
        currentKeyboardState = Keyboard.GetState();
        previousKeyboardState = currentKeyboardState; // Initialize both to the same state
    }

    public void Update(GameTime gameTime)
    {
        previousKeyboardState = currentKeyboardState;
        currentKeyboardState = Keyboard.GetState();
    }

    /* Returns true if the key is currently down. */
    private bool isKeyPressed(Keys key)
    {
        return currentKeyboardState.IsKeyDown(key);
    }

    /* Returns true if the key was pressed during this Update() call,
       but not during the last Update() call. Use this when you want
       to check if a key has just been pressed, as it will return true
       initially, but as the key continues to be held down it will
       return false. */
    private bool isKeyJustPressed(Keys key)
    {
        return !previousKeyboardState.IsKeyDown(key) && currentKeyboardState.IsKeyDown(key);
    }

    /* player keys */
    public bool isPlayerMoveUpPressed()         { return isKeyPressed(Keys.W); }
    public bool isPlayerMoveDownPressed()       { return isKeyPressed(Keys.S); }
    public bool isPlayerMoveLeftPressed()       { return isKeyPressed(Keys.A); }
    public bool isPlayerMoveRightPressed()      { return isKeyPressed(Keys.D); }
    public bool isPlayerAttackJustPressed()     { return isKeyJustPressed(Keys.Z) || isKeyJustPressed(Keys.N); }
    public bool isPlayerTakeDamageJustPressed() { return isKeyJustPressed(Keys.E); }

    /* player item use keys */
    public bool isPlayerUseItem1JustPressed()   { return isKeyJustPressed(Keys.NumPad1); }
    public bool isPlayerUseItem2JustPressed()   { return isKeyJustPressed(Keys.NumPad2); }
    public bool isPlayerUseItem3JustPressed()   { return isKeyJustPressed(Keys.NumPad3); }
    public bool isPlayerUseItem4JustPressed()   { return isKeyJustPressed(Keys.NumPad4); }
    public bool isPlayerUseItem5JustPressed()   { return isKeyJustPressed(Keys.NumPad5); }
    public bool isPlayerUseItem6JustPressed()   { return isKeyJustPressed(Keys.NumPad6); }
    public bool isPlayerUseItem7JustPressed()   { return isKeyJustPressed(Keys.NumPad7); }
    public bool isPlayerUseItem8JustPressed()   { return isKeyJustPressed(Keys.NumPad8); }
    public bool isPlayerUseItem9JustPressed()   { return isKeyJustPressed(Keys.NumPad9); }

    /* enemy keys */
    public bool isEnemyPressO()                 { return isKeyJustPressed(Keys.O); }
    public bool isEnemyPressP()                 { return isKeyJustPressed(Keys.P); }
    
    /* item keys */
    public bool isPreviousItemKeyPress()        { return isKeyJustPressed(Keys.I); }
    public bool isNextItemKeyPress()            { return isKeyJustPressed(Keys.U); }

    /* block keys */
    public bool isNextBlockPressed()            { return isKeyJustPressed(Keys.I); }
    public bool isPreviousBlockPressed()        { return isKeyJustPressed(Keys.U); }

    /* gameplay keys */
    public bool isResetPressed()                { return isKeyJustPressed(Keys.R); }
    public bool isQuitPressed()                 { return isKeyJustPressed(Keys.Q); }
}
