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

        private int frame = 0;
        public int Frame /* index of current frame's source rectangle */
        {
            get { return frame; }
            set { frame = value % frames.Count; }
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

        public Sprite(Texture2D texture, List<Rectangle> frames)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
        }


        public void Update(GameTime gameTime)
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
            spriteBatch.Draw(texture, position, frames[Frame], Color.White, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 1.0f);
        }

        // Set the position of the sprite
        public void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }
        public void SetPosition(Vector2 position)
        {
            X = position.X;
            Y = position.Y;
        }
    }
}

