using System;
using System.Diagnostics;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cse3902.Objects
{
    public class Block : IBlock
	{

        //private ISprite sprite;
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
    
        private float x = 200, y = 200;
       
        public bool isVisible = false;
        private KeyboardController keyboardcontroller;
        private KeyboardState KbState;

        public Block(ContentManager content,KeyboardController keyboard)
		{
           
            //sprite = new Sprite();
            sourceRectangles = new Rectangle[2];
            sourceRectangles[0] = new Rectangle(2, 11, 16, 16);
            sourceRectangles[1] = new Rectangle(2, 11, 33, 16);

            keyboardcontroller = keyboard;


            texture = content.Load<Texture2D>("Tileset");
        }

     
        public void draw(SpriteBatch spriteBatch)
        {
            
                spriteBatch.Draw(texture,
                    new Vector2(x, y),
                    sourceRectangles[GameData.BlockIndex],
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    3f,
                    SpriteEffects.None, 1f
                );
            
        }

        public void update(GameTime gameTime)
        {
            HandleInput();

        }

        private void HandleInput()
        {
            KbState = Keyboard.GetState();
            if (keyboardcontroller.isCycleBlockPress())
            {
                if (KbState.IsKeyDown(Keys.T))
                {
                    // Switch to the previous block
                    SwitchToPreviousBlock();
                }
                else if (KbState.IsKeyDown(Keys.Y))
                {
                    // Switch to the next block
                    SwitchToNextBlock();
                }
            }
        }
        private void SwitchToPreviousBlock()
        {
            GameData.BlockIndex--;

            if (GameData.BlockIndex < 0)
            {
                // Wrap around to the last block if at the beginning
                GameData.BlockIndex = (byte)(sourceRectangles.Length - 1);
            }

            // Additional logic if needed when switching to the previous block
        }

        private void SwitchToNextBlock()
        {
            GameData.BlockIndex++;

            if (GameData.BlockIndex >= sourceRectangles.Length)
            {
                // Wrap around to the first block if at the end
                GameData.BlockIndex = 0;
            }

            // Additional logic if needed when switching to the next block
        }

    }
}

