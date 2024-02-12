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
        private KeyboardState previousState;
        private bool[] animationVisibility; // Array to track visibility for each animation index

        public Block(ContentManager content,KeyboardController keyboard)
		{
           
            //sprite = new Sprite();
            sourceRectangles = new Rectangle[3];
            sourceRectangles[0] = new Rectangle(2, 11, 16, 16);
            sourceRectangles[1] = new Rectangle(19, 11, 16, 16);
            sourceRectangles[2] = new Rectangle(36, 11, 16, 16);

            animationVisibility = new bool[sourceRectangles.Length];

            for (int i = 0; i < animationVisibility.Length; i++)
            {
                animationVisibility[i] = false;
            }

            animationVisibility[0] = true; // Set the initial index to be visible
            keyboardcontroller = keyboard;


            texture = content.Load<Texture2D>("Tileset");
        }

     
        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < sourceRectangles.Length; i++)
            {
                if (animationVisibility[i])
                {
                    spriteBatch.Draw(texture,
                        new Vector2(x, y),
                        sourceRectangles[i],
                        Color.White,
                        0f,
                        new Vector2(0, 0),
                        3f,
                        SpriteEffects.None, 1f
                    );
                }
            }
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
                if (KbState.IsKeyDown(Keys.T)  && !previousState.IsKeyDown(Keys.T))
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
            animationVisibility[GameData.BlockIndex] = false;

            GameData.BlockIndex--;

            if (GameData.BlockIndex < 0)
            {
                // Wrap around to the last block if at the beginning
                GameData.BlockIndex = (byte)(sourceRectangles.Length - 1);
            }

            animationVisibility[GameData.BlockIndex] = true;

        }

        private void SwitchToNextBlock()
        {
            animationVisibility[GameData.BlockIndex] = false;

            GameData.BlockIndex++;

            if (GameData.BlockIndex >= sourceRectangles.Length)
            {
                // Wrap around to the first block if at the end
                GameData.BlockIndex = 0;
            }
            animationVisibility[GameData.BlockIndex] = true;

        }

    }
}

