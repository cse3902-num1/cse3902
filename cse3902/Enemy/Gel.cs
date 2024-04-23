using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace cse3902.Enemy
{
    public class Gel : EnemyBase
    {
        private float GelMoveSpeedEnermyConstant = 100f;
        private float GhostGelMoveSpeedEnermyConstant = 30f;
        private const int RandomChangeInterval = 500;
        private Level level;
        public Gel(GameContent content, Level level) : base(content)
        {
            this.HP = EnermyConstant.GEL_HEALTH;
            sprite = new Sprite(content.enemiesSheet,
            new List<Rectangle>()
            {
                EnermyConstant.GelSpriteSheetAnimation1,
                EnermyConstant.GelSpriteSheetAnimation2
            },
            EnermyConstant.GelOrigin
     );
            this.level = level;
            Position = EnermyConstant.GelInitialPosition;
            Collider = new BoxCollider(Position, EnermyConstant.GelColliderSize, EnermyConstant.GelColliderOrigin, ColliderType.ENEMY);
        }
        /*if Gel is in nightmare mode, when Gel is dying it will follow player, and still take damage.
         * Otherwise it moves randomly*/
        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;

            if (IsGhost)
            {
                Vector2 playerPos = level.player.Position;
                if (newPosition.X < playerPos.X)
                {
                    newPosition.X += GhostGelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (newPosition.X > playerPos.X)
                {
                    newPosition.X -= GhostGelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (newPosition.Y < playerPos.Y)
                {
                    newPosition.Y += GhostGelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (newPosition.Y > playerPos.Y)
                {
                    newPosition.Y -= GhostGelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {

                switch (randomNum)
                {
                    case 1:
                        newPosition.X -= GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 2:
                        newPosition.X += GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 3:
                        newPosition.Y -= GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 4:
                        newPosition.Y += GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                }
            }
            Position = newPosition;
        }
        // update Gel's position
        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            base.Update(gameTime, controllers);

            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= RandomChangeInterval)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controllers);
        }
    }
}
