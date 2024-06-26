﻿using System;
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
        private float scale = 2.0f;

        private float _alpha = 1.0f;
        public int Frame /* index of current frame's source rectangle */
        {
            get { return frame; }
            set { frame = value % frames.Count; }
        }

        private double frameTimerThreshold = 1.0 / 5.0; /* how long to spend on each frame (seconds) */
        private double frameTimer = 0.0; /* how long we've spent on current frame (seconds) */

        private Vector2 origin = new Vector2(0, 0);

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

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public void setAlpha(float f)
        {
            _alpha = f;
        }

        public Sprite(Sprite sprite)
        {
            texture = sprite.texture;
            frames = sprite.frames;
            scale = sprite.scale;
            origin = sprite.origin;
        }

        public Sprite(Texture2D texture, List<Rectangle> frames)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
        }

        public Sprite(Texture2D texture, List<Rectangle> frames, float scale)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
            this.scale = scale;
        }

        public Sprite(Texture2D texture, List<Rectangle> frames, Vector2 origin)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
            this.origin = origin;
        }

        public Sprite(Texture2D texture, List<Rectangle> frames, Vector2 origin, float scale)
        {
            this.position = Vector2.Zero;
            this.texture = texture;
            this.frames = frames;
            this.origin = origin;
            this.scale = scale;
        }


        public void Update(GameTime gameTime, List<IController> controllers)
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
            spriteBatch.Draw(texture, position, frames[Frame], Color.White * _alpha, 0.0f, origin, scale, SpriteEffects.None, 1f);
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

        public bool IsAnimationDone()
        {
            return Frame >= frames.Count - 1; /* TODO: fully display last frame before returning true */
        }
    }
}

