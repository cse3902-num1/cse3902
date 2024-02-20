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
            public static int BlockIndex { get; set; } = 0;

        }

        //private ISprite sprite
        private List<Sprite> blocks;
       
        private float x = 200, y = 200;
       
        public bool isVisible = false;
      
        public Block(GameContent content)
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
        }

     
        public void Draw(SpriteBatch spriteBatch)
        {
            blocks[GameData.BlockIndex].SetPosition(x, y);
            blocks[GameData.BlockIndex].Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, IController controller)
        {
            if (controller.isNextBlockPressed())
            {
                SwitchToNextBlock();
            }

            if (controller.isPreviousBlockPressed())
            {
                SwitchToPreviousBlock();
            }
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

