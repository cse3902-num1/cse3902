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
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 3 * 16, 16, 16),
                        new Rectangle(1 * 16, 3 * 16, 16, 16),
                    }, new Vector2(8, 8))
                },
            };
        }

        public void Update(GameTime gameTime, KeyboardController controller)
        {
            /* move player if any movement key is pressed */
            Vector2 position = player.Position;
            if (controller.isPlayerMoveLeftPressed() == true)
            {
                player.Facing = Direction.Left;
                position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveRightPressed() == true)
            {
                player.Facing = Direction.Right;
                position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveUpPressed() == true)
            {
                player.Facing = Direction.Up;
                position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveDownPressed() == true)
            {
                player.Facing = Direction.Down;
                position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            /* change to idle state if no movement keys are pressed */
            else
            {
                player.State = new PlayerStateIdle(content, player);
            }

            player.Position = position;

            sprites[player.Facing].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
