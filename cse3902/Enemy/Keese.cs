using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using cse3902.RoomClasses;

namespace cse3902.Enemy
{
    public class Keese : EnemyBase
    {
        public Keese(GameContent content, Room room) : base(content, room)
        {
            this.HP = 5;
            sprite = new Sprite(content.enemiesSheet,
                new List<Rectangle>()
                {
                    new Rectangle(184, 11, 15, 16),
                    new Rectangle(200, 11, 15, 16)
                },
                new Vector2(7.5f, 8f)
            );

            Position = new Vector2(200, 200);
            Collider = new BoxCollider(Position, new Vector2(15, 16), new Vector2(7.5f, 8f), ColliderType);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.Y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
