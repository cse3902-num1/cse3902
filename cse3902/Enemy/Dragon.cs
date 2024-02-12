﻿using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Dragon : IEnemy
    {
        //private ISprite sprite;
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private float timer = 0;
        private int threshold = 250;
        private int currentAnimationIndex = 1;
        private float x = 200, y = 200;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;
        public bool isVisible = false;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Dragon(ContentManager content)
        {
            //sprite = new Sprite();
            sourceRectangles = new Rectangle[4];
            sourceRectangles[0] = new Rectangle(0, 10, 25, 32);
            sourceRectangles[1] = new Rectangle(25, 10, 25, 32);
            sourceRectangles[2] = new Rectangle(50, 10, 25, 32);
            sourceRectangles[3] = new Rectangle(75, 10, 25, 32);
            texture = content.Load<Texture2D>("enemies");
        }

        public void move(GameTime gameTime, int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    //sprite.moveUp();
                    y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    //sprite.moveLeft();
                    x -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    //sprite.moveRight();
                    x += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    //sprite.moveDown();
                    y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void attack()
        {

        }

        public void takeDmg()
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture,
                    new Vector2(x, y),
                    sourceRectangles[currentAnimationIndex],
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    3f,
                    SpriteEffects.None,
                    1f
                );
            }
        }

        public void update(GameTime gameTime)
        {

            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            move(gameTime, randomNum);


            if (timer > threshold)
            {
                currentAnimationIndex = (currentAnimationIndex + 1) % 4;
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
