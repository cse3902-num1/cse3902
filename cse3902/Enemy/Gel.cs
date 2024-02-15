﻿using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace cse3902.Enemy
{
    public class Gel : IEnemy
    {
        private Sprite sprite;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;

        public Gel(GameContent content)
        {

            sprite = new Sprite(content.enemiesSheet, 
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 7, 16),
                    new Rectangle(10, 11, 7, 16)
                }
            );
            sprite.SetPosition(200, 200);
        }

        public void Move(GameTime gameTime, int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    sprite.Y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    sprite.X -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    sprite.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    sprite.Y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void Attack()
        {

        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime);
        }
    }
}
