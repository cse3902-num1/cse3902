using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using cse3902.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class KeyboardController : IController
{
    private List<Block> blocks;
    private List<Item> items;
    private List<Enemy> enemies;


    private int currentBlockIndex;
    private int currentItemIndex;
    private int currentEnemyIndex;
    private int currentNPCIndex;

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
    public bool isDamaged() {
        if (keyboardState.IsKeyDown(Keys.E)) {
            return true;
        }
        return false;
    }
    /*
     *  initialize the lists of game entities (blocks, items, enemies) 
     *  that KeyboardController will interact with
     */
    public void SetBlocks(List<Block> blockList)
    {
        blocks = blockList;
        currentBlockIndex = 0;
    }

    public void SetItems(List<Item> itemList)
    {
        items = itemList;
        currentItemIndex = 0;
    }

    public void SetEnemies(List<Enemy> enemyList)
    {
        enemies = enemyList;
        currentEnemyIndex = 0;
    }

    /*
     * for block control: "t" switches to the previous item and "y" switches to the next
     */
    public bool isCycleBlockPress()
    {
        if (keyboardState.IsKeyDown(Keys.T))
        {
            currentBlockIndex = (currentBlockIndex - 1 + blocks.Count) % blocks.Count;
            return true;
        }
        else if (keyboardState.IsKeyDown(Keys.Y))
        {
            currentBlockIndex = (currentBlockIndex + 1) % blocks.Count;
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
            currentItemIndex = (currentItemIndex - 1 + items.Count) % items.Count;
            return true;
        }
        else if (keyboardState.IsKeyDown(Keys.I))
        {
            currentItemIndex = (currentItemIndex + 1) % items.Count;
            return true;
        }
        return false;
    }

    /*
    * for Enemy control: "o" switches to the previous item and "p" switches to the next
    */
    public bool isCycleEnemyPress()
    {
        if (keyboardState.IsKeyDown(Keys.O))
        {
            currentEnemyIndex = (currentEnemyIndex - 1 + enemies.Count) % enemies.Count;
            return true;
        }
        else if (keyboardState.IsKeyDown(Keys.P))
        {
            currentEnemyIndex = (currentEnemyIndex + 1) % enemies.Count;
            return true;
        }
        return false;
    }



    public void Update(GameTime gameTime)
    {
        keyboardState = Keyboard.GetState();

        if (isCycleBlockPress())
        {
            blocks[currentBlockIndex].BlockCycle();
        }

        if (isCycleItemPress())
        {
            items[currentItemIndex].ItemCycle();
        }

        if (isCycleEnemyPress())
        {
            enemies[currentEnemyIndex].CharacterCycle();
        }

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
        // Reset entity indices to their initial values
        currentBlockIndex = 0;
        currentItemIndex = 0;
        currentEnemyIndex = 0;
    }

}
   
