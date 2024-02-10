using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class Sprite : ISprite
    {
        private Vector2 position;
        private Texture2D texture;
        private List<Rectangle> frames; /* source rectangles */
        public int Frame /* index of current frame's source rectangle */
        {
            get { return Frame; }
            set { Frame = value % frames.Count; }
        }

        private double frameTimerThreshold = 1.0 / 5.0; /* how long to spend on each frame (seconds) */
        private double frameTimer = 0.0; /* how long we've spent on current frame (seconds) */

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        //need sprite
        public Sprite(Texture2D texture, List<Rectangle> frames)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
        }


        public void Update(Game game, GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTimer < frameTimerThreshold) return;

            frameTimer = 0.0;

            Frame++;
            if (Frame >= frames.Count)
            {
                Frame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, frames[Frame], Color.White);
        }

        // Set the position of the sprite
        public void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Set the state of the sprite
        public void SetState(string state)
        {
            // Implement logic to change the state of the sprite
        }

    }
}

