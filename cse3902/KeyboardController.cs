using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using cse3902.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using cse3902.Interfaces;
using System.Linq;
using System.Diagnostics;

namespace cse3902;

public class KeyboardController : IController
{
    private KeyboardState currentKeyboardState;
    private  KeyboardState previousKeyboardState;

    private Queue<Keys> last6Keys;

    public KeyboardController()
    {
        currentKeyboardState = Keyboard.GetState();
        previousKeyboardState = currentKeyboardState; // Initialize both to the same state

        last6Keys = new Queue<Keys>();
    }

    public void Update(GameTime gameTime)
    {
        previousKeyboardState = currentKeyboardState;
        currentKeyboardState = Keyboard.GetState();

        Keys[] pressedKeys = currentKeyboardState.GetPressedKeys();
        Keys[] lastPressedKeys = previousKeyboardState.GetPressedKeys();
        foreach (Keys k in pressedKeys) {
            if (lastPressedKeys.Contains(k)) break;
            last6Keys.Enqueue(k);
        }
        while (last6Keys.Count > 6) {
            last6Keys.Dequeue();
        }

        // foreach (Keys k in last6Keys) Debug.WriteLine(k);
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
    public bool isPlayerMoveUpPressed()         { return isKeyPressed(Keys.W) || isKeyPressed(Keys.Up); }
    public bool isPlayerMoveDownPressed()       { return isKeyPressed(Keys.S) || isKeyPressed(Keys.Down); }
    public bool isPlayerMoveLeftPressed()       { return isKeyPressed(Keys.A) || isKeyPressed(Keys.Left); }
    public bool isPlayerMoveRightPressed()      { return isKeyPressed(Keys.D) || isKeyPressed(Keys.Right); }
    public bool isPlayerAttackJustPressed()     { return isKeyJustPressed(Keys.Z) || isKeyJustPressed(Keys.N); }
    public bool isPlayerTakeDamageJustPressed() { return isKeyJustPressed(Keys.E); }
    

    /* player item use keys */
    public bool isPlayerUseBombJustPressed()   { return isKeyJustPressed(Keys.NumPad1) || isKeyJustPressed(Keys.D1); }
    public bool isPlayerUseMagicalBoomerangPressed()   { return isKeyPressed(Keys.NumPad2) || isKeyPressed(Keys.D2); }
    public bool isPlayerUseBlueBowPressed()   { return isKeyPressed(Keys.NumPad3) || isKeyPressed(Keys.D3); }
    public bool isPlayerUseFireballPressed()   { return isKeyPressed(Keys.NumPad4) || isKeyPressed(Keys.D4); }
    public bool isPlayerUseFirePressed()   { return isKeyPressed(Keys.NumPad5) || isKeyPressed(Keys.D5); }
    public bool isPlayerUseGreenBoomerangPressed()   { return isKeyPressed(Keys.NumPad6) || isKeyPressed(Keys.D6); }
    public bool isPlayerUseGreenBowPressed()   { return isKeyPressed(Keys.NumPad7) || isKeyPressed(Keys.D7); }
    public bool isPlayerUsePurpleCrystalPressed()   { return isKeyPressed(Keys.NumPad8) || isKeyPressed(Keys.D8); }

    /* enemy keys */
    public bool isEnemyPressO()                 { return isKeyJustPressed(Keys.O); }
    public bool isEnemyPressP()                 { return isKeyJustPressed(Keys.P); }
    
    /* item keys */
    public bool isPreviousItemKeyPress()        { return isKeyJustPressed(Keys.I); }
    public bool isNextItemKeyPress()            { return isKeyJustPressed(Keys.U); }

    /* block keys */
    public bool isNextBlockPressed()            { return isKeyJustPressed(Keys.T); }
    public bool isPreviousBlockPressed()        { return isKeyJustPressed(Keys.Y); }

    /* gameplay keys */
    public bool isResetPressed()                { return isKeyJustPressed(Keys.R); }
    public bool isQuitPressed()                 { return isKeyJustPressed(Keys.Q); }
    public bool isMutePressed()                 { return isKeyJustPressed(Keys.M); }

    public bool isPausePressed()                { return isKeyJustPressed(Keys.P); }
    /* room controls */
    public bool isLeftClick() { return false; }
    public bool isRightClick() { return false; }

    /* display the inventory */
    public bool isInventoryDisplayedPressed() { return isKeyJustPressed(Keys.C); }
    public bool isSwitchSlotAPressed() { return isKeyJustPressed(Keys.V); }
    public bool isSwitchSlotBPressed() { return isKeyJustPressed(Keys.B); }

    public bool isCheatCodeJustPressed()
    {
        Keys[] keys = last6Keys.ToArray();
        if (keys.Length != 6) return false;
        if (keys[0] != Keys.B) return false;
        if (keys[1] != Keys.O) return false;
        if (keys[2] != Keys.G) return false;
        if (keys[3] != Keys.G) return false;
        if (keys[4] != Keys.U) return false;
        if (keys[5] != Keys.S) return false;
        return true;
    }
}
