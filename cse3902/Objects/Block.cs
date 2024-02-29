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
        private int BlockIndex;
        private List<Sprite> blocks;
        private Vector2 position;
       
        private float x = 200, y = 200;
       
        public bool isVisible = false;
      
        public Block(GameContent content, int index, Vector2 position)
        {
            BlockIndex = index;
            this.position = position;

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
            blocks[BlockIndex].Position = position;
            blocks[BlockIndex].Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, IController controller)
        {
            
        }



    }
}

