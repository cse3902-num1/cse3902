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
        private Vector2 BlockOrigin = new Vector2(8, 8);
        private float blockScale = 3.0f;
        public int BlockIndex
        {
            get { return blockIndex; }
            set {
                blockIndex = value;

                /* only add a collider if the block is of the right type */
                Collider = null;
                if (value == 1) {
                    Collider = new BoxCollider(position, BlockConstant.ColliderScale, BlockConstant.ColliderOffset, ColliderType.BLOCK);
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
                        BlockConstant.BlockSprite1}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        BlockConstant.BlockSprite2}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                       BlockConstant.BlockSprite3}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        BlockConstant.BlockSprite4}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        BlockConstant.BlockSprite5}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                        BlockConstant.BlockSprite6}, BlockOrigin, blockScale)
                },
                { new Sprite(content.TilesSheet, new List<Rectangle>() {
                      BlockConstant.BlockSprite7}, BlockOrigin, blockScale)
                }
            };

            /* only add a collider if the block is of the right type */
            Collider = null;
            if (this.blockIndex == 1) {
                Collider = new BoxCollider(position, BlockConstant.ColliderScale, BlockConstant.ColliderOffset, ColliderType.BLOCK);
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

