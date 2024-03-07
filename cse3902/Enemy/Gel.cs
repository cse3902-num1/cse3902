﻿using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using cse3902.RoomClasses;

namespace cse3902.Enemy
{
    public class Gel : EnemyBase
    {
        
        public Gel(GameContent content, Room room) : base(content, room)
        {

            sprite = new Sprite(content.enemiesSheet, 
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 7, 16),
                    new Rectangle(10, 11, 7, 16)
                },
                new Vector2(3.5f, 8f)
            );

            Position = new Vector2(200, 200);
            Collider = new BoxCollider(Position, new Vector2(7, 16), new Vector2(3.5f, 8f), ColliderType.ENEMY);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position = newPosition;
        }

        public override void Attack()
        {

        }

        public override void TakeDmg(int damage)
        {

        }


        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            base.Update(gameTime, controllers);

            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controllers);
        }
    }
}
