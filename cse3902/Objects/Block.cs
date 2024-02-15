using System;
using System.Diagnostics;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace cse3902.Objects
{
   
    public class Block : IBlock
	{
        // Shared data class
        public static class GameData
        {
            public static int BlockIndex { get; set; } = 1;

        }

        //private ISprite sprite
        private List<Sprite> blocks;
       
        private float x = 200, y = 200;
       
        private bool isVisible = false;
        private KeyboardController keyboardcontroller;
        private KeyboardState KbState;
        private KeyboardState previousState;
      
        public Block(GameContent content, KeyboardController keyboard)
        {

            blocks = new List<Sprite>() {
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(2, 11, 16, 16) })
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(19, 11, 16, 16) })
                }
                ,
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(36, 11, 16, 16) })
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(53, 11, 16, 16) })
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(19, 28, 16, 16) })
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(36, 28, 16, 16) })
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                       new Rectangle(53, 28, 16, 16) })
                }

            };
            keyboardcontroller = keyboard;
        }

     
        public void draw(SpriteBatch spriteBatch)
        {
            blocks[GameData.BlockIndex].SetPosition(x, y);
            blocks[GameData.BlockIndex].Draw(spriteBatch);
        }

        public void update(GameTime gameTime)
        {
            
            KbState = Keyboard.GetState();
            if (keyboardcontroller.isCycleBlockPress())
            {
                if (KbState.IsKeyDown(Keys.T) && !previousState.IsKeyDown(Keys.T))
                {
                    // Switch to the previous block
                    SwitchToPreviousBlock();
                }
                else if (KbState.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
                {
                    // Switch to the next block
                    SwitchToNextBlock();
                }


            }
            previousState = KbState;

        }

     
        private void SwitchToPreviousBlock()
        {
          
            GameData.BlockIndex--;

            if (GameData.BlockIndex < 0)
            {
                // Wrap around to the last block if at the beginning
                GameData.BlockIndex = (byte)(blocks.Count - 1);
            }
        }

        private void SwitchToNextBlock()
        {
            GameData.BlockIndex++;

            if (GameData.BlockIndex >= blocks.Count)
            {
                // Wrap around to the first block if at the end
                GameData.BlockIndex = 0;
            }
          
        }

    }
}

