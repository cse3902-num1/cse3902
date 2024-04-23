using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;

namespace cse3902.PlayerClasses
{
    public class PlayerStateMove : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, ISprite> sprites;
        private GameContent content;
        private Vector2 PlayerMoveOrigin = new Vector2(8,8);
        private float PlayerMoveScale = 200;
        

        public PlayerStateMove(GameContent content, Player player)
        {
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingLeftAnimation1,
                        PlayerConstant.PlayerWalkingLeftAnimation2,
                    }, PlayerMoveOrigin)
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingRightAnimation1,
                        PlayerConstant.PlayerWalkingRightAnimation2,
                    }, PlayerMoveOrigin)
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingUpAnimation1,
                        PlayerConstant.PlayerWalkingUpAnimation2,
                    }, PlayerMoveOrigin)
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerWalkingDownAnimation1,
                        PlayerConstant.PlayerWalkingDownAnimation2,
                    }, PlayerMoveOrigin)
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
                position.X -= PlayerMoveScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveRightPressed()) == true)
            {
                player.Facing = Direction.Right;
                position.X += PlayerMoveScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveUpPressed()) == true)
            {
                player.Facing = Direction.Up;
                position.Y -= PlayerMoveScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controllers.Any(c => c.isPlayerMoveDownPressed()) == true)
            {
                player.Facing = Direction.Down;
                position.Y += PlayerMoveScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            /* change to idle state if no movement keys are pressed */
            else
            {
                player.State = new PlayerStateIdle(content, player);
            }

            player.Position = position;

            sprites[player.Facing].Update(gameTime, controllers);
        }
        public void CollisionMove(ICollider collider, int width,int height)
        {
            // a is subject b is object
            BoxCollider b = (BoxCollider)collider;
                    float aleft = player.Position.X - player.Origin.X;
                    float aright = aleft + player.Size.X;
                    float atop = player.Position.Y - player.Origin.Y;
                    float abottom = atop + player.Size.Y;

                    float bleft = b.Position.X - b.Origin.X;
                    float bright = bleft + b.Size.X;
                    float btop = b.Position.Y - b.Origin.Y;
                    float bbottom = btop + b.Size.Y;
            Vector2 Position = player.Position;
                    if(height > width)
                    {
                        if(aleft >= bleft)
                        {
                           Position.X -= PlayerMoveScale;
                        }
                        else
                        {
                            Position.X += PlayerMoveScale;
                        }
                    }
                    else
                    {
                        if (atop >= btop)
                        {
                            Position.Y += PlayerMoveScale;

                        }
                        else
                        {
                            Position.Y -= PlayerMoveScale;
                        }
                    }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
