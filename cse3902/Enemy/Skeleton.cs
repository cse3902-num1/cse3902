using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Skeleton : EnemyBase
    {

        public Skeleton(GameContent content, Room room) : base(content, room)
        {
            this.HP = 3;
            sprite = new Sprite(content.skeleton,
                new List<Rectangle>()
                {
                    new Rectangle(0, 0, 15, 15),
                    new Rectangle(15, 0, 15, 15)
                },
                new Vector2(7.5f, 7.5f)
            );

            Position = new Vector2(200, 200);
            Collider = new BoxCollider(Position, new Vector2(15 * 2, 15 * 2), new Vector2(7.5f * 2, 7.5f * 2), ColliderType);
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
