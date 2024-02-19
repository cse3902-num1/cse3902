using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, ISprite> sprites;
        private GameContent content;

        public PlayerStateMove(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered move state");
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 0 * 16, 16, 16),
                        new Rectangle(1 * 16, 0 * 16, 16, 16),
                    })
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 1 * 16, 16, 16),
                        new Rectangle(1 * 16, 1 * 16, 16, 16),
                    })
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 2 * 16, 16, 16),
                        new Rectangle(1 * 16, 2 * 16, 16, 16),
                    })
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 3 * 16, 16, 16),
                        new Rectangle(1 * 16, 3 * 16, 16, 16),
                    })
                },
            };
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* move player if any movement key is pressed */
            if (controller.isPlayerMoveLeftPressed() == true)
            {
                player.Facing = Direction.Left;
                player.Position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveRightPressed() == true)
            {
                player.Facing = Direction.Right;
                player.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveUpPressed() == true)
            {
                player.Facing = Direction.Up;
                player.Position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveDownPressed() == true)
            {
                player.Facing = Direction.Down;
                player.Position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            /* change to idle state if no movement keys are pressed */
            else
            {
                player.State = new PlayerStateIdle(content, player);
            }

            sprites[player.Facing].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
