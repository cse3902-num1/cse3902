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
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(35, 11, 15, 15),
                        new Rectangle(52, 11, 15, 15),
                    })
                },
                {
                    Direction.Right,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(35, 11, 15, 15),
                        new Rectangle(52, 11, 15, 15),
                    })
                },
                {
                    Direction.Up,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(69, 11, 15, 15),
                        new Rectangle(86, 11, 15, 15),
                    })
                },
                {
                    Direction.Down,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(1, 11, 15, 15),
                        new Rectangle(18, 11, 15, 15),
                    })
                },
            };
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* move player if any movement key is pressed */
            if (controller.isPlayerMoveLeftPress() == true)
            {
                player.Facing = Direction.Left;
                player.Position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveRightPress() == true)
            {
                player.Facing = Direction.Right;
                player.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveUpPress() == true)
            {
                player.Facing = Direction.Up;
                player.Position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveDownPress() == true)
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
