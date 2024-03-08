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
        //public static class GameData
        //{
        //    public static int BlockIndex { get; set; } = 0;

        //}

        //private ISprite sprite
        private int blockIndex;
        private List<Sprite> blocks;
        private Vector2 position;
        public ICollider Collider;
       
       
        public bool isVisible = true;

        public int BlockIndex
        {
            get { return blockIndex; }
            set {
                blockIndex = value;

                /* only add a collider if the block is of the right type */
                Collider = null;
                if (value == 1) {
                    Collider = new BoxCollider(position, new Vector2(16, 16), new Vector2(8, 8), ColliderType.BLOCK);
                }
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set {
                position = value;
                if (Collider is not null) {
                    Collider.Position = value;
                }
            }
        }
      
        public Block(GameContent content, int index, Vector2 position)
        {
            blockIndex = index;
            this.position = position;

            blocks = new List<Sprite>() {
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(2, 11, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(19, 11, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(36, 11, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(53, 11, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(19, 28, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        new Rectangle(36, 28, 16, 16) }, new Vector2(8, 8), 3.0f)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                       new Rectangle(53, 28, 16, 16) }, new Vector2(8, 8), 3.0f)
                }
            };

            /* only add a collider if the block is of the right type */
            Collider = null;
            if (this.blockIndex == 1) {
                Collider = new BoxCollider(position, new Vector2(16 * 3, 16 * 3), new Vector2(8 * 3, 8 * 3), ColliderType.BLOCK);
            }
        }

     
        public void Draw(SpriteBatch spriteBatch)
        {
            blocks[blockIndex].Position = position;
            blocks[blockIndex].Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (Collider is not null) {
                Collider.Position = position;
            }
        }
    }
}

