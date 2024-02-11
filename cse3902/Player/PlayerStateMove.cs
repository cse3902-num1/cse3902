using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite movingLeftSprite;
        private Sprite movingRightSprite;
        private Sprite movingUpSprite;
        private Sprite movingDownSprite;
        private Sprite currentSprite; // will reference one of the above sprites
        private GameContent content;

        public PlayerStateMove(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered move state");
            this.content = content;
            this.player = player;
            movingLeftSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(97, 1, 15, 15),
                new Rectangle(113, 1, 15, 15)
            });
            movingRightSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(33, 1, 15, 15),
                new Rectangle(49, 1, 15, 15)
            });
            movingUpSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(65, 1, 15, 15),
                new Rectangle(81, 1, 15, 15)
            });
            movingDownSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(1, 1, 15, 15),
                new Rectangle(17, 1, 15, 15)
            });
            currentSprite = movingRightSprite; // just a default value
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* move player if any movement key is pressed */
            if (controller.isPlayerMoveLeftPress() == true)
            {
                currentSprite = movingLeftSprite;
                player.Position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveRightPress() == true)
            {
                currentSprite = movingRightSprite;
                player.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveUpPress() == true)
            {
                currentSprite = movingUpSprite;
                player.Position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveDownPress() == true)
            {
                currentSprite = movingDownSprite;
                player.Position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            /* change to idle state if no movement keys are pressed */
            else
            {
                player.State = new PlayerStateIdle(content, player);
            }

            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.SetPosition(player.Position.X, player.Position.Y);
            currentSprite.Draw(spriteBatch);
        }
    }
}