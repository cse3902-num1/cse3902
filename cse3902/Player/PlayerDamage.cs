using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;

namespace cse3902
{
    public class PlayerDamage : IPlayerState
    {
        private Player player;
        private GameContent content;
        private Dictionary<Direction, ISprite> directionSprite;
        
        public PlayerDamage(GameContent content, Player player)
        {
            player.damageTimer.Start();
            this.content = content;
            this.player = player;
            // default is down since we currently only have the facing down damaged sprite
            directionSprite = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 0 * 16, 16, 16),
                        new Rectangle(1 * 16, 0 * 16, 16, 16),
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 1 * 16, 16, 16),
                        new Rectangle(1 * 16, 1 * 16, 16, 16),
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 2 * 16, 16, 16),
                        new Rectangle(1 * 16, 2 * 16, 16, 16),
                    }, new Vector2(8, 8))
                },
                {
                  Direction.Down,
                  new Sprite(content.LinkSpritesheet, new List<Rectangle>()
                  {
                      new Rectangle(74, 223,16,16),
                        new Rectangle(0, 231, 16, 16),
                        
                        new Rectangle(198,239,16,16),
                        new Rectangle(222,240,16,16)
                  },new Vector2(8, 8))
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
                position.X -= 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveRightPressed()) == true)
            {
                player.Facing = Direction.Right;
                position.X += 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveUpPressed()) == true)
            {
                player.Facing = Direction.Up;
                position.Y -= 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveDownPressed()) == true)
            {
                player.Facing = Direction.Down;
                position.Y += 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            player.Facing = Direction.Down;
            /* change to idle state if no movement keys are pressed */

            player.Position = position;

            if (player.damageTimer.Elapsed.TotalMilliseconds > 1000)
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
