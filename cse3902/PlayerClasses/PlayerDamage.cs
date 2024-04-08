using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;

namespace cse3902.PlayerClasses
{
    public class PlayerDamage : IPlayerState
    {
        private Player player;
        private GameContent content;
        private Dictionary<Direction, ISprite> directionSprite;
        private Vector2 playerMoveOrigin = new Vector2(8,8);
        private int playerMovingSpeedScale = 200;
        private const int RandomChangeInterval = 1000;
        public PlayerDamage(GameContent content, Player player)
        {
            player.damageTimer.Start();
            this.content = content;
            this.player = player;

            // default is down since we currently only have the facing down damaged sprite
            directionSprite = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalkDamaged, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingLeftAnimation1,
                        PlayerConstant.PlayerWalkingLeftAnimation2,
                        PlayerConstant.PlayerWalkingLeftAnimation3,
                        PlayerConstant.PlayerWalkingLeftAnimation4
                    }, playerMoveOrigin)
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalkDamaged, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingRightAnimation1,
                        PlayerConstant.PlayerWalkingRightAnimation2,
                        PlayerConstant.PlayerWalkingRightAnimation3,
                        PlayerConstant.PlayerWalkingRightAnimation4
                    }, playerMoveOrigin)
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalkDamaged, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingUpAnimation1,
                        PlayerConstant.PlayerWalkingUpAnimation2,
                        PlayerConstant.PlayerWalkingUpAnimation3,
                        PlayerConstant.PlayerWalkingUpAnimation4
                    }, playerMoveOrigin)
                },
                {
                  Direction.Down,
                  new Sprite(content.SpritesheetLinkWalkDamaged, new List<Rectangle>()
                  {
                        PlayerConstant.PlayerWalkingDownAnimation1,
                        PlayerConstant.PlayerWalkingDownAnimation2,
                        PlayerConstant.PlayerWalkingDownAnimation3,
                        PlayerConstant.PlayerWalkingDownAnimation4
                  },playerMoveOrigin)
                },
            };


        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* move player if any movement key is pressed */
            
            Vector2 position = player.Position;
         
            if (controllers.Any(c => c.isPlayerMoveLeftPressed()) == true)
            {
                player.Facing = Direction.Left;
                position.X -= playerMovingSpeedScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveRightPressed()) == true)
            {
                player.Facing = Direction.Right;
                position.X += playerMovingSpeedScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveUpPressed()) == true)
            {
                player.Facing = Direction.Up;
                position.Y -= playerMovingSpeedScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveDownPressed()) == true)
            {
                player.Facing = Direction.Down;
                position.Y += playerMovingSpeedScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            /* change to idle state if no movement keys are pressed */

            player.Position = position;

            if (player.damageTimer.Elapsed.TotalMilliseconds > RandomChangeInterval)
            {
                player.damageTimer.Stop();
                player.damageTimer.Reset();
                player.State = new PlayerStateIdle(content, player);
                
            }
            directionSprite[player.Facing].Update(gameTime, controllers);
            
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            directionSprite[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            directionSprite[player.Facing].Draw(spriteBatch);
        }
    }
}
